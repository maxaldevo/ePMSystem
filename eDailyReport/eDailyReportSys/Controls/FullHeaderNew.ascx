<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FullHeaderNew.ascx.cs" Inherits="WebApplication1.Controls.FullHeaderNew" %>

<li class="header nav-small-cap">The Hospital System</li>
<%-- <li <a href="Default.aspx"><i class="ti-more"></i>Home</a></li>--%>
<li id="Home">
    <a href="Default.aspx">
       <i class="ti-home"></i><span>Home</span>
    </a>
</li>
<li id="dashboard" class="treeview">
    <a href="#">
        <i class="ti-dashboard"></i>
        <span>Training</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
       
        <li id="Courses"><a href="Courses.aspx"><i class="ti-more"></i>E-Learning</a></li>
        <li id="CLACourses"><a href="CLACourses.aspx"><i class="ti-more"></i>Classroom Training</a></li>
        <li id="OJT"><a href="/OTSTrainingStatus.aspx"><i class="ti-more"></i>OJT Training</a></li>
        <li id="OTS"><a href="/OJTTrainingStatus.aspx"><i class="ti-more"></i>OTS Training</a></li>
    </ul>
</li>

<li id="feedback" class="treeview">
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
<li id="attendance" class="treeview">
    <a href="#">
        <i class="fa fa-clock-o"></i>
        <span>Attendance System</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
        <li id="AttendanceAdd"><a href="/AttendanceAddNew.aspx"><i class="ti-more"></i>Register Attendance</a></li>
        <li id="AttendancePending"><a href="/AttendancePending.aspx"><i class="ti-more"></i>Pending Attendance</a></li>
        <li id="AttendanceReport"><a href="/AttendanceReport.aspx"><i class="ti-more"></i>Attendance Report</a></li>
    </ul>
</li>
<li id="gap" class="treeview">
    <%--<li class="treeview menu-open">--%>
    <a href="#">
        <i class="ti-check-box"></i>
        <span>Assessment</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
        <li><a href="/GapAnalysisTakeExam.aspx"><i class="ti-more"></i>Gap Analysis</a></li>
        <li><a href="/ClassroomAssessmentByUser.aspx"><i class="ti-more"></i>Classroom Assessment</a></li>
    </ul>
</li>

<li id="reports" class="treeview">
    <a href="#">
        <i class="ti-stats-up"></i>
        <span>Reports</span>
        
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
        <li><a href="/CLATrainingStatusReport.aspx"><i class="ti-more"></i>Classroom Training Status</a></li>
<%--        <li><a href="#"><i class="ti-more"></i>Report2</a></li>--%>
    </ul>
</li>

<li id="account" class="treeview">
    <a href="#">
        <i class="ti-user"></i>
        <span>Account</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
        <li id="AccountSettings"><a href="/AccountSettings.aspx"><i class="ti-more"></i>Account Settings</a></li>
        <li id="Profile"><a href="Profile.aspx"><i class="ti-more"></i>Profile</a></li>
    </ul>
</li>
<li id="admin" class="treeview">
    <a href="#">
        <i class="ti-shield"></i>
        <span>Admin</span>
        <span class="pull-right-container">
            <i class="fa fa-angle-right pull-right"></i>
        </span>
    </a>
    <ul class="treeview-menu">
        <li id="FeedbackSummary"><a href="/FeedbackSummary.aspx"><i class="ti-more"></i>Feedback Dashboard</a></li>
          <li id="CLATrainingStatus"><a href="/CLATrainingStatus.aspx"><i class="ti-more"></i>Classroom Training Status</a></li>
        
        <li id="FeedbackMonthly"><a href="/FeedbackMonthly.aspx"><i class="ti-more"></i>Feedback Monthly Dashboard</a></li>
        <li id="CLAOverallStatus"><a href="/CLAOverallStatus.aspx"><i class="ti-more"></i>Overall Classroom Training Status</a></li>
        
        <li><a href="/CoursesDetails.aspx"><i class="ti-more"></i>Courses Details</a></li>
        <li><a href="/EditCourseTopics.aspx"><i class="ti-more"></i>Courses Topics</a></li>
        <li><a href="/UserRoles.aspx"><i class="ti-more"></i>User Roles</a></li>
        <li><a href="/ELECoursesReview.aspx"><i class="ti-more"></i>E-Larning Courses Admin</a></li>
        <li><a href="/AddNewUser.aspx"><i class="ti-more"></i>Add New User</a></li>
        <li><a href="/ElearningProgressTracker.aspx"><i class="ti-more"></i>Elearning Progress Tracker</a></li>
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