﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QF7220110.ascx.cs" Inherits="ePMSystem.Controls.QF7220110" %>
			


<asp:Panel ID="Panel1" runat="server">
	<div class="box">
		<div class="box-body col-12">
			<%--Forms Area--%>
			<div class="progress" style='height: 30px; margin-top: -15px;'>
				<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
					<h3 style="text-align: center; font-size: larger; margin-top: 10px;">Contract Name:
						<asp:Label ID="lbl_ContractName" runat="server" Text="QF7220110 - Debris Transporting Contract"></asp:Label></h3>
				</div>
			</div>
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_AuthPer" runat="server" Text="AuthPer"></asp:Label>:</span>
						<asp:TextBox ID="txt_AuthPer" CssClass="form-control" runat="server" placeholder="AuthPer"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_AuthPer"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_representative" runat="server" Text="representative"></asp:Label>:</span>
						<asp:TextBox ID="txt_representative" CssClass="form-control" runat="server" placeholder="representative"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_representative"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_secondCompname" runat="server" Text="tel"></asp:Label>:</span>
						<asp:TextBox ID="txt_secondcompname" CssClass="form-control" runat="server" placeholder="secondcompname"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="secondcompname"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Secondaddress" runat="server" Text="fax"></asp:Label>:</span>
						<asp:TextBox ID="txt_secondaddress" CssClass="form-control" runat="server" placeholder="secondaddress"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="secondaddress"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_secondtel" runat="server" Text="secondtele"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_secondtele" runat="server" CssClass="form-control" placeholder="secondtele"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_secondtele"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_secondfax" runat="server" Text="secondfax"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_secondfax" runat="server" CssClass="form-control" placeholder="secondfax"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_secondfax"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span><asp:Label ID="lbl_secondemail" runat="server" Text="email"></asp:Label> :</span>
						<asp:TextBox ID="txt_secondemail" CssClass="form-control" runat="server" placeholder="email"></asp:TextBox>

						<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_secondemail"
							ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
							Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="A" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_secondemail" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_secondAuthPer" runat="server" Text="secondAuthPer"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_secondAuthPer" runat="server" class="form-control" placeholder="secondAuthPer"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_secondAuthPer"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_secondrepresentative" runat="server" Text="secondrepresentative"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_secondrepresentative" runat="server" class="form-control" placeholder="secondrepresentative"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_secondrepresentative"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contrractdate" runat="server" Text="contrractdate"></asp:Label>:</span>
						<input type="date" name="bday" id="txt_contrractdate" runat="server" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contrractdate"></asp:RequiredFieldValidator>
					</div>
				</div>
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
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_projname" runat="server" Text="projname"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_projname" runat="server" class="form-control" placeholder="projname"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_projname"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_projno" runat="server" Text="projno"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_projno" runat="server" class="form-control" placeholder="projno"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_projno"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Doingbusinessduringperiodbyday" runat="server" Text="Doingbusinessduringperiodbyday"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_Doingbusinessduringperiodbyday" runat="server" class="form-control" placeholder="Doingbusinessduringperiodbyday"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_Doingbusinessduringperiodbyday"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_delaypenaltyvalue" runat="server" Text="delaypenaltyvalue"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_delaypenaltyvalue" runat="server" class="form-control" placeholder="delaypenaltyvalue"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_delaypenaltyvalue"></asp:RequiredFieldValidator>
					</div>
				</div>
				
			</div>
			<br />
			<div class="row">
				
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractvaluenum" runat="server" Text="contractvaluenum"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractvaluenum" runat="server" class="form-control" placeholder="contractvaluenum"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractvaluenum"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractvaluetext" runat="server" Text="contractvaluetext"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractvaluetext" runat="server" class="form-control" placeholder="contractvaluetext"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractvaluetext"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_totalamountburial" runat="server" Text="totalamountburial"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_totalamountburial" runat="server" class="form-control" placeholder="totalamountburial"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_totalamountburial"></asp:RequiredFieldValidator>
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
				<asp:CheckBox ID="chkb_AppendixB" runat="server" Text="BOQ" TextAlign="Right" Checked="True" Enabled="False" />

				<div class="col-md-10">
					<asp:FileUpload ID="FU_AppendixB" runat="server" AllowMultiple="true" class="form-control" />
					<asp:Button ID="btn_AppB" runat="server" Text="Appendix B" Visible="false" />
				</div>
			</div>
			<br />

			<div class="row">
				<asp:CheckBox ID="chkb_AppendixC" runat="server" Text="Time schedule" TextAlign="Right" />

				<div class="col-md-10">
					<asp:FileUpload ID="FU_AppendixC" runat="server" AllowMultiple="true" class="form-control" />
					<asp:Button ID="btn_AppC" runat="server" Text="Appendix C" Visible="false" />
				</div>
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