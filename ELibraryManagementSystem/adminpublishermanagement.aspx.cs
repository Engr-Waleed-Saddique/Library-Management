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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (string.IsNullOrEmpty((string)Session["role"]))
            {
                Response.Redirect("homepage.aspx");
            }
        }
        // Publihser Add Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                Response.Write("<script>alert('Publisher with this id already exist.You cannot add another author with the " +
                    "same Author Id.');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }

        // Publisher update button click event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher didnot exist');</script>");
            }
        }



        //Publisher Delete Button 
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Author didnot Exist');</script>");
            }
        }


        //Go button Click Event
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }


        //user define function
        bool checkIfPublisherExist()
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
                SqlCommand cmd = new SqlCommand("Select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "';", con);
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

        //user define function
        void addNewPublisher()
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
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) VALUES(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Added Successfully');</script>");
                clearForm();
                /*This line of code show the new record add in the database in gridView.If we not add this line the new record
                is not showing automatically in the gridview.
                 */
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); ;
            }
        }


        //user defined function 
        void updatePublisher()
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
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox3.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); ;
            }
        }


        //User define function
        void deletePublisher()
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
                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tbl WHERE publisher_id='" + TextBox3.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); ;
            }
        }

        //user Define function 
        void getPublisherById()
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
                SqlCommand cmd = new SqlCommand("Select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher Id')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                //return false;
            }
        }

        //user define function 
        void clearForm()
        {
            TextBox3.Text = "";
            TextBox2.Text = "";
        }
        
    }
}