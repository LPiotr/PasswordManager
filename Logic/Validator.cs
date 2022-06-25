using System;

namespace PasswordManager.Logic
{
    public class Validator 
    {
        public bool ValidatePassword(string loginName, string password, string confirmPassword, bool toRegister)
        {
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 15;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;
            bool passwordsAreSame = false;
            bool passwordIsNotOnBlackList = true;

            //słowniki
            
            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) { hasUpperCaseLetter = true; }
                    else if (char.IsLower(c)) { hasLowerCaseLetter = true; }
                    else if (char.IsDigit(c)) { hasDecimalDigit = true; }
                }
                if (password.Equals(confirmPassword)) { passwordsAreSame = true; }

               // jesli (blacklistedPassword == falsz) passwordIsNotOnBlackList = prawda;
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
