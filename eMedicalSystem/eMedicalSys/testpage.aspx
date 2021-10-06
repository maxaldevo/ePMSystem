<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="eMedicalSys.testpage" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<%@ Register assembly="DevExpress.XtraScheduler.v18.2.Core, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="SqlDataSource1" ClientIDMode="AutoID" Start="2021-10-06" OnActiveViewChanged="ASPxScheduler1_ActiveViewChanged" OnActiveViewChanging="ASPxScheduler1_ActiveViewChanging">
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

            <WeekView Enabled="false"></WeekView>

            <MonthView ViewSelectorItemAdaptivePriority="5" Enabled="true"></MonthView>

            <TimelineView ViewSelectorItemAdaptivePriority="3" Enabled="true"></TimelineView>

            <FullWeekView Enabled="true">
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>

                <AppointmentDisplayOptions ColumnPadding-Left="2" ColumnPadding-Right="4"></AppointmentDisplayOptions>
            </FullWeekView>

            <AgendaView ViewSelectorItemAdaptivePriority="1" Enabled="true"></AgendaView>
        </Views>

        <Storage>
            <Appointments AutoRetrieveId="True">
                <Mappings AllDay="AllDay" AppointmentId="UniqueID" Description="Description" End="EndDate" Label="Label" Location="Location" RecurrenceInfo="RecurrenceInfo" ReminderInfo="ReminderInfo" ResourceId="ResourceID" Start="StartDate" Status="Status" Subject="Subject" Type="Type" />
            </Appointments>
        </Storage>

    </dxwschs:ASPxScheduler>
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
</asp:Content>
