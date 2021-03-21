using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button

                    LinkButton3.Visible = false; // logout link button

                    LinkButton4.Visible = true; // admin login link button
                    LinkButton5.Visible = true; // staff login link button

                }
                else if (Session["role"].Equals("Passenger"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button

                    LinkButton4.Visible = false; // admin login link button
                    LinkButton5.Visible = false; // staff login link button
                }
                else if (Session["role"].Equals("Admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button

                    LinkButton4.Visible = false; // admin login link button
                    LinkButton5.Visible = false; // staff login link button
                }
                else if (Session["role"].Equals("Manager"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button

                    LinkButton4.Visible = false; // admin login link button
                    LinkButton5.Visible = false; // staff login link button
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("stafflogin.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["userid"] = "";
            Session["role"] = "";
            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button

            LinkButton3.Visible = false; // logout link button

            LinkButton4.Visible = true; // admin login link button
            LinkButton5.Visible = true; // staff login link button

            Response.Redirect("homepage.aspx");
        }
    }
}