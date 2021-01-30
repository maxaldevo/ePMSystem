<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="SecurityAdmin.aspx.cs" Inherits="WebApplication1.SecurityAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
              * {
            font-family: 'Foco', sans-serif;
        }
        table thead tr {
            background-color: #23B3E8;
            color: white;
            font-weight: bold;
            text-align: center;
        }

        table tbody tr {
            text-align: center;
        }

        table tbody tr td {
            text-align: center;
        }

        .row {
            margin-top: -15px;
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
            margin-top: 15px;
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
                <div class="row" style="margin-top: -15px;">
                    <div class="col-12 col-md-12">
                        <div class="progress" style='height: 30px; margin-top: -10px;'>
                            <div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background: #23B3E8;" aria-valuemin="0" aria-valuemax="100">
                                <h3 style="text-align: center; font-size: larger; margin-top: 10px;">Security Admin | Manage Group and Users</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <%--              <ul class="nav nav-tabs" role="tablist">
						<li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#home8" role="tab"><span><i class="ion-home mr-15"></i>Home</span></a> </li>
						<li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#profile8" role="tab"><span><i class="ion-person mr-15"></i>Person</span></a> </li>
						<li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#messages8" role="tab"><span><i class="ion-email mr-15"></i>Email</span></a> </li>
					</ul>
                <br />--%>

                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" OnActiveTabChanged="TabContainer1_ActiveTabChanged" >

                    <ajaxToolkit:TabPanel ID="TabGroups" HeaderText="Manage Groups" runat="server" >
                        <ContentTemplate>

                            <div class="row">
                                <div class="col-12 col-md-12">
                                    <div class="card card-primary card-outline">
                                        <div class="card-body p-0">
                                            <asp:GridView ID="gvGroups" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="RoleId" OnRowEditing="OnRowEditing"
                                                OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"
                                                EmptyDataText="No records has been found.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Group Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRoleId" runat="server" Text='<%# Eval("RoleId") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblRoleName" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtRoleName" CssClass="form-control" runat="server" Text='<%# Eval("RoleName") %>'></asp:TextBox></div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtRoleName" ValidationGroup="A" runat="server" ErrorMessage="Role Name is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Notes">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNotes" runat="server" Text='<%# Eval("Notes") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtNotes" CssClass="form-control" runat="server" Text='<%# Eval("Notes") %>'></asp:TextBox></div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNotes" ValidationGroup="A" runat="server" ErrorMessage="Notes field is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Count Users">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCount" runat="server" Text='<%# Eval("CountUsers") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowHeader="true" HeaderText="Controls" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/pencil-edit-button.png"
                                                        ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" DeleteImageUrl="~/Images/clear.png" ShowDeleteButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <a class="btn btn-primary" data-toggle="collapse" href="#multiCollapseExample1" role="button" aria-expanded="false" aria-controls="multiCollapseExample1" style="margin-left: 20px;">Add New group</a>
                                            <br />
                                            <div id="multiCollapseExample1" class="collapse multi-collapse" style="margin-top: 20px;">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="table-responsive" style="border: Dodgerblue solid 0.5px;">
                                                            <table class="table table">
                                                                <tr>
                                                                    <td style="padding: 5px;">Group Name:<br />
                                                                        <asp:TextBox ID="txtGroupName" runat="server" CssClass="form-control" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="C" ControlToValidate="txtGroupName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>

                                                                    <td style="padding: 5px;">Notes:<br />
                                                                        <asp:TextBox ID="txtGroupNotes" runat="server" CssClass="form-control" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator05" ForeColor="Red" ValidationGroup="C" ControlToValidate="txtGroupNotes" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>Add:<br />
                                                                        <asp:Button ID="btnAddGroup" OnClick="btnAddGroup_Click" CssClass="btn btn-info" runat="server" Text="Add Group" ValidationGroup="C" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabUserroles" HeaderText="Manage User Groups" CssClass="nav-item" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-12 col-md-12">
                                    <div class="card card-primary card-outline">
                                        <div class="card-body p-0">
                                            <asp:GridView ID="gvUsers" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowEditing="OnRowEditing2"
                                                OnRowCancelingEdit="OnRowCancelingEdit2" OnRowDataBound="gvUsers_RowDataBound2" OnRowUpdating="OnRowUpdating2" OnRowCommand="gvUsers_RowCommand" 
                                                EmptyDataText="No records has been found.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="User Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                                     <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblFName" Font-Size="Small" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" Font-Size="Smaller" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Role">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRoleName" Font-Size="Smaller" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblRoleId" runat="server" Visible="false" Text='<%# Eval("RoleId") %>'></asp:Label>
                                                            <asp:DropDownList ID="DropDownListRoles" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Active">
                                                        <ItemTemplate>
                                                              <asp:CheckBox runat="server" Enabled="false" Text=" " Checked='<%#Convert.ToBoolean(Eval("Active"))%>'></asp:CheckBox>
                                                            </ItemTemplate>
                                                         </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reset Password">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkReset" Font-Size="Smaller" CssClass="btn btn-block btn-info" Text="Reset password" CommandArgument='<%# Eval("ID") %>' CommandName="Reset" runat="server"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Deactivate User">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDeActivate" Font-Size="Smaller" CommandArgument='<%# Eval("ID") %>' CommandName="DeActivate" runat="server" CssClass="btn btn-block btn-warning">
                                                                <i class="fa fa-refresh" aria-hidden="true">  <%# IsActive(Eval("Active")) %></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Image" HeaderText="Controls" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/pencil-edit-button.png"
                                                        ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="B" CausesValidation="true" />
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabAddUser" HeaderText="Add New User" runat="server">
                        <ContentTemplate>
                              <div class="row">
                    <div class="col-md-3">
                        <div class="controls">
                             <span>Full Name:</span>
                            <asp:TextBox ID="txtFName" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtFName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                             <span>First Name:</span>
                            <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="First Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                              <span>Last Name:</span>
                            <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                             <span>Email :</span>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="A" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    </div>
                  <br />
                                    <div class="row">
                         <div class="col-md-3">
                        <div class="controls">
                             <span>Mobile No. :</span>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Mobile No"></asp:TextBox>
                           
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="controls">
                             <span>Employee No. :</span>
                            <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control" placeholder="Employee No"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtEmpNo"></asp:RequiredFieldValidator>
                        </div>
                    </div>
      
                    <div class="col-md-3">
                        <div class="controls">
                             <span>Security Access Group :</span>
                            <asp:DropDownList ID="DropDownRoles" OnSelectedIndexChanged="DropDownRoles_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                                     <div class="col-md-3">
                        <div class="controls">
                             <span>Select a Position :</span>
                            <asp:DropDownList ID="DropDownHRRoles" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DropDownHRRoles_SelectedIndexChanged" runat="server"></asp:DropDownList>
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
                    </div>                </div>
                <br />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <br />
            </ContentTemplate>

            <Triggers>

        
            </Triggers>
        </asp:UpdatePanel>
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
            bindDataTable(); // bind data table on first page load
            BinddropdownHRRoles();
            bindDataTableUsers();
            BinddropdownRoles();
            fixDropWidth();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable); // bind data table on every UpdatePanel 
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTableUsers); 
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownRoles); 
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownHRRoles); 
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fixDropWidth); 
        });
        function bindDataTable() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=gvGroups.ClientID%>').dataTable({
                    "sDom": "Rlfrtip",
                    "bAutoWidth": true,
                    "bFilter": true,
                    "bPagination": true,
                    "sPaginationType": "full_numbers",
                    "bStateSave": true,
                    "bPaginate": true,
                    "bInfo": true,
                    "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]]
                });
            });
        };
        function bindDataTableUsers() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=gvUsers.ClientID%>').dataTable({
                    "sDom": "Rlfrtip",
                    "bAutoWidth": true,
                    "bFilter": true,
                    "bPagination": true,
                    "sPaginationType": "full_numbers",
                    "bStateSave": true,
                    "bPaginate": true,
                    "bInfo": true,
                    "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
                    columnDefs: [
                        {
                            targets: 1,
                            className: 'dt-body-center'
                        }
                    ]
                });
            });
        };
               function BinddropdownRoles() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownRoles.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };
                     function BinddropdownHRRoles() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownHRRoles.ClientID%>').select2({
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