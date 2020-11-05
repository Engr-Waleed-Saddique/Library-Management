using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty((string)Session["role"]))
                {
                    LinkButton2.Visible = true; //user login button
                    LinkButton3.Visible = true; //user sign up button

                    LinkButton4.Visible = false;  //log out button
                    LinkButton5.Visible = false; //hello user button

                    LinkButton6.Visible = true; //admin login button
                    LinkButton7.Visible = false; //author management button
                    LinkButton8.Visible = false; //publisher management button
                    LinkButton9.Visible = false; //book inventry button
                    LinkButton10.Visible = false; //book issuing button
                    LinkButton11.Visible = false; //member management button
                }
                else
                    if (Session["role"].Equals("user"))
                {

                    LinkButton2.Visible = false; //user login button
                    LinkButton3.Visible = false; //user sign up button

                    LinkButton4.Visible = true;  //log out button
                    LinkButton5.Visible = true; //hello user button
                    LinkButton5.Text = "Hello " + Session["fullname"].ToString();

                    LinkButton6.Visible = true; //admin login button
                    LinkButton7.Visible = false; //author management button
                    LinkButton8.Visible = false; //publisher management button
                    LinkButton9.Visible = false; //book inventry button
                    LinkButton10.Visible = false; //book issuing button
                    LinkButton11.Visible = false; //member management button    
                }
                else
                    if (Session["role"].Equals("admin"))
                {

                    LinkButton2.Visible = false; //user login button
                    LinkButton3.Visible = false; //user sign up button

                    LinkButton4.Visible = true;  //log out button
                    LinkButton5.Visible = true; //hello user button
                    LinkButton5.Text = "Hello Admin";

                    LinkButton6.Visible = false; //admin login button
                    LinkButton7.Visible = true; //author management button
                    LinkButton8.Visible = true; //publisher management button
                    LinkButton9.Visible = true; //book inventry button
                    LinkButton10.Visible = true; //book issuing button
                    LinkButton11.Visible = true; //member management button    
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventry.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        //Log out button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton2.Visible = true; //user login button
            LinkButton3.Visible = true; //user sign up button

            LinkButton4.Visible = false;  //log out button
            LinkButton5.Visible = false; //hello user button

            LinkButton6.Visible = true; //admin login button
            LinkButton7.Visible = false; //author management button
            LinkButton8.Visible = false; //publisher management button
            LinkButton9.Visible = false; //book inventry button
            LinkButton10.Visible = false; //book issuing button
            LinkButton11.Visible = false; //member management button
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}