using PasswordManager.Logic;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.IO;
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
                File.AppendAllText("database.txt", newContent, Encoding.Unicode);
            }
            //generate password hash
            //save to file
            //clear and close register form
        }
    }
}