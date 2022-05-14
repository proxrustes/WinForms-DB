using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kompromat
{
    public partial class Anketa : Form
    {
        DataAccessor da = new DataAccessor();
        Main main = new Main();
        public Anketa()
        {
            InitializeComponent();

            TB_Bio.Multiline = true;
            TB_Bio.WordWrap = true;
            UpdateAnketa(Main.SetValueForText1);
            foreach(Person person in da.ShowAll())
            {
                comboBox.Items.Add(person.Id);
            }
        }
        public async void UpdateAnketa(Person person)
        {
            
            try
            {
                TB_FirstName.Text = person.FirstName;
            }
            catch { TB_LastName.Text = null; }
            
            
            try
            {
                TB_LastName.Text = person.LastName;
            }
            catch { TB_LastName.Text = null; }
            
            try
            {
                TB_FatherName.Text = person.FatherName;
            }
            catch { TB_FatherName.Text = null; }
            
            try
            {
                TB_Telegram.Text = person.Telegram;
            }
            catch { TB_Telegram.Text = null; }
            try
            {
                TB_University.Text = person.University;
            }
            catch { TB_University.Text = null; }
            try
            {
                TB_Email.Text = person.Email;
            }
            catch { TB_Email.Text = null; }

            try
            {
                DateTime.Value = person.Birthday;
            }
            catch{}
            
            try
            {
                TB_PhoneNumber.Text = person.PhoneNumber;
            }
            catch { }
            try
            {
                TB_Bio.Text = person.Bio;
            }
            catch { }

        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt64(TB_PhoneNumber.Text);
                Debug.WriteLine(Main.SetValueForText1.Id.ToString());
                
            }
            catch
            {
                TB_PhoneNumber.Text = null;
            }
            da.UpdatePerson(new Person { Id = Convert.ToInt32(Main.SetValueForText1.Id), FirstName = TB_FirstName.Text, LastName = TB_LastName.Text, FatherName = TB_FatherName.Text, Birthday = DateTime.Value, Email = TB_Email.Text, PhoneNumber = TB_PhoneNumber.Text, Telegram = TB_Telegram.Text, University = TB_University.Text, Bio = TB_Bio.Text });
            //main.Enabled = true;
            //this.Close();
        }

        private async void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.SetValueForText1 = da.GetInfo((int)(comboBox.SelectedItem));
            UpdateAnketa(Main.SetValueForText1);
        }
        
    }
}
