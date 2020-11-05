using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagementSystem
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["role"]))
            {
                Response.Redirect("homepage.aspx");
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            GridView1.DataBind();
        }

        // Go button Click
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }
        //Book issue click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkIfBookExist() && checkIfMemberExits())
            {
                if (checkIfEntryrExist())
                {
                    Response.Write("<script>alert('This member has already this book');</script>");
                }
                else
                {
                    issueBook();
                }
            }
            else
            {
               Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }

        }
        //book return click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExits())
            {
                if (checkIfEntryrExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('This entry doesnot exist.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }
        //user define functions

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                /*Here we check whether the connection is open or not if not open then open it.
                 For ConnectionState we have to add namespace of System.Data*/
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id='"+TextBox2.Text.Trim()+"' AND " +
                    "member_id='"+TextBox3.Text.Trim()+"'",con);
                int result=cmd.ExecuteNonQuery();

                if(result > 0)
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //Query to update the current stock becasue one book is issue and we have to minus it from current stock.
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock+1 WHERE book_id='" + TextBox2.Text.Trim() + "'",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Return Successfully');</script>");
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); ;
            }
        }
        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                /*Here we check whether the connection is open or not if not open then open it.
                 For ConnectionState we have to add namespace of System.Data*/
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date)" +
                    "VALUES(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)",con);

                cmd.Parameters.AddWithValue("@member_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();
                //Query to update the current stock becasue one book is issue and we have to minus it from current stock.
                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock-1 WHERE book_id='"+TextBox2.Text.Trim()+"'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Issued Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); ;
            }
        }
        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id='"+TextBox2.Text.Trim()+"'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >=1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString().Trim();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
                cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >=1)
                {
                    TextBox1.Text = dt.Rows[0]["full_name"].ToString().Trim();
                }
                else
                {
                    Response.Write("<script>alert('Invalid User ID');</script>");
                }

            }
            catch
            {

            }
        }
        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox2.Text.Trim() + "' AND " +
                    "current_stock >0", con);
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
            catch(Exception ex)
            {
                return false;
            }
            
        }
        bool checkIfMemberExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
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
                return false;
            }

        
        }
        bool checkIfEntryrExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id='" + TextBox3.Text.Trim() + "' AND book_id='"+TextBox2.Text.Trim()+"'", con);
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
                return false;
            }

        }

        /*this function is to check if due date is over then this function mark that row in to red colour.
         To add this function we have to select the gridview and open the properties then from properties we have to click on 
        events tab and select the RowDataBound attribute and then double click on it.
         */
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    //DataControlRowType check whether the row have some proper values or not.
                    //check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);

                    //cells[5] means the 5th cell of the grid view table not the database table and this cell also start from 0 index.
                    DateTime today = DateTime.Today;
                    if(today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}