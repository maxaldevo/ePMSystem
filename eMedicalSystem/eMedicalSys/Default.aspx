<%@ Page  Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ePMSystem.Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	    <style>
    
        * {
            font-family: 'Foco', sans-serif;
        }

        h4 {
            text-align:center;color:#2d5e7e;font-weight:bold;
        }
              h4 a{
            text-align:center;color:#2d5e7e;font-weight:bold;
        }
    </style>
    <link rel="shortcut icon" href="/favicon.ico" type="image/x-icon">
    <link rel="icon" href="/favicon.ico" type="image/x-icon">
    <section class="content">
        <div class="row">
            <div class="col-12">
                <div class="box">
                    <div class="box-body">
                        <h5 style="margin-left:20px;">Welcome ,
                            <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                        </h5>
                        <div class="row" style="margin-top:30px;">
                               <div class="col-md-1"></div>

                            <div class="col-md-2">
                                <div class="card">
                                   Welcome
                                </div>
                            </div>


                             <!-- Training -->
                            <%--<div class="col-md-2">
                                <div class="card">
                                   <asp:ImageButton CssClass="card-img-top" OnClick="ImageButtonTaining_Click"  class="card-img-top" src="images/Training-300x250.jpg" alt="Training" runat="server" ID="ImageButtonTaining" />
                                </div>
                            </div>--%>
                     
                               <!-- OJT -->
                                 <%--<div class="col-md-2">
                                <div class="card">
                                   <asp:ImageButton  CssClass="card-img-top" OnClick="ImageButtonOJT_Click"  class="card-img-top" src="images/OJT-300x250.jpg" alt="OJT" runat="server" ID="ImageButtonOJT" />
                                </div>
                            </div>--%>
                                             <!-- OTS -->
                         <%--<div class="col-md-2">
                                <div class="card">
                                   <asp:ImageButton CssClass="card-img-top" OnClick="ImageButtonOTS_Click"  class="card-img-top" src="images/OTS-300x250.jpg" alt="OTS" runat="server" ID="ImageButtonOTS" />
                                </div>
                            </div>--%>
                             <!-- E-Learning -->
                               <%--<div class="col-md-2">
                                <div class="card">
                                    <asp:ImageButton OnClick="ImageButtonELearning_Click" CssClass="card-img-top" src="images/S-E-Learning-300x250.jpg" runat="server" ID="ImageButtonELearning" />
                                </div>
                            </div>--%>
                            <!-- /.col -->
                            <!-- Assessment -->
                                <%--<div class="col-md-2">
                                <div class="card">
                                    <asp:ImageButton ID="ImageButtonAssessment2" OnClick="ImageButtonAssessment2_Click" runat="server" CssClass="card-img-top"  src="images/Assessment-300x250.jpg" />
                                </div>
                            </div>--%>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-1"></div>
                               <!--Feedback -->
                          <%--<div class="col-md-2">
                                <div class="card">
                                    <asp:ImageButton CssClass="card-img-top" OnClick="linkFeedback_Click" class="card-img-top" src="images/Feedback-300x250.jpg" alt="Feedback" runat="server" ID="linkFeedback" />
                                </div>
                            </div>--%>
                      
                            <!--Reports -->
                          <%--<div class="col-md-2">
                                <div class="card">
                                    <asp:ImageButton CssClass="card-img-top"  src="images/Report-300x250.jpg"  alt="Reports" runat="server" ID="ImageButtonReport"  />
                                </div>
                            </div>--%>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
