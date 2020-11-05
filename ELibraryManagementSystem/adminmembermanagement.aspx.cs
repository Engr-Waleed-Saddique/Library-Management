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
    public partial class adminmember : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["role"]))
            {
                Response.Redirect("homepage.aspx");
            }
            GridView1.DataBind();
        }
        //Go Button 
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberById();
        }
        // Active Button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("active");
        }
        //Pending Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("Pending");
        }
        //Deactivate button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("Deactive");
        }
        //Delete Button 
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMemberById();
        }


        //user define function
        void getMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        // 0 is column 1 which is full_name.
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox1.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox8.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(5).ToString();
                        TextBox11.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();


                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Member ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void updateMemberStatusById(string status)
        {
            if (checkIfMemberExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBox3.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TextBox7.Text = status;
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated Successfully.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member Id')</script>");
            }
        }

        //user defined function
        void deleteMemberById()
        {
            if(checkIfMemberExist())
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
                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member Id');</script>");
            }
        }

        //user defined functions

        bool checkIfMemberExist()
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
                SqlCommand cmd = new SqlCommand("Select * from member_master_tbl where member_id='" + TextBox3.Text.Trim() + "';", con);
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


        //user define method
        void clearForm()
        {
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox1.Text = "";
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}