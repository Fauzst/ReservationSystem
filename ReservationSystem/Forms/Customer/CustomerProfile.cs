using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Forms;
namespace ReservationSystem.Forms.Customer
{
    public partial class CustomerProfile : Form
    {
        public string _firstName;
        public string _lastName;
        public string _email;
        public int _age;
        public string _mobileNumber;
        public string _telehpone;
        public string _sex;
        public string _username;
        public int accountID_CustomerProfile { get; set; }

        public CustomerProfile()
        {
            InitializeComponent();
        }

        public CustomerProfile(int accountID)
        {
            InitializeComponent();
            accountID_CustomerProfile = accountID;
         
  
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string connectionString = DatabaseConfig.ConnectionString;
        private void CustomerProfile_Load(object sender, EventArgs e)
        {
     
            accountIDTextBox.Text = accountID_CustomerProfile.ToString();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string getInfoQuery = "SELECT firstName, lastName, age, sex, mobileNumber, email, telephoneNumber FROM customer " +
                                          "WHERE accountID = @accountID; ";

                    using (MySqlCommand getInfoCommand = new MySqlCommand(getInfoQuery, connection))
                    {
                        getInfoCommand.Parameters.AddWithValue("@accountID", accountID_CustomerProfile);

                        using (MySqlDataReader reader = getInfoCommand.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                _firstName = reader["firstName"].ToString();
                                _lastName = reader["lastName"].ToString();
                                string ageGet = reader["age"].ToString();
                                _age = int.Parse(ageGet);
                                _sex = reader["sex"].ToString();
                                _mobileNumber = reader["mobileNumber"].ToString();
                                _email = reader["email"].ToString();
                                _telehpone = reader["telephoneNumber"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No record found for the given account ID.");
                            }

                        }

                        string queryGetUser = "SELECT username FROM users WHERE accountID = @accountID;";
                        using (MySqlCommand  queryGetUserCommand = new MySqlCommand(queryGetUser, connection))
                        {
                            queryGetUserCommand.Parameters.AddWithValue("@accountID", accountID_CustomerProfile);

                            using (MySqlDataReader readUser = queryGetUserCommand.ExecuteReader())
                            {
                                if (readUser.Read())
                                {
                                    _username = readUser["username"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            firstName.Text = _firstName;
            lastName.Text = _lastName;
            age.Text = _age.ToString();
            mobileNumber.Text = _mobileNumber;
            email.Text = _email;
            telephone.Text = _telehpone;
            accountIDTextBox.Text = accountID_CustomerProfile.ToString();
            username.Text = _username;


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Customer_Main customer_Main = new Customer_Main(accountID_CustomerProfile);
            customer_Main.Show();
            this.Hide();
        }

        

        private void editButton_Click(object sender, EventArgs e)
        {
            firstName.ReadOnly = false;
            lastName.ReadOnly = false;
            age.ReadOnly = false;
            mobileNumber.ReadOnly = false;
            email.ReadOnly = false;
            telephone.ReadOnly = false;
            saveBtn.Visible = true;



        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            firstName.ReadOnly = true;
            lastName.ReadOnly = true;
            age.ReadOnly = true;
            mobileNumber.ReadOnly = true;
            email.ReadOnly = true;
            telephone.ReadOnly = true;
            saveBtn.Visible = false;
            

            if (!email.Text.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The email must end with '@gmail.com'. Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(firstName.Text) &&
                !string.IsNullOrWhiteSpace(lastName.Text) &&
                !string.IsNullOrWhiteSpace(age.Text) &&
                !string.IsNullOrWhiteSpace(mobileNumber.Text) &&
                !string.IsNullOrWhiteSpace(email.Text) &&
                !string.IsNullOrWhiteSpace(telephone.Text))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string updateProfileQuery = "UPDATE customer " +
                                                    "SET firstName = @firstName, lastName = @lastName, age = @age, mobileNumber = @mobileNumber, email = @email, telephoneNumber = @telephone, sex = @sex " +
                                                    "WHERE accountID = @accountID;";

                        using (MySqlCommand command = new MySqlCommand(updateProfileQuery, connection))
                        {
                            command.Parameters.AddWithValue("@firstName", firstName.Text);
                            command.Parameters.AddWithValue("@lastName", lastName.Text);

                            if (!int.TryParse(age.Text, out int parsedAge))
                            {
                                MessageBox.Show("Age must be a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            command.Parameters.AddWithValue("@age", parsedAge);

                            command.Parameters.AddWithValue("@mobileNumber", mobileNumber.Text);
                            command.Parameters.AddWithValue("@email", email.Text);
                            command.Parameters.AddWithValue("@telephone", telephone.Text);
                            command.Parameters.AddWithValue("@accountID", accountID_CustomerProfile);
                            command.Parameters.AddWithValue("@sex", comboBox1.Text);
                            command.ExecuteNonQuery();

                            MessageBox.Show("Profile Successfully Updated!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Some Input Fields are Empty!");
            }

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            CustomerReservation customerReservation = new CustomerReservation(accountID_CustomerProfile);
            customerReservation.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
