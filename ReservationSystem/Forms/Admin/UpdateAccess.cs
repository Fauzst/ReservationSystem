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

namespace ReservationSystem.Forms.Admin
{
    public partial class UpdateAccess : Form
    {
        public UpdateAccess()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private string connectionString = DatabaseConfig.ConnectionString;
        public string accountID;
        public int _accountID;
        public string userAccess;

        private void button2_Click(object sender, EventArgs e)
        {
            string queryUpdate = "UPDATE users SET userAccess = @userAccess WHERE accountID = @accountID;";
            accountID = accountIDTB.Text;
            
            userAccess = comboBox1.Text;
           
            if (int.TryParse(accountID, out _accountID))
            {
                if (_accountID > 0 && comboBox1.Text == "admin" || comboBox1.Text == "frontdesk" || comboBox1.Text == "customer")
                {
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(queryUpdate, connection))
                            {
                                command.Parameters.AddWithValue("@userAccess", userAccess);
                                command.Parameters.AddWithValue("@accountID", _accountID);

                                command.ExecuteNonQuery();

                                MessageBox.Show("Successfully updated user's access!");
                                this.Hide();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                    }

                    
                }
                
            }
            else
            {
                MessageBox.Show("AccountID must be numerical!");
            }

        }

        private void UpdateAccess_Load(object sender, EventArgs e)
        {

        }
    }
}
