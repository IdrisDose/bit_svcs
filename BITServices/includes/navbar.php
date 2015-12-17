<?php
	session_start();
	if(isset($_SESSION["logged_in"]))
	{
		$loggedin = $_SESSION["logged_in"];
	}
?>

<nav class="navbar navbar-fixed-top norm-nav">
	<div class="container-fluid">
		<div class="navbar-header">
			<a href="index.php" class="navbar-brand">
				<img class="img-up" src="images/BitSvcs-logo.png" alt="Bit Services Logo" title="Bit Services">
			</a>
		</div>					
		<div class="navbar-collapse">
			<ul class="nav navbar-nav norm-nav-navbar text-center">
				<li><a href="index.php">Home</a></li>
				<li><a href="services.php">Services</a></li>
				<li><a href="aboutus.php">About us</a></li> 
				<li><a href="contact.php">Contact Us</a></li> 
				<li><a href="panel.php" class="hidden">User Panel</a></li> 
			</ul>
			<ul class="nav navbar-nav navbar-right norm-nav-navbar text-center">
				<li id="signup"><a href="#modal-signup" onclick="showPopup('signup')"><span class="glyphicon glyphicon-user"></span> Sign-up</a></li>
				<li id="login"><a href="#modal-login" onclick="showPopup('login')"><span class="glyphicon glyphicon-log-in"></span> Log-in</a></li>
				<li id="account" class="hidden"><a href="php/redirect.php?page=account"><span class="glyphicon glyphicon-user"></span> My Account</a></li>
				<li id="dashboard" class="hidden"><a id="dashboard-a" href=""><span class="glyphicon glyphicon-th"></span> My Dashboard</a></li>
				<li id="logout" class="hidden"><a href="php/logout.php"><span class="glyphicon glyphicon-log-out"></span> Log-out</a></li>
			</ul>
		</div>
	</div>
</nav>

<script>
	$(document).ready(function(){
	    var $document = $(document);

	    $document.scroll(function() {
	    	if ($document.scrollTop() >= 10) {
	    		$('.navbar').css('background', '#F2F2F2');
	        	$('.navbar a').css('color', 'black');
	  		} else {
	      		$('.navbar').css('background', 'transparent');
	      		$('.navbar a').css('color', '#fff');
	      	}
	    });

	});
</script>

<?php
	if(isset($loggedin)){
		if($loggedin){ ?>
		
		<script>
			$(function(){
				$("#signup").addClass('hidden');
				$("#login").addClass('hidden');
				$("#logout").removeClass('hidden');
				$("#account").removeClass('hidden');
				$("#dashboard").removeClass('hidden');
  				document.getElementById("dashboard-a").href="php/redirect.php?page=dashboard";
			});
		</script>
<?php }} ?>