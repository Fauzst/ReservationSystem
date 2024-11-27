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
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public string accountIDString;
        public int deleteUserID;
        private string connectionString = DatabaseConfig.ConnectionString;

        private void button2_Click(object sender, EventArgs e)
        {
            string queryDelete = "DELETE FROM users WHERE accountID = @accountID;";
            accountIDString = accountIDTB.Text;
            

            if (int.TryParse(accountIDString, out deleteUserID))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(queryDelete, connection))
                        {
                            command.Parameters.AddWithValue("@accountID", deleteUserID);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }

                MessageBox.Show("Deleted user with Account ID: " + accountIDString);
                this.Hide();
            }
            else
            {
                MessageBox.Show("AccountID must be numerical!");
            }
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {

        }
    }
}
