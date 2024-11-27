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
using static Google.Protobuf.Reflection.FeatureSet.Types;
using ReservationSystem.Forms;
namespace ReservationSystem.Forms.Customer
{
    public partial class Reschedule : Form
    {
        public int accountID_Reschedule { get; set; }
        public int reservationID;
        public DateTime startDate;
        public DateTime endDate;
        private string connectionString = DatabaseConfig.ConnectionString;
        public string venue;
        public string room;
        public int daysOccupancy;
        public string catering;

        public Reschedule(int accountID)
        {
            InitializeComponent();
            accountID_Reschedule = accountID;
        }

        private void Reschedule_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public float[] postCleaningFee = { 299.99F, 399.99F, 499.99F, 599.99F, 699.99F, 799.99F, 899.99F, 999.99F, 1099.99F };
        public float[] reservationFee = { 99.99F, 199.99F, 299.99F, 399.99F, 499.99F, 599.99F, 699.99F, 799.99F, 899.99F };
        public float[] cateringFee = { 999.99F, 1999.99F, 2999.99F };
        public float[] roomFee = { 3499.99F, 3599.99F, 3699.99F, 3999.99F, 4099.99F, 4199.99F, 4999.99F, 5099.99F, 5199.99F };
        public float totalCharge;
        private void button2_Click(object sender, EventArgs e)
        {
            string _reservationID = reservationIDTextBox.Text;
            int reservationID;
            if (int.TryParse(_reservationID, out reservationID))
            {
                reservationID = int.Parse(_reservationID);
                startDate = dateTimePicker1.Value;
                endDate = dateTimePicker2.Value;

                daysOccupancy = (endDate.Date - startDate).Days;

                string dateValidation = "SELECT reservationID FROM reservations " +
                                        "WHERE reservationID != @reservationID " +
                                        "AND venue = @venueType " +
                                        "AND room = @roomType " +
                                        "AND (dateStart < @endDate AND dateEnd > @startDate);";
                string getInfoQeury = "SELECT venue, room, catering FROM reservations WHERE reservationID = @reservationID AND reservationStatus != 'Reservation Fulfilled';";
                string rescheduleQuery = "UPDATE reservations " +
                                         "SET dateEnd = @dateEnd, dateStart = @dateStart " +
                                         "WHERE reservationID = @reservationID;";



                if (daysOccupancy > 0 && reservationIDTextBox.Text != "" && reservationID > 0)
                {

                    try
                    {

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            using (MySqlCommand getInfoCommand = new MySqlCommand(getInfoQeury, connection))
                            {
                                getInfoCommand.Parameters.AddWithValue("@reservationID", reservationID);
                                using (MySqlDataReader getInfo = getInfoCommand.ExecuteReader())
                                {
                                    if (getInfo.Read())
                                    {
                                        venue = getInfo["venue"].ToString();
                                        room = getInfo["room"].ToString();
                                        catering = getInfo["catering"].ToString();
                                    }
                                }
                                using (MySqlCommand checkDateValidityCommand = new MySqlCommand(dateValidation, connection))
                                {
                                    checkDateValidityCommand.Parameters.AddWithValue("@venueType", venue);
                                    checkDateValidityCommand.Parameters.AddWithValue("@roomType", room);
                                    checkDateValidityCommand.Parameters.AddWithValue("@endDate", endDate);
                                    checkDateValidityCommand.Parameters.AddWithValue("@startDate", startDate);
                                    checkDateValidityCommand.Parameters.AddWithValue("@reservationID", reservationID);


                                    object result = checkDateValidityCommand.ExecuteScalar();
                                    if (result == null)
                                    {
                                        using (MySqlCommand rescheduleCommand = new MySqlCommand(rescheduleQuery, connection))
                                        {
                                            rescheduleCommand.Parameters.AddWithValue("@dateEnd", endDate);
                                            rescheduleCommand.Parameters.AddWithValue("@dateStart", startDate);
                                            rescheduleCommand.Parameters.AddWithValue("@reservationID", reservationID);

                                            rescheduleCommand.ExecuteNonQuery();
                                        }

                                        MessageBox.Show("Successfully Rescheduled!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Date Schedule is Occupied!");
                                    }

                                }
                            }

                            // Bill Recalculation
                            switch (venue)
                            {
                                default:
                                    MessageBox.Show("Pick A Venue!");
                                    break;

                                case "Conference Room":
                                    switch (room)
                                    {
                                        default:

                                            break;

                                        case "Small Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[3] + reservationFee[3] + (cateringFee[1] * daysOccupancy) + (roomFee[3] * daysOccupancy);

                                            }
                                            else
                                            {

                                                totalCharge = postCleaningFee[3] + reservationFee[3] + (roomFee[3] * daysOccupancy);
                                            }


                                            break;

                                        case "Medium Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[4] + reservationFee[4] + (cateringFee[1] * daysOccupancy) + (roomFee[4] * daysOccupancy);

                                            }
                                            else
                                            {

                                                totalCharge = postCleaningFee[4] + reservationFee[4] + (roomFee[4] * daysOccupancy);
                                            }

                                            break;

                                        case "Large Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[5] + reservationFee[5] + (cateringFee[1] * daysOccupancy) + (roomFee[5] * daysOccupancy);

                                            }
                                            else
                                            {

                                                totalCharge = postCleaningFee[5] + reservationFee[5] + (roomFee[5] * daysOccupancy);
                                            }

                                            break;
                                    }
                                    break;

                                case "Banquet Hall":
                                    switch (room)
                                    {
                                        default:
                                            MessageBox.Show("Pick A Room Type!");
                                            break;

                                        case "Small Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[6] + reservationFee[6] + (cateringFee[2] * daysOccupancy) + (roomFee[6] * daysOccupancy);

                                            }
                                            else
                                            {

                                                totalCharge = postCleaningFee[6] + reservationFee[6] + (roomFee[6] * daysOccupancy);
                                            }

                                            break;

                                        case "Medium Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[7] + reservationFee[7] + (cateringFee[2] * daysOccupancy) + (roomFee[7] * daysOccupancy);

                                            }
                                            else
                                            {

                                                totalCharge = postCleaningFee[7] + reservationFee[7] + (roomFee[7] * daysOccupancy);
                                            }


                                            break;

                                        case "Large Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[8] + reservationFee[8] + (cateringFee[2] * daysOccupancy) + (roomFee[8] * daysOccupancy);

                                            }
                                            else
                                            {

                                                totalCharge = postCleaningFee[8] + reservationFee[8] + (roomFee[8] * daysOccupancy);
                                            }

                                            break;
                                    }
                                    break;

                                case "Outdoor Space":
                                    switch (room)
                                    {
                                        default:
                                            MessageBox.Show("Pick A Room Type!");
                                            break;

                                        case "Small Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[0] + reservationFee[0] + (cateringFee[0] * daysOccupancy) + (roomFee[0] * daysOccupancy);

                                            }
                                            else
                                            {
                                                ;
                                                totalCharge = postCleaningFee[0] + reservationFee[0] + (roomFee[0] * daysOccupancy);
                                            }

                                            break;

                                        case "Medium Room":
                                            if (catering == "Included")
                                            {

                                                totalCharge = postCleaningFee[1] + reservationFee[1] + (cateringFee[0] * daysOccupancy) + (roomFee[1] * daysOccupancy);

                                            }
                                            else
                                            {

                                                totalCharge = postCleaningFee[1] + reservationFee[1] + (roomFee[1] * daysOccupancy);
                                            }


                                            break;

                                        case "Large Room":
                                            if (catering == "Included")
                                            {
                                                totalCharge = postCleaningFee[2] + reservationFee[2] + (cateringFee[0] * daysOccupancy) + (roomFee[2] * daysOccupancy);

                                            }
                                            else
                                            {
                                                totalCharge = postCleaningFee[2] + reservationFee[2] + (roomFee[2] * daysOccupancy);
                                            }

                                            break;
                                    }
                                    break;


                            }

                            totalCharge = totalCharge + (totalCharge * 0.12F);

                            string queryUpdateBill = "UPDATE reservations " +
                                                     "SET bill = @totalCharge " +
                                                     "WHERE reservationID = @reservationID;";

                            using (MySqlCommand updateBillCommand = new MySqlCommand(queryUpdateBill, connection))
                            {
                                updateBillCommand.Parameters.AddWithValue("@totalCharge", totalCharge);
                                updateBillCommand.Parameters.AddWithValue("@reservationID", reservationID);

                                updateBillCommand.ExecuteNonQuery();
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
                    MessageBox.Show("Invalid Schedule or ReservationID!");
                }
            }
            else
            {
                MessageBox.Show("ReservationID must be numerical!");
            }
        }
    } 

}
