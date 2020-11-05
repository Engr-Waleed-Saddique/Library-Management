<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="ELibraryManagementSystem.adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //To make the table more efficent by using datatable library.
        $(document).ready(function () {
            //by default asp.net grid have not thead element in table and datatable work on thead so we have to add it manually through code of js then call datatable.
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
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
                                    <h4>Book Issuing</h4>
                                </center>
                            </div>
                         </div>
                         <div class="row">
                                
                                <div class="col">
                                    <center>
                                        <img width="100px;" src="imgs/books.png"/>
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
                            <div class="col-md-6">
                                <label>Book Id</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Book Id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Book ID" ControlToValidate="TextBox2" ForeColor="Red" Display="Dynamic" ValidationGroup="book_issue"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Member Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Id"></asp:TextBox>
                                        <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Member ID" ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic" ValidationGroup="book_issue"></asp:RequiredFieldValidator>
                                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member Name" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Issue Date" ControlToValidate="TextBox5" ForeColor="Red" Display="Dynamic" ValidationGroup="book_issue"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Due Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Due Date" ControlToValidate="TextBox6" ForeColor="Red" Display="Dynamic" ValidationGroup="book_issue"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-block btn-primary" runat="server" ValidationGroup="book_issue" Text="Issue" OnClick="Button2_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="Button4" CssClass="btn btn-lg btn-block btn-success" runat="server" ValidationGroup="book_issue" Text="Return" OnClick="Button4_Click" />
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
                                    <h4>Issued Book List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:elibraryDbConnectionString %>' SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member Id" SortExpression="member_id"></asp:BoundField>
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name"></asp:BoundField>
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id"></asp:BoundField>
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name"></asp:BoundField>
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date"></asp:BoundField>
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div>
                        </div>
                    </div>
                </div>
                
            </div>

        </div>
    </div>

</asp:Content>
