
using System.Windows.Controls;

namespace MS_Prefix_Calculator
{
    interface ICalculate
    {
        int Calculate(string[] numsAsStrings, TextBox tBox);
    }
}
