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
    public partial class FrontdeskMain : Form
    {
        public FrontdeskMain()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Walkin walkin = new Walkin();
            walkin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private string connectionString = DatabaseConfig.ConnectionString;

        private void FrontdeskMain_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string queryReservations = "SELECT reservationID, dateStart, dateEnd, venue, room, bill, firstName, lastName, reservationStatus FROM reservations WHERE reservationStatus != 'Success';";

            DataTable reservations = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(queryReservations, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(reservations);
                            dataGridView1.DataSource = reservations;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateStatus updateStatus = new UpdateStatus();
            updateStatus.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }
    }
}
