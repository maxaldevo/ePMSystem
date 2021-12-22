<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LimitedHeader.ascx.cs" Inherits="WebApplication1.Controls.LimitedHeader" %>

<li class="header nav-small-cap">The Hospital System</li>
<li id="Home">
    <a href="Default.aspx">
       <i class="ti-home"></i><span>Home</span>
    </a>
</li>
<li id="upper" class="treeview">
    <a href="#">
        <i class="ti-dashboard"></i>
        <span>Training</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
<%--        <li id="Home"><a href="Default.aspx"><i class="ti-more"></i>Home</a></li>--%>
        <li id="Courses"><a href="Courses.aspx"><i class="ti-more"></i>E-Learning</a></li>
        <li id="CLACourses"><a href="CLACourses.aspx"><i class="ti-more"></i>Classroom Training</a></li>
   <li id="OJT"><a href="/OTSTrainingStatus.aspx"><i class="ti-more"></i>OJT Training</a></li>
        <li id="OTS"><a href="/OJTTrainingStatus.aspx"><i class="ti-more"></i>OTS Training</a></li>
    </ul>
</li>

<li id="upper" class="treeview">
    <a href="#">
        <i class="ti-pie-chart"></i>
        <span>Feedback</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
        <li id="FeedbackCourseByUser"><a href="/FeedbackCourseByUser.aspx"><i class="ti-more"></i>User Feedback Courses</a></li>
   
    </ul>
</li>

<li class="treeview">
    <%--<li class="treeview menu-open">--%>
    <a href="#">
        <i class="ti-check-box"></i>
        <span>Assessment</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
       <%-- <li><a href="https://kipiclms.azurewebsites.net/" target="_blank"><i class="ti-more"></i>Gap Analysis</a></li>--%>
          <li><a href="/GapAnalysisTakeExam.aspx"><i class="ti-more"></i>Gap Analysis</a></li>
         <li><a href="/ClassroomAssessmentByUser.aspx"><i class="ti-more"></i>Classroom Assessment</a></li>
    </ul>
</li>

<li class="treeview">
    <a href="#">
        <i class="ti-stats-up"></i>
        <span>Reports</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
    <%--    <li><a href="#"><i class="ti-more"></i>Report1</a></li>
        <li><a href="#"><i class="ti-more"></i>Report2</a></li>--%>
    </ul>
</li>

<li class="treeview">
    <a href="#">
        <i class="ti-user"></i>
        <span>Account</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
         <li><a href="/AccountSettings.aspx"><i class="ti-more"></i>Account Settings</a></li>
        <li id="Profile"><a href="Profile.aspx"><i class="ti-more"></i>Profile</a></li>
    </ul>
</li>



<li>
    <asp:LinkButton ID="LinB1" runat="server" OnClick="LinB1_Click">
       <i class="ti-power-off"></i><span>Log Out</span>
    </asp:LinkButton>
</li>
<script type="text/javascript">
    function UserDeleteConfirmation() {
        return confirm("Are you sure you want to Log out?");
    }
</script>