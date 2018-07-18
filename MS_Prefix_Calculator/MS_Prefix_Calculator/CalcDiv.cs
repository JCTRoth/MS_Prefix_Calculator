﻿using System;
using System.Linq;
using System.Windows.Controls;

namespace MS_Prefix_Calculator
{
    public class CalcDiv : ICalculate
    {
        /// <summary>
        /// Calulates division 1..20
        /// </summary>
        /// <param name="numsAsStrings">Is array of Calculator TextBox -> separated by space</param>
        /// <param name="tBox">TextBox is "Display" of Calculator and can recive direkt input by keyb. - Output printed on TextBox</param>
        /// <returns></returns>
        public int Calculate(string[] numsAsStrings, TextBox tBox)
        {
            double result = 1;
            double realNum;
            //used LINQ
            numsAsStrings = numsAsStrings.Where(val => val != "/").ToArray();

            //numsAsStrings[0] = "0";

            foreach (String num in numsAsStrings)
            {

                realNum = double.Parse(num);
                result = realNum / result;
            }

            if (tBox != null)
            {

                tBox.Text = result.ToString();
            }

            return (int)result;
        }
    }
}
