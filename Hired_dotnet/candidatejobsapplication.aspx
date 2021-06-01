<%@ Page Title="" Language="C#" MasterPageFile="~/Hired_dotnet.Master" AutoEventWireup="true" CodeBehind="candidatejobsapplication.aspx.cs" Inherits="Hired_dotnet.candidatejobsapplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
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
                           <h4>Apply For the Job</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/user.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="col">
                        <center>
                           <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Company Details"></asp:Label>
                        </center>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Candidate ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Candidate ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Job ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Job ID"></asp:TextBox>
                              <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Job Title</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Job Title" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Company Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Company Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Website</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Website" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Email" TextMode="Email" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                         <label>Status</label>
                         <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="Status" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Sector</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Sector" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Nominal Capital</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Nominal Capital" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="col">
                        <center>
                           <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="Job Details"></asp:Label>
                        </center>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                         <label>Job Type</label>
                         <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox12" runat="server" placeholder="Job Type" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Experience Required</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox13" runat="server" placeholder="Experience Required" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Age Crieteria</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox14" runat="server" placeholder="Age Criteria" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Skills</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Skills" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeholder="Description" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                         <label>Post</label>
                         <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox17" runat="server" placeholder="Post" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Salary</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox18" runat="server" placeholder="Salary" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Duration</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox19" runat="server" placeholder="Duration" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="col">
                        <center>
                           <asp:Label class="badge badge-pill badge-info" ID="Label3" runat="server" Text="Your Requirment"></asp:Label>
                        </center>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Skills</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox20" runat="server" placeholder="Skills" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Achievements</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox21" runat="server" placeholder="Achievements" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-12">
                        <label>Projects</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox22" runat="server" placeholder="Projects" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                         <label>Age</label>
                         <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox23" runat="server" placeholder="Age"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Experience</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox24" runat="server" placeholder="Experience"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Image Upload - Any Format(Limit 10MB)</label>
                        <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                     <div class="col-md-6">
                        <label>Resume Upload - Pdf Format(Limit 50MB)</label>
                        <asp:FileUpload class="form-control" ID="FileUpload2" runat="server" />
                     </div>
                  </div>
                  <br />
                  <div class="row">
                        <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Post" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update"/>
                     </div>
                      <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" />
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
                           <h4>Your Applications</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">
                       <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
                       <div class="col">
                           <asp:GridView ID="GridView2" class="table table-striped table-bordered" runat="server"></asp:GridView>
                       </div>
                   </div>

                   <br />
                   <br />
                   <br />
                   <br />
                   
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>Jobs Available</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ssds_hnConnectionString %>"  SelectCommand="SELECT * FROM [job_tbl]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="job_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="job_id" HeaderText="job_id" ReadOnly="True" SortExpression="job_id" />
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("job_title") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Company ID - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("company_id") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Company Name - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("company_name") %>'></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Description -
                                                   <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("description") %>'></asp:Label>
                                                </div>
                                             </div>
                                              <div class="row">
                                                <div class="col-12">
                                                   Skills Required -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("skills_req") %>'></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Job Type -
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("job_type") %>'></asp:Label>
                                                   &nbsp;| Experience Required -
                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("experience_req") %>'></asp:Label> months
                                                   &nbsp;| Age Criteria -
                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("age_criteria") %>'></asp:Label> Years
                                                </div>
                                             </div>
                                              <div class="row">
                                                <div class="col-12">
                                                   Job Post -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("job_post") %>'></asp:Label>
                                                   &nbsp;| Duration -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("duration") %>'></asp:Label> months
                                                   &nbsp;| Salary - $
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("salary") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">
                                              <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("company_img") %>' />
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

   
    <!-- Footer -->
        <footer>
            <div id="footer3" class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                        <p>
                            <asp:LinkButton class="footerlinks" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Candidate Profile</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Available Jobs</asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
        </footer>
    <!-- ./Footer -->
</asp:Content>
