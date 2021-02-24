<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QF72201L01D.ascx.cs" Inherits="ePMSystem.Controls.QF72201L01D" %>


<asp:Panel ID="Panel1" runat="server">
	<div class="box">
		<div class="box-body col-12">
			<%--Forms Area--%>
			<div class="progress" style='height: 30px; margin-top: -15px;'>
				<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
					<h3 style="text-align: center; font-size: larger; margin-top: 10px;">Contract Name:
						<asp:Label ID="lbl_ContractName" runat="server" Text="QF72201L01D - Subcontract  works contract Remeasured "></asp:Label></h3>
				</div>
			</div>
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_compname" runat="server" Text="compname"></asp:Label>:</span>
						<asp:TextBox ID="txt_compname" CssClass="form-control" runat="server" placeholder="compname"></asp:TextBox><br />
					En<asp:TextBox ID="txt_compname_En" runat="server" class="form-control" placeholder="compname_En"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_compname"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_address" runat="server" Text="address"></asp:Label>:</span>
						<asp:TextBox ID="txt_address" CssClass="form-control" runat="server" placeholder="address"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_address_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_address"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_tel" runat="server" Text="tele"></asp:Label>:</span>
						<asp:TextBox ID="txt_tele" CssClass="form-control" runat="server" placeholder="tele"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_tele_En" runat="server" placeholder="Enter telephone number En" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_tele"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_fax" runat="server" Text="fax"></asp:Label>:</span>
						<asp:TextBox ID="txt_fax" CssClass="form-control" runat="server" placeholder="fax"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_fax_En" runat="server" placeholder="Enter fax number En" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_fax"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span><asp:Label ID="lbl_email" runat="server" Text="email"></asp:Label> :</span>
						<asp:TextBox ID="txt_email" CssClass="form-control" runat="server" placeholder="email"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_email_En" runat="server" class="form-control"></asp:TextBox>

						<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
							ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
							Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="A" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="txt_email" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contrractdate" runat="server" Text="contrractdate"></asp:Label>
							:</span>
						<input type="date" name="bday" id="txt_contrractdate" runat="server" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" /><br />
						<input type="date" name="bday" id="txt_contrractdate_En" runat="server" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contrractdate"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractday" runat="server" Text="contractday"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractday" runat="server" CssClass="form-control" placeholder="contractday"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_contractday_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractday"></asp:RequiredFieldValidator>
					</div>
				</div>
				
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_AuthPer" runat="server" Text="AuthPer"></asp:Label>:</span>
						<asp:TextBox ID="txt_AuthPer" CssClass="form-control" runat="server" placeholder="AuthPer"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_AuthPer_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_AuthPer"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_representative" runat="server" Text="representative"></asp:Label>:</span>
						<asp:TextBox ID="txt_representative" CssClass="form-control" runat="server" placeholder="representative"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_representative_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_representative"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_materialCertificates" runat="server" Text="materialCertificates"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_materialCertificates" runat="server" class="form-control" placeholder="materialCertificates"></asp:TextBox><br />
					En<asp:TextBox ID="txt_materialCertificates_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_materialCertificates"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_removegarbage" runat="server" Text="removegarbage"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_removegarbage" runat="server" class="form-control" placeholder="removegarbage"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_removegarbage"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_mainclient" runat="server" Text="mainclient"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_mainclient" runat="server" class="form-control" placeholder="mainclient"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_mainclient_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_mainclient"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_projname" runat="server" Text="projname"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_projname" runat="server" class="form-control" placeholder="projname"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_projname_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_projname"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_projno" runat="server" Text="projno"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_projno" runat="server" class="form-control" placeholder="projno"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_projno_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_projno"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_scopeofwork" runat="server" Text="scopeofwork"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_scopeofwork" runat="server" class="form-control" placeholder="scopeofwork"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_scopeofwork_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_scopeofwork"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_delaypenaltyvalue" runat="server" Text="delaypenaltyvalue"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_delaypenaltyvalue" runat="server" class="form-control" placeholder="delaypenaltyvalue"></asp:TextBox>
                                                <asp:DropDownList ID="ddl_delaypenalty" runat="server" Width="234px" CssClass="custom-select form-control">
                                                    <asp:ListItem>كل يوم</asp:ListItem>
                                                    <asp:ListItem>كل اسبوع</asp:ListItem>
                                                </asp:DropDownList><br />
                                                En<asp:TextBox ID="txt_delaypenaltyvalue_En" runat="server" class="form-control"></asp:TextBox>
                                                En<asp:DropDownList ID="ddl_delaypenalty_En" runat="server" Width="234px" CssClass="custom-select form-control">
                                                    <asp:ListItem>Everyday</asp:ListItem>
                                                    <asp:ListItem>Everyweek</asp:ListItem>
                                                </asp:DropDownList>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_delaypenaltyvalue"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_absentpenality" runat="server" Text="absentpenality"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_absentpenality" runat="server" class="form-control" placeholder="absentpenality"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_absentpenality_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_absentpenality"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_insurance" runat="server" Text="projno"></asp:Label>
							:</span>
                                                <asp:DropDownList ID="ddl_insurance" runat="server" Width="234px" CssClass="custom-select form-control">
                                                    <asp:ListItem>0%</asp:ListItem>
                                                    <asp:ListItem>1%</asp:ListItem>
                                                    <asp:ListItem>2%</asp:ListItem>
                                                </asp:DropDownList><br />
                                                En<asp:DropDownList ID="ddl_insurance_En" runat="server" Width="234px" CssClass="custom-select form-control">
                                                    <asp:ListItem>0%</asp:ListItem>
                                                    <asp:ListItem>1%</asp:ListItem>
                                                    <asp:ListItem>2%</asp:ListItem>
                                                </asp:DropDownList>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="ddl_insurance"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_performanbond" runat="server" Text=""></asp:Label>
							:</span>
                                                <asp:DropDownList ID="ddl_performanbond" runat="server" Width="234px" CssClass="custom-select form-control">
                                                    <asp:ListItem>0%</asp:ListItem>
                                                    <asp:ListItem>5%</asp:ListItem>
                                                    <asp:ListItem>10%</asp:ListItem>
                                                </asp:DropDownList><br />
                                                En<asp:DropDownList ID="ddl_performanbond_En" runat="server" Width="234px" CssClass="custom-select form-control">
                                                    <asp:ListItem>0%</asp:ListItem>
                                                    <asp:ListItem>5%</asp:ListItem>
                                                    <asp:ListItem>10%</asp:ListItem>
                                                </asp:DropDownList>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="ddl_performanbond"></asp:RequiredFieldValidator>
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
						<asp:TextBox ID="txt_contractvaluenum" runat="server" CssClass="form-control" placeholder="contractvaluenum"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_contractvaluenum_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractvaluenum"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractvaluetext" runat="server" Text="contractvaluetext"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractvaluetext" runat="server" class="form-control" placeholder="contractvaluetext"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_contractvaluetext_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractvaluetext"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_currencycode" runat="server" Text="currencycode"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_currencycode" runat="server" class="form-control" placeholder="currencycode"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_currencycode_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_currencycode"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_currencyname" runat="server" Text="currencyname"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_currencyname" runat="server" class="form-control" placeholder="currencyname"></asp:TextBox><br />
                                                En<asp:TextBox ID="txt_currencyname_En" runat="server" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_projno"></asp:RequiredFieldValidator>
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