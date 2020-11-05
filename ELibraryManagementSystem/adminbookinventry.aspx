<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventry.aspx.cs" Inherits="ELibraryManagementSystem.adminbookinventry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //To make the table more efficent by using datatable library.
        $(document).ready(function () {
            //by default asp.net grid have not thead element in table and datatable work on thead so we have to add it manually through code of js then call datatable.
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        // To get the preview of image uploaded by the user
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                        <img id="imgview" height="150px" width="100px;" src="imgs/books.png"/>
                                    </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col mb-1">
                                <center>
                                    <asp:FileUpload ID="FileUpload1" onchange="readURL(this);" class="form-control" runat="server"></asp:FileUpload>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Book Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Book Id"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Publisher Id" ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                        <asp:Button CssClass="form-control btn btn-primary" ID="Button" runat="server" Text="GO" OnClick="Button_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Book Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Publisher Id" ControlToValidate="TextBox2" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="Urdu" Value="Urdu"></asp:ListItem>
                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="French" Value="French"></asp:ListItem>
                                        <asp:ListItem Text="Arabic" Value="Arabic"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Publisher Id" InitialValue="Select" ControlToValidate="DropDownList1" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server"> 
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1"></asp:ListItem>
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>

                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                                        <asp:ListItem Text="A2" Value="A2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="Date" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Publish Date" ControlToValidate="TextBox1" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple">
                                        <asp:ListItem Text="Adventure" Value="Adventure"></asp:ListItem>
                                        <asp:ListItem Text="Comic Book" Value="Comic Book"></asp:ListItem>
                                        <asp:ListItem Text="Self Help" Value="Self Help"></asp:ListItem>
                                        <asp:ListItem Text="Motivation" Value="Motivation"></asp:ListItem>
                                        <asp:ListItem Text="Healthy Living" Value="Healthy Living"></asp:ListItem>
                                        <asp:ListItem Text="Wellness" Value="Wellness"></asp:ListItem>
                                        <asp:ListItem Text="Crime" Value="Crime"></asp:ListItem>
                                        <asp:ListItem Text="Drama" Value="Drama"></asp:ListItem>
                                        <asp:ListItem Text="Fantasy" Value="Fantasy"></asp:ListItem>
                                        <asp:ListItem Text="Horror" Value="Horror"></asp:ListItem>
                                        <asp:ListItem Text="Poetry" Value="Poetry"></asp:ListItem>
                                    </asp:ListBox>  
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="1st"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Edition" ControlToValidate="TextBox9" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Book Cost(per unit)" TextMode="Number" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Book Cost" ControlToValidate="TextBox10" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Book pages" ControlToValidate="TextBox11" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Actual Stock" ControlToValidate="TextBox4" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Book Cost(per unit)" TextMode="Number" ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Pages" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Book Description" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Book Description" ControlToValidate="TextBox6" ForeColor="Red" Display="Dynamic" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button1" CssClass="btn btn-lg btn-block btn-success" runat="server" ValidationGroup="book" Text="Add" OnClick="Button1_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" CssClass="btn btn-lg btn-block btn-warning" runat="server" ValidationGroup="book" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-block btn-danger" runat="server" ValidationGroup="book" Text="Delete" OnClick="Button2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventry List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDbConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <%-- To Make Custom Grid View Design we have to remove all the columns
                                            instead of book id. Then we have to click on edit columns option from 
                                            the design view. then we have to select item template and add it. 
                                            Then we have to right click on grid view and click on edit template then
                                            from the list we have to choose itemtemplate and add it.--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Author-<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language-
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Publihser-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages-
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition-
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Cost-
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock-&nbsp;
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available Stock-
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description-
                                                                    <asp:Label ID="Label11" runat="server" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <%-- We have to select the image icon in itemtemplate and then bind the data and select the coloumn of book_image_link
                                                                then this code will genrated automatically. We have to add the class of img-fluid to make it responsive. --%>
                                                            <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
