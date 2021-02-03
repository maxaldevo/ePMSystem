<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddNewContract.aspx.cs" Inherits="WebApplication1.AddNewContract" %>

<%@ Register Src="~/Controls/UsrContrlTest.ascx" TagPrefix="uc1" TagName="UsrContrlTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .tr.group,
        .tr.group:hover {
            background-color: green !important;
        }

        .group td {
            background-color: #23B3E8 !important;
            color: white;
            font-weight: bold
        }

        .row {
            margin-top: -10px;
        }

        table thead tr {
            background-color: #23B3e8;
            color: white;
            font-weight: bold;
        }

        table {
            text-align: center;
        }

        #circle {
            position: absolute;
            top: 35%;
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
            top: 35%;
            left: 60%;
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

						<div class="progress" style='height: 30px; margin-top: -15px;'>
							<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
								<h3 style="text-align: center; font-size: larger; margin-top: 10px;">Manage Courses Schedule/Sessions</h3>
							</div>
						</div>
					</div>
				</div>
				<div class="row">
					<div class="col-md-6">
						<div class="form-group">
							<span>Please select Contract Type :</span>
							<asp:DropDownList ID="dropdownContractType" runat="server" AutoPostBack="true">
							</asp:DropDownList>
						</div>
					</div>
					<div class="col-md-2">
						<div class="form-group">
							<span>Show Form:</span><br />
							<asp:Button ID="btnfillform" runat="server" Text="Filling Form" CssClass="btn btn-info btn-md" OnClick="btnfillform_Click" />
						</div>
					</div>
				</div>
				<div class="row justify-content-left">
					<div class="col-md-6">
						<asp:Label ID="lblResult" runat="server" Font-Bold="true" Font-Size="Larger" Text=""></asp:Label>
					</div>
				</div>
                <br />
				<div class="row">
					<div class="col-12">
						<asp:Panel ID="Panel1" runat="server" Visible="true">
							<div class="box">
								<div class="box-body col-12">
									<%--Forms Area--%>
                                    <uc1:UsrContrlTest runat="server" id="UsrContrlTest" Visible="false" />
									<%--Forms Area--%>
								</div>
								</div>
						</asp:Panel>
					</div>
				</div>
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dropdownContractType" EventName="SelectedIndexChanged" />
                
                <asp:AsyncPostBackTrigger ControlID="btnfillform" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </section>

    <link href="js/toaster/toastr.min.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="js/toaster/toastr.min.js"></script>
    <script src="js/toaster/script.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/rowgroup/1.1.2/css/rowGroup.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.4.0/css/buttons.dataTables.min.css" />

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.27/build/pdfmake.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.27/build/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/rowgroup/1.1.2/js/dataTables.rowGroup.min.js"></script>

    <script src="https://cdn.datatables.net/buttons/1.4.0/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.0/js/buttons.flash.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.0/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.0/js/buttons.print.min.js"></script>

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" defer></script>
    <link href="../css/select2.css" rel="stylesheet" />
    <script>

        $(function () {
            bindselect();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindselect);

        });
        function bindselect() {
            $(document).ready(function () {
                var oTable = $('#' + '<%=dropdownContractType.ClientID%>').select2({
                    placeholder: "Select an option",
                    allowClear: true
                });
            });
        };
    </script>
</asp:Content>