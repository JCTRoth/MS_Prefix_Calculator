using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace MS_Prefix_Calculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow
    {

        /// <summary>
        /// Default Constructor of Main Class
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        
        void Button_Plus(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "+ ";

        }

        void Button_Minus(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "- ";

        }

        void Button_Getteilt(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "/ ";
        }

        void Button_Pow(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "P ";
        }



        private void Button_Clear(object sender, RoutedEventArgs e)
        {

            Anzeige.Clear();
            Console.WriteLine(@"Cleared");
        }


        private void Button_Fac(object sender, RoutedEventArgs e) // placeholder
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "!";

        }

        [Obsolete ("Use async version for big numbers", true)]
        bool IsPrime(long number)
        {
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }
        }

       

        async Task<bool> IsPrimeAsync(long number)
        {
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }
        }


        private async void Button_Prime(object sender, RoutedEventArgs e)
        {

            long isPrime = 789089876234523891;
            bool result = await IsPrimeAsync(isPrime);
            MessageBox.Show("Is " + isPrime + " a Prime Num.? " + result.ToString());
        }

        private void Button_History(object sender, RoutedEventArgs e)
        {
            CalcHistory history = new CalcHistory();
            String message ="";
            try
            {
                using (Stream streamLoad = File.Open("MyFile.bin", FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    history = (CalcHistory)binaryFormatter.Deserialize(streamLoad);
                }
            }
            catch (FileNotFoundException errorMessage)
            {
                Console.WriteLine(@"file not there", errorMessage);
            }
            catch (SerializationException errorMesage)
            {
                Console.WriteLine(@"File empty", errorMesage);
            }
            List<String> historyList;
            historyList = history.GetList();
            for (int i = 0; i < historyList.Count; i++)
            {
                
                message += historyList.ElementAt(i) +"\n";


            }
            MessageBox.Show(message);
        }



        // exceptions used down here 
        // async used down here
        //
        //Button_Calculate eq. Enter
        //Calulates and saves entert calc. + result
        //
        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            CalcHistory save = new CalcHistory();
            try
            {
                using (Stream streamLoad = File.Open("MyFile.bin", FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    save = (CalcHistory) binaryFormatter.Deserialize(streamLoad);
                }
            }
            catch (FileNotFoundException errorMessage)
            {
                Console.WriteLine(@"file not there");
            }
            catch (SerializationException errorMesage)
            {
                Console.WriteLine(@"File empty", errorMesage);
            }

            save.AddResultToList(Anzeige.GetLineText(0));
            String anzeigeString = Anzeige.GetLineText(0);
            string[] stringValues;
            for(int i = 0; i < 20; ++i)
            {

                stringValues = anzeigeString.Split(null);
                math_operator(stringValues[0], stringValues);
                Console.WriteLine(@"ausgabe"+i);


            }
            save.AddResultToList(Anzeige.GetLineText(0));
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<String> test;
            test = save.GetList();
            formatter.Serialize(stream, save);
            stream.Close();
            
        }



        private int calcFac(String[] numsAsStrings)
        {

            Anzeige.Text = Anzeige.GetLineText(0) + "!";

            numsAsStrings = numsAsStrings.Where(val => val != "!").ToArray();
            int input = int.Parse(numsAsStrings[0]);
            Func<int, long> fac = null; // used long for output value
            fac = n => (n <= 1) ? 1 : n * fac(n - 1);
            long result = fac(input);
            Anzeige.Text = result.ToString();
            return 0;
        }

        int math_operator(string op_value, string[] stringValues)
        {
            ICalculate operation = null;

            switch (op_value)
            {
                case "":
                    break;

                case "+":
                    operation = new CalcAdd();
                    break;

                case "-":
                    operation = new CalcMinus();
                    break;

                case "/":
                    operation = new CalcDiv();
                    break;

                case "P":
                    operation = new CalcPow();
                    break;

                case "!":
                    calcFac(stringValues);
                    break;
            }
            if (operation != null) operation.Calculate(stringValues, Anzeige);

            return 0;
        }


        //Number Buttons here
        private void Button_Write_1(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "1";
        }

        private void Button_Write_2(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "2";
        }

        private void Button_Write_3(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "3";
        }

        private void Button_Write_4(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "4";
        }

        private void Button_Write_5(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "5";
        }

        private void Button_Write_6(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "6";
        }

        private void Button_Write_7(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "7";
        }

        private void Button_Write_8(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "8";
        }

        private void Button_Write_9(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "9";
        }

        private void Button_Write_0(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + "0";
        }       
        
        private void Button_Space(object sender, RoutedEventArgs e)
        {
            Anzeige.Text = Anzeige.GetLineText(0) + " ";
        } 

        //used for debugging
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(Anzeige.GetLineText(0));            
        }


    }
}
