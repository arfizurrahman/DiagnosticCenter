<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="DiagnosticCenter.UI.Appointment" %>


<!DOCTYPE html>
<html>
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Diagnostic Centre Management</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <!-- Ionicons -->
    <link href="../Content/jquery-ui.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="dist/css/ionicons.css" rel="stylesheet" />
    <link href="../Content/Style.css" rel="stylesheet" />
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
  <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
  <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/iCheck/flat/blue.css">
  <!-- Morris chart -->
  <link rel="stylesheet" href="plugins/morris/morris.css">
  <!-- jvectormap -->
  <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css">
  <!-- Date Picker -->

  <!-- bootstrap wysihtml5 - text editor -->
  <link rel="stylesheet" href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">
    
    <link href="~/Content/bootstrap-clockpicker.css" rel="stylesheet" />
   <%-- <link href="~/Content/jquery-clockpicker.css" rel="stylesheet" />--%>
    <link href="plugins/timepicker/bootstrap-timepicker.min.css" rel="stylesheet" />

    <style>
        label.error {
            color: red;
            font-style: italic;
        }
    </style>
  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
     
    <!--[if lt IE 9]>

  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition skin-blue sidebar-mini">
<div class="wrapper">

  <header class="main-header">
    <!-- Logo -->
    <a href="index2.html" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>DC</b>M</span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>Diagnostic</b>Center</span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
        <span class="sr-only">Toggle navigation</span>
      </a>

      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
          <!-- Messages: style can be found in dropdown.less-->
          
          <!-- Notifications: style can be found in dropdown.less -->
          
          
        
          <!-- User Account: style can be found in dropdown.less -->
          <li class="dropdown user user-menu">
            <a href="#" class="fa fa-gears" data-toggle="dropdown">
              
            </a>
            <ul class="dropdown-menu">
              <!-- User image -->
              
              
              <!-- Menu Footer-->
              <li class="user-footer">
                <div class="pull-left">
                  <a href="#" class="btn btn-default btn-flat">Profile</a>
                </div>
                <div class="pull-right">
                  <a href="Login.aspx" class="btn btn-default btn-flat">Sign out</a>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
          
        </ul>
      </div>
    </nav>
  </header>
  <!-- Left side column. contains the logo and sidebar -->
  <aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
      <!-- Sidebar user panel -->
      
     
      <!-- /.search form -->
      <!-- sidebar menu: : style can be found in sidebar.less -->
      <ul class="sidebar-menu">
        <li class="header">MAIN NAVIGATION</li>
        <li class="treeview">
          <a href="Index.aspx">
            <i class="fa fa-home"></i> <span>Home</span>
            
          </a>
         
        </li>
        
          <li class="treeview">
          <a href="TestTypeSetup.aspx">
            <i class="fa fa-tint"></i>
            <span>Test Type Setup</span>
            
          </a>
          
        </li>
          <li class="treeview">
          <a href="TestSetup.aspx">
            <i class="fa fa-tint"></i>
            <span>Test Setup</span>
            
          </a>
          
        </li>
          
            <li class="treeview">
          <a href="#">
            <i class="fa fa-users"></i>
            <span>Patient</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="AddPatient.aspx"><i class="fa fa-user-plus"></i> Add Patient</a></li>
            <li><a href="PatientProfile.aspx"><i class="fa fa-user"></i> Patient profile</a></li>
          
            
          </ul>
        </li>
        
          
          <li class="active treeview">
          <a href="#">
            <i class="glyphicon glyphicon-user"></i>
            <span>Doctor</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li class="active"><a href="AddDoctor.aspx"><i class="fa fa-user-plus"></i> Add Doctor</a></li>
            <li><a href="DoctorsProfile.aspx"><i class="fa fa-user"></i> Doctors Profile</a></li>
          
            
          </ul>
        </li>
          <li class="treeview"> <a href="TestRquestByPatient.aspx">
            <i class="fa fa-list"></i>
            <span>Test Request</span>
            
          </a>
          
        </li>
          <li class="treeview active"> <a href="Appointment.aspx">
            <i class="fa fa-edit"></i>
            <span>Appointment</span>
            
          </a>
          
        </li>
        
        <li><a href="Payment.aspx"><i class="glyphicon glyphicon-usd"></i> <span>Payment</span></a></li>
        <li><a href="UnpaidBillReport.aspx"><i class="fa fa-money"></i> <span>UnpaidBill</span></a></li>
     
      </ul>
    </section>
    <!-- /.sidebar -->
  </aside>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
<section class="content-header">
      <h1>
        Appointment
        <small>Control panel</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
       
        <li class="active">Appointment</li>
         
      </ol>
    </section>
    <br>
     <section class="col-lg-12 connectedSortable">
         <form class="form-horizontal" runat="server" id="appointmentForm">
         <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Appointment Detailes</h4>
                        </div>
                        <div class="panel-body">

  <div class="form-group">
    <label class="control-label col-sm-4" for="patientCodeTextBox">Patient Code</label>
    <div class="col-sm-8">
        <input type="text" class="form-control" id="patientCodeTextBox" required placeholder="patient code" runat="server"/>
    </div>
  </div>
 
<div class="form-group">
    <label class="control-label col-sm-4" for="selectDoctorDropDownList">Select Doctor</label>
    <div class="col-sm-8"> 
      <asp:DropDownList AutoPostBack="False" ID="selectDoctorDropDownList" runat="server" Height="25px" Width="130px" >
                        </asp:DropDownList>
    </div>
  </div>
        <div class="bootstrap-timepicker">
                <div class="form-group">
                  <label class="control-label col-sm-4" for="timeTextBox">Time</label>
                  <div class="input-group col-sm-8">
                      <input type="text" id="timeTextBox" value="12:00" runat="server" class="form-control timepicker"/>

                    <div class="input-group-addon"><i class="fa fa-clock-o"></i></div>
                  </div>
                  <!-- /.input group -->
                </div>
       
              </div>
        
           
  
  <div class="form-group">
      <label class="control-label col-sm-4" for=""></label> 
    <div class="col-sm-8">
      <asp:Button class="btn btn-md btn-primary" Text="Save" runat="server" OnClick="saveButton_Click" />
    </div>
  </div>
  <div class="form-group">
      <label class="control-label col-sm-4" for=""></label> 
    <div class="col-sm-8">
        <h4><span class="label label-success" id="messageLabel" runat="server"></span></h4>
        <h4><span class="label label-danger" id="messageLabel2" runat="server"></span></h4>
    </div>
  </div>

                            </div>
                            </div>
                            </div>
   <div class="col-sm-6">

            <div class=" breadcrumb">
                <h4>List of Doctors</h4>
            </div>
            <asp:GridView ID="appointmentGridView" runat="server" Width="540px" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="SL" HeaderStyle-Width="5px">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PatientCode">
                            <ItemTemplate>
                                <asp:Label runat="server"><%#Eval("PatientCode")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact No">
                            <ItemTemplate>
                                <asp:Label runat="server"><%#Eval("PatientContactNo")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Doctor">
                            <ItemTemplate>
                                <asp:Label runat="server"><%#Eval("DoctorName")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                                <asp:Label runat="server"><%#Eval("Time")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                               <asp:LinkButton ID="LnkBtnEdit" CommandName="EditRow" CommandArgument='<%# Eval("ContactNo") %>' runat="server" OnClick="editBtn_Click" CausesValidation="false">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <asp:LinkButton ID="LnkBtnRemove" CommandName="DeleteRow" CommandArgument='<%# Bind("ContactNo") %>' runat="server" OnClientClick="return confirm('Are you sure?')" CausesValidation="false">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
        </div>
                            </div>
             </form>

        </section>
  </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">
      <b>Version</b> 1.0
    </div>
    <strong>Developed by Suhe $ Nisa</strong> All rights
    reserved.
  </footer>

  <aside class="control-sidebar control-sidebar-dark">
  
    <!-- Tab panes -->
    <div class="tab-content">
      <!-- Home tab content -->
      <div class="tab-pane" id="control-sidebar-home-tab">
        

      </div>
      <!-- /.tab-pane -->
      <!-- Stats tab content -->
      
      <!-- /.tab-pane -->
    </div>
  </aside>
  
 
</div>
<!-- ./wrapper -->

<!-- jQuery 2.2.3 -->
    <%--<script src="plugins/jQuery/jquery-2.2.3.min.js"></script>--%>
<!-- jQuery UI 1.11.4 -->
    <script src="../Scripts/jquery-3.1.1.js"></script>
        <script src="dist/js/jquery-ui.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
    $.widget.bridge('uibutton', $.ui.button);
</script>
<!-- Bootstrap 3.3.6 -->
<script src="bootstrap/js/bootstrap.min.js"></script>
<!-- Morris.js charts -->
        <script src="../Scripts/raphael-min.js"></script>

<script src="plugins/morris/morris.min.js"></script>
<!-- Sparkline -->
<script src="plugins/sparkline/jquery.sparkline.min.js"></script>
<!-- jvectormap -->
<script src="plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
<script src="plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
<!-- jQuery Knob Chart -->
<script src="plugins/knob/jquery.knob.js"></script>
<!-- daterangepicker -->        <script src="../Scripts/moment.min.js"></script>
<%--<script src="plugins/daterangepicker/daterangepicker.js"></script>
<!-- datepicker -->
<script src="plugins/datepicker/bootstrap-datepicker.js"></script>--%>
<!-- Bootstrap WYSIHTML5 -->
<script src="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
<!-- Slimscroll -->
<script src="plugins/slimScroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="plugins/fastclick/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="dist/js/app.min.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="dist/js/pages/dashboard.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="dist/js/demo.js"></script>

    <script src="plugins/timepicker/bootstrap-timepicker.min.js"></script>
    
   <script>
       $(document).ready(function () {


           $("#appointmentForm").validate({
               rules: {
                   nameTextBox: "required",
                   contactNoText: "required",
                   dateOfBirthTextBox: "required",
                   addressTextBox: "required",
                   emailTextBox: "required",
                   feeTextBox: "required",
                   qualificationTextBox: "required"

               },
               messages: {
                   nameTextBox: "Please enter patient name",
                   contactNoText: "Please enter contact no.",
                   dateOfBirthTextBox: "Please enter date of birth.",
                   addressTextBox: "Please enter address",
                   emailTextBox: "Please enter email",
                   feeTextBox: "Please enter fee",
                   qualificationTextBox: "Please enter qualification details"


               }
           });

           $(".timepicker").timepicker({
               showInputs: false
           });

       });

   </script>
    
</body>
</html>


