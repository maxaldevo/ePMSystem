<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="SecurityGrouprights.aspx.cs" Inherits="WebApplication1.SecurityGrouprights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .table tr,.table td {
   height: 8px;
   text-align: center
}

.table>tbody>tr>td, .table>tbody>tr>th, .table>tfoot>tr>td, .table>tfoot>tr>th, .table>thead>tr>td, .table>thead>tr>th
{
  padding:0px; 
}
        table {
            table-layout: fixed;
        }

           .table tbody tr {

                 white-space: nowrap;
            }

        .row {
            margin-top: -10px;
        }
 .table thead tr  {
            background-color: #23B3E8;
            color: white;
            font-weight: bold;

              white-space: nowrap;
        }
        .table-striped tr {
            background-color: lightgray;
            color: white;
            font-weight: bold;
            line-height: 25px;
        }

        .table {
            text-align: center;
        }

            .table tbody tr td {
            color:#312d2d;
            font-weight:bold;
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
            margin-top: -15px;
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
                            <div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background: #23B3E8;" aria-valuemin="0" aria-valuemax="100">
                                <h3 style="text-align: center; font-size: larger; margin-top: 10px; font-weight:bold;">Group Rights</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <span>Please select Group/Batch :</span><br />
                            <asp:DropDownList ID="dropdownGroups" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdownGroups_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <span>Show Data:</span><br />
                        <asp:Button ID="btnShowData" runat="server" Text="Show Data" CssClass="btn btn-info btn-sm" OnClick="btnShowData_Click" />
                    </div>
                </div>

                <div class="row justify-content-left" style="margin-top: 5px;">
                    <div class="col-md-12">
                        <asp:Label ID="lblResult" runat="server" Font-Bold="true" Font-Size="Larger" Text=""></asp:Label>
                    </div>
                </div>
                <br />
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <div class="row" style="margin-top: 5px;">
                        <div class="col-12">

                            <div class="box">
                                <div class="box-body col-12">

                                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                        <HeaderTemplate>
                                            <div class="table-responsive">
                                                <table class="table">
                                                    <thead>
                                                        <tr style="line-height:10px;">

                                                            <th scope="col">Module Name</th>
                                                            <th scope="col">Page Name</th>
                                                            <th scope="col">Page URL</th>
                                                            <th>
                                                                <div class="form-group"  style="margin:auto;margin-top:7px;">
                                                                    <div class="checkbox">
                                                                        <asp:CheckBox ID="selectall" Text="Access All" runat="server" OnCheckedChanged="selectall_CheckedChanged" AutoPostBack="true" />
                                                                    </div>
                                                                </div>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr runat="server">

                                                <td>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id") %>' Visible="false" />
                                                              <asp:Label ID="lblRRId" runat="server" Text='<%# Eval("RoleRightId") %>' Visible="false" />
                                                    
                                                    <asp:Label ID="lblRoleId" runat="server" Text='<%# Eval("RoleId") %>' Visible="false" />
                                                    <asp:Label ID="lblParentId" runat="server" Text='<%# Eval("ParentId") %>' Visible="false" />
                                                    <asp:Label ID="lblModuleId" runat="server" Text='<%# Eval("ModuleId") %>' Visible="false" />
                                                    <asp:Label ID="lblModuleName" runat="server" Text='<%# Eval("ModuleName") %>' Font-Size="Small" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' Font-Size="Small" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPageURL" runat="server" Text='<%# Eval("URL") %>' Font-Size="Small" />
                                                </td>
                                                <td>
                                                    <div class="form-group" style="margin:auto;margin-top:7px;">
                                                        <div class="checkbox">
                                                     <asp:CheckBox ID="chkSelect" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" runat="server" Text="Allow" Checked='<%# Eval("HasAccess").ToString() != "0" %>' />
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                        </table>
                                 </div>
                                <div class="row">
                                    <h4 style="text-align: center; color: red">
                                        <asp:Label ID="lblEmptyData" runat="server" Visible='<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>' Text="No records found" /></h4>
                                </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <asp:Button ID="btnSave" runat="server" Text="Save Records" CssClass="btn btn-success" ValidationGroup="A" OnClick="btnSave_Click" />
                    </div>
                </asp:Panel>
                </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dropdownGroups" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnShowData" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </section>

    <script src="Scripts/jquery-3.3.1.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.4.0/css/buttons.dataTables.min.css" />

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
            // bindDataTable();
            bindGroups();
            fixDropWidth();
            //   Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable); // bind data table on every
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindGroups);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fixDropWidth);

        });
        function bindGroups() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=dropdownGroups.ClientID%>').select2({
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