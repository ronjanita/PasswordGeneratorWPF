using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordGeneratorWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string requiredCharacter = "";
        private int passwordlength = 1;
        private bool uppercase = false;
        private bool digits = false;
        private bool symbols = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            passwordlength = (int)Slider.Value;
        }
        private void Userinputtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            requiredCharacter = Userinputtext.Text;
        }
        private void Uppercase_Checked(object sender, RoutedEventArgs e)
        {
            uppercase = true;
        }
        private void Uppercase_Unchecked(object sender, RoutedEventArgs e)
        {
            uppercase = false;
        }
        private void Digits_Checked(object sender, RoutedEventArgs e)
        {
            digits = true;
        }
        private void Digits_Unchecked(object sender, RoutedEventArgs e)
        {
            digits = false;
        }
        private void Symbols_Checked(object sender, RoutedEventArgs e)
        {
            symbols = true;
        }
        private void Symbols_Unchecked(object sender, RoutedEventArgs e)
        {
            symbols = false;
        }
        private void Generatepassword_Click(object sender, RoutedEventArgs e)
        {
            string password = GeneratePassword(passwordlength, uppercase, digits, symbols, requiredCharacter);
            ShowGeneratedPassword(password);
        }
        private void ShowGeneratedPassword(string password)
        {
            Finalpassword.Text = password;
        }
        private string GeneratePassword(int length, bool includeUpper, bool includeNum, bool includeSym, string required)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            string charPool = lowercase;
            if (includeUpper) charPool += uppercase;
            if (includeNum) charPool += numbers;
            if (includeSym) charPool += symbols;

            Random rand = new Random();
            List<char> passwordChars = new List<char>();

            if (!string.IsNullOrEmpty(required))
            {
                passwordChars.Add(required[0]);
                length--;
            }

            for (int i = 0; i < length; i++)
            {
                passwordChars.Add(charPool[rand.Next(charPool.Length)]);
            }

            return new string(passwordChars.OrderBy(_ => rand.Next()).ToArray());
        }
    }
}
