<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication1.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .box-header {
        padding:10px;       

        }
           .row {
            margin-top: -15px;
        }
    </style>
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">

    <section class="content">

        <div class="row d-flex justify-content-center">

            <div class="card " style="width: 15rem;">
                <asp:Image ID="image1" runat="server" class="card-img-top img-responsive" alt="user pic" />
            </div>
        </div>
        <div class="row">
            <%--<div class="col-md-4">
                <div class="box box-solid bg-info">
                    <div class="box-header">
                        <h4 class="box-title"><strong>Professional Details</strong></h4>
                    </div>

                    <div class="box-body">
                        <p>
                            <strong>Position : </strong>
                            <asp:Label ID="lblTitle" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                        <p>
                            <strong>Group | Area | Section : </strong>
                            <asp:Label ID="lblGroup" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                        <p>
                            <strong>Experience : </strong>
                            <asp:Label ID="lblExperience" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                             <p>
                            <strong>Emp No : </strong>
                            <asp:Label ID="lblempNo" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                              
                             <p>
                            <strong>Joining Date : </strong>
                            <asp:Label ID="lblJoiningDate" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                      <hr />
                                     <p>
                            <strong>Education : </strong>
                            <asp:Label ID="Label1" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                      <hr />
                    </div>
                </div>
            </div>--%>
            <div class="col-md-4 col-12">

                <div class="box box-solid bg-success">
                    <div class="box-header">
                        <h4 class="box-title"><strong>Personal Details</strong></h4>
                    </div>

                    <div class="box-body">
                        <p>
                            <strong>Name : </strong>
                            <asp:Label ID="lblFName" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                        <p>
                            <strong>Civil No. : </strong>
                            <asp:Label ID="lblCivilId" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                        <p>
                            <strong>Email : </strong>
                            <asp:Label ID="lblEmail" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                        <p>
                            <strong>Mobile : </strong>
                            <asp:Label ID="lblMobile" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                    </div>
                </div>
            </div>
            

            <div class="col-md-4 col-12">
                <div class="box box-solid bg-primary">
                    <div class="box-header">
                        <h4 class="box-title"><strong>Contact Details</strong></h4>
                    </div>

                    <div class="box-body">
                        <p>
                            <strong>Address : </strong>
                            <asp:Label ID="lblAddressDetails" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                        <p>
                            <strong>Pin code : </strong>
                            <asp:Label ID="lblPinCode" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />

                        <p>
                            <strong>Phone No. : </strong>
                            <asp:Label ID="lblPhoneNo" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>