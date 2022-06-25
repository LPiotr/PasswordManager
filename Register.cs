using PasswordManager.Logic;
using System;
using System.IO;
using System.Text;
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
            //user validation
            // to be implemented

            //password validation
            var validator = new Validator();
            bool isPasswordMatch = validator.ValidatePassword(textBox1.Text, textBox2.Text, textBox3.Text, true);

            if (isPasswordMatch != true)
            {
                label2.Text = "";
                label2.Text = "";
                MessageBox.Show("HASŁA NIE ZGADZAJĄ SIĘ - POPRAW!");
            }
            else
            {
                //encrypt password
                var encryptobj = new EncryptorAndDecryptor();
                var hashToSave = encryptobj.Enrypt(textBox2.Text);

                //string to save
                string newContent = textBox1.Text + "|" + Encoding.Default.GetString(hashToSave)+"|"
                    + Convert.ToString(DateTime.Now) + Environment.NewLine;
                
                //save to file
                File.AppendAllText("database.txt", newContent, Encoding.UTF8);
                MessageBox.Show("nowy login i hasło zostało dodane!");
                //close register form
                Close();
            }
        }
    }
}