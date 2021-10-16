<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="eMedicalSys.testpage" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<%@ Register Assembly="DevExpress.XtraScheduler.v18.2.Core, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .table-striped tbody tr:nth-of-type(odd) {
            background-color: dodgerblue;
            color: white;
        }

        .table-striped tbody tr:nth-of-type(even) {
            border: 1px solid lightblue;
            background-color: #e6e9ee;
        }

        .table {
            justify-content: center;
            align-items: center;
        }

            .table tr {
                text-align: center;
                justify-content: center;
                align-items: center;
            }

            .table thead {
                text-align: center;
                justify-content: center;
                align-items: center;
            }

            .table tr td {
                text-align: center;
            }

        #circle {
            position: absolute;
            top: 40%;
            left: 55%;
            transform: translate(-50%,-50%);
            width: 150px;
            height: 150px;
        }

        .loader {
            position: fixed;
            width: calc(100% - 0px);
            height: calc(100% - 0px);
            border: 8px solid #162534;
            border-top: 8px solid #09f;
            border-radius: 50%;
            animation: rotate 5s linear infinite;
            z-index: 999999;
        }

        @keyframes rotate {
            100% {
                transform: rotate(360deg);
            }
        }

        #circle {
            position: absolute;
            top: 40%;
            left: 55%;
            transform: translate(-50%,-50%);
            width: 150px;
            height: 150px;
            z-index: 9999;
        }

        .loader {
            width: calc(100% - 0px);
            height: calc(100% - 0px);
            border: 8px solid #162534;
            border-top: 8px solid #09f;
            border-radius: 50%;
            animation: rotate 5s linear infinite;
        }

        @keyframes rotate {
            100% {
                transform: rotate(360deg);
            }
        }

        .row {
            margin-top: -10px;
        }

        select:focus {
            width: auto;
            position: relative;
        }
    </style>
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
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
            ClientIDMode="Predictable" ViewStateMode="Inherit" DisplayAfter="1">
            <ProgressTemplate>
                <div id="circle">
                    <div class="loader">
                        <div class="loader">
                            <div class="loader">
                                <div class="loader">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-primary card-outline">
                            <div class="card-body p-0">
                                <asp:Button ID="btnAddNewRecord" OnClick="btnAddNewRecord_Click" runat="server" Text="Add New Patient" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                                <asp:Button ID="btn_AppointmentCheckIn" OnClick="btnAppointmentCheckIn_Click" runat="server" Text="Appointment CheckIn" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                                <br />
                                <br />

                                <asp:Label ID="lbltime" runat="server"></asp:Label>
                                <asp:GridView ID="gvUsers" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                    EmptyDataText="No records found." OnRowEditing="OnRowEditing" >
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
                                        <asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/correct.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="card card-primary card-outline">
                            <div class="card-body p-0">
                                <span style="font-weight: bold">Choose Room:</span>
                                <asp:DropDownList ID="DropDownRoom" Width="250px" OnSelectedIndexChanged="DropDownRoom_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card card-primary card-outline">
                            <div class="card-body p-0">
                                <span style="font-weight: bold">Choose Service:</span>
                                <asp:DropDownList ID="DropDownService" Width="250px" OnSelectedIndexChanged="DropDownService_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%--            <div class="col-md-3">
                <div class="card card-primary card-outline">
                    <div class="card-body p-0">
                    <span style="font-weight: bold">Choose Date:</span>
                    <asp:DropDownList ID="DropDowndate" Width="200px" OnSelectedIndexChanged="DropDowndate_SelectedIndexChanged" AutoPostBack="true"  runat="server" ></asp:DropDownList>
                </div>
                    </div>
            </div>--%>
                    <div class="col-md-3">
                        <div class="card card-primary card-outline">
                            <div class="card-body p-0">
                                <span style="font-weight: bold">Choose Session Start:</span>
                                <asp:DropDownList ID="DropDownTimebegin" Width="250px" OnSelectedIndexChanged="DropDownTimebegin_SelectedIndexChanged" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card card-primary card-outline">
                            <div class="card-body p-0">
                                <span style="font-weight: bold">Choose Session End:</span>
                                <asp:DropDownList ID="DropDownTimeEnd" Width="250px" OnSelectedIndexChanged="DropDownTimeEnd_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <asp:Button ID="btn_BookAppointment" OnClick="btnBookAppointment_Click" runat="server" Text="Book Appointment" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblResult" runat="server" Text="" Visible="true"></asp:Label>
                    </div>
                </div>
                <%--<div class="row">
            <div class="col-md-3">
                <div class="card card-primary card-outline">
                    <div class="card-body p-0">
                    <span style="font-weight: bold">Choose Time:</span>
                    <asp:DropDownList ID="DropDownTime" Width="200px" OnSelectedIndexChanged="DropDownTime_SelectedIndexChanged" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
            </div>--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAddNewRecord" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btn_BookAppointment" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="DropDownRoom" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="DropDownService" EventName="SelectedIndexChanged" />
                <%--            <asp:AsyncPostBackTrigger ControlID="DropDowndate" EventName="SelectedIndexChanged" />--%>
                <asp:AsyncPostBackTrigger ControlID="DropDownRoom" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </section>
    <br />
    <br />
    <br />
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="SqlDataSource1" ClientIDMode="AutoID" ResourceDataSourceID="SqlDataSource2" GroupType="Resource" Start="2021-10-07" Theme="iOS" AllowAppointmentDragBetweenResources="false">
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

        <%--<OptionsForms AppointmentFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/Appointment_Form.ascx" AppointmentInplaceEditorFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/InplaceEditor.ascx" GotoDateFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/GotoDateForm.ascx" RecurrentAppointmentDeleteFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentDeleteForm.ascx" RecurrentAppointmentEditFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentEditForm.ascx" RemindersFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/ReminderForm.ascx" />
        <OptionsToolTips AppointmentDragToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentDragToolTip.ascx" AppointmentMobileToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentMobileToolTip.ascx" AppointmentToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentToolTip.ascx" SelectionToolTipUrl="~/DevExpress/ASPxSchedulerForms/SelectionToolTip.ascx" />--%>

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
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:eMedicalConnectionString %>" SelectCommand="SELECT * FROM [eMedical_User]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eMedicalConnectionString %>" SelectCommand="SELECT * FROM [Appointments]">
        
    <%--    DeleteCommand="DELETE FROM [Appointments] WHERE [UniqueID] = @UniqueID" InsertCommand="INSERT INTO [Appointments] ([Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceID], [ResourceIDs], [ReminderInfo], [RecurrenceInfo], [CustomField1]) VALUES (@Type, @StartDate, @EndDate, @AllDay, @Subject, @Location, @Description, @Status, @Label, @ResourceID, @ResourceIDs, @ReminderInfo, @RecurrenceInfo, @CustomField1)" UpdateCommand="UPDATE [Appointments] SET [Type] = @Type, [StartDate] = @StartDate, [EndDate] = @EndDate, [AllDay] = @AllDay, [Subject] = @Subject, [Location] = @Location, [Description] = @Description, [Status] = @Status, [Label] = @Label, [ResourceID] = @ResourceID, [ResourceIDs] = @ResourceIDs, [ReminderInfo] = @ReminderInfo, [RecurrenceInfo] = @RecurrenceInfo, [CustomField1] = @CustomField1 WHERE [UniqueID] = @UniqueID">
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
        </UpdateParameters>--%>
    </asp:SqlDataSource>

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>
    <link href="css/select2.css" rel="stylesheet" />

    <script>
        $(function () {
            bindDataTable(); // bind data table on first page load
            BinddropdownRooms();
            //BinddropdownTimes();
            //Binddropdowndates();
            BinddropdownTimebegins();
            BinddropdownTimeEnds();
            BinddropdownServices();

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable); // bind data table on every UpdatePanel refresh
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownRooms);
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownTimes);
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Binddropdowndates);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownTimebegins);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownTimeEnds);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownServices);

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

        function BinddropdownRooms() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownRoom.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };

<%--        function BinddropdownTimes() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownTime.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };

        function Binddropdowndates() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDowndate.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };--%>

        function BinddropdownTimebegins() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownTimebegin.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };

        function BinddropdownTimeEnds() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownTimeEnd.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };

        function BinddropdownServices() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownService.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };

    </script>
</asp:Content>

