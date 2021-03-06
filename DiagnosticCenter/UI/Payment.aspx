﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="DiagnosticCenter.UI.Payment" %>


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
  <link rel="stylesheet" href="plugins/datepicker/datepicker3.css">
  <!-- Daterange picker -->
  <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css">
  <!-- bootstrap wysihtml5 - text editor -->
  <link rel="stylesheet" href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">
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
          <li class="active treeview">
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
            <li><a href="PatientProfile.aspx"><i class="fa fa-user"></i> Patient Profile</a></li>
          
            
          </ul>
        </li>
        
          
          <li class="treeview">
          <a href="#">
            <i class="glyphicon glyphicon-user"></i>
            <span>Doctor</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="AddDoctor.aspx"><i class="fa fa-user-plus"></i> Add Doctor</a></li>
            <li><a href="DoctorsProfile.aspx"><i class="fa fa-user"></i> Doctors Profile</a></li>
          
            
          </ul>
        </li>
          <li class="treeview"> <a href="TestRquestByPatient.aspx">
            <i class="fa fa-list"></i>
            <span>Test Request</span>
            
          </a>
          
        </li>
          <li class="treeview"> <a href="Appointment.aspx">
            <i class="fa fa-edit"></i>
            <span>Appointment</span>
            
          </a>
          
        </li>
        
        
       
        <li class="active"><a href="Payment.aspx"><i class="glyphicon glyphicon-usd"></i> <span>Payment</span></a></li>
        <li><a href="UnpaidBillReport.aspx"><i class="fa fa-money"></i> <span>UnpaidBill</span></a></li>
        
      </ul>
    </section>
    <!-- /.sidebar -->
  </aside>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
 
        <section class="content-header">
      <h1>
        Payment
        <small>Control panel</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
       
        <li class="active">Payment</li>
         
      </ol>
    </section>
    <br>
     <section class="col-lg-12 connectedSortable">
         <form class="form-horizontal" runat="server" id="testSetupForm">
         <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Payment Detailes</h4>
                        </div>
                        <div class="panel-body">

  <div class="form-group">
    <label class="control-label col-sm-4" for="patientCodeTextBox">Patient Code</label>
    <div class="col-sm-8">
        <input type="text" class="form-control" id="patientCodeTextBox" required="false" placeholder="Code" runat="server"/>
    </div>
  </div>
  <%--<div class="form-group">
    <label class="control-label col-sm-4" for="billNoTextBox">Bill No</label>
    <div class="col-sm-8"> 
      <input type="number" class="form-control" id="billNoTextBox" required="false" placeholder="Bill no" runat="server"/>
    </div>
  </div>--%>
  
  
  <div class="form-group">
      <label class="control-label col-sm-4" for=""></label> 
    <div class="col-sm-8">
      <asp:Button class="btn btn-md btn-primary" Text="Save" runat="server" OnClick="searchButton_Click" />
    </div>
  </div>
                            <asp:HiddenField ID="idHiddenField" runat="server" />
                            <div class="form-group">
    <label class="control-label col-sm-4" for="amountTextBox">Amount</label>
    <div class="col-sm-8">
        <input type="text" class="form-control" id="amountTextBox" disabled required placeholder="" runat="server"/>
    </div>
  </div>
  <div class="form-group">
    <label class="control-label col-sm-4" for="dueDateTextBox">Due Date</label>
    <div class="col-sm-8"> 
      <input type="text" class="form-control" id="dueDateTextBox" disabled required="" placeholder="" runat="server"/>
    </div>
  </div>
 <div class="form-group">
      <label class="control-label col-sm-4" for=""></label> 
    <div class="col-sm-8">
      <asp:Button class="btn btn-md btn-primary" Text="pay" ID="payButton" runat="server" OnClick="payButton_Click" />
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
  <!-- Control Sidebar -->
 
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
  

   <script>
       $(document).ready(function () {


           $("#testSetupForm").validate({
               rules: {
                   testNameTextBox: "required",
                   feeTextBox: "required",
                   testTypeDropDownList: "required"

               },
               messages: {
                   testNameTextBox: "Please enter test name",
                   feeTextBox: "Please enter fee",
                   testTypeDropDownList: "Please select test type"



               }
           });


       });

   </script>
    
</body>
</html>

