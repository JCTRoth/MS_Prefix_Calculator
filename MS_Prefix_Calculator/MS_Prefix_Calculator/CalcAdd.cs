using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MS_Prefix_Calculator
{

    /// <summary>
    /// Calulates Addition of 2 nums.
    /// </summary>
    /// <param name="numsAsStrings">Is array of Calculator TextBox -> separated by space</param>
    /// <param name="tBox">TextBox is "Display" of Calculator and can recive direkt input by keyb. - Output printed on TextBox</param>
    /// <returns></returns>
    public class CalcAdd : ICalculate
    {
        public int Calculate(string[] numsAsStrings, TextBox tBox)
        {
            double result = 0;
            double realNum;

            numsAsStrings[0] = "0";

            foreach (String num in numsAsStrings)
            {

                realNum = double.Parse(num);
                result = realNum + result;
            }

            if (tBox != null)
            {

                tBox.Text = result.ToString();
            }

            return (int)result;
        }
    }
}
