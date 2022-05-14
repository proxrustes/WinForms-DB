using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kompromat
{
    public partial class Main : Form
    {
        public static Person SetValueForText1 = new Person();
       
        List<Person> persons = new List<Person>();
        DataAccessor da = new DataAccessor();

        public Main()
        {
            InitializeComponent();
            persons = da.ShowAll();
            UpdateKompromat<Person>(persons);
            foreach (Person person in da.ShowAll())
            {
                ComboBox.Items.Add(person.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "";

            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    if (control.Text.Length > 0)
                    {
                        Debug.WriteLine(control.Text.Length);
                        if (query == "")
                        {
                            query += $"{control.Name} = N'{control.Text}'";
                        } 
                        else
                        {
                            query += $"AND {control.Name} = N'{control.Text}'";
                        }
                        
                    }
                }
            }
            
            if (checkBox.Checked)
            {
                if (query == "")
                {
                    query += $"Birthday = '{Birthday.Value}'";
                }
                else
                {
                    query += $"AND Birthday =  '{Birthday.Value}'";
                }
            }

            persons = da.GetPerson(query);
            UpdateKompromat<Person>(persons);
        }
      
        private async void UpdateKompromat<Person>(List<Person> list)
        {
            var bindingList = new BindingList<Person>(list);
            var source = new BindingSource(bindingList, null);
            Grid.DataSource = source;
        }

      
        private async void ShowAll_Button_Click(object sender, EventArgs e)
        {
            persons = da.ShowAll();
            UpdateKompromat<Person>(persons);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            
        }

        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip my_menu = new ContextMenuStrip();
                int position = Grid.HitTest(e.X, e.Y).RowIndex;
                try
                {
                    Grid.Rows[position].Selected = true;
                    if (position >= 0)
                    {
                        my_menu.Items.Add("Delete").Name = "Delete";
                        my_menu.Items.Add("Inspect").Name = "Inspect";
                    }
                    my_menu.Show(Grid, new Point(e.X, e.Y));
                    my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);
                }
                catch { }
            }
        }

        private async void my_menu_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            switch  (e.ClickedItem.Name.ToString())
            {
                case "Delete":
                    da.DeleteUser(SetValueForText1.Id);
                    persons = da.ShowAll();
                    UpdateKompromat<Person>(persons);
                    break;

                case "Inspect":
                    Anketa anketa = new Anketa();
                    anketa.Show();
                    break;

            }
        }

        private async void Grid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Grid.Rows[e.RowIndex];
                SetValueForText1 = da.GetInfo(Convert.ToInt32(row.Cells[0].Value.ToString()));
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            persons = da.ShowAll();
            UpdateKompromat<Person>(persons);
        }

        private void ComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            persons.Clear();
            persons.Add(da.GetInfo((int)(ComboBox.SelectedItem)));
            UpdateKompromat(persons);
        }
    }
}
