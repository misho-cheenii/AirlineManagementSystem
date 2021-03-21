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
    public partial class roles : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    Button1.Visible = true; // staff
                    Button2.Visible = true; // passenger

                    Button3.Visible = true; // flight

                    Button4.Visible = true; // airline

                }
                else if (Session["role"].Equals("Manager"))
                {
                    Button1.Visible = false; // staff
                    Button2.Visible = true; // passenger

                    Button3.Visible = true; // flight

                    Button4.Visible = false; // airline
                }
                else if (Session["role"].Equals("Admin"))
                {
                    Button1.Visible = true; // staff
                    Button2.Visible = true; // passenger

                    Button3.Visible = true; // flight

                    Button4.Visible = true; // airline
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("staff.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("flight.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("airplane.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("passenger.aspx");
        }
    }
}