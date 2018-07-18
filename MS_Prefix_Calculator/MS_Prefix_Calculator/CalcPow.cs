using System.Linq;
using System.Windows.Controls;

namespace MS_Prefix_Calculator
{
    public class CalcPow : ICalculate
    {
        /// <summary>
        /// Calulates POW A(a on b) on B ...and so on
        /// </summary>
        /// <param name="numsAsStrings">Is array of Calculator TextBox -> separated by space</param>
        /// <param name="tBox">TextBox is "Display" of Calculator and can recive direkt input by keyb. - Output printed on TextBox</param>
        /// <returns></returns>
        public int Calculate(string[] numsAsStrings, TextBox tBox)
        {
            double result = 0;
            numsAsStrings = numsAsStrings.Where(val => val != "P").ToArray();
            double left = 1;
            double right = 0;
            for (int i = 0; i < numsAsStrings.Length; i++)
            {
                right = double.Parse(numsAsStrings[i]);
                if (left > 1)
                {
                    for (int u = 0; u < left - 1; u++)
                    { //left -1, da im ersten Fall (left = 1 ) schon hoch 1 gerechnet wurde und dies mit dem Result verrechnet wurde
                        result = result * right;
                    }
                }
                else
                {
                    result = right;
                }
                left = right;
            }

            if (tBox != null)
            {

                tBox.Text = result.ToString();
            }

            return (int)result;
        }
    }
    }

