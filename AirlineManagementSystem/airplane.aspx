<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="airplane.aspx.cs" Inherits="AirlineManagementSystem.airplane" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">>
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                               <h4>Airline Management</h4>
                           </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                              <img width="120px" src="imgs/airlinemanage.png" />         
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
                                <center>
                           <h4>Edit Panel</h4>
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
                                <label>Airline Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Id"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Airline Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Class Type</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="0">--Select Class--</asp:ListItem>
                                        <asp:ListItem Text="Economy" Value="Economy" />
                                        <asp:ListItem Text="First" Value="First" />
                                        <asp:ListItem Text="Business" Value="Business" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Capacity</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Economy/First/Bussiness"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Price</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Rs." TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="row">
                            <div class="col-3 mx-auto ">
                                <asp:Button ID="Button3" class="btn btn-outline-success" runat="server" Text="Add" OnClick="Button3_Click"/>
                            </div>
                            <div class="col-3 mx-auto">
                                <asp:Button ID="Button4" class="btn btn-outline-warning" runat="server" Text="Update" OnClick="Button4_Click"/>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="col-md-7 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Airline Details</h4>
                                 </center>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>
                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AirlineManagement_V2ConnectionString %>" SelectCommand="SELECT A.id AS Airplane, cp.class AS Class, cp.capacity AS Capacity, cp.price FROM classprice AS cp INNER JOIN airplane AS A ON A.id = cp.a_id ORDER BY Airplane"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="Airplane" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="Airplane" HeaderText="Airplane" ReadOnly="True" SortExpression="Airplane" />
                                    <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
                                    <asp:BoundField DataField="Capacity" HeaderText="Capacity" SortExpression="Capacity" />
                                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <a href="adminrole.aspx"><< Back to manage</a><br>
        <br>
    </div>
</asp:Content>
