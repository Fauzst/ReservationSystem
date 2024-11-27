using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Forms;
namespace ReservationSystem.Forms.Customer
{

    public partial class Customer_Main : Form
    {
        public int accountID_CustomerMain = 0;

        public Customer_Main(int accountID)
        {
            accountID_CustomerMain += accountID;
            InitializeComponent();
    
        }

        public Customer_Main()
        {
            InitializeComponent();
        }

        private string connectionString = DatabaseConfig.ConnectionString;

        private void Customer_Main_Load()
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Main_Load(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            CustomerProfile customerProfile = new CustomerProfile(accountID_CustomerMain);
            customerProfile.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string queryGetData = "SELECT reservationID, dateStart, dateEnd, venue, room, bill, reservationStatus " +
                                    "FROM reservations " +
                                    "WHERE accountID = @accountID"; 

 
            DataTable reservationTable = new DataTable();


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
        
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(queryGetData, connection))
                    {
                        command.Parameters.AddWithValue("@accountID", accountID_CustomerMain);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                         
                            adapter.Fill(reservationTable);
                        }
                    }
                    
                }

     
                dataGridView1.DataSource = reservationTable;

        
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerReservation customerReservation = new CustomerReservation(accountID_CustomerMain);
            customerReservation.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reschedule reschedule = new Reschedule(accountID_CustomerMain);
            reschedule.Show();
        }
    }
}
