<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddNewContract.aspx.cs" Inherits="WebApplication1.AddNewContract" %>

<%@ Register Src="~/Controls/QDP510QF11.ascx" TagPrefix="uc1" TagName="QDP510QF11" %>
<%@ Register Src="~/Controls/QDP510QF17.ascx" TagPrefix="uc1" TagName="QDP510QF17" %>
<%@ Register Src="~/Controls/QF710315.ascx" TagPrefix="uc1" TagName="QF710315" %>
<%@ Register Src="~/Controls/QF710316.ascx" TagPrefix="uc1" TagName="QF710316" %>
<%@ Register Src="~/Controls/QF710405.ascx" TagPrefix="uc1" TagName="QF710405" %>
<%@ Register Src="~/Controls/QF7220109.ascx" TagPrefix="uc1" TagName="QF7220109" %>
<%@ Register Src="~/Controls/QF7220110.ascx" TagPrefix="uc1" TagName="QF7220110" %>
<%@ Register Src="~/Controls/QF7220111.ascx" TagPrefix="uc1" TagName="QF7220111" %>
<%@ Register Src="~/Controls/QF7220112.ascx" TagPrefix="uc1" TagName="QF7220112" %>
<%@ Register Src="~/Controls/QF72201E15.ascx" TagPrefix="uc1" TagName="QF72201E15" %>
<%@ Register Src="~/Controls/QF72201L01A.ascx" TagPrefix="uc1" TagName="QF72201L01A" %>
<%@ Register Src="~/Controls/QF72201L01B.ascx" TagPrefix="uc1" TagName="QF72201L01B" %>
<%@ Register Src="~/Controls/QF72201L01C.ascx" TagPrefix="uc1" TagName="QF72201L01C" %>
<%@ Register Src="~/Controls/QF72201L01D.ascx" TagPrefix="uc1" TagName="QF72201L01D" %>
<%@ Register Src="~/Controls/QF72201L02A.ascx" TagPrefix="uc1" TagName="QF72201L02A" %>
<%@ Register Src="~/Controls/QF72201L02B.ascx" TagPrefix="uc1" TagName="QF72201L02B" %>
<%@ Register Src="~/Controls/QF72201L03A.ascx" TagPrefix="uc1" TagName="QF72201L03A" %>
<%@ Register Src="~/Controls/QF72201L03B.ascx" TagPrefix="uc1" TagName="QF72201L03B" %>
<%@ Register Src="~/Controls/QF72201L09.ascx" TagPrefix="uc1" TagName="QF72201L09" %>
<%@ Register Src="~/Controls/QF72201L10.ascx" TagPrefix="uc1" TagName="QF72201L10" %>
<%@ Register Src="~/Controls/QF72201L12.ascx" TagPrefix="uc1" TagName="QF72201L12" %>
<%@ Register Src="~/Controls/QF72201L15.ascx" TagPrefix="uc1" TagName="QF72201L15" %>
<%@ Register Src="~/Controls/QF72201L1511.ascx" TagPrefix="uc1" TagName="QF72201L1511" %>
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
								<h3 style="text-align: center; font-size: larger; margin-top: 10px;">Fill New Contract</h3>
							</div>
						</div>
					</div>
				</div>
				<div class="row">
					<div class="col-md-6">
						<div class="form-group">
							<span>Please select Contract Type :</span>
							<asp:DropDownList ID="dropdownContractType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdownContractType_SelectedIndexChanged">
							</asp:DropDownList>
						</div>
					</div>
					<div class="col-md-2">
						<div class="form-group">
							<%--<span>Show Form:</span><br />
							<asp:Button ID="btnfillform" runat="server" Text="Filling Form" CssClass="btn btn-info btn-md" OnClick="btnfillform_Click" />--%>
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
                                    <uc1:QF72201L01A runat="server" id="QF72201L01A" Visible="false" />
                                    <uc1:QF72201L01B runat="server" id="QF72201L01B" Visible="false" />
                                    <uc1:QF72201L02A runat="server" id="QF72201L02A" Visible="false" />
                                    <uc1:QF72201L02B runat="server" id="QF72201L02B" Visible="false" />
                                    <uc1:QF72201L01D runat="server" id="QF72201L01D" Visible="false" />
                                    <uc1:QF710315 runat="server" id="QF710315" Visible="false" />
                                    <uc1:QF710316 runat="server" id="QF710316" Visible="true" />
                                    <uc1:QF710405 runat="server" id="QF710405" Visible="false" />
                                    <uc1:QF7220109 runat="server" id="QF7220109" Visible="false" />
                                    <uc1:QF7220110 runat="server" id="QF7220110" Visible="false" />
                                    <uc1:QF7220111 runat="server" id="QF7220111" Visible="false" />
                                    <uc1:QF7220112 runat="server" id="QF7220112" Visible="false" />
                                    <uc1:QF72201L12 runat="server" id="QF72201L12" Visible="false" />
                                    <uc1:QF72201L01C runat="server" id="QF72201L01C" Visible="false" />
                                    <uc1:QDP510QF11 runat="server" id="QDP510QF11" Visible="false" />
                                    <uc1:QDP510QF17 runat="server" id="QDP510QF17" Visible="false" />
                                    <uc1:QF72201L09 runat="server" id="QF72201L09" Visible="false" />
                                    <uc1:QF72201E15 runat="server" id="QF72201E15" Visible="false" />
                                    <uc1:QF72201L03A runat="server" id="QF72201L03A" Visible="false" />
                                    <uc1:QF72201L03B runat="server" id="QF72201L03B" Visible="false" />
                                    <uc1:QF72201L10 runat="server" id="QF72201L10" Visible="false" />
                                    <uc1:QF72201L15 runat="server" id="QF72201L15" Visible="false" />
                                    <uc1:QF72201L1511 runat="server" id="QF72201L1511" Visible="false" />

					</div>
				</div>
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dropdownContractType" EventName="SelectedIndexChanged" />
                
                <%--<asp:AsyncPostBackTrigger ControlID="btnfillform" EventName="Click" />--%>
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