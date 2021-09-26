<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="WebApplication1.ProductsList" %>

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
                        <h3 style="text-align: center; font-size: larger; margin-top: 10px;">Admin | Products List</h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-outline">
                    <div class="card-body p-0">
                        <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New Product" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                        <br />
                        <br />
                        <asp:GridView ID="gvProducts" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" EmptyDataText="No records found.">
                            <Columns>
                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPName" CssClass="form-control" runat="server" Text='<%# Eval("ProductName") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" ControlToValidate="txtPName" ValidationGroup="A" runat="server" ErrorMessage="Product Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtQty" CssClass="form-control" runat="server" Text='<%# Eval("Qty") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorQty" ControlToValidate="txtQty" ValidationGroup="A" runat="server" ErrorMessage="Qty" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cost Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostPrice" runat="server" Text='<%# Eval("CostPrice") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCostPrice" CssClass="form-control" runat="server" Text='<%# Eval("CostPrice") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCostPrice" ControlToValidate="txtCostPrice" ValidationGroup="A" runat="server" ErrorMessage="Cost Price" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Profit Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProfitPrice" runat="server" Text='<%# Eval("ProfitPrice") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtProfitPrice" CssClass="form-control" runat="server" Text='<%# Eval("ProfitPrice") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProfitPrice" ControlToValidate="txtProfitPrice" ValidationGroup="A" runat="server" ErrorMessage="Profit Price" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sale Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalePrice" runat="server" Text='<%# Eval("SalePrice") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSalePrice" CssClass="form-control" runat="server" Text='<%# Eval("SalePrice") %>'></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSalePrice" ControlToValidate="txtSalePrice" ValidationGroup="A" runat="server" ErrorMessage="Sale Price" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                <asp:TemplateField HeaderText="Hospital">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHospital" runat="server" Text='<%# Eval("HospitalName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Clinic">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClinic" runat="server" Text='<%# Eval("Clinicname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Added By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/pencil-edit-button.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" />
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
                var oTable = $('#' + '<%=gvProducts.ClientID%>').dataTable({
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
