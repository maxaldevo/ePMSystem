<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="WebApplication1.AccountSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        .table-striped tbody tr:nth-of-type(odd) {
            background-color: dodgerblue;
            color: white;
        }

        .table-striped tbody tr:nth-of-type(even) {
            border: 1px solid lightblue;
            background-color: #e6e9ee;
        }

        .table {
            justify-content: center;
            align-items: center;
        }

            .table tr {
                text-align: center;
                justify-content: center;
                align-items: center;
            }

            .table thead {
                text-align: center;
                justify-content: center;
                align-items: center;
            }

            .table tr td {
                text-align: center;
            }

        #circle {
            position: absolute;
            top: 40%;
            left: 55%;
            transform: translate(-50%,-50%);
            width: 150px;
            height: 150px;
        }

        .loader {
            position: fixed;
            width: calc(100% - 0px);
            height: calc(100% - 0px);
            border: 8px solid #162534;
            border-top: 8px solid #09f;
            border-radius: 50%;
            animation: rotate 5s linear infinite;
            z-index: 999999;
        }

        @keyframes rotate {
            100% {
                transform: rotate(360deg);
            }
        }

        #circle {
            position: absolute;
            top: 40%;
            left: 55%;
            transform: translate(-50%,-50%);
            width: 150px;
            height: 150px;
            z-index: 9999;
        }

        .loader {
            width: calc(100% - 0px);
            height: calc(100% - 0px);
            border: 8px solid #162534;
            border-top: 8px solid #09f;
            border-radius: 50%;
            animation: rotate 5s linear infinite;
        }

        @keyframes rotate {
            100% {
                transform: rotate(360deg);
            }
        }

        .row {
            margin-top: -10px;
        }

        select:focus {
            width: auto;
            position: relative;
        }
    </style>
    <section class="content">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
            ClientIDMode="Predictable" ViewStateMode="Inherit" >
            <ProgressTemplate>
                <div id="circle">
                    <div class="loader">
                        <div class="loader">
                            <div class="loader">
                                <div class="loader">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-3 col-12">
                        <div class="card " style="width: 14rem;">
                            <asp:Image ID="image1" runat="server" class="card-img-top img-responsive" alt="user pic" />
                        </div>
                    </div>
                    <div class="col-md-9 col-12">
                        <div class="box box-solid bg-info">
                            <div class="box-header">
                                <h4 class="box-title"><strong>Account Details</strong></h4>
                            </div>

                            <div class="box-body">
                                <p>
                                    <strong>Name : </strong>
                                    <asp:Label ID="lblFName" Font-Bold="true" runat="server" Text=""></asp:Label>
                                </p>
                                <hr />
                                <p>
                                    <strong>Civil ID : </strong>
                                    <asp:Label ID="lblCivilID" Font-Bold="true" runat="server" Text=""></asp:Label>
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
                </div>
                <div class="row">
                    <div class="col-lg-12 d-flex justify-content-center text-center">
                        <div class="box">
                            <div class="box-body ribbon-box">
                                <div class="ribbon ribbon-dark">Manage Photo</div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-3 text-center">
                                    </div>
                                    <div class="col-lg-3 text-center">
                                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-rounded btn-info mb-5" runat="server">
                        <i class="fa fa-download" ></i>
                       Download Image
                                        </asp:LinkButton>
                                    </div>
                                    <div class="col-lg-3 text-center">
                                        <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" CssClass="btn btn-rounded btn-info mb-5" runat="server">
                        <i class="fa fa-upload" ></i>
                       Change Image
                                        </asp:LinkButton>
                                    </div>
                                    <div class="col-lg-3 text-center">
                                    </div>
                                </div>
                                <br />
                                <div class="row d-flex justify-content-center text-center" id="UploadDiv" runat="server" visible="false">
                                        <asp:FileUpload ID="FileUpload1" accept="image/*" runat="server" />
                                            <asp:RequiredFieldValidator ErrorMessage="Please choose an image" ControlToValidate="FileUpload1" ValidationGroup="A"
                                                runat="server" Display="Dynamic" ForeColor="Red" />
                                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Only picture files are allowed!" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.gif|.GIF|.jpg|.JPG|.jpeg|.JPEG)$" ControlToValidate="FileUpload1" Display="None"></asp:RegularExpressionValidator>
                               <asp:LinkButton ID="linbuttonUpload" OnClick="linbuttonUpload_Click" ValidationGroup="A" CssClass="btn btn-rounded btn-primary mb-5" runat="server">
                        <i class="fa fa-upload" ></i>
                     Save Image
                      </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12 d-flex justify-content-center text-center">
                        <div class="box">
                            <div class="box-body ribbon-box">
                                <div class="ribbon ribbon-primary">Manage Password</div>

                                <asp:LinkButton ID="linkChangePassword" OnClick="linkChangePassword_Click"  CssClass="btn btn-rounded btn-info mb-5" runat="server" ValidationGroup="A" >
                        <i class="fa fa-unlock-alt" ></i>
                     Change Password
                                </asp:LinkButton>
                                <br />
                                <br />
                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <div class="row d-flex justify-content-center text-center">

                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredPassword" ErrorMessage="*" ControlToValidate="txtPassword" ValidationGroup="B"
                                                runat="server" Display="Dynamic" ForeColor="Red" />
                                            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPassword" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{6,}$" runat="server" ErrorMessage="Minimum 6 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txtPasswordconfirm" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredPassConfirm" ErrorMessage="*" ControlToValidate="txtPasswordconfirm" ValidationGroup="B"
                                                runat="server" Display="Dynamic" ForeColor="Red" />
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                         ControlToValidate="txtPasswordconfirm"
                                         CssClass="ValidationError" ValidationGroup="B"
                                         ControlToCompare="txtPassword"
                                         ErrorMessage="Passwords has to match" 
                                         ToolTip="Password must be the same"   Display="Dynamic" ForeColor="Red"/>
                                        </div>
                                   
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" CssClass="btn btn-rounded btn-success mb-5" ValidationGroup="B"/>
                                    </div>
                                            <div class="col-lg-2">
                                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-rounded btn-info mb-5" runat="server" Text="Cancel" />
                                    </div>
                                         </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
            </ContentTemplate>
            <Triggers>
                    <asp:PostBackTrigger ControlID="linbuttonUpload" />
                <asp:PostBackTrigger ControlID="LinkButton1" />
                <asp:PostBackTrigger ControlID="LinkButton2"  />
               <%-- <asp:PostBackTrigger ControlID="FileUpload1" />--%>
                <asp:AsyncPostBackTrigger ControlID="linkChangePassword" EventName="Click"  />
                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </section>
      <script src="Scripts/jquery-3.3.1.js"></script>
        <link media="screen" rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <script type="text/javascript">
        function showpopwarning(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "preventDuplicates": true,
                "preventOpenDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "2000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.warning(msg, title);
            return false;
        }
    </script>
    <script type="text/javascript">
        function showpopsuccess(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": true,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "2000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.success(msg, title);
            return false;
        }
    </script>
    <script type="text/javascript">
        function showpoperror(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "2000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.error(msg, title);
            return false;
        }
    </script>
</asp:Content>