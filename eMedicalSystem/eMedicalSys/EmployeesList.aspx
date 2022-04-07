<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="EmployeesList.aspx.cs" Inherits="WebApplication1.EmployeesList" %>

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
                     <div class="row">
            <div class="col-12 col-md-12">

                <div class="progress" style='height: 30px; margin-top: -10px;'>
                    <div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
                        <h3 style="text-align: center; font-size: larger; margin-top: 10px; font-weight:bold;">Services List</h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-outline">
                    <div class="card-body p-0">
                        <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New Employee" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                        <br />
                        <br />
                        <asp:GridView ID="gvEmployees" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
                           OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"
                            EmptyDataText="No records found.">
                            <Columns>
                                <asp:TemplateField HeaderText="Emp No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtFullnameEn" CssClass="form-control" runat="server" Text='<%# Eval("FullnameEn") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorServiceName" ControlToValidate="txtFullnameEn" ValidationGroup="A" runat="server" ErrorMessage="Full Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" Text='<%# Eval("Designation") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorServiceName" ControlToValidate="txtDesignation" ValidationGroup="A" runat="server" ErrorMessage="Designation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nationality">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNationality" runat="server" Text='<%# Eval("Nationality") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtNationality" CssClass="form-control" runat="server" Text='<%# Eval("Nationality") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDurationofSession" ControlToValidate="txtNationality" ValidationGroup="A" runat="server" ErrorMessage="Nationality" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Civil No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCivilId" runat="server" Text='<%# Eval("CivilId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCivilId" CssClass="form-control" runat="server" Text='<%# Eval("CivilId") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="txtCivilId" ValidationGroup="A" runat="server" ErrorMessage="Civil No." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Passport No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPassportNo" runat="server" Text='<%# Eval("PassportNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassportNo" CssClass="form-control" runat="server" Text='<%# Eval("PassportNo") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="txtPassportNo" ValidationGroup="A" runat="server" ErrorMessage="Passport No." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Passport Exp. Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPassportExpDate" runat="server" Text='<%# Eval("PassportExpDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassportExpDate" CssClass="form-control" runat="server" Text='<%# Eval("PassportExpDate") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="txtPassportExpDate" ValidationGroup="A" runat="server" ErrorMessage="Passport Exp. Date" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() == "false" ? "InActive" : "Active" %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chk_IsAvailable" runat="server" Text ="? Change Availability"
                                                Checked='<%# Eval("Status").ToString() == "false" ? false : true %>'/>
                                        </div>
                                    </EditItemTemplate>
                                </asp:TemplateField>--%>
                                
                                <asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/pencil-edit-button.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" />
                                <%--<asp:TemplateField HeaderText="Hospital Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("HospitalName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Clinic Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Clinicname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Added By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

    <script>
        $(function () {
            bindDataTable(); // bind data table on first page load
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable); // bind data table on every UpdatePanel refresh
        });
        function bindDataTable() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=gvEmployees.ClientID%>').dataTable({
                    dom: 'Blfrtip',
                    "bInfo": true,
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ],
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
                });
            });
        };
    </script>
</asp:Content>
