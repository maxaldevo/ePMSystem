<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/HRMasterPage.Master" AutoEventWireup="true" CodeBehind="RegistNewUser.aspx.cs" Inherits="WebApplication1.RegistNewUser" %>

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
            ClientIDMode="Predictable" ViewStateMode="Inherit" DisplayAfter="1">
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
                    <div class="col-12 col-md-12">

                        <div class="progress" style='height: 30px; margin-top: -10px;'>
                            <div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
                                <h3 style="text-align: center; font-size: larger; margin-top: 10px; font-weight:bold;">Add New Clinic</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">File No.:</span>
                            <asp:TextBox ID="txtClinicName" CssClass="form-control" runat="server" placeholder="File No."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Employee ID:</span>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Employee ID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                            <%--<asp:DropDownList ID="DropDownHospitals" OnSelectedIndexChanged="DropDownHospitals_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>--%>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Full Name(ENGLISH):</span>
                            <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Full Name(ARABIC):</span>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Passport No.:</span>
                            <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Passport No."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Passport Expired date:</span>
                            <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="Passport Expired date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                            <%--<asp:DropDownList ID="DropDownHospitals" OnSelectedIndexChanged="DropDownHospitals_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>--%>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">STATUS:</span>
                            <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" placeholder="STATUS "></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Joined date:</span>
                            <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" placeholder="Joined date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Notice:</span>
                            <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" placeholder="Notice"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtClinicName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <br />
                <br />
                <div class="row">
                    <div class="col-md-2">

                        <asp:Button ID="btnShowData" runat="server" Text="Save Data" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblResult" runat="server" Text="" Visible="true"></asp:Label>
                    </div>
                </div>
                <br />
            </ContentTemplate>
            <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="DropDownHospitals" EventName="SelectedIndexChanged" />--%>

                <asp:AsyncPostBackTrigger ControlID="btnShowData" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </section>

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>
    <link href="css/select2.css" rel="stylesheet" />
    <script>

        $(function () {

            fixDropWidth();
            /*BinddropdownHospitals();*/
            //BinddropdownHRRoles();
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fixDropWidth);
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownHospitals);
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownHRRoles);

        });
        <%--function BinddropdownHospitals() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownHospitals.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };--%>
 
        function fixDropWidth() {
            $("select").width("100%");
        };
    </script>
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
