using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay6
{
    public static class MyExtensions
    {
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            string titleString = "";
            if (string.IsNullOrEmpty(str))
                return str;
            string[] words = str.Split(' ');

            string lastWord = words.LastOrDefault();

            foreach (string word in words)
            {
                string titleWord = word[0].ToString().ToUpper() + word.Substring(1);
                titleString += titleWord;
                if (word != lastWord)
                    titleString += ' ';
            }
            return titleString;
        }

        public static float AverageExceptZero(this List<int> list)
        {
            if (list == null || list.Count == 0)
                return 0;

            var nonZeroValues = list.Where(x => x != 0).ToList();

            if (nonZeroValues.Count == 0)
                return 0;

            float sum = nonZeroValues.Sum();
            float avg = sum / nonZeroValues.Count;

            return avg;
        }
    }
}
