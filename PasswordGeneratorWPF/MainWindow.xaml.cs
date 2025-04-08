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
        //private string GeneratePassword(int length, bool Uppercase, bool Digits, bool Symbols, string required)
        //{
        //    string lowercase = "abcdefghijklmnopqrstuvwxyz";
        //    string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    string numbers = "0123456789";
        //    string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        //    string charPool = lowercase;
        //    if (Uppercase) charPool += uppercase;
        //    if (Digits) charPool += numbers;
        //    if (Symbols) charPool += symbols;

        //    List<char> passwordChars = new List<char>();

        //    if (!string.IsNullOrEmpty(required))
        //    {
        //            passwordChars.AddRange(required);
        //            length -= required.Length;
        //    }

        //    Random rand = new Random();

        //    for (int i = 0; i < length; i++)
        //    {
        //        passwordChars.Add(charPool[rand.Next(charPool.Length)]);
        //    }
        //    return new string(passwordChars.ToArray());
        //}
        private string GeneratePassword(int length, bool Uppercase, bool Digits, bool Symbols, string required)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";
            string availableCharacters = lowercase;

            string passwordToReturn = "";

            if (Uppercase)
            {
                availableCharacters = availableCharacters + uppercase;
            }
            if (Digits)
            {
                availableCharacters = availableCharacters + digits;
            }
            if (Symbols)
            {
                availableCharacters = availableCharacters + symbols;
            }

            if (required != "")   //überprüfung ob useringabe NICHt leer ist, falls ja, gehts weiter, falls nein wird dieser teil 
            {
                passwordToReturn = passwordToReturn + required;
                //for (int characterPosition = 0; characterPosition < required.Length; characterPosition++)  //jedes zeichen von userinput wird durch gegangen
                //{
                //    passwordChars.Add(required[characterPosition]);  //jedes zeichen wird einzel in liste hinzugefügt aber bleiben in der reihenfolge wie sie in required stehen
                //}
                length = length - required.Length;  //wenn user z.b 5 buchstaben eingbit und am anfang ein 12 charater langes wort will, müssen nurnoch 7 random erstellt werden
            }

            Random random = new Random();

            while (length > 0)
            {
                int randomIndex = random.Next(0, availableCharacters.Length);


                passwordToReturn = passwordToReturn + availableCharacters[randomIndex];
                length = length - 1;
            }

            
            return passwordToReturn;
        }
    }
}
