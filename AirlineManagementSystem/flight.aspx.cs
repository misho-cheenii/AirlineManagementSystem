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
    public partial class fight : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("Select id, name from location", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataBind();
                    DropDownList2.DataSource = dt;
                    DropDownList2.DataBind();
                }
            }
        }

        //add location
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIflocationExists())
            {
                Response.Write("<script>alert('City already exists');</script>");
            }
            else
            {
                addNewlocation();
            }
        }

        // update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfupdateFlightExists())
            {
                updateFlight();
            }
            else
            {
                Response.Write("<script>alert('Flight with this ID does not exist');</script>");
            }
        }

        //Go
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfupdateFlightExists())
            {
                getFlightByID();
            }
            else
            {
                Response.Write("<script>alert('Flight with this ID does not exist');</script>");
            }
        }

        //ADD
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfaddFlightExists())
            {
                Response.Write("<script>alert('Flight with this ID ALREADY exists');</script>");
            }
            else
            {
                addNewFlight();
            }
        }

        void getFlightByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from flight where id='" + TextBox7.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox8.Text = dt.Rows[0][3].ToString();
                    TextBox9.Text = dt.Rows[0][4].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Flight ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void updateFlight()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("UPDATE flight SET Departure=@Departure , Arrival=@Arrival WHERE id='" + TextBox7.Text.Trim() + "'", con);
                String dep;
                dep = TextBox8.Text.Trim();
                DateTime Mydep;
                Mydep = new DateTime();
                Mydep = DateTime.Parse(dep);

                String arr;
                arr = TextBox9.Text.Trim();
                DateTime Myarr;
                Myarr = new DateTime();
                Myarr = DateTime.Parse(arr);

                cmd.Parameters.AddWithValue("@Arrival", Myarr);
                cmd.Parameters.AddWithValue("@Departure", Mydep);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update Successful');</script>");
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

         void addNewFlight()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO flight(id,source,destination,Departure,Arrival,air_id) values(@id,@source,@destination,@Departure,@Arrival,@air_id)", con);
                
                int myInt = 0;

                Int32.TryParse(DropDownList1.SelectedItem.Value, out myInt);

                int myInt2 = 0;

                Int32.TryParse(DropDownList2.SelectedItem.Value, out myInt2);

                DateTime departTime = DateTime.ParseExact(TextBox5.Text.Trim(), "yyyy-MM-ddTHH:mm", null);
                    DateTime arriveTime = DateTime.ParseExact(TextBox6.Text.Trim(), "yyyy-MM-ddTHH:mm", null);
                    cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@source", myInt);
                   cmd.Parameters.AddWithValue("@destination", myInt2);
                    cmd.Parameters.AddWithValue("@Arrival", arriveTime);
                    cmd.Parameters.AddWithValue("@Departure", departTime);
                    cmd.Parameters.AddWithValue("@air_id", TextBox2.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update Successful');</script>");
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewlocation()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO location(name) values(@name)", con);

                cmd.Parameters.AddWithValue("@name", TextBox10.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Class added Successfully');</script>");
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIflocationExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from location where name='" + TextBox10.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        bool checkIfaddFlightExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from flight where [id='" + TextBox1.Text.Trim() + "' OR id='" + TextBox7.Text.Trim() + "']", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        bool checkIfupdateFlightExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from flight where id='" + TextBox7.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            DropDownList1.Text = "";
            DropDownList2.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }
    }
}