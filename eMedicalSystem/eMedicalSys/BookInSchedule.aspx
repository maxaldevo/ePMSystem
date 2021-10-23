<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookInSchedule.aspx.cs" Inherits="eMedicalSys.BookInSchedule" %>
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
<%--<lord-icon
    src="https://cdn.lordicon.com/zhxxdohn.json"
    trigger="hover"
    colors="primary:#121331,secondary:#08a88a"
    style="width:100px;height:100px">
</lord-icon>
                                
<lord-icon
    src="https://cdn.lordicon.com/mdksbrtj.json"
    trigger="loop"
    colors="primary:#121331,secondary:#08a88a"
    style="width:100px;height:100px">
</lord-icon>--%>
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
                <br />
                <br />

                <div class="row">
                    <div class="col-md-4">
                        <span style="font-weight: bold">LASER ROOM</span>
                        <asp:GridView ID="gvBookingTimes_Roomone" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="BTID" EmptyDataText="No records found." OnRowDataBound="gvBookingTimes_RoomOne_RowDataBound">
                            <%--OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"--%>
                            <Columns>
                                <asp:TemplateField HeaderText="Time Begin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("BTID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblBookingTimeBegin" runat="server" Text='<%# Convert.ToDateTime( Eval("BookingDate_TimeBegin").ToString()).ToShortTimeString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time End">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookingTimeEnd" runat="server" Text='<%# Convert.ToDateTime( Eval("BookingDate_TimeEnd").ToString()).ToShortTimeString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Booked">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsBooked" runat="server" Text='<%# Convert.ToBoolean(Eval("IsBooked").ToString()) == false ? "Available" : "Busy" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/correct.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-4">
                        <span style="font-weight: bold">BEAUTICIAN ROOM</span>
                        <asp:GridView ID="gvBookingTimes_RoomTwo" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="BTID" EmptyDataText="No records found." OnRowDataBound="gvBookingTimes_RoomTwo_RowDataBound">
                            <%--OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"--%>
                            <Columns>
                                <asp:TemplateField HeaderText="Time Begin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("BTID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblBookingTimeBegin" runat="server" Text='<%# Convert.ToDateTime( Eval("BookingDate_TimeBegin").ToString()).ToShortTimeString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time End">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookingTimeEnd" runat="server" Text='<%# Convert.ToDateTime( Eval("BookingDate_TimeEnd").ToString()).ToShortTimeString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Booked">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsBooked" runat="server" Text='<%# Convert.ToBoolean(Eval("IsBooked").ToString()) == false ? "Available" : "Busy" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/correct.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-4">
                        <span style="font-weight: bold">DOCTOR ROOM</span>
                        <asp:GridView ID="gvBookingTimes_RoomThree" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="BTID" EmptyDataText="No records found." OnRowDataBound="gvBookingTimes_RoomThree_RowDataBound">
                            <%--OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"--%>
                            <Columns>
                                <asp:TemplateField HeaderText="Time Begin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("BTID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblBookingTimeBegin" runat="server" Text='<%# Convert.ToDateTime( Eval("BookingDate_TimeBegin").ToString()).ToShortTimeString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time End">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookingTimeEnd" runat="server" Text='<%# Convert.ToDateTime( Eval("BookingDate_TimeEnd").ToString()).ToShortTimeString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Booked">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsBooked" runat="server" Text='<%# Convert.ToBoolean(Eval("IsBooked").ToString()) == false ? "Available" : "Busy" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowHeader="true" ButtonType="Image" CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/correct.png" ShowEditButton="True" UpdateImageUrl="~/Images/correct.png" ValidationGroup="A" CausesValidation="true" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
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
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.lordicon.com/libs/mssddfmo/lord-icon-2.1.0.js"></script>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>
    <link href="css/select2.css" rel="stylesheet" />

    <script>
        $(function () {
            bindDataTable(); // bind data table on first page load
            //SearchinGrid();
            BinddropdownRooms();
            //BinddropdownTimes();
            //Binddropdowndates();
            BinddropdownTimebegins();
            BinddropdownTimeEnds();
            BinddropdownServices();

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable); // bind data table on every UpdatePanel refresh
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(SearchinGrid);
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


        function SearchinGrid() {
            $(document).ready(function () {
                // Setup - add a text input to each footer cell
                
                $('#' + '<%=gvUsers.FooterRow%>').each(function () {
                    var title = $(this).text();
                    $(this).html('<input type="text" placeholder="Search ' + title + '" />');
                });

                // DataTable
                var table = $('#' + '<%=gvUsers.ClientID%>').DataTable({
                    initComplete: function () {
                        // Apply the search
                        this.api().columns().every(function () {
                            var that = this;

                            $('input', this.footer()).on('keyup change clear', function () {
                                if (that.search() !== this.value) {
                                    that
                                        .search(this.value)
                                        .draw();
                                }
                            });
                        });
                    }
                });

            });
        }

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
