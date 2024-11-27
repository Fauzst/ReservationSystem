using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ReservationSystem.Forms;
namespace ReservationSystem.Forms.Login
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
           
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void goToLoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private string connectionString = DatabaseConfig.ConnectionString;

        private void SignupButton_Click(object sender, EventArgs e)
        {
            if (firstNameInput.Text != "" && lastNameInput.Text != "" && ageInput.Text != "" && usernameSignup.Text != "" && passwordSignup.Text != "")
            {
                string firstName = firstNameInput.Text;
                string lastName = lastNameInput.Text;
                string ageString = ageInput.Text;
                int age;
                if (int.TryParse(ageString, out age))
                {
                    
                }
                else
                {
                    MessageBox.Show("Age must be numerical!");
                }
    
                string username = usernameSignup.Text;
                string password = passwordSignup.Text;
                string userAccess = "customer";
                string accountIDstring = "";
                int accountID = 0;
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        //Queries
                        string queryAddToUserTable = "INSERT INTO users (username, password, userAccess) VALUES (@username, @password, @userAccess);";
                        string queryAddToCustomer = "INSERT INTO customer (firstName, lastName, age, accountID) VALUES (@firstName, @lastName, @age, @accountID);";

                        //Get AccountID
                        string queryGetAccountID = "SELECT accountID FROM users WHERE username = @username;";



                        using (MySqlCommand command1 = new MySqlCommand(queryAddToUserTable, connection))
                        {
                    
                            command1.Parameters.AddWithValue("@username", username);
                            command1.Parameters.AddWithValue("@password", password);
                            command1.Parameters.AddWithValue("@userAccess", userAccess);
                            command1.ExecuteNonQuery();
                        }

                        using (MySqlCommand command2 = new MySqlCommand(queryGetAccountID, connection))
                        {
                            command2.Parameters.AddWithValue("@username", username);

                            object result = command2.ExecuteScalar();
                            if (result != null)
                            {
                                accountIDstring += result.ToString();
                                accountID += int.Parse(accountIDstring);
                            }

                     
                        }

                        using (MySqlCommand command3 = new MySqlCommand(queryAddToCustomer, connection))
                        {
                            command3.Parameters.AddWithValue("@firstName", firstName);
                            command3.Parameters.AddWithValue("@lastName", lastName);
                            command3.Parameters.AddWithValue("@age", age);
                            command3.Parameters.AddWithValue("@accountID", accountID);
                            command3.ExecuteNonQuery();
                        }

                        MessageBox.Show("Successfully Signed Up!");

                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Hide();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                MessageBox.Show("Fill all the Input Field!");
            }
        }
    }
}
