using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BANK_Kargin.View;
using System.Threading.Tasks;
using System.ComponentModel;
#nullable enable
namespace BANK_Kargin.ViewModel
{  
    public class ViewModelDepositCalculators : ViewModelBase
    {
        private string stableIncom = "... Руб.";
        private string optimalIncom = "... Руб.";
        private string standartIncom = "... Руб.";
        private int tbSumm=0;
        private int tbPeriod=0;
        private int tbEVM=0;

        private string stableSumm = "... Руб";
        private string stableBet = "... %";

        private string optimalSumm = "... Руб";
        private string optimalBet = "... %";

        private string standartSumm = "... Руб";
        private string standartBet = "... %";
        public string StableIncom
        {
            get { return stableIncom; }
            set 
            { 
                stableIncom = value;
                NotifyPropertyChanged();
            }
        }
        public string OptimalIncom
        {
            get { return optimalIncom; }
            set
            {
                optimalIncom = value;
                NotifyPropertyChanged();
            }
        }
        public string StandartIncom
        {
            get { return standartIncom; }
            set
            {
                standartIncom = value;
                NotifyPropertyChanged();
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
                else
                {
                    NotifyPropertyChanged();
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
                else
                {
                    NotifyPropertyChanged();
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
                else
                {
                    NotifyPropertyChanged();
                }
            }
        }
        public string StableSumm
        {
            get { return stableSumm; }
            set
            {
                stableSumm = value;

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
        public ActionCommand OnClickСomparison { get; set; }
        public ActionCommand OnClikcBtns { get; set; }


        public ViewModelDepositCalculators()
        {
            OnClickСomparison = new ActionCommand(() => ToComparisonWithData());
            OnClikcBtns = new ActionCommand(() => new Authorization().ShowDialog());
        }
        private void ToComparisonWithData()
        {
            ComparisonDeposit Screen = new ComparisonDeposit();
            Screen.DataContext = this;
            Screen.Show();


        }
        public void Calculate()
        {
            if (TbSumm >= 0 && tbPeriod >= 0 && tbEVM >= 0)
            {
                double stableTotal = (TbSumm * Math.Pow(1.08, Convert.ToDouble(TbPeriod) / 365)) - TbSumm;
                double stableSumm = TbSumm+stableTotal ;
                double optimalTotal = (TbSumm * Math.Pow(1 + (0.05 / 12), tbPeriod / 30) + TbEVM * Math.Pow(1 + (0.05 / 12), tbPeriod / 30)) - TbSumm;
                double optimalSumm = TbSumm + optimalTotal;
                double standartTotal = (TbSumm * Math.Pow(1 + (0.06 / 12), tbPeriod / 30) + TbEVM * Math.Pow(1 + (0.06 / 12), tbPeriod / 30)) - TbSumm;
                double standartSumm = TbSumm + standartTotal;
                StableIncom = Convert.ToString(Math.Round(stableTotal, 0)) + " Руб.";
                StableSumm = Convert.ToString(Math.Round(stableSumm, 0)) + " Руб.";
                OptimalIncom = Convert.ToString(Math.Round(optimalTotal, 0)) + " Руб.";
                OptimalSumm = Convert.ToString(Math.Round(optimalSumm, 0)) + " Руб.";
                StandartIncom = Convert.ToString(Math.Round(standartTotal, 0)) + " Руб.";
                StandartSumm = Convert.ToString(Math.Round(standartSumm, 0)) + " Руб.";
                StableBet = Convert.ToString(Math.Round(((stableTotal/tbSumm)*(365/tbPeriod))*100,1)) + " %.";
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
