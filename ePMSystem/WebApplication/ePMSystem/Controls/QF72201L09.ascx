<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QF72201L09.ascx.cs" Inherits="ePMSystem.Controls.QF72201L09" %>
																
<asp:Panel ID="Panel1" runat="server">
	<div class="box">
		<div class="box-body col-12">
			<%--Forms Area--%>
			<div class="progress" style='height: 30px; margin-top: -15px;'>
				<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
					<h3 style="text-align: center; font-size: larger; margin-top: 10px;">Contract Name:
						<asp:Label ID="lbl_ContractName" runat="server" Text="QDP510QF11"></asp:Label></h3>
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
							<asp:Label ID="lbl_tel" runat="server" Text="tele"></asp:Label>:</span>
						<asp:TextBox ID="txt_tele" CssClass="form-control" runat="server" placeholder="tele"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_tele"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_fax" runat="server" Text="fax"></asp:Label>:</span>
						<asp:TextBox ID="txt_fax" CssClass="form-control" runat="server" placeholder="fax"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_fax"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span><asp:Label ID="lbl_email" runat="server" Text="email"></asp:Label> :</span>
						<asp:TextBox ID="txt_email" CssClass="form-control" runat="server" placeholder="email"></asp:TextBox>

						<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
							ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
							Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="A" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="txt_email" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contrractdate" runat="server" Text="contractday"></asp:Label>
							:</span>
						<input type="date" name="bday" id="txt_contrractdate" runat="server" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractdate"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractday" runat="server" Text="contractday"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractday" runat="server" CssClass="form-control" placeholder="contractday"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractday"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_AuthPer" runat="server" Text="AuthPer"></asp:Label>:</span>
						<asp:TextBox ID="txt_AuthPer" CssClass="form-control" runat="server" placeholder="AuthPer"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_AuthPer"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_representative" runat="server" Text="representative"></asp:Label>:</span>
						<asp:TextBox ID="txt_representative" CssClass="form-control" runat="server" placeholder="representative"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_representative"></asp:RequiredFieldValidator>
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
							<asp:Label ID="lbl_projarea" runat="server" Text="projarea"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_projarea" runat="server" class="form-control" placeholder="projarea"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_projarea"></asp:RequiredFieldValidator>
					</div>
				</div>
				
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_mainclient" runat="server" Text="mainclient"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_mainclient" runat="server" class="form-control" placeholder="mainclient"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_mainclient"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_scopeofwork" runat="server" Text="scopeofwork"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_scopeofwork" runat="server" class="form-control" placeholder="scopeofwork"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_scopeofwork"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_SecondpartyActivityCountry" runat="server" Text="SecondpartyActivityCountry"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_SecondpartyActivityCountry" runat="server" class="form-control" placeholder="SecondpartyActivityCountry"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_SecondpartyActivityCountry"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Secondpartydiscountvalue1" runat="server" Text="Secondpartydiscountvalue1"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_Secondpartydiscountvalue1" runat="server" class="form-control" placeholder="Secondpartydiscountvalue1"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_Secondpartydiscountvalue1"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>

			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Secondpartydiscountvaluetext1" runat="server" Text="Secondpartydiscountvaluetext1"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_Secondpartydiscountvaluetext1" runat="server" class="form-control" placeholder="Secondpartydiscountvaluetext1"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_Secondpartydiscountvaluetext1"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_implementvalueonprojects1" runat="server" Text="implementvalueonprojects1"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_implementvalueonprojects1" runat="server" class="form-control" placeholder="implementvalueonprojects1"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_implementvalueonprojects1"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_implementvalueonprojects2" runat="server" Text="implementvalueonprojects2"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_implementvalueonprojects2" runat="server" class="form-control" placeholder="implementvalueonprojects2"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_implementvalueonprojects2"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_secondpartydurationforpayment" runat="server" Text="secondpartydurationforpayment"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_secondpartydurationforpayment" runat="server" class="form-control" placeholder="secondpartydurationforpayment"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_secondpartydurationforpayment"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_secondpartymaximumtimetopay" runat="server" Text="secondpartymaximumtimetopay"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_secondpartymaximumtimetopay" runat="server" class="form-control" placeholder="secondpartymaximumtimetopay"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_secondpartymaximumtimetopay"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
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
				<asp:CheckBox ID="chkb_AppendixA" runat="server" Text="Special Condition + Scope of works" TextAlign="Right" Checked="True" Enabled="False" />

				<div class="col-md-10">
					<%--<asp:FileUpload ID="FU_AppendixA" runat="server" class="form-control" />--%>
					<asp:Button ID="btn_AppA" runat="server" OnClick="btn_AppA_Click" Text="Appendix A" Visible="false" />
					<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
					<br />
					<asp:LinkButton ID="lnkbtn_appendixB" runat="server" Visible="false">Download</asp:LinkButton>
				</div>
			</div>

			<div class="row">


				<asp:CheckBox ID="chkb_AppendixB" runat="server" Text="BOQ" TextAlign="Right" Checked="True" Enabled="False" />

				<div class="col-md-10">
					<asp:FileUpload ID="FU_AppendixB" runat="server" AllowMultiple="true" class="form-control" />
					<asp:Button ID="btn_AppB" runat="server" Text="Appendix B" OnClick="btn_AppB_Click" Visible="false" />
				</div>
			</div>

			<div class="row">
				<asp:CheckBox ID="chkb_AppendixC" runat="server" Text="Time schedule" TextAlign="Right" />

				<div class="col-md-10">
					<asp:FileUpload ID="FU_AppendixC" runat="server" AllowMultiple="true" class="form-control" />
					<asp:Button ID="btn_AppC" runat="server" Text="Appendix C" OnClick="btn_AppC_Click" Visible="false" />
				</div>
			</div>

			<div class="row">
				<asp:CheckBox ID="chkb_AppendixD" runat="server" Text="Drawings" TextAlign="Right" />

				<div class="col-md-10">
					<asp:FileUpload ID="FU_AppendixD" runat="server" AllowMultiple="true" class="form-control" />
					<asp:Button ID="btn_AppD" runat="server" Text="Appendix D" OnClick="btn_AppD_Click" Visible="false" />
				</div>
			</div>

			<div class="row">
				<asp:CheckBox ID="chkb_AppendixE" runat="server" Text="letter of credit" TextAlign="Right" />
				<div class="col-md-10">
					<asp:FileUpload ID="FU_AppendixE" runat="server" AllowMultiple="true" class="form-control" />
					<asp:Button ID="btn_AppE" runat="server" Text="Appendix E" OnClick="btn_AppE_Click" Visible="false" />
				</div>
			</div>

			<div class="row">
				<asp:CheckBox ID="chkb_AppendixF" runat="server" Text="Specifications" TextAlign="Right" />

				<div class="col-md-10">
					<asp:FileUpload ID="FU_AppendixF" runat="server" AllowMultiple="true" class="form-control" />
					<asp:Button ID="btn_AppF" runat="server" Text="Appendix F" OnClick="btn_AppF_Click" Visible="false" />
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
			<%--Save & Print Buttons Area--%>
			<%--<div class="progress" style='height: 30px; margin-top: -15px;'>
				<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
					<h3 style="text-align: center; font-size: larger; margin-top: 10px;">
						<asp:Label ID="Label1" runat="server" Text="Save & Print"></asp:Label></h3>
				</div>
			</div>--%>
                        <asp:Button ID="btnShowData" runat="server" Text="Save Data" CssClass="btn btn-info btn-sm" ValidationGroup="A" />
			
			<%--Save & Print Buttons Area--%>
		</div>
	</div>
</asp:Panel>