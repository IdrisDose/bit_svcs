<?php
  session_start();
  if(!$_SESSION["logged_in"])
  {
    header("Location:php/logout.php");
  }

  require_once 'php/job.class.php';
  require_once 'php/invoice.class.php';
  require_once 'php/employee.class.php';
  require_once 'php/client.class.php';
  
  $j = new Job();
  $i = new Invoice();
  $e = new Employee();
  $c = new Client();
  $jobnames = array();

  if($_SESSION["isSupervisor"])
  {

    $isEmployee = true;
    $isClient = false;
    $isSupervisor = true;

    $userName = $_SESSION['employee']['emp_name'];
    $id = $_SESSION['employee']['emp_id'];
  } 
  else if($_SESSION['isClient'])
  {
    $isEmployee = false;
    $isClient = true;
    $isSupervisor = false;


    $userName = $_SESSION['client']['cl_name'];
    $id = $_SESSION['client']['cl_id'];
  } 
  else if($_SESSION["isContractor"])
  {
    $isEmployee = true;
    $isClient = false;
    $isSupervisor = false;

    $userName = $_SESSION['employee']['emp_name'];
    $id = $_SESSION['employee']['emp_id'];
  }
  
?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
    	<meta http-equiv="X-UA-Compatible" content="IE=edge">
    	<meta name="viewport" content="width=device-width, initial-scale=1">
		<meta name="description" content="BIT Services. IT Services for anyone.">
		<meta name="author" content="Idris Gaist-Lloyd">
		<title>Bit Services</title>
		<?php include_once 'includes/head.php'; ?>
	</head>
	
  <body>
    <section id="header-container">
		<nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        
        <div class="navbar-header">
          <a href="index.php" class="navbar-brand">
            BIT Services - Dashboard
          </a> 
        </div>          

        <div class="navbar-collapse">
          <ul class="nav navbar-nav navbar-right">
            <li><a href="dashboard.php">Dashboard</a></li>
            <li><a href="account.php">My Account</a></li>
            <li><a href="account.php#settings">Settings</a></li>
            <li><a href="php/logout.php">Log-out</a></li>
          </ul>
        </div>
      </div>
    </nav>
  </section>
    <div style="margin-top:50px"></div>
    <?php
      if($isEmployee)
      {
        include 'includes/emp-dash.php';
      }

      if($isClient)
      {
        include 'includes/client-dash.php';
          
      } 
    ?>
	</body>
</html>