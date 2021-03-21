using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineManagementSystem
{
    public partial class airplane : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // airplane/class add
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAirplaneExists())
            {
                if (checkIfClassExists())
                {
                    Response.Write("<script>alert('Class already exists');</script>");
                }
                else
                {
                    addNewClass();
                }
            }
            else
            {
                addNewAirplane();
            }
        }

        // airplane update
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAirplaneExists())
            {
                if (checkIfClassExists())
                {
                    updateAirplane();
                }
                else
                {
                    Response.Write("<script>alert('Airplane with this classtype does not exist');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Airplane does not exist');</script>");
            }
        }

        // user defined function

        void updateAirplane()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE classprice SET price=@price, capacity=@capacity WHERE a_id='" + TextBox1.Text.Trim() + "' AND class = '" + DropDownList1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@price", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@capacity", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update Successful');</script>");
                GridView1.DataBind();
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewAirplane()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO airplane(id,name) values(@id,@name)" + "INSERT INTO classprice(class,capacity,price, a_id) values(@class,@capacity,@price,@a_id)", con);

                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@class", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@capacity", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@price", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@a_id", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Airplane added Successfully');</script>");
                GridView1.DataBind();
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewClass()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO classprice(class,capacity,price, a_id) values(@class,@capacity,@price,@a_id)", con);

                cmd.Parameters.AddWithValue("@class", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@capacity", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@price", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@a_id", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Class added Successfully');</script>");
                GridView1.DataBind();
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfAirplaneExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from airplane where id='" + TextBox1.Text.Trim() + "';", con);
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

        bool checkIfClassExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from classprice where a_id='" + TextBox1.Text.Trim() + "' AND class='" + DropDownList1.Text.Trim() + "'", con);
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
            TextBox3.Text = "";
            DropDownList1.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }
    }
}