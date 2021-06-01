<%@ Page Title="" Language="C#" MasterPageFile="~/Hired_dotnet.Master" AutoEventWireup="true" CodeBehind="adminmain.aspx.cs" Inherits="Hired_dotnet.adminmain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 mx-auto">
 
                <div class="card">
                    <div class="card-body">
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Admin Profile</h4>
                                    </center>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="imgs/admin.png" />
                                       
                                    </center>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col-md-6">
                                <label>Admin ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Admin ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
 
                            <div class="col-md-6">
                                <label>Admin Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Admin Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date of Birth" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Admin Email</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Admin Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Old Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Old Password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="New Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col-12">
                                <asp:Button ID="Button1" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
 
                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>
        </div>
    </div>

    <!-- Footer -->
        <footer>
            <div id="footer3" class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                        <p>
                            <asp:LinkButton class="footerlinks" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Admin Profile</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Remove Users</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Delete Jobs</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Delete Job Applications</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">Job Information</asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
        </footer>
    <!-- ./Footer -->


</asp:Content>
