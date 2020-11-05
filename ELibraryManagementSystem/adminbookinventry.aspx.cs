using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagementSystem
{
    public partial class adminbookinventry : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["role"]))
            {
                Response.Redirect("homepage.aspx");
            }
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
                GridView1.DataBind();
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        //Go Button Click
        protected void Button_Click(object sender, EventArgs e)
        {
            getBookByID();
        }
        //add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkIfBookExist())
            {
                Response.Write("<script>Book Already Exists, Try some other Book Id</script>");

            }
            else
            {
                addNewBook();
            }

        }
        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }
        //Delete button Click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookById();
        }


        //user define function 

        void deleteBookById()
        {
            if (checkIfBookExist())
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
                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book Id');</script>");
            }
        }

        void updateBookByID()
        {
            if (checkIfBookExist())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox5.Text.Trim());
                    if(global_actual_stock == actual_stock )
                    {

                    }
                    else
                    {
                        if(actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual stock value cannot be less than the issued books.');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox5.Text = "" + current_stock;
                        }
                    }

                    //this is to fetch the multiple values from list box and save it in the string.
                    string genres = "";
                    foreach(int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    //this code is to check whether the new image link is added or if it was empty then the old link of the image
                    // be save.
                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name,genre=@genre,author_name=@author_name," +
                        "publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost," +
                        "no_of_pages=@no_of_pages,book_description=@book_description,actual_stock=@actual_stock,current_stock=@current_stock," +
                        "book_img_link=@book_img_link WHERE book_id='"+TextBox3.Text.Trim()+"'", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name",TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre",genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock",actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock",current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link",filepath);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book updated Successfully.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book Id')</script>");
            }
        }

        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='"+TextBox3.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>=1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue= dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    TextBox1.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    //issued books we have to minus the actual stock from current stock then we get the issued books
                    TextBox7.Text = ""+(Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString())- Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    TextBox6.Text = dt.Rows[0]["book_description"].ToString();

                    //It is when we have change the book id new record is fetch then we have to remove all the previous selection we have made in listbox.
                    ListBox1.ClearSelection();

                    // To seprate the value of genre by comma seprated.
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    // we have to make nested loop to make match the items in database from the list box.The items in
                    // listbox which are match we have to select them.
                    for(int i=0;i<genre.Length;i++)
                    {
                        for(int j=0;j<ListBox1.Items.Count;j++)
                        {
                            if(ListBox1.Items[j].ToString()==genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath=dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                /* It is the name of column of table which values you want to show in dropdown cause one colun values will
                show in dropdown list. */
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                //For publisher dropdown list
                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();


            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
            }
        void addNewBook()
        {
            string genres = "";
            //to iterate through the list box we have to use foreach loop becaue multiple items may be selected in list box.
            foreach(int i in ListBox1.GetSelectedIndices())
            {
                genres = genres + ListBox1.Items[i] + ",";
            }
            //genres=Adventure,Self Help,
            //to remove the last comma from the string we use built in function.
            genres = genres.Remove(genres.Length-1);


            //File upload code
            string filepath = "~/book_inventory/books1.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("book_inventory/"+filename));
            filepath = "~/book_inventory/" + filename;

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id,book_name,genre,author_name,publisher_name," +
                    "publish_date,language," +
                    "edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) VALUES(" +
                    "@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language," +
                    "@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value );
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Added Successfully');</alert>");
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        //user define function 
        bool checkIfBookExist()
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
                SqlCommand cmd = new SqlCommand("Select * from book_master_tbl where book_id='" + TextBox3.Text.Trim() + "' OR book_name=" +
                    "'"+TextBox2.Text.Trim()+"';", con);
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

    }
}