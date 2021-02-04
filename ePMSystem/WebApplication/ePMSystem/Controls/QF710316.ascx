<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QF710316.ascx.cs" Inherits="ePMSystem.Controls.QF710316" %>
			


<asp:Panel ID="Panel1" runat="server">
	<div class="box">
		<div class="box-body col-12">
			<%--Forms Area--%>
			<div class="progress" style='height: 30px; margin-top: -15px;'>
				<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
					<h3 style="text-align: center; font-size: larger; margin-top: 10px;">Contract Name:
						<asp:Label ID="lbl_ContractName" runat="server" Text="QF710316"></asp:Label></h3>
				</div>
			</div>
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_compname" runat="server" Text="compname"></asp:Label>:</span>
						<asp:TextBox ID="txt_compname" CssClass="form-control" runat="server" placeholder="compname"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_compname"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_address" runat="server" Text="address"></asp:Label>:</span>
						<asp:TextBox ID="txt_address" CssClass="form-control" runat="server" placeholder="address"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_address"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_tel" runat="server" Text="tel"></asp:Label>:</span>
						<asp:TextBox ID="txt_tele" CssClass="form-control" runat="server" placeholder="tel"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_tele"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_fax" runat="server" Text="fax"></asp:Label>:</span>
						<asp:TextBox ID="txt_fax" CssClass="form-control" runat="server" placeholder="fax"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_fax"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span><asp:Label ID="lbl_email" runat="server" Text="email"></asp:Label> :</span>
						<asp:TextBox ID="txt_email" CssClass="form-control" runat="server" placeholder="email"></asp:TextBox>

						<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
							ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
							Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="A" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_email" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_AuthPer" runat="server" Text="AuthPer"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_AuthPer" runat="server" class="form-control" placeholder="AuthPer"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_AuthPer"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_representative" runat="server" Text="representative"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_representative" runat="server" class="form-control" placeholder="representative"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_representative"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contrractdate" runat="server" Text="contrractdate"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contrractdate" runat="server" class="form-control" placeholder="contrractdate"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contrractdate"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractday" runat="server" Text="contractday"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractday" runat="server" class="form-control" placeholder="contractday"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractday"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_mainclient" runat="server" Text="mainclient"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_mainclient" runat="server" class="form-control" placeholder="mainclient"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_mainclient"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_ContractDuration" runat="server" Text="ContractDuration"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_ContractDuration" runat="server" class="form-control" placeholder="ContractDuration"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_ContractDuration"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_projno" runat="server" Text="projno"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_projno" runat="server" class="form-control" placeholder="projno"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_projno"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_scopeofwork" runat="server" Text="scopeofwork"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_scopeofwork" runat="server" class="form-control" placeholder="scopeofwork"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_scopeofwork"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractvaluenum" runat="server" Text="contractvaluenum"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractvaluenum" runat="server" class="form-control" placeholder="contractvaluenum"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractvaluenum"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractvaluetext" runat="server" Text="contractvaluetext"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractvaluetext" runat="server" class="form-control" placeholder="contractvaluetext"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractvaluetext"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_TonAsphaltPricevalue_V" runat="server" Text="TonAsphaltPricevalue"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_TonAsphaltPricevalue" runat="server" class="form-control" placeholder="TonAsphaltPricevalue"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_TonAsphaltPricevalue"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_TonAsphaltPricevalue_T" runat="server" Text="TonAsphaltPricetext"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_TonAsphaltPricetext" runat="server" class="form-control" placeholder="TonAsphaltPricetext"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_TonAsphaltPricetext"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Durationofpaymentmethod_V" runat="server" Text="Durationofpaymentmethod"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_Durationofpaymentmethod" runat="server" class="form-control" placeholder="Durationofpaymentmethod"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_Durationofpaymentmethod"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Durationofpaymentmethod_T" runat="server" Text="Durationofpaymentmethodtext"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_Durationofpaymentmethodtext" runat="server" class="form-control" placeholder="Durationofpaymentmethodtext"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_Durationofpaymentmethodtext"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_BalancePercentage" runat="server" Text="BalancePercentage"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_BalancePercentage" runat="server" class="form-control" placeholder="BalancePercentage"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_BalancePercentage"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_ApprovalDocumentValue_V" runat="server" Text="ApprovalDocumentValue"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_ApprovalDocumentValue" runat="server" class="form-control" placeholder="ApprovalDocumentValue"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_ApprovalDocumentValue"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_ApprovalDocumentValue_T" runat="server" Text="ApprovalDocumenttext"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_ApprovalDocumenttext" runat="server" class="form-control" placeholder="ApprovalDocumenttext"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_ApprovalDocumenttext"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Asphaltworkspace" runat="server" Text="Asphaltworkspace"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_Asphaltworkspace" runat="server" class="form-control" placeholder="Asphaltworkspace"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_Asphaltworkspace"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_ApprovalDocumentDurationbyday" runat="server" Text="ApprovalDocumentDurationbyday"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_ApprovalDocumentDurationbyday" runat="server" class="form-control" placeholder="ApprovalDocumentDurationbyday"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_ApprovalDocumentDurationbyday"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>

			<br />
			<%--Forms Area--%>
		</div>
	</div>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server">
	<div class="box">
		<div class="box-body col-12">
			<%--Appendix Area--%>
			<div class="progress" style='height: 30px; margin-top: -15px;'>
				<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
					<h3 style="text-align: center; font-size: larger; margin-top: 10px;">
						<asp:Label ID="lbl_AppendixList" runat="server" Text="Appendix List"></asp:Label></h3>
				</div>
			</div>
			<div class="row">
				
			</div>
			<br />
			<div class="row">
				
			</div>
			<br />
			<div class="row">
				
			</div>
			<br />
			<div class="row">
				
			</div>

			<br />
			<%--Appendix Area--%>
		</div>
	</div>
</asp:Panel>
<asp:Panel ID="Panel3" runat="server">
	<div class="box">
		<div class="box-body col-12">
                        <asp:Button ID="btnShowData" runat="server" Text="Save Data" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
			
		</div>
	</div>
</asp:Panel>