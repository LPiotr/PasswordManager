using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Logic
{
    public class Validator 
    {
        public bool ValidatePassword(string loginName, string password, string confirmPassword, bool toRegister)
        {
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 15;

            /*
            if (toRegister = false)
            {

            }
            */

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;
            bool passwordsAreSame = false;
            bool passwordIsNotOnBlackList = true;


            //string dictionaryPath = @"C:\Users\Piotr\Documents\STUDIA AHE 2022\Ochrona danych -projekt\PasswordManager\Polish.dic";

            //List<string> simplePasswords = File.ReadAllLines(dictionaryPath).ToList();
            //C:\Users\Piotr\Documents\STUDIA AHE 2022\Ochrona danych - projekt\PasswordManager\
           // bool blacklistedPassword = simplePasswords.Equals(password);

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
                if (password.Equals(confirmPassword)) passwordsAreSame = true;

               // if (blacklistedPassword == false) passwordIsNotOnBlackList = true;
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
