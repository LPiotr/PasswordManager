using PasswordManager.Logic;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName;
            string password;
            DateTime date;

            var loginPasswordChain = checkIsUserInBase(textBox1.Text);
            string[] stringSplit = loginPasswordChain.Split('|');

            userName = stringSplit[0];
            password = stringSplit[1];
            date = Convert.ToDateTime(stringSplit[2]);

            byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);

            var encrypt = new EncryptorAndDecryptor();
            encrypt.Enrypt(textBox2.Text, passwordInBytes);
        }

        private string checkIsUserInBase(string text)
        {
            int counter = 0;
            string line;

            StreamReader file = new StreamReader("database.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line.Equals(text))
                {
                    break;
                }
                break;
                counter++;
            }

            file.Close();
            return line;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
}