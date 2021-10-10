<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="eMedicalSys.testpage" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<%@ Register assembly="DevExpress.XtraScheduler.v18.2.Core, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>

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
                        <div class="col-md-12">
                            <div class="card card-primary card-outline">
                                <div class="card-body p-0">
                                    <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New User" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                                    <br />
                                    <br />
                                    <asp:GridView ID="gvUsers" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                        EmptyDataText="No records found." OnRowEditing="OnRowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Full Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpno" runat="server" Text='<%# Eval("EmployeeNo") %>'></asp:Label>
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
                                            <asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/correct.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true"/>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
        </section>
    <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="SqlDataSource1" ClientIDMode="AutoID"  ResourceDataSourceID="SqlDataSource2" GroupType="Resource" Start="2021-10-07" Theme="iOS">
        <Views>
            <DayView ViewSelectorItemAdaptivePriority="2" Enabled="true">
                
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>

                <AppointmentDisplayOptions ColumnPadding-Left="2" ColumnPadding-Right="4"></AppointmentDisplayOptions>
            </DayView>
            <WorkWeekView ViewSelectorItemAdaptivePriority="6" Enabled="true">
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>

                <AppointmentDisplayOptions ColumnPadding-Left="2" ColumnPadding-Right="4"></AppointmentDisplayOptions>
            </WorkWeekView>
            <WeekView Enabled="false">

            </WeekView>
            <MonthView ViewSelectorItemAdaptivePriority="5" Enabled="true">

            </MonthView>
            <TimelineView ViewSelectorItemAdaptivePriority="3" Enabled="true">

            </TimelineView>
            <FullWeekView Enabled="true">
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>

                <AppointmentDisplayOptions ColumnPadding-Left="2" ColumnPadding-Right="4"></AppointmentDisplayOptions>
            </FullWeekView>
            <AgendaView ViewSelectorItemAdaptivePriority="1" Enabled="true">
                
            </AgendaView>
        </Views>
        
        <OptionsForms AppointmentFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/Appointment_Form.ascx" AppointmentInplaceEditorFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/InplaceEditor.ascx" GotoDateFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/GotoDateForm.ascx" RecurrentAppointmentDeleteFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentDeleteForm.ascx" RecurrentAppointmentEditFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentEditForm.ascx" RemindersFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/ReminderForm.ascx" />
        <OptionsToolTips AppointmentDragToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentDragToolTip.ascx" AppointmentMobileToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentMobileToolTip.ascx" AppointmentToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentToolTip.ascx" SelectionToolTipUrl="~/DevExpress/ASPxSchedulerForms/SelectionToolTip.ascx" />
        
        <Storage>
            <Appointments AutoRetrieveId="True">
                <Mappings AllDay="AllDay" AppointmentId="UniqueID" Description="Description" End="EndDate" Label="Label" Location="Location" RecurrenceInfo="RecurrenceInfo" ReminderInfo="ReminderInfo" ResourceId="ResourceID" Start="StartDate" Status="Status" Subject="Subject" Type="Type" />
                <labels>
                    <dxwschs:AppointmentLabel Color="58, 159, 254" DisplayName="Business" MenuCaption="&amp;Business" />
                    <dxwschs:AppointmentLabel Color="255, 152, 30" DisplayName="Vacation" MenuCaption="&amp;Vacation" />
                    <dxwschs:AppointmentLabel Color="150, 207, 39" DisplayName="Must Attend" MenuCaption="Must &amp;Attend" />
                    <dxwschs:AppointmentLabel Color="62, 198, 254" DisplayName="Travel Required" MenuCaption="&amp;Travel Required" />
                    <dxwschs:AppointmentLabel Color="0, 184, 201" DisplayName="Needs Preparation" MenuCaption="&amp;Needs Preparation" />
                    <dxwschs:AppointmentLabel Color="165, 79, 254" DisplayName="Birthday" MenuCaption="&amp;Birthday" />
                    <dxwschs:AppointmentLabel Color="92, 107, 192" DisplayName="Anniversary" MenuCaption="&amp;Anniversary" />
                    <dxwschs:AppointmentLabel Color="159, 159, 159" DisplayName="None" MenuCaption="&amp;None" />
                    <dxwschs:AppointmentLabel Color="75, 194, 80" DisplayName="Personal" MenuCaption="&amp;Personal" />
                    <dxwschs:AppointmentLabel Color="253, 184, 18" DisplayName="Phone Call" MenuCaption="Phone &amp;Call" />
                </labels>
            </Appointments>
            <Resources>
                <Mappings Caption="RoomName" ResourceId="ID" />
            </Resources>
        </Storage>

    </dxwschs:ASPxScheduler>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eMedicalConnectionString %>" SelectCommand="SELECT * FROM [eMedical_Room] WHERE ([UpdatedByID] = @UpdatedByID)">
        <SelectParameters>
            <asp:Parameter DefaultValue="14" Name="UpdatedByID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:eMedicalConnectionString %>" SelectCommand="SELECT * FROM [eMedical_User]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eMedicalConnectionString %>" DeleteCommand="DELETE FROM [Appointments] WHERE [UniqueID] = @UniqueID" InsertCommand="INSERT INTO [Appointments] ([Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceID], [ResourceIDs], [ReminderInfo], [RecurrenceInfo], [CustomField1]) VALUES (@Type, @StartDate, @EndDate, @AllDay, @Subject, @Location, @Description, @Status, @Label, @ResourceID, @ResourceIDs, @ReminderInfo, @RecurrenceInfo, @CustomField1)" SelectCommand="SELECT * FROM [Appointments]" UpdateCommand="UPDATE [Appointments] SET [Type] = @Type, [StartDate] = @StartDate, [EndDate] = @EndDate, [AllDay] = @AllDay, [Subject] = @Subject, [Location] = @Location, [Description] = @Description, [Status] = @Status, [Label] = @Label, [ResourceID] = @ResourceID, [ResourceIDs] = @ResourceIDs, [ReminderInfo] = @ReminderInfo, [RecurrenceInfo] = @RecurrenceInfo, [CustomField1] = @CustomField1 WHERE [UniqueID] = @UniqueID">
        <DeleteParameters>
            <asp:Parameter Name="UniqueID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Type" Type="Int32" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="AllDay" Type="Boolean" />
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="Location" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Status" Type="Int32" />
            <asp:Parameter Name="Label" Type="Int32" />
            <asp:Parameter Name="ResourceID" Type="Int32" />
            <asp:Parameter Name="ResourceIDs" Type="String" />
            <asp:Parameter Name="ReminderInfo" Type="String" />
            <asp:Parameter Name="RecurrenceInfo" Type="String" />
            <asp:Parameter Name="CustomField1" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Type" Type="Int32" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="AllDay" Type="Boolean" />
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="Location" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Status" Type="Int32" />
            <asp:Parameter Name="Label" Type="Int32" />
            <asp:Parameter Name="ResourceID" Type="Int32" />
            <asp:Parameter Name="ResourceIDs" Type="String" />
            <asp:Parameter Name="ReminderInfo" Type="String" />
            <asp:Parameter Name="RecurrenceInfo" Type="String" />
            <asp:Parameter Name="CustomField1" Type="String" />
            <asp:Parameter Name="UniqueID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

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
                var oTable = $('#' + '<%=gvUsers.ClientID%>').dataTable({
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
