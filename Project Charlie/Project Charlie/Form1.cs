using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Charlie
{
    public partial class Form1 : Form
    {
        public void ClearAll()
        {
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            phonenumberTextBox.Text = "";
            emailTextBox.Text = "";
            dateDateTimePicker.Value = DateTime.Now;
            hourNumericUpDown.Value = 0;
            minuteNumericUpDown.Value = 0;
            meetingwithComboBox.Text = "Select Member";
            meetingaimButton.Text = "Select Meeting Aim";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            string FName = nameTextBox.Text;
            string SName = surnameTextBox.Text;
            string PhoneNumber = phonenumberTextBox.Text;
            string Email = emailTextBox.Text;
            string Date = dateDateTimePicker.Text;
            string Time = hourNumericUpDown.Value + ":" + minuteNumericUpDown.Value;
            string MWith = meetingwithComboBox.Text;
            string MAim = meetingaimButton.Text;

            int parsedValue;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            if (nameTextBox.Text == "") // Tests if the First Name TextBox is Empty and executes the block below if the statement is true.
            {
                nameTextBox.BackColor = Color.Red;
                MessageBox.Show("Error: You have missing details, Please input the remaining information: First Name");
            }
            else if (surnameTextBox.Text == "") // Tests if the  Surname TextBox is Empty and executes the block below if the statement is true.
            {
                surnameTextBox.BackColor = Color.Red;
                MessageBox.Show("Error: You have missing details, Please input the remaining information: Surname");
            }
            else if (phonenumberTextBox.Text == "" || !int.TryParse(phonenumberTextBox.Text, out parsedValue)) // Tests if the Mobile Number TextBox is Empty and executes the block below if the statement is true.
            {
                phonenumberTextBox.BackColor = Color.Red;
                MessageBox.Show("Error: The Mobile Number you have added is invalid.");
            }
            else if (emailTextBox.Text == "" || !(emailTextBox.Text.Contains("@"))) // Tests if the Email TextBox is Empty and executes the block below if the statement is true.
            {
                emailTextBox.BackColor = Color.Red;
                MessageBox.Show("Error: The Email you have added is invalid.");
            }
            else if (dateDateTimePicker.Value < DateTime.Now) // Tests if the Date is not in the future based on the current date and executes the block below if the statement is true.
            {
                MessageBox.Show("Error: You must pick a date in the future");
            }
            else if (hourNumericUpDown.Value < hour)
            {
                hourNumericUpDown.BackColor = Color.Red;
                minuteNumericUpDown.BackColor = Color.Red;
                MessageBox.Show("Error: You must pick a time in the future");
            }
            else if (hourNumericUpDown.Value == hour || hourNumericUpDown.Value > hour)
            {
                if (hourNumericUpDown.Value == hour)
                {
                    if (minuteNumericUpDown.Value < minute)
                    {
                        hourNumericUpDown.BackColor = Color.Red;
                        minuteNumericUpDown.BackColor = Color.Red;
                        MessageBox.Show("Error: You must pick a time in the future");
                    }
                    if (meetingwithComboBox.Text == "Select Member") // Tests if a member has not been selected is and executes the block below if the statement is true.
                    {
                        meetingwithComboBox.BackColor = Color.Red;
                        MessageBox.Show("Error: You have missing details, Please input the remaining information: Member you are meeting with");
                    }
                    else if (meetingaimButton.Text == "Select Meeting Aim") // Tests if a meeting type has not been selected is and executes the block below if the statement is true.
                    {
                        meetingaimButton.BackColor = Color.Red;
                        MessageBox.Show("Error: You have missing details, Please input the remaining information: Meeting Aim");
                    }
                    else
                    {
                        if (minuteNumericUpDown.Value < 10)
                        {
                            onsiteListBox.Items.Add("[" + MAim + "] " + FName.Substring(0, 1) + "." + SName + " - " + MWith + " at " + Time.Insert(Time.IndexOf(":") + 1, "0")); // Displays the data if all info is correct
                            ClearAll();
                            MessageBox.Show("You have successfully signed in!");
                        }
                        else
                        {
                            onsiteListBox.Items.Add("[" + MAim + "] " + FName.Substring(0, 1) + "." + SName + " - " + MWith + " at " + Time); // Displays the data if all info is correct
                            ClearAll();
                            MessageBox.Show("You have successfully signed in!");
                        }
                    }
                }
                if (hourNumericUpDown.Value > hour)
                {
                    if (meetingwithComboBox.Text == "Select Member") // Tests if a member has not been selected is and executes the block below if the statement is true.
                    {
                        meetingwithComboBox.BackColor = Color.Red;
                        MessageBox.Show("Error: You have missing details, Please input the remaining information: Member you are meeting with");
                    }
                    else if (meetingaimButton.Text == "Select Meeting Aim") // Tests if a meeting type has not been selected is and executes the block below if the statement is true.
                    {
                        meetingaimButton.BackColor = Color.Red;
                        MessageBox.Show("Error: You have missing details, Please input the remaining information: Meeting Aim");
                    }
                    else
                    {
                        if (minuteNumericUpDown.Value < 10)
                        {
                            onsiteListBox.Items.Add("[" + MAim + "] " + FName.Substring(0, 1) + "." + SName + " - " + MWith + " at " + Time.Insert(Time.IndexOf(":") + 1, "0")); // Displays the data if all info is correct
                            ClearAll();
                            MessageBox.Show("You have successfully signed in!");
                        }
                        else
                        {
                            onsiteListBox.Items.Add("[" + MAim + "] " + FName.Substring(0, 1) + "." + SName + " - " + MWith + " at " + Time); // Displays the data if all info is correct
                            ClearAll();
                            MessageBox.Show("You have successfully signed in!");
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2;
            f2 = new Form2();

            if (f2.ShowDialog() == DialogResult.OK)
            {
                if (f2.radioButton1.Checked == true)
                {
                    meetingaimButton.Text = f2.radioButton1.Text;
                }
                else if (f2.radioButton2.Checked == true)
                {
                    meetingaimButton.Text = f2.radioButton2.Text;
                }
                else if (f2.radioButton3.Checked == true)
                {
                    meetingaimButton.Text = f2.radioButton3.Text;
                }
                else if (f2.radioButton4.Checked == true)
                {
                    meetingaimButton.Text = f2.radioButton4.Text;
                }
            }
        }

        private void onsiteListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (onsiteListBox.Items.Count > 0)
                {
                    onsiteListBox.Items.RemoveAt(onsiteListBox.SelectedIndex);
                }
                else if (onsiteListBox.Items.Count < 1)
                {
                    MessageBox.Show("Error: There are currently no items to delete");
                }
            }

        }
    }
}

