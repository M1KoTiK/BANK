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
        public ActionCommand OnClickСomparison { get; set; }
    
        public ViewModelDepositCalculators()
        {
            OnClickСomparison = new ActionCommand(() => new ComparisonDeposit().ShowDialog());   
        }
       
        public void Calculate()
        {
            if (TbSumm >= 0 && tbPeriod >= 0 && tbEVM >= 0)
            {
                double stableTotal = (TbSumm * Math.Pow(1.08, Convert.ToDouble(TbPeriod) / 365)) - TbSumm;
                double optimalTotal = (TbSumm * Math.Pow(1 + (0.05 / 12), tbPeriod / 30) + TbEVM * Math.Pow(1 + (0.05 / 12), tbPeriod / 30)) - TbSumm;
                double standartTotal = (TbSumm * Math.Pow(1 + (0.06 / 12), tbPeriod / 30) + TbEVM * Math.Pow(1 + (0.06 / 12), tbPeriod / 30)) - TbSumm;
                StableIncom = Convert.ToString(Math.Round(stableTotal, 0)) + " Руб.";
                OptimalIncom = Convert.ToString(Math.Round(optimalTotal, 0)) + " Руб.";
                StandartIncom = Convert.ToString(Math.Round(standartTotal, 0)) + " Руб.";
            }
            else
            {
                System.Windows.MessageBox.Show("Значение не может быть отрицательным");
            }
        }

    }
}
