using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using MS_Prefix_Calculator;
//using System.Windows.Controls;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMinus()
        {
            string[] numsAsStrings = { "-", "7", "4" };
            //TextBox tBox = new TextBox();
            CalcMinus calcM = new CalcMinus();
            int num = calcM.Calculate(numsAsStrings, null);
            Assert.AreEqual(num, -3);
        }

        [TestMethod]
        public void TestMinus2()
        {
            string[] numsAsStrings = { "-", "200", "311" };
            //TextBox tBox = new TextBox();
            CalcMinus calcM = new CalcMinus();
            int num = calcM.Calculate(numsAsStrings, null);
            Assert.AreEqual(num, 111);
        }

        [TestMethod]
        public void TestPlus()
        {
            string[] numsAsStrings = { "+", "7", "4" };
            //TextBox tBox = new TextBox();
            CalcAdd calcM = new CalcAdd();
            int num = calcM.Calculate(numsAsStrings, null);
            Assert.AreEqual(num, 11);
        }

        [TestMethod]
        public void TestPlus2()
        {
            string[] numsAsStrings = { "+", "70000", "1004" };
            //TextBox tBox = new TextBox();
            CalcAdd calcM = new CalcAdd();
            int num = calcM.Calculate(numsAsStrings, null);
            Assert.AreEqual(num, 71004);
        }

        [TestMethod]
        public void TestDiv()
        {
            string[] numsAsStrings = { "/", "3", "12" };
            //TextBox tBox = new TextBox();
            CalcDiv calcM = new CalcDiv();
            int num = calcM.Calculate(numsAsStrings, null);
            Assert.AreEqual(num, 4);
        }

        [TestMethod]
        public void TestPow()
        {
            string[] numsAsStrings = { "P", "3", "4" };

            CalcPow calcM = new CalcPow();
            int num = calcM.Calculate(numsAsStrings, null);
            Assert.AreEqual(num, 48);

        }
    }
}
