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
using System.Windows.Forms.DataVisualization.Charting;
using ReservationSystem.Forms;

namespace ReservationSystem.Forms.Admin
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private string connectionString = DatabaseConfig.ConnectionString;



        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            string queryTotal = "SELECT COUNT(*) AS TotalCount FROM reservations;";
            string queryAccTotal = "SELECT COUNT(*) AS TotalCount FROM reservations WHERE reservationStatus = 'Accepted';";
            string queryCanTotal = "SELECT COUNT(*) AS TotalCount FROM reservations WHERE reservationStatus = 'Cancelled';";
            string querySucTotal = "SELECT COUNT(*) AS TotalCount FROM reservations WHERE reservationStatus = 'Success';";
            string revTotal = "SELECT SUM(bill) AS Total FROM reservations;";

            int conferenceSmall = 0, conferenceMedium = 0, conferenceLarge = 0;
            int banquetSmall = 0, banquetMedium = 0, banquetLarge = 0;
            int outdoorSmall = 0, outdoorMedium = 0, outdoorLarge = 0;


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand getTotal = new MySqlCommand(queryTotal, connection))
                    {
                        using (MySqlDataReader reader = getTotal.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                d1.Text = reader.IsDBNull(reader.GetOrdinal("TotalCount"))
                        ? "0"
                        : reader["TotalCount"].ToString();
                            }
                        }
                    }
                    using (MySqlCommand getAccTotal = new MySqlCommand(queryAccTotal, connection))
                    {
                        using (MySqlDataReader reader = getAccTotal.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                d2.Text = reader.IsDBNull(reader.GetOrdinal("TotalCount"))
                        ? "0"
                        : reader["TotalCount"].ToString();
                            }
                        }
                    }
                    using (MySqlCommand getCanTotal = new MySqlCommand(queryCanTotal, connection))
                    {
                        using (MySqlDataReader reader = getCanTotal.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                d3.Text = reader.IsDBNull(reader.GetOrdinal("TotalCount"))
                        ? "0"
                        : reader["TotalCount"].ToString();
                            }
                        }
                    }
                    using (MySqlCommand getSucTotal = new MySqlCommand(querySucTotal, connection))
                    {
                        using (MySqlDataReader reader = getSucTotal.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                d4.Text = reader.IsDBNull(reader.GetOrdinal("TotalCount"))
                        ? "0"
                        : reader["TotalCount"].ToString();
                            }
                        }
                    }
                    using (MySqlCommand getRevTotal = new MySqlCommand(revTotal, connection))
                    {
                        float totalBillFloat;

                        using (MySqlDataReader reader = getRevTotal.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the sum as a float
                                totalBillFloat = reader.IsDBNull(reader.GetOrdinal("Total")) ? 0f : reader.GetFloat("Total");
                                a1.Text = totalBillFloat.ToString();
                                a2.Text = (totalBillFloat * 0.40f).ToString("F2");
                                a3.Text = (totalBillFloat * 0.6f).ToString("F2");
                            }
                        }
                    }

                    // Room Data
                    

                    // Queries
                    string QconferenceSmall = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Conference Room' AND room = 'Small Room';";
                    string QconferenceMedium = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Conference Room' AND room = 'Medium Room';";
                    string QconferenceLarge = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Conference Room' AND room = 'Large Room';";
                    string QbanquetSmall = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Banquet Hall' AND room = 'Small Room';";
                    string QbanquetMedium = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Banquet Hall' AND room = 'Medium Room';";
                    string QbanquetLarge = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Banquet Hall' AND room = 'Large Room';";
                    string QoutdoorSmall = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Outdoor Space' AND room = 'Small Room';";
                    string QoutdoorMedium = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Outdoor Space' AND room = 'Medium Room';";
                    string QoutdoorLarge = "SELECT COUNT(*) AS Total FROM reservations WHERE venue = 'Outdoor Space' AND room = 'Large Room';";

                    int ExecuteQuery(string query)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return reader.IsDBNull(reader.GetOrdinal("Total")) ? 0 : reader.GetInt32("Total");
                                }
                            }
                        }
                        return 0;
                    }

                    // Populate variables by executing each query
                    conferenceSmall = ExecuteQuery(QconferenceSmall);
                    conferenceMedium = ExecuteQuery(QconferenceMedium);
                    conferenceLarge = ExecuteQuery(QconferenceLarge);

                    banquetSmall = ExecuteQuery(QbanquetSmall);
                    banquetMedium = ExecuteQuery(QbanquetMedium);
                    banquetLarge = ExecuteQuery(QbanquetLarge);

                    outdoorSmall = ExecuteQuery(QoutdoorSmall);
                    outdoorMedium = ExecuteQuery(QoutdoorMedium);
                    outdoorLarge = ExecuteQuery(QoutdoorLarge);
                }

                chart1.ChartAreas.Clear();
                    ChartArea chartArea = new ChartArea("MainArea");
                    chart1.ChartAreas.Add(chartArea);
                    chart1.Series.Clear();
                    Series series1 = new Series("Small Room")
                    {
                        ChartType = SeriesChartType.Column, // Bar chart
                        IsValueShownAsLabel = true // Show values on top of the bars
                    };
                    chart1.Series.Add(series1);
                    Series series2 = new Series("Medium Room")
                    {
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true
                    };
                    chart1.Series.Add(series2);
                    Series series3 = new Series("Large Room")
                    {
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true
                    };
                    chart1.Series.Add(series3);

                    series1.Points.AddXY("Conference Room", conferenceSmall);
                    series1.Points.AddXY("Banquet Hall", banquetSmall);
                    series1.Points.AddXY("Outdoor Space", outdoorSmall);
                    series2.Points.AddXY("Conference Room", conferenceMedium);
                    series2.Points.AddXY("Banquet Hall", banquetMedium);
                    series2.Points.AddXY("Outdoor Space", outdoorMedium);
                    series3.Points.AddXY("Conference Room", conferenceLarge);
                    series3.Points.AddXY("Banquet Hall", banquetLarge);
                    series3.Points.AddXY("Outdoor Space", outdoorLarge);
                    chart1.Titles.Clear();
                    chart1.Titles.Add("Room Statistic");
                    chart1.Titles[0].Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
                    chart1.ChartAreas["MainArea"].AxisX.Title = "Categories";
                    chart1.ChartAreas["MainArea"].AxisY.Title = "Values";
                    chart1.ChartAreas["MainArea"].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                    chart1.ChartAreas["MainArea"].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ManageUser manageUser = new ManageUser();
            manageUser.Show();
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
