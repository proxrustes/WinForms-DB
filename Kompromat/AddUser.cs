using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kompromat
{
    public partial class AddUser : Form
    {
        Main main = new Main();
        public AddUser()
        {
            InitializeComponent();

            TB_Bio.Multiline = true;
            TB_Bio.WordWrap = true;
        }


        private async void AddButton_Click(object sender, EventArgs e)
        {
            DataAccessor da = new DataAccessor();
            da.InsertPerson(new Person { FirstName = TB_FirstName.Text, LastName = TB_LastName.Text, FatherName = TB_FatherName.Text, Birthday = DateTime.Value, Email = TB_Email.Text, PhoneNumber = TB_PhoneNumber.Text, Telegram = TB_Telegram.Text, University = TB_University.Text, Bio = TB_Bio.Text });
            main.Enabled = true;
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
