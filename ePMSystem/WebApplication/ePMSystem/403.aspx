<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="403.aspx.cs" Inherits="WebApplication1._403" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="row">
            <div class="container h-p100">
                <div class="row h-p100 align-items-center justify-content-center text-center">
                    <div class="col-lg-7 col-md-10 col-12">
                        <div class="b-double border-gray rounded">
                            <%--<h1 class="text-white font-size-180 font-weight-bold error-page-title"><i class="fa fa-gear fa-spin"></i></h1>--%>
                            <h1 class="text-white font-size-180 font-weight-bold error-page-title"> 403</h1>
                            <h3>Forbiddon Error!</h3>
                            <h3>looks like, page doesn't exist</h3>
                            <h4 class="mb-25">Please check back later.</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
