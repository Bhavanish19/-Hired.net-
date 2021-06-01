<%@ Page Title="" Language="C#" MasterPageFile="~/Hired_dotnet.Master" AutoEventWireup="true" CodeBehind="companyappliedcands.aspx.cs" Inherits="Hired_dotnet.companyappliedcands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                           <h4>Candidate Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/books.png" />
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
                        <label>Job ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Job ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                      <div class="col-md-6">
                        <label>Candidate ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Candidate ID"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                        <div class="col-12">     
                            <asp:Button ID="Button1" class="btn btn-lg btn-block btn-primary" runat="server" Text="Go" />
                        </div>
                  </div>
                   <br />
                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Date of Birth" TextMode="Date" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Contact No" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email ID" TextMode="Email" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox17" runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pincode</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="Pincode" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <center>
                           <span class="badge badge-pill badge-info">Qualification Details</span>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                         <label>Status</label>
                         <div class="form-group">
                            <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="Status" ReadOnly="True"></asp:TextBox>
                          </div>
                     </div>
                     <div class="col-md-6">
                        <label>Highest Qualification</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Highest Qualfication" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Skills</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Skills" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Achievements</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Achievements" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-12">
                        <label>Projects</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Projects" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                         <label>Age</label>
                         <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox15" runat="server" placeholder="Age" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Experience</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox16" runat="server" placeholder="Experience" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <br />
                  <div class="row">
                        <div class="col-12">     
                            <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Download Resume" />
                        </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>All Applied Candidates</h4>
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
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
    
    <!-- Footer -->
        <footer>
            <div id="footer3" class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                        <p>
                            <asp:LinkButton class="footerlinks" ID="LinkButton1" runat="server">Company Profile</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton2" runat="server">Candidates Applied</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton3" runat="server">Post Jobs</asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
        </footer>
    <!-- ./Footer -->
</asp:Content>
