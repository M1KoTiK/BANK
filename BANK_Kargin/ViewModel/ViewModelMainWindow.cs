using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BANK_Kargin.View;
using BANK_Kargin.ViewModel;
using System.Threading.Tasks;

namespace BANK_Kargin.ViewModel
{
    public class ViewModelMainWindow : ViewModelBase
    {
        public ActionCommand OnClickCalcluteBtn { get; set; }
        public ViewModelMainWindow()
        {
            OnClickCalcluteBtn = new ActionCommand(()=> new DepopsitCalculators().ShowDialog());

        }


    }
}
