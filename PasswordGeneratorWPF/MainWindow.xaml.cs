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
        private void Generatepassword_Click(object sender, RoutedEventArgs e)
        {
            string password = GeneratePassword(passwordlength, Uppercase.IsChecked == true, Digits.IsChecked == true, Symbols.IsChecked == true, requiredCharacter);
            ShowGeneratedPassword(password);
        }
        private void ShowGeneratedPassword(string password)
        {
            Finalpassword.Text = password;
        }
        private string GeneratePassword(int length, bool Uppercase, bool Digits, bool Symbols, string required)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            string charPool = lowercase;
            if (Uppercase) charPool += uppercase;
            if (Digits) charPool += numbers;
            if (Symbols) charPool += symbols;

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
