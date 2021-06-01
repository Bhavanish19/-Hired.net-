<%@ Page Title="" Language="C#" MasterPageFile="~/Hired_dotnet.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="Hired_dotnet.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150px" src="imgs/adminuser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Admin Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Admin ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Admin ID"></asp:TextBox>
                        </div>
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>
    </div>
    
    <!-- Footer -->
        <footer>
            <div id="footer3" class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                        <p>
                            <asp:LinkButton class="footerlinks" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">User Login</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Company Login</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Admin Login</asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
        </footer>
    <!-- ./Footer -->
</asp:Content>
