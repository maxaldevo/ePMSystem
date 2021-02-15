<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QDP510QF11.ascx.cs" Inherits="ePMSystem.Controls.QDP510QF11" %>

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
							<asp:Label ID="lbl_SecondAuthPer" runat="server" Text="SecondAuthPer"></asp:Label>:</span>
						<asp:TextBox ID="txt_SecondAuthPer" CssClass="form-control" runat="server" placeholder="SecondAuthPer"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_SecondAuthPer"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_primaryAuthPer" runat="server" Text="primaryAuthPer"></asp:Label>:</span>
						<asp:TextBox ID="txt_primaryAuthPer" CssClass="form-control" runat="server" placeholder="primaryAuthPer"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_primaryAuthPer"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_Secondcompname" runat="server" Text="Secondcompname"></asp:Label>:</span>
						<asp:TextBox ID="txt_Secondcompname" CssClass="form-control" runat="server" placeholder="Secondcompname"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_Secondcompname"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contrractdate" runat="server" Text="contrractdate"></asp:Label>:</span>
						<input type="date" name="bday" id="txt_contrractdate" runat="server" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contrractdate"></asp:RequiredFieldValidator>
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
						<asp:TextBox ID="txt_contractday" runat="server" CssClass="form-control" placeholder="contractday"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractday"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_contractvaluenum" runat="server" Text="contractvaluenum"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_contractvaluenum" runat="server" CssClass="form-control" placeholder="contractvaluenum"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_contractvaluenum"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_civilId" runat="server" Text="civilId"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_civilId" runat="server" class="form-control" placholder="civilId"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_civilId"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_materialtype" runat="server" Text="materialtype"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_materialtype" runat="server" class="form-control" placholder="materialtype"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_materialtype"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_materialserial" runat="server" Text="materialserial"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_materialserial" runat="server" class="form-control" placholder="materialserial"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_materialserial"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_materialmanufactureyear" runat="server" Text="materialmanufactureyear"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_materialmanufactureyear" runat="server" class="form-control" placholder="materialmanufactureyear"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_materialmanufactureyear"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_materialstatus" runat="server" Text="materialstatus"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_materialstatus" runat="server" class="form-control" placholder="materialstatus"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_materialstatus"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_bulkvalue" runat="server" Text="bulkvalue"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_bulkvalue" runat="server" class="form-control" placholder="bulkvalue"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_bulkvalue"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_balancepayafterdays" runat="server" Text="balancepayafterdays"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_balancepayafterdays" runat="server" class="form-control" placholder="balancepayafterdays"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_balancepayafterdays"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="col-md-3">
					<div class="controls">
						<span>
							<asp:Label ID="lbl_receiveduration" runat="server" Text="receiveduration"></asp:Label>
							:</span>
						<asp:TextBox ID="txt_receiveduration" runat="server" class="form-control" placholder="receiveduration"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txt_receiveduration"></asp:RequiredFieldValidator>
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
			<%--Save & Print Buttons Area--%>
			<%--<div class="progress" style='height: 30px; margin-top: -15px;'>
				<div class="progress-bar" role="progressbar" style="width: 100%; height: 30px; background-color: #23B3e8" aria-valuemin="0" aria-valuemax="100">
					<h3 style="text-align: center; font-size: larger; margin-top: 10px;">
						<asp:Label ID="Label1" runat="server" Text="Save & Print"></asp:Label></h3>
				</div>
			</div>--%>
                        <asp:Button ID="btnShowData" runat="server" Text="Save Data" CssClass="btn btn-info btn-sm" ValidationGroup="A" OnClick="btnShowData_Click"/>
			
			<%--Save & Print Buttons Area--%>
		</div>
	</div>
</asp:Panel>
