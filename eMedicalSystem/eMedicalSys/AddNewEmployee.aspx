<%@ Page Title="" Language="C#" MasterPageFile="~/HRMasterPage.master" AutoEventWireup="true" CodeBehind="AddNewEmployee.aspx.cs" Inherits="WebApplication1.AddNewEmployee" %>

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
                    <div class="col-12 col-md-12">

                        <div class="progress" style='height: 30px; margin-top: -10px;'>
                            <div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
                                <h3 style="text-align: center; font-size: larger; margin-top: 10px; font-weight: bold;">Add New Employee</h3>
                            </div>
                        </div>
                    </div>
                </div>


                <asp:Panel GroupingText="INFO." runat="server" ForeColor="#3366ff" Font-Bold="true">
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">File No.:</span>
                                <asp:TextBox ID="txtFileno" CssClass="form-control" runat="server" placeholder="File No."></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtFileno"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Emp. ID:</span>
                                <asp:TextBox ID="txtempid" CssClass="form-control" runat="server" placeholder="Emp. ID"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtempid"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Full Name (Ar):</span>
                                <asp:TextBox ID="txtFullNameAr" CssClass="form-control" runat="server" placeholder="Full Name (Ar)"></asp:TextBox>
                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last Name" Text=" " Visible="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtFullNameAr"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Full Name (En):</span>
                                <asp:TextBox ID="txtFullNameEn" CssClass="form-control" runat="server" placeholder="Full Name (En)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtFullNameEn"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Designation :</span>
                                <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" placeholder="Designation"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtDesignation"></asp:RequiredFieldValidator>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                    Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="A" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Nationality :</span>
                                <asp:TextBox ID="txtNationality" runat="server" CssClass="form-control" placeholder="Nationality"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtNationality"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Civil No. :</span>
                                <asp:TextBox ID="txtcivilNo" runat="server" CssClass="form-control" placeholder="Civil No."></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtcivilNo" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtcivilNo"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Residency Date :</span>
                                <asp:TextBox ID="txtResidencyDate" runat="server" CssClass="form-control" placeholder="Residency Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtResidencyDate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Passport No :</span>
                                <asp:TextBox ID="txtPassportNo" CssClass="form-control" runat="server" placeholder="Passport No"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtPassportNo"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Passport Exp. Date :</span>
                                <asp:TextBox ID="txtPassportExpDate" runat="server" CssClass="form-control" placeholder="Passport Exp. Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtPassportExpDate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Status :</span>
                                <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control" placeholder="Status"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtStatus"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Joined Date :</span>
                                <asp:TextBox ID="txtJoinedDate" runat="server" CssClass="form-control" placeholder="Joined Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtJoinedDate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Transfered From :</span>
                                <asp:TextBox ID="txtTransferedFrom" CssClass="form-control" runat="server" placeholder="Transfered From"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtTransferedFrom"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Transfered From (Date) :</span>
                                <asp:TextBox ID="txtTransferedFromdate" CssClass="form-control" runat="server" placeholder="Transfered From (Date)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtTransferedFromdate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Transfered To :</span>
                                <asp:TextBox ID="txtTransferedTo" CssClass="form-control" runat="server" placeholder="Transfered To"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtTransferedTo"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Transfered To (Date) :</span>
                                <asp:TextBox ID="txtTransferedTodate" CssClass="form-control" runat="server" placeholder="Transfered To (Date)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtTransferedTodate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Salary :</span>
                                <asp:TextBox ID="txtSalary" CssClass="form-control" runat="server" placeholder="Salary"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtSalary"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">RTD :</span>
                                <asp:CheckBox ID="chk_RTD" Text="Terminated" CssClass="form-control" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Remarks :</span>
                                <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="70px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtRemarks"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <br />
                <asp:Panel GroupingText="VACATION" runat="server" ForeColor="#3366ff" Font-Bold="true">
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation From :</span>
                                <asp:TextBox ID="txtVacationFrom" CssClass="form-control" runat="server" placeholder="Vacation From"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationFrom"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation To :</span>
                                <asp:TextBox ID="txtVacationTo" CssClass="form-control" runat="server" placeholder="Vacation To"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationTo"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation Days No. :</span>
                                <asp:TextBox ID="txtVacationDaysNo" CssClass="form-control" runat="server" placeholder="Vacation Days No."></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationDaysNo"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation Extension(1) From :</span>
                                <asp:TextBox ID="txtVacationExt_1_From" CssClass="form-control" runat="server" placeholder="Extension(1) From"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationExt_1_From"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation Extension(1) To :</span>
                                <asp:TextBox ID="txtVacationExt_1_To" CssClass="form-control" runat="server" placeholder="Extension(1) To"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationExt_1_To"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation Extension(2) From :</span>
                                <asp:TextBox ID="txtVacationExt_2_From" CssClass="form-control" runat="server" placeholder="Extension(2) From"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationExt_2_From"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation Extension(2) To :</span>
                                <asp:TextBox ID="txtVacationExt_2_To" CssClass="form-control" runat="server" placeholder="Extension(2) To"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationExt_2_To"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation Extension(3) From :</span>
                                <asp:TextBox ID="txtVacationExt_3_From" CssClass="form-control" runat="server" placeholder="Extension(3) From"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationExt_3_From"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <span style="font-weight: bold; color: black;">Vacation Extension(3) To :</span>
                                <asp:TextBox ID="txtVacationExt_3_To" CssClass="form-control" runat="server" placeholder="Extension(3) To"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtVacationExt_3_To"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="controls">
                                <%--<span style="font-weight:bold">Security Access Group :</span>--%>
                                <asp:DropDownList ID="DropDownRoles" OnSelectedIndexChanged="DropDownRoles_SelectedIndexChanged" AutoPostBack="true" runat="server" Visible="false"></asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <br />
                    <div class="row">

                        <div class="col-md-3">
                            <div class="controls">
                                <%--<span>Hospitals :</span>--%>
                                <asp:DropDownList ID="DropDownHospitals" OnSelectedIndexChanged="DropDownHospitals_SelectedIndexChanged" AutoPostBack="true" runat="server" Visible="false"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="controls">
                                <%--<span>Clinic :</span>--%>
                                <asp:DropDownList ID="DropDownClinics" AutoPostBack="true" OnSelectedIndexChanged="DropDownClinics_SelectedIndexChanged" runat="server" Visible="false"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">

                            <asp:Button ID="btnShowData" OnClick="btnShowData_Click" runat="server" Text="Save Data" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblResult" runat="server" Text="" Visible="true"></asp:Label>
                        </div>
                    </div>
                    <br />
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownHospitals" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="DropDownClinics" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="DropDownRoles" EventName="SelectedIndexChanged" />

                <asp:AsyncPostBackTrigger ControlID="btnShowData" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <!--User list belongs only this user's clinic-->

    </section>

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>
    <link href="css/select2.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

    <script>

        $(function () {

            fixDropWidth();
            BinddropdownHospitals();
            BinddropdownHRClinics();
            BinddropdownRoles();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fixDropWidth);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownHospitals);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownHRClinics);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BinddropdownRoles);

        });
        function BinddropdownHospitals() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownHospitals.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };
        function BinddropdownHRClinics() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownClinics.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };
        function BinddropdownRoles() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=DropDownRoles.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };

        function fixDropWidth() {
            $("select").width("100%");
        };
    </script>
    <link media="screen" rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <script type="text/javascript">
        function showpopwarning(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "preventDuplicates": true,
                "preventOpenDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "2000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.warning(msg, title);
            return false;
        }
    </script>
    <script type="text/javascript">
        function showpopsuccess(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": true,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "2000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.success(msg, title);
            return false;
        }
    </script>
    <script type="text/javascript">
        function showpoperror(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "2000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.error(msg, title);
            return false;
        }
    </script>
</asp:Content>
