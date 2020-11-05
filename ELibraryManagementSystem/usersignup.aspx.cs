using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ClientServices;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagementSystem
{
    public partial class usersignup : System.Web.UI.Page
    {
        //Database connection accessing the con variable from web.config using configuration 
        //manager.For this we have to add using System.Configuration

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        //Sign Up Button Click Event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                Response.Write("<script>alert('Member already exist with this ID, Try other Id')</script>");
            }
            else
            {
                signUpNewMember();
            }
        }
        //User Defined Method

        bool checkMemberExists()
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
                SqlCommand cmd = new SqlCommand("Select * from member_master_tbl where member_id='"+TextBox8.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >=1)
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


        void signUpNewMember()
        {
            /*It is good practice to use try catch for database connection cause we got some time exceptions in database
            ConnectivityStatus. We have to add using System.Data.SqlClient for SqlConnection*/

            try
            {
                SqlConnection con = new SqlConnection(strcon);

                /*Here we check whether the connection is open or not if not open then open it.
                 For ConnectionState we have to add namespace of System.Data*/
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode," +
                    "full_address,member_id,password,account_status) VALUES(@full_name,@dob,@contact_no,@email,@state,@city,@pincode," +
                    "@full_address,@member_id,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successfull.Go to user Login to Login');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>"); ;
            }
        }
    }
}