using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class DataProcessor
    {
        DataBase db = new DataBase();
        int[] data;

        public DataProcessor()
        {
            data = db.GetMyData();
        }
        public int ShowTotalExpense()
        {
            int total = 0;
            foreach (var item in data)
            {
                total += item;
            }
            return total;
        }
    }
}