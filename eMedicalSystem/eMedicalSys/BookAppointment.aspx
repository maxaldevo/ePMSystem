<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="WebApplication1.BookAppointment" %>

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
    <style>
        .table-striped tbody tr:nth-of-type(odd) {
            background-color: #23B3E8;
            color: white;
        }

        .table-striped tbody tr:nth-of-type(even) {
            border: 1px solid lightblue;
        }

        table thead tr {
            background-color: #23B3E8;
            color: white;
            font-weight: bold;
        }

        table {
            text-align: center;
        }

        .row {
            margin-top: -15px;
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
                                <h3 style="text-align: center; font-size: larger; margin-top: 10px; font-weight:bold;">Add New Booking Time</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Date:</span>
                            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                            <asp:TextBox ID="txt_date" CssClass="form-control" runat="server" placeholder="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_date"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">No of Days:</span>
                            <asp:TextBox ID="txtDaysNumber" CssClass="form-control" runat="server" placeholder="No of Days"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtDaysNumber"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Services :</span>
                            <asp:DropDownList ID="DropDownService" OnSelectedIndexChanged="DropDownService_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Button ID="btnShowData" OnClick="btnShowData_Click" runat="server" Text="Save Data" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblResult" runat="server" Text="" Visible="true"></asp:Label>
                    </div>
                </div>
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownService" EventName="SelectedIndexChanged" />

                <asp:AsyncPostBackTrigger ControlID="btnShowData" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <!--Products list belongs only this user's clinic-->
        <br />
        
    </section>

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>
    <link href="css/select2.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    


    <script>
        
        $(function () {

            //bindDataTable(); // bind data table on first page load
            fixDropWidth();
            BinddropdownService();

            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable); // bind data table on every UpdatePanel refresh
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fixDropWidth);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownService);

        });
        function BinddropdownService() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownService.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };
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