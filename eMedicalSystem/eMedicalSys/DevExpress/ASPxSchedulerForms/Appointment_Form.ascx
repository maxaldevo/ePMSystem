<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Appointment_Form.ascx.cs" Inherits="eMedicalSys.DevExpress.ASPxSchedulerForms.Appointment_Form" %>


<div runat="server" id="ValidationContainer">
    <table class="dxscAppointmentForm" <%= DevExpress.Web.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 230px;">
        <tr>
            <td>

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
            </td>
        </tr>
        <tr>
            <td class="dxscSingleCell">
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
            </td>

        </tr>
        <tr>
            <td class="dxscSingleCell">
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
            </td>

        </tr>
        <tr>
            <td class="dxscSingleCell">
                <table class="dxscLabelControlPair">
                    <tr>
                        <td class="dxscLabelCell">
                            <dx:ASPxLabel ID="lblPatient" runat="server" Text="Choose Patient: ">
                            </dx:ASPxLabel>
                        </td>
                        <td class="dxscControlCell">
                            <asp:DropDownList ID="DropDownPatient" OnSelectedIndexChanged="DropDownPatient_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
        <tr>
            <td>
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

            </td>
        </tr>
        <tr>
            <td>
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
            </td>
        </tr>
    </table>
</div>
