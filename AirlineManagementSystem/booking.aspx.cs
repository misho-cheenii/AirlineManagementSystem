using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineManagementSystem
{
    public partial class booking : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            getBookingByID();
        }

        void getBookingByID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT [Flight_No],[Booking_By],[To],[From],[Class],[Departure],[Duration] from bookingdetails where Booking_No='" + TextBox1.Text.Trim() + "';", con);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        GridView1.DataSource = dr;
                        GridView1.DataBind();
                        dr.Dispose();
                        dr.Close();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("userlogin.aspx");

            }
            else
            {
                deleteBooking();

            }
            
        }
        void deleteBooking()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM [bookingdetails] WHERE Booking_No ='" + TextBox1.Text.Trim() + "';", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Booking Delete Successful');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}