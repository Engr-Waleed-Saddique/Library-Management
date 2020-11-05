<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="ELibraryManagementSystem.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <h4>Publishers Details</h4>
                                </center>
                            </div>
                         </div>
                         <div class="row">
                                
                                <div class="col">
                                    <center>
                                        <img width="100px;" src="imgs/publisher.png"/>
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
                                <label>Publisher Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Publisher Id" ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic" ValidationGroup="publisher"></asp:RequiredFieldValidator>
                                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Publisher Name" ControlToValidate="TextBox2" ForeColor="Red" Display="Dynamic" ValidationGroup="publisher"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div> 
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-block btn-success" runat="server" ValidationGroup="publisher" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" CssClass="btn btn-lg btn-block btn-warning" runat="server" ValidationGroup="publisher" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" CssClass="btn btn-lg btn-block btn-danger" runat="server" ValidationGroup="publisher" Text="Delete" OnClick="Button4_Click" />
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
                                    <h4>Publisher List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDbConnectionString2 %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
