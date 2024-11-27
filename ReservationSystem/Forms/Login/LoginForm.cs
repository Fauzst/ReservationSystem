using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ReservationSystem.Forms.Login;
using ReservationSystem.Forms.Customer;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;
using ReservationSystem.Forms.Frontdesk;
using ReservationSystem.Forms.Admin;
using ReservationSystem.Forms;
namespace ReservationSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel1.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel1.Width - radius, panel1.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel1.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panel1.Region = new Region(path);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

            SignupForm signupForm = new SignupForm();
            signupForm.Show();

            this.Hide();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private string connectionString = DatabaseConfig.ConnectionString;

        public int accountID = 0;

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameLogin.Text;
            string password = passwordLogin.Text;
  

            string userAccess = null;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT userAccess FROM users WHERE username = @username AND password = @password";
                    string queryGetAccountID = "SELECT accountID FROM users WHERE username = @username;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            userAccess = result.ToString();
                        }

                    }

                    using (MySqlCommand commandGetAccountID = new MySqlCommand(queryGetAccountID, connection))
                    {
                        commandGetAccountID.Parameters.AddWithValue("@username", username);

                        object getIdResult = commandGetAccountID.ExecuteScalar();

                        if (getIdResult != null)
                        {
                            string IdResultString = getIdResult.ToString();
                            accountID += int.Parse(IdResultString);
                        }
                    }
                }
            }
            catch
            (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



             switch (userAccess)
            {
                case "customer":
                    Customer_Main customer_main = new Customer_Main(accountID);
                    CustomerProfile customerProfile = new CustomerProfile(accountID);
                    CustomerReservation customerReservation = new CustomerReservation(accountID);
                   
                    customer_main.Show();
                    this.Hide();
                    break;

                case "frontdesk":
                    FrontdeskMain frontdeskMain = new FrontdeskMain();
                    frontdeskMain.Show();
                    this.Hide();
                    break;

                case "admin":
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("Invalid Login Credentials");
                    break;
            }
        }


        
    }
}
