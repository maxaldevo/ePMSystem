<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ServicesList.aspx.cs" Inherits="WebApplication1.ServicesList" %>

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
                        <h3 style="text-align: center; font-size: larger; margin-top: 10px;">Admin | Services List</h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-outline">
                    <div class="card-body p-0">
                        <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New Service" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                        <br />
                        <asp:GridView ID="gvServices" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="SID" 
                           OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"
                            EmptyDataText="No records found.">
                            <Columns>
                                <asp:TemplateField HeaderText="Service Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("SID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPName" runat="server" Text='<%# Eval("ServiceName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtServiceName" CssClass="form-control" runat="server" Text='<%# Eval("ServiceName") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorServiceName" ControlToValidate="txtServiceName" ValidationGroup="A" runat="server" ErrorMessage="Service Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHospital" runat="server" Text='<%# Eval("ServiceType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <asp:DropDownList ID="DropDownServiceTypes" AutoPostBack="true" OnSelectedIndexChanged="DropDownServiceTypes_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Duration of Session">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDurationofSession" runat="server" Text='<%# Eval("NoofSessions") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtDurationofSession" CssClass="form-control" runat="server" Text='<%# Eval("NoofSessions") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDurationofSession" ControlToValidate="txtDurationofSession" ValidationGroup="A" runat="server" ErrorMessage="Duration of Session" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="txtPrice" ValidationGroup="A" runat="server" ErrorMessage="Price" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chk_IsAvailable" runat="server" Text ="? Change Availability"
                                                Checked='<%# Eval("Status").ToString() == "false" ? false : true %>'/>
                                        </div>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/pencil-edit-button.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" DeleteImageUrl="~/Images/clear.png" ShowDeleteButton="True" />
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
                var oTable = $('#' + '<%=gvServices.ClientID%>').dataTable({
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
