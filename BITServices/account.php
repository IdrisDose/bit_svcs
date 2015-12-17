<!doctype html>
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
		<div id="overlay" class="hidden"></div>
		<section id="header-container">
			<nav class="navbar navbar-inverse navbar-fixed-top">
		      <div class="container-fluid">
		        
		        <div class="navbar-header">
		          <a href="index.php" class="navbar-brand">
		            BIT Services - Account Management
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
		<?php include_once 'includes/loginform.php'; ?>
		
		<div id="footer" class="navbar-fixed-bottom">
			<div class="container text-center"> 
				&copy; Idris 2015 (<a href="http://idrisdev.net">http://idrisdev.net</a>) - BIT Services
			</div>
		</div>
	</body>		
</html>
