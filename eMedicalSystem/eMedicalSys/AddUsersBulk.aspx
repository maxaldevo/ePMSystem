<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddUsersBulk.aspx.cs" Inherits="WebApplication1.AddUsersBulk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
        <div class="row" style="margin-top: -15px;">
            <div class="col-12 col-md-12">
                <div class="progress" style='height: 30px; margin-top: -10px;'>
                    <div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background: #23B3E8;" aria-valuemin="0" aria-valuemax="100">
                        <h3 style="text-align: center; font-size: larger; margin-top: 10px;">Add List of Users
                        </h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:LinkButton ID="linDownload" CssClass="btn btn-primary mb-5" runat="server" OnClick="linDownload_Click" Text="Download Template">Download Template  <i class="fa fa-download"></i></asp:LinkButton>
            </div>
            <div class="col-md-3">
                <asp:LinkButton ID="lnkReset" CssClass="btn btn-warning mb-5" runat="server" OnClick="lnkReset_Click" Text="Reset">Reset  <i class="fa fa-refresh"></i></asp:LinkButton>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:FileUpload ID="FileUploadLink" runat="server" CssClass="btn btn-info mb-5" type="file" accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ForeColor="Red" ValidationGroup="C" ControlToValidate="FileUploadLink" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <asp:Button ID="btnUpload" runat="server" Text="Upload & Preview" OnClick="btnUpload_Click" CssClass="btn btn-info mb-5" />
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblInvalid" Font-Size="Large" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>

            </div>
            <div class="col-md-2">
                <asp:Button ID="btnShowInvalidRecords" runat="server" Text="Show Invalid Records" OnClick="btnShowInvalidRecords_Click" CssClass="btn btn-warning mb-5" Visible="false" />
            </div>
        </div>
                     <br />
                                      <div class="row">
                                <div class="col-md-12">
                                    <asp:LinkButton ID="lnkImport" CssClass="btn btn-success mb-5" runat="server" Visible="false" OnClick="lnkImport_Click" Text="Save Data">Save Data  <i class="fa fa-save"></i></asp:LinkButton></div>
                            </div>
        <br />
                           
                            <div class="row">
                                <div class="col-md-12" style="margin: 10px;">
                                    <asp:Label ID="lblError" Font-Size="Large" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label></div>
                                </div>
                            <div class="row">
                              <div class="col-md-12">    <div class="table-responsive table-bordered">
                                                <asp:Repeater ID="RepeaterUploadedUsers" runat="server" OnItemDataBound="RepeaterUploadedRooms_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table id="table_2">
                                                            <thead>
                                                                <tr>
                                                                    <th></th>
                                                                    <th>Full Name</th>
                                                                    <th>First Name</th>
                                                                    <th>Last Name</th>
                                                                    <th>Email</th>
                                                                    <th>PhoneNo</th>
                                                                    <th>EmployeeNo</th>
                                                                    <th>Position</th>
                                                                    <th>Security Group</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr id="tdValue2" runat="server">
                                                            <td></td>
                                                            <td>
                                                                <%-- <asp:Label ID="lblRoomId" runat="server" Text='<%# Eval("ID") %>' Visible="false" />--%>
                                                                <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FullName") %>' Visible="true" />

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' Visible="true" />

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' Visible="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' Visible="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("PhoneNo") %>' Visible="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEmployeeNo" runat="server" Text='<%# Eval("EmployeeNo") %>' Visible="true" />
                                                            </td>
                                                                 <td>
                                                                <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Position") %>' Visible="true" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSecurityGroup" runat="server" Text='<%# Eval("SecurityGroup") %>' Visible="true" />
                                                            </td>


                                                        </tr>
                                                    </ItemTemplate>

                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                  </div>
                            </div>
                         
    </section>

     <script src="Scripts/jquery-3.3.1.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.4.0/css/buttons.dataTables.min.css" />

    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.27/build/pdfmake.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.27/build/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.0/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.0/js/buttons.flash.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.0/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.0/js/buttons.print.min.js"></script>

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>
    <link href="css/select2.css" rel="stylesheet" />
    <script>
        $(function () {
            bindDataTableUsers();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTableUsers); 
        });

        function bindDataTableUsers() {
            $(document).ready(function () {
                var t = $('#table_2').dataTable({
                    "columnDefs": [{
                        "searchable": false,
                        "orderable": false,
                        "targets": 0
                    }],
                    "order": [[1, 'asc']]
                });

                t.on('draw.dt', function () {
                    var PageInfo = $('#example').DataTable().page.info();
                    t.column(0, { page: 'current' }).nodes().each(function (cell, i) {
                        cell.innerHTML = i + 1 + PageInfo.start;
                    });
                });
            });
        };
        function bindDataTableUploadedRooms() {
            $(document).ready(function () {
                var t = $('#table_2').dataTable({
                    "columnDefs": [{
                        "searchable": false,
                        "orderable": false,
                        "targets": 0
                    }],
                    "order": [[1, 'asc']]
               
                });

                t.on('draw.dt', function () {
                    var PageInfo = $('#example').DataTable().page.info();
                    t.column(0, { page: 'current' }).nodes().each(function (cell, i) {
                        cell.innerHTML = i + 1 + PageInfo.start;
                    });
                });
            });
        };
    </script>
    <link media="screen" rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
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
                "timeOut": "12000",
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
            function showpopinfo(msg, title) {
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
                    "timeOut": "12000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                // toastr['success'](msg, title);
                var d = Date();
                toastr.info(msg, title);
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
                "timeOut": "12000",
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