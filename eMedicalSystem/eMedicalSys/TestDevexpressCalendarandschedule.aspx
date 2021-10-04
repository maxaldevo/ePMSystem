<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestDevexpressCalendarandschedule.aspx.cs" Inherits="eMedicalSys.TestDevexpressCalendarandschedule" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%--    <dxwschs:aspxscheduler runat="server">
        <Views>
            <WeekView Enabled="false"></WeekView>
            <FullWeekView Enabled="true">
            </FullWeekView>
        </Views>

    </dxwschs:aspxscheduler>
    <dx:BootstrapScheduler runat="server"></dx:BootstrapScheduler>--%>

        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" ActiveViewType="WorkWeek"
        GroupType="Resource" AppointmentDataSourceID="AppointmentDataSource" ResourceDataSourceID="efResourceDataSource">
        <Views>
            <DayView ResourcesPerPage="3" ShowWorkTimeOnly="true">
                <WorkTime Start="07:00:00" End="20:00:00" />
            </DayView>
            <WorkWeekView ResourcesPerPage="2" ShowWorkTimeOnly="true">
                <WorkTime Start="07:00:00" End="20:00:00" />
            </WorkWeekView>
            <FullWeekView Enabled="true" ResourcesPerPage="2" ShowWorkTimeOnly="true">
                <WorkTime Start="07:00:00" End="20:00:00" />
            </FullWeekView>
            <WeekView Enabled="false" />
            <MonthView ResourcesPerPage="2" ShowWeekend="false">
                <AppointmentDisplayOptions StartTimeVisibility="Never" EndTimeVisibility="Never" StatusDisplayType="Bounds" ShowRecurrence="true"/>
                <MonthViewStyles>
                    <DateCellBody Height="170px" />
                </MonthViewStyles>
            </MonthView>
            <TimelineView ResourcesPerPage="2">
                <%--<Scales>
                    <dxwschs:TimeScaleMonth />
                    <dxwschs:TimeScaleDay />
                </Scales>--%>
                <TimelineViewStyles>
                    <TimelineCellBody Height="250px" />
                </TimelineViewStyles>
            </TimelineView>
            <AgendaView Enabled="false" />
        </Views>
        <Storage EnableReminders="false" />
    </dxwschs:ASPxScheduler>

    <asp:datasource runat="server" ID="AppointmentDataSource" DataSourceID="efAppointmentDataSource" IsSiteMode="True"></asp:datasource>
    <ef:EntityDataSource ID="efAppointmentDataSource" runat="server" ContextTypeName="DevExpress.Web.Demos.MedicsSchedulingDBContext" EntitySetName="MedicalAppointments"
        EnableInsert="true" EnableUpdate="true" EnableDelete="true" EnableFlattening="false" />
    <ef:EntityDataSource ID="efResourceDataSource" runat="server" ContextTypeName="DevExpress.Web.Demos.MedicsSchedulingDBContext" EntitySetName="Medics" EnableFlattening="false" />

</asp:Content>
