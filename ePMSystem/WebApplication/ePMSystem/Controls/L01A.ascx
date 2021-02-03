<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="L01A.ascx.cs" Inherits="ePMSystem.Controls.UsrContrlTest" %>
										<br />
										<div class="row">
											<div class="col-md-3">
												<div class="controls">
													<span>Full Name:</span>
													<asp:TextBox ID="txtFName" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtFName"></asp:RequiredFieldValidator>
												</div>
											</div>
											<div class="col-md-3">
												<div class="controls">
													<span>First Name:</span>
													<asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="First Name"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
												</div>
											</div>
											<div class="col-md-3">
												<div class="controls">
													<span>Last Name:</span>
													<asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
												</div>
											</div>
											<div class="col-md-3">
												<div class="controls">
													<span>Email :</span>
													<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>

													<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
														ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
														Display="Dynamic" ErrorMessage="Invalid email address" ValidationGroup="A" />
													<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true"></asp:RequiredFieldValidator>
												</div>
											</div>
										</div>
										<br />
										<div class="row">
											<div class="col-md-3">
												<div class="controls">
													<span>Mobile No. :</span>
													<asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Mobile No"></asp:TextBox>
												</div>
											</div>
											<div class="col-md-3">
												<div class="controls">
													<span>Employee No. :</span>
													<asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control" placeholder="Employee No"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="A" SetFocusOnError="true" ControlToValidate="txtEmpNo"></asp:RequiredFieldValidator>
												</div>
											</div>

											<div class="col-md-3">
												<div class="controls">
													<span>Security Access Group :</span>
													<asp:DropDownList ID="DropDownRoles" AutoPostBack="true" runat="server"></asp:DropDownList>
												</div>
											</div>
											<div class="col-md-3">
												<div class="controls">
													<span>Select Position :</span>
													<asp:DropDownList ID="DropDownHRRoles" AutoPostBack="true" runat="server"></asp:DropDownList>
												</div>
											</div>
										</div>
										<br />