using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidatePassword(textBox2.Text);
        }

        bool ValidatePassword(string password)
        {
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 15;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;
            bool passwordsAreSame = false;
            bool passwordIsNotOnBlackList = false;

            List<string> simplePasswords = new List<string>();
            {
                // lista do zmigrowania do resourses
                // DO POPRAWY LOGIKA SPRAWDZANIA LISTY NIEDOZWOLONYCH HASEL
                //TAKE SAME HASŁA TEŻ DO POPRAWKI
                simplePasswords.Add("12345678");
                simplePasswords.Add("1234");
                simplePasswords.Add("password");
                simplePasswords.Add("has\u0142" + "o1234");
            }
            bool blacklistedPassword = simplePasswords.Equals(password);

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }

                if (blacklistedPassword == false) passwordIsNotOnBlackList = true;
                else if (password.Equals(textBox3.Text)) passwordsAreSame = true;
            }

            bool isValid = meetsLengthRequirements
                        && hasUpperCaseLetter
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        && passwordsAreSame
                        && passwordIsNotOnBlackList;
                        ;
            return isValid;
        }


}
}
