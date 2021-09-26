<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ServiceTypesList.aspx.cs" Inherits="WebApplication1.ServiceTypesList" %>

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
                        <h3 style="text-align: center; font-size: larger; margin-top: 10px; font-weight:bold;">Service Types List</h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-outline">
                    <div class="card-body p-0">
                        <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New Service Type" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                        <br />
                        <br />
                        <asp:GridView ID="gvServiceTypes" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
                           
                            EmptyDataText="No records found.">
                            <Columns>
                                <asp:TemplateField HeaderText="Service Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblServiceType" runat="server" Text='<%# Eval("ServiceType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hospital Name">
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
                                </asp:TemplateField>
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
                var oTable = $('#' + '<%=gvServiceTypes.ClientID%>').dataTable({
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
