<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Appointment_Form.ascx.cs" Inherits="eMedicalSys.DevExpress.ASPxSchedulerForms.Appointment_Form" %>



    <section class="content">
        <%--<table class="dxscAppointmentForm" <%= DevExpress.Web.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 230px;">
            <tr>
                <td>--%>
                    <%--<div class="row">
                        <div class="col-md-12">
                            <div class="card card-primary card-outline">
                                <div class="card-body p-0">
                                    <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New User" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                                    <br />
                                    <br />
                                    <asp:GridView ID="gvUsers" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                        EmptyDataText="No records found." OnRowUpdating="OnRowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="User Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCivilId" runat="server" Text='<%# Eval("EmployeeNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Civil ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCivilId" runat="server" Text='<%# Eval("CivilID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowHeader="true" ButtonType="Image" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                <%--</td>
            </tr>
            <tr>
                <td>--%>

                    <table class="dxscLabelControlPair">
                        <tr>
                            <td class="dxscLabelCell">
                                <dx:ASPxLabel ID="lblRoom" runat="server" Text="Choose Room: ">
                                </dx:ASPxLabel>
                            </td>
                            <td class="dxscControlCell">
                                <asp:DropDownList ID="DropDownRoom" OnSelectedIndexChanged="DropDownRoom_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                <%--</td>
            </tr>
            <tr>
                <td class="dxscSingleCell">--%>
                    <table class="dxscLabelControlPair">
                        <tr>
                            <td class="dxscLabelCell">
                                <dx:ASPxLabel ID="lbldates" runat="server" Text="Choose Date: ">
                                </dx:ASPxLabel>
                            </td>
                            <td class="dxscControlCell">
                                <asp:DropDownList ID="DropDowndate" OnSelectedIndexChanged="DropDowndate_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                <%--</td>

            </tr>
            <tr>
                <td class="dxscSingleCell">--%>
                    <table class="dxscLabelControlPair">
                        <tr>
                            <td class="dxscLabelCell">
                                <dx:ASPxLabel ID="lblTimebegin" runat="server" Text="Choose Session Start: ">
                                </dx:ASPxLabel>
                            </td>
                            <td class="dxscControlCell">
                                <asp:DropDownList ID="DropDownTimebegin" OnSelectedIndexChanged="DropDownTimebegin_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
               <%-- </td>

            </tr>
            <tr>
                <td class="dxscSingleCell">--%>
                    <%--<table class="dxscLabelControlPair">
                        <tr>
                            <td class="dxscLabelCell">
                                <dx:ASPxLabel ID="lblPatient" runat="server" Text="Choose Patient: ">
                                </dx:ASPxLabel>
                            </td>
                            <td class="dxscControlCell">
                                <asp:DropDownList ID="DropDownPatient" OnSelectedIndexChanged="DropDownPatient_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>--%>
                <%--</td>

            </tr>
            <tr>
                <td>--%>
                    <table class="dxscLabelControlPair">
                        <tr>
                            <td class="dxscLabelCell">
                                <dx:ASPxLabel ID="lblService" runat="server" Text="Choose Service: ">
                                </dx:ASPxLabel>
                            </td>
                            <td class="dxscControlCell">
                                <asp:DropDownList ID="DropDownService" OnSelectedIndexChanged="DropDownService_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                <%--</td>
            </tr>
            <tr>
                <td>--%>
                    <table class="dxscLabelControlPair">
                        <tr>
                            <td class="dxscLabelCell">
                                <dx:ASPxLabel ID="lblTime" runat="server" Text="Choose Time: ">
                                </dx:ASPxLabel>
                            </td>
                            <td class="dxscControlCell">
                                <asp:DropDownList ID="DropDownTime" OnSelectedIndexChanged="DropDownTime_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                <%--</td>
            </tr>
        </table>--%>
    </section>



    
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