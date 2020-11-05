<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="ELibraryManagementSystem.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //by default asp.net grid have not thead element in table and datatable work on thead so we have to add it manually through code of js then call datatable.
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                         </div>
                         <div class="row">
                                
                                <div class="col">
                                    <center>
                                        <img width="100px;" src="imgs/writer.png"/>
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
                            <div class="col-md-4">
                                <label>Author Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Author Id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Author Id" ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic" ValidationGroup="author"></asp:RequiredFieldValidator>
                                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Author Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Author Name" ControlToValidate="TextBox2" ForeColor="Red" Display="Dynamic" ValidationGroup="author"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div> 
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-block btn-success" runat="server" ValidationGroup="author" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" CssClass="btn btn-lg btn-block btn-warning" runat="server" ValidationGroup="author" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" CssClass="btn btn-lg btn-block btn-danger" runat="server" ValidationGroup="author" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>
                    </div>
                    </div>
                <a href="homepage.aspx"><< Back to Home</a><br /><br />
                </div>
                
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDbConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
