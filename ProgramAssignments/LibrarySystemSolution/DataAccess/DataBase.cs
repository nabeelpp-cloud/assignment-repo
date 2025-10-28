using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataBase
    {
        public int[] expense = { 1200, 25000, 3000, 7000 };

        public int[] GetMyData()
        {
            return expense;
        }
    }
}
