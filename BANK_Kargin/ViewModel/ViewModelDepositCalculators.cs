using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BANK_Kargin.Model;
using BANK_Kargin.View;
using Word = Microsoft.Office.Interop.Word;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.ComponentModel;
#nullable enable
namespace BANK_Kargin.ViewModel
{
    public class ViewModelDepositCalculators : ViewModelBase
    {
        private const string PathToTempWord = @"C:\Users\User\source\repos\BANK\BANK_Kargin\Resources\template.docx";

        enum TypeDepositRate
        {
            Standart,
            Stable,
            Optimal
        }

        private string stableIncome = "... Руб.";
        private string optimalIncome = "... Руб.";
        private string standartIncome = "... Руб.";
        private int tbSumm = 0;
        private int tbPeriod = 0;
        private int tbEVM = 0;

        private string stableSumm = "... Руб";
        private string stableBet = "... %";

        private string optimalSumm = "... Руб";
        private string optimalBet = "... %";

        private string standartSumm = "... Руб";
        private string standartBet = "... %";

        private string login = "";
        private string password = "";
        public string StableIncome
        {
            get { return stableIncome; }
            set
            {
                stableIncome = value;

            }
        }
        public string OptimalIncome
        {
            get { return optimalIncome; }
            set
            {
                optimalIncome = value;

            }
        }
        public string StandartIncome
        {
            get { return standartIncome; }
            set
            {
                standartIncome = value;

            }
        }
        public int TbSumm
        {
            get { return tbSumm; }
            set
            {
                if (this.tbSumm != value)
                {
                    tbSumm = value;
                    Calculate();
                }


            }
        }
        public int TbPeriod
        {
            get { return tbPeriod; }
            set
            {
                if (this.tbPeriod != value)
                {
                    tbPeriod = value;
                    Calculate();
                }

            }

        }
        public int TbEVM
        {
            get { return tbEVM; }
            set
            {
                if (this.tbEVM != value)
                {
                    tbEVM = value;
                    Calculate();
                }
            }
        }
        public string StableSumm
        {
            get { return stableSumm; }
            set
            {
                stableSumm = value;
                NotifyPropertyChanged();
            }
        }
        public string OptimalSumm
        {
            get { return optimalSumm; }
            set
            {
                optimalSumm = value;
               
            }

        }
        public string StandartSumm
        {
            get { return standartSumm; }
            set
            {
                standartSumm = value;
                
            }
        }
        public string StableBet
        {
            get { return stableBet; }
            set
            {
                stableBet = value;
                
            }
        }
        public string OptimalBet
        {
            get { return optimalBet; }
            set
            {
                optimalBet = value;
            
            }
        }
        public string StandartBet
        {
            get { return standartBet; }
            set
            {
                standartBet = value;
                
            }
        }

        TypeDepositRate TDR = TypeDepositRate.Standart;
        public ActionCommand OnClickСomparison { get; set; }
        public ActionCommand OnClikcCalcStandart { get; set; }
        public ActionCommand OnClikcCalcOptimal { get; set; }
        public ActionCommand OnClikcCalcStable { get; set; }
        public ActionCommand OnClikcLog { get; set; }

        public string Login
        {
            get => login;
            set
            {
                login = value;
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }



        public ViewModelDepositCalculators()
        {
            OnClickСomparison = new ActionCommand(ToComparisonWithData);
            OnClikcCalcStandart = new ActionCommand(() =>
            {
                TDR = TypeDepositRate.Standart;
                ToAuthorizationWithData();

            });

            OnClikcCalcOptimal = new ActionCommand(() =>
            {
                TDR = TypeDepositRate.Optimal;
                ToAuthorizationWithData();

            });

            OnClikcCalcStable = new ActionCommand(() =>
            {
                TDR = TypeDepositRate.Stable;
                ToAuthorizationWithData();
            });

            OnClikcLog = new ActionCommand(() =>
            {
                testAuth();
            });
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document worddocument)
        {
            var range = worddocument.Content; 
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        public void testAuth()
        {
            if (LogIn(Login, Password))
            {
                BankEnt db = ConnToDBBank.GetConnection();
                var query = from u in db.User where login == u.Login && password == u.Password select u;
                var timeEnd = DateTime.Now.AddDays(tbPeriod).Date;
                var timeNow = DateTime.Now.Date;
                string name = "";
                string mname = "";
                string lname = "";
                string series = "";
                string number = "";
                string adress = "";
                string email = "";
                string bday = "";
                int id = -1;
                string bankAcc = "";
                string summDeposit = tbSumm.ToString();
                string percent = "";
                string periodDeposit = tbPeriod.ToString();
                string issued = "";
                string dateIssued = "";
                string placeBday = "";
                string fullIssue = issued + " " + dateIssued;
                switch (TDR)
                {
                    case TypeDepositRate.Optimal:
                        percent = "5%";
                        
                        break;
                    case TypeDepositRate.Stable:
                        percent = "8%";

                        break;
                    case TypeDepositRate.Standart:
                        percent = "6%";

                        break;

                }
                foreach (var item in query)
                {
                    name = item.Name;
                    mname = item.Surname;
                    lname = item.Patronymic;
                    id = item.ID;
                    adress = item.Adress;
                    email = item.Email;
                    issued = item.Issued;
                    series = item.Series;
                    number = item.Number;
                    dateIssued = Convert.ToString(item.DateOfIssue);

                }
                var queryb = from b in db.BankAccount where id == b.ID_USER  select b;
                foreach (var item in queryb)
                {
                     bankAcc = item.ID;
                }
                var saveFD = new SaveFileDialog();

                saveFD.Filter = "Файлы Word (*.docx)|*.docx|All files (*.*)|*.*";
                Nullable<bool> result = saveFD.ShowDialog();
                if (result == true)
                {
                    var wordApp = new Word.Application();
                    wordApp.Visible = false;
                    //string Issueed2 = Issueed1 + " " + DateOfIssue1;
                    try
                    {
                        string FIO = $"{name} {mname} {lname}";
                        var wordDocument = wordApp.Documents.Open(PathToTempWord);
                        ReplaceWordStub("<NUMDOG>", id.ToString(), wordDocument);
                        ReplaceWordStub("<DAY>", DateTime.Today.ToString("dd"), wordDocument);
                        ReplaceWordStub("<MONTHS>", DateTime.Today.ToString("MM"), wordDocument);
                        ReplaceWordStub("<YEAR>", DateTime.Today.ToString("yy"), wordDocument);
                        ReplaceWordStub("<FIOVKLAD>", FIO, wordDocument);
                        ReplaceWordStub("<FIOVKLAD>", FIO, wordDocument);
                        ReplaceWordStub("<SUMVKLAD>", summDeposit, wordDocument);
                        ReplaceWordStub("<TIMEVKLD>", timeNow.ToShortDateString(), wordDocument);
                        ReplaceWordStub("<DATEENDVKLAD>", timeEnd.ToShortDateString(), wordDocument);
                        ReplaceWordStub("<PERCENTVKLAD>", percent, wordDocument);
                        ReplaceWordStub("<NUMBERACC>", bankAcc, wordDocument);
                        ReplaceWordStub("<ADRESSREG>", adress, wordDocument);
                        ReplaceWordStub("<EMAIL>", email, wordDocument);
                        ReplaceWordStub("<SERIYA>", number, wordDocument);
                        ReplaceWordStub("<ISSUE>", fullIssue, wordDocument);
                        ReplaceWordStub("<DATEBIRTH>", bday, wordDocument);
                        ReplaceWordStub("<PLACEBIRTH>", placeBday, wordDocument);
                        ReplaceWordStub("<SERIES>", series, wordDocument);
                        ReplaceWordStub("<NOMER>", number, wordDocument);
                        ReplaceWordStub("<FIOVKLAD1>", FIO, wordDocument);
                        wordDocument.SaveAs(saveFD.FileName);
                        MessageBox.Show("Договор сохранен");
                        wordDocument.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
        }
        private bool LogIn(string login, string password)
        {
            BankEnt db = ConnToDBBank.GetConnection();
            var query = from u in db.User where login == u.Login && password == u.Password select u;
            var user = query.FirstOrDefault();
            if (user is null)
            {
                return false;
            }
            return true;
        }


        private void WorkWithWord()
        {

        }
        private void ToComparisonWithData()
        {
            ComparisonDeposit Screen = new ComparisonDeposit();
            Screen.DataContext = this;
            Screen.Show();


        }
        private void ToAuthorizationWithData()
        {
            Authorization Screen = new Authorization();
            Screen.DataContext = this;
            Screen.Show();


        }

        public void Calculate()
        {
            if (TbSumm >= 0 && tbPeriod >= 0 && tbEVM >= 0)
            {
                double stableTotal = (TbSumm * Math.Pow(1.08, Convert.ToDouble(TbPeriod) / 365)) - TbSumm;
                double stableSumm = TbSumm + stableTotal;
                double optimalTotal = (TbSumm * Math.Pow(1 + (0.05 / 12), tbPeriod / 30) + TbEVM * Math.Pow(1 + (0.05 / 12), tbPeriod / 30)) - TbSumm;
                double optimalSumm = TbSumm + optimalTotal;
                double standartTotal = (TbSumm * Math.Pow(1 + (0.06 / 12), tbPeriod / 30) + TbEVM * Math.Pow(1 + (0.06 / 12), tbPeriod / 30)) - TbSumm;
                double standartSumm = TbSumm + standartTotal;
                StableIncome = Convert.ToString(Math.Round(stableTotal, 0)) + " Руб.";
                StableSumm = Convert.ToString(Math.Round(stableSumm, 0)) + " Руб.";
                OptimalIncome = Convert.ToString(Math.Round(optimalTotal, 0)) + " Руб.";
                OptimalSumm = Convert.ToString(Math.Round(optimalSumm, 0)) + " Руб.";
                StandartIncome = Convert.ToString(Math.Round(standartTotal, 0)) + " Руб.";
                StandartSumm = Convert.ToString(Math.Round(standartSumm, 0)) + " Руб.";
                StableBet = Convert.ToString(Math.Round(((stableTotal / tbSumm) * (365 / tbPeriod)) * 100, 1)) + " %.";
                OptimalBet = Convert.ToString(Math.Round(((optimalTotal / tbSumm) * (365 / tbPeriod)) * 100, 1)) + " %.";
                StandartBet = Convert.ToString(Math.Round(((standartTotal / tbSumm) * (365 / tbPeriod)) * 100, 1)) + " %.";
            }
            else
            {
                System.Windows.MessageBox.Show("Значение не может быть отрицательным");
            }
        }

    }
}
