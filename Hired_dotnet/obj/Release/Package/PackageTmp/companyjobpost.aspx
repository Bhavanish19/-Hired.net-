<%@ Page Title="" Language="C#" MasterPageFile="~/Hired_dotnet.Master" AutoEventWireup="true" CodeBehind="companyjobpost.aspx.cs" Inherits="Hired_dotnet.companyjobpost" %>
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
                           <h4>Post Job</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ssds_hnConnectionString %>" SelectCommand="SELECT [company_img] FROM [job_tbl] WHERE ([company_id] = @company_id)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="company_id" SessionField="[username]" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                                <Columns>
                                    
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image class="img-fluid" ID="Image2" runat="server" ImageUrl='<%# Eval("company_img") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Job ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Job ID"></asp:TextBox>
                              <asp:Button ID="Button1" class="form-control btn btn-primary" runat="server" Text="Go" OnClick="Button1_Click" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>Job Title</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Job Title"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Company Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Company Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Company ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Company ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                         <label>Job Type</label>
                         <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Select" Value="Select" />
                              <asp:ListItem Text="Full Time" Value="Full Time" />
                              <asp:ListItem Text="Part Time" Value="Part Time" />
                              <asp:ListItem Text="WFH" Value="WFH" />
                            </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Experience Required</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox13" runat="server" placeholder="Experience Required" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Age Crieteria</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox14" runat="server" placeholder="Age Criteria" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Skills Required</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Skills Required" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeholder="Description" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                         <label>Post</label>
                         <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox17" runat="server" placeholder="Post"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Salary</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox18" runat="server" placeholder="Salary" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Duration</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox19" runat="server" placeholder="Duration" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                      <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click"/>
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
                           <h4>My Jobs</h4>
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
                            <asp:LinkButton class="footerlinks" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Company Profile</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Candidates Applied</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton class="footerlinks" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Post Jobs</asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
        </footer>
    <!-- ./Footer -->
</asp:Content>
