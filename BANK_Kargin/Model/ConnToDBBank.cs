using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_Kargin.Model
{
    public class ConnToDBBank
    {
        private static BankEnt DBEntities;

        public static BankEnt GetConnection()
        {
            if (DBEntities == null)
            {
                DBEntities = new BankEnt();
            }
            return DBEntities;
        }

    }
}
