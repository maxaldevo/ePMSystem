<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddNewProduct.aspx.cs" Inherits="WebApplication1.AddNewProduct" %>

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
                                <h3 style="text-align: center; font-size: larger; margin-top: 10px;">Admin | Add New Product</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Product Name:</span>
                            <asp:TextBox ID="txtPName" CssClass="form-control" runat="server" placeholder="Product Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtPName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Quantity:</span>
                            <asp:TextBox ID="txtqty" CssClass="form-control" runat="server" placeholder="Quantity"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtqty"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Cost Price:</span>
                            <asp:TextBox ID="txtCPrice" CssClass="form-control" runat="server" placeholder="Cost Price"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtCPrice"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Profit Price:</span>
                            <asp:TextBox ID="txtProfitPrice" CssClass="form-control" runat="server" placeholder="Profit Price"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtProfitPrice"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Sale Price:</span>
                            <asp:TextBox ID="txtSalePrice" runat="server" CssClass="form-control" placeholder="Sale Price"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtSalePrice"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Hospitals :</span>
                            <asp:DropDownList ID="DropDownHospitals" OnSelectedIndexChanged="DropDownHospitals_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                            <span style="font-weight:bold">Clinic :</span>
                            <asp:DropDownList ID="DropDownClinics" AutoPostBack="true" OnSelectedIndexChanged="DropDownClinics_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                
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
                <asp:AsyncPostBackTrigger ControlID="DropDownHospitals" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="DropDownClinics" EventName="SelectedIndexChanged" />

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
            BinddropdownHospitals();
            BinddropdownHRClinics();

            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable); // bind data table on every UpdatePanel refresh
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fixDropWidth);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownHospitals);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownHRClinics);

        });
        function BinddropdownHospitals() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownHospitals.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };
        function BinddropdownHRClinics() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownClinics.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };
        <%--function bindDataTable() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=gvProducts.ClientID%>').dataTable({
                    dom: 'Blfrtip',
                    "bInfo": true,
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ],
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
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