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

namespace ReservationSystem.Forms.Frontdesk
{
    public partial class UpdateStatus : Form
    {
        public UpdateStatus()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string connectionString = DatabaseConfig.ConnectionString;

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE reservations SET reservationStatus = @status WHERE reservationID = @reservationID;";
            string reservationID = textBox1.Text;
            string status = comboBox1.Text;
            int _reservationID;

            if (int.TryParse(reservationID, out _reservationID))
            {

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@status", status);
                            command.Parameters.AddWithValue("@reservationID", _reservationID);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Reservation Status Successfully Updated!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Reservation ID must be numerical!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UpdateStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
