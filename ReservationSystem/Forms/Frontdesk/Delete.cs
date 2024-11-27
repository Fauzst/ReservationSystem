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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
        private string connectionString = DatabaseConfig.ConnectionString;

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM reservations WHERE reservationID = @reservationID;";
            string reservationID = textBox1.Text;
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
                            command.Parameters.AddWithValue("@reservationID", _reservationID);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Reservation Successfully Deleted!");
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
                MessageBox.Show("ReservationID must be numerical!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
