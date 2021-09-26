<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="WebApplication1.RoomList" %>

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
                        <h3 style="text-align: center; font-size: larger; margin-top: 10px; font-weight:bold;">Rooms List</h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-outline">
                    <div class="card-body p-0">
                        <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New Room" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                        <br />
                        <br />
                        <asp:GridView ID="gvRooms" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"  OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"  EmptyDataText="No records found.">
                            <Columns>
                                <asp:TemplateField HeaderText="Room">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblRoomname" runat="server" Text='<%# Eval("RoomName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtRoomName" CssClass="form-control" runat="server" Text='<%# Eval("RoomName") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoomName" ControlToValidate="txtRoomName" ValidationGroup="A" runat="server" ErrorMessage="Room Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() == "false" ? "InActive" : "Active" %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chk_IsAvailable" runat="server" Text ="? Change Availability"
                                                Checked='<%# Eval("Status").ToString() == "false" ? false : true %>'/>
                                        </div>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/pencil-edit-button.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true"/>
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
                var oTable = $('#' + '<%=gvRooms.ClientID%>').dataTable({
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
