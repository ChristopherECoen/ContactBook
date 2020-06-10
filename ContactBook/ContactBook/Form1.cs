using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ContactBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadFile();
            CheckBirthdays();
            UpdateDisplayMember();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Person());
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        private void UpdateDisplayMember()
        {
            listBox1.DisplayMember = "";
            listBox1.DisplayMember = "Name";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count ==0) {
                return;
            }
            int savedIndex = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            if (savedIndex - 1 > 0)
            {
                listBox1.SelectedIndex = savedIndex - 1;
            } else if(listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) { 
                return;
            }
            Person person = (Person)listBox1.SelectedItem;

            txtName.Text = person.name;
            txtEmail.Text = person.email;
            txtPhone.Text = person.phoneNum;
            txtAddress.Text = person.address;
            birthdayPicker.Value = person.birthdate;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            Person person = (Person)listBox1.SelectedItem;

            person.name = txtName.Text;
            person.email = txtEmail.Text;
            person.phoneNum = txtPhone.Text;
            person.address = txtAddress.Text;
            person.birthdate = birthdayPicker.Value;
            UpdateDisplayMember();
            SaveFile();
        }
        private void CheckBirthdays() {
            Person person;
            string birthdays = "";
            for (int i =0; i<listBox1.Items.Count;i++) {
                person = listBox1.Items[i] as Person;

                if (person != null && person.birthdate.Day == DateTime.Today.Day && person.birthdate.Month == DateTime.Today.Month) {
                    birthdays += person.name + " is " + (DateTime.Today.Year - person.birthdate.Year).ToString() + " today.\n";
                }
            }
            if (birthdays != "") {
                MessageBox.Show(birthdays, "Birthday Notification:");
            }
        }
        public void SaveFile() {
            try {
                SaveFile saveFile = new SaveFile();
                saveFile.People = listBox1.Items.Cast<Person>().ToList();
                xmlAssist.Save(saveFile, "ContactInfo.cec");
            }
            catch (Exception ex){
                MessageBox.Show("Error Saving Contact List:" + ex.ToString());
            }
        }
        private void LoadFile() {
            try {
                SaveFile saveFile = xmlAssist.Load("ContactInfo.cec");
                for (int i = 0; i<saveFile.People.Count; i++) {
                    listBox1.Items.Add(saveFile.People[i]);
                }
            }
            catch
            {

            }
        }


    }
}