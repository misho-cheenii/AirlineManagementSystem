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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AirlineManagementSystem
{
    public partial class flightsearch : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("userlogin.aspx");
                
            }
            else
            {
                addNewBooking();

            }
        }
        
        void addNewBooking()
        {

             try
             {
                 int flag = 0;
                 using (SqlConnection con = new SqlConnection(strcon))
                 {

                     if (con.State == ConnectionState.Closed)
                     {
                         con.Open();
                     }

                     SqlCommand cmd = new SqlCommand("SELECT class, capacity, Booked_Seats from av_seats where Flight_id='" + TextBox3.Text.Trim() + "';", con);

                     DataTable dt = new DataTable();

                     SqlDataAdapter da = new SqlDataAdapter(cmd);

                     da.Fill(dt);

                     foreach (DataRow dr in dt.Rows)
                     {
                         string bs = dr["Booked_Seats"].ToString();
                         string av = dr["capacity"].ToString();
                         string dropd = DropDownList1.Text;
                         string cl = dr["class"].ToString();
                         if (  (bs == av) && (dropd == cl))
                         {
                             Response.Write("<script>alert('Seat not available');</script>");
                             break;
                         }
                         else
                         {
                             flag = 1;
                         }
                     }


                     con.Close();
                 }
                 if (flag == 1)
                 {
                     using (SqlConnection con = new SqlConnection(strcon))
                     {
                         if (con.State == ConnectionState.Closed)
                         {
                             con.Open();
                         }

                         SqlCommand cmd = new SqlCommand("INSERT INTO booking(p_id,f_id,class_id) values('" + Convert.ToInt32(Session["userid"].ToString()) + "','" + TextBox3.Text.Trim() + "',(select Class_id from classFlight where Flight_id = '" + TextBox3.Text.Trim() + "' AND class = '" + DropDownList1.Text.Trim() + "'))", con);

                         cmd.ExecuteNonQuery();
                         con.Close();
                        
                     }
                     ticketGenerate();
                 }


             }
             catch (Exception ex)
             {
                 Response.Write("<script>alert('" + ex.Message + "');</script>");
             }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getFlightByID();
        }

        void getFlightByID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT class from classFlight where Flight_id='" + TextBox3.Text.Trim() + "';", con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataBind();
                    rdr.Dispose();
                    rdr.Close();
                    con.Close();
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT class as Class, avseats as AvailableSeats from av_seats where Flight_id='" + TextBox3.Text.Trim() + "';", con);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        GridView2.DataSource = dr;
                        GridView2.DataBind();
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

        void ticketGenerate()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT TOP(1) * from bookingdetails where Flight_No='" + TextBox3.Text.Trim() + "' order by Booking_No desc", con);
                clearForm();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow dr;
                dr = dt.Rows[0];
                Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    Color color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    //Company Logo
                    cell = ImageCell("~/imgs/airlines.jpg", 8f, PdfPCell.ALIGN_CENTER);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk("Database Ways\n\n", FontFactory.GetFont("Arial", 20, Font.BOLD, Color.RED)));
                    phrase.Add(new Chunk("Airline Management System\n\n", FontFactory.GetFont("Arial", 16, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                    DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.SetWidths(new float[] { 0.3f, 1f });
                    table.SpacingBefore = 20f;

                    //Employee Details
                    cell = PhraseCell(new Phrase("\n\nTicket\n", FontFactory.GetFont("Arial", 24, Font.UNDERLINE, Color.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);
                    document.Add(table);

                    DrawLine(writer, 160f, 80f, 160f, 690f, Color.BLACK);
                    DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, Color.BLACK);

                    table = new PdfPTable(2);
                    table.SetWidths(new float[] { 0.5f, 2f });
                    table.TotalWidth = 340f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 20f;
                    table.HorizontalAlignment = Element.ALIGN_RIGHT;

                    //Booking_By
                    table.AddCell(PhraseCell(new Phrase("Booking_By:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["Booking_By"].ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Flight Id
                    table.AddCell(PhraseCell(new Phrase("Flight_No:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dr["Flight_No"].ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Booking Id
                    table.AddCell(PhraseCell(new Phrase("Booking_No:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase((dr["Booking_No"]).ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Flight From
                    table.AddCell(PhraseCell(new Phrase("From:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase((dr["From"]).ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Flight To
                    table.AddCell(PhraseCell(new Phrase("To:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase((dr["To"]).ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Departure
                    table.AddCell(PhraseCell(new Phrase("Departure:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(Convert.ToDateTime(dr["Departure"]).ToString("f"), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Arrival
                    table.AddCell(PhraseCell(new Phrase("Arrival:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(Convert.ToDateTime(dr["Arrival"]).ToString("f"), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Duration
                    table.AddCell(PhraseCell(new Phrase("Duration:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase((dr["Duration"]).ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);
                    // Convert.ToInt32(dr["Duration"].ToString())

                    //Price
                    table.AddCell(PhraseCell(new Phrase("Price:", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase((dr["Price"]).ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Ticket.pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }
        void clearForm()
        {
            TextBox3.Text = "";
            DropDownList1.DataSource = null;
            DropDownList1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
    }
}