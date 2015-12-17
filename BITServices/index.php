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
			
			<!-- quick n dirty global navbar -->
			<?php include_once 'includes/navbar.php'; ?> 
			
		</section>
		<?php include_once 'includes/loginform.php'; ?>
		
		<div class="home-bg main">
		<section class="promo section section-on-bg" style="">
			<div class="container text-center promo-text">
				<h2 class="title section-on-bg">BIT Services. Excellent IT services for all your needs.</h2>
				<p class="intro">BIT Services provides fast and efficent services for anyone, regardless if you're a company or an individual, you need it, we provide it.</p>
				
				<a class="btn btn-cta-primary" href="services.php">View Services</a>
			</div>

			<div class="placeholders text-center">
				<div class="container-fluid skill-bubbles">
					<h1 class="page-header dash-header text-center"> Our skills </h1>
		            <div class="bubble-box">
			            <div class="col-xs-6 col-md-3 placeholder">
			              <img data-src="holder.js/200x200/auto" class="img-responsive center-div" alt="Generic placeholder thumbnail">
			              <h4>Contracting</h4>
			              <span class="text-muted">Lorem Ipsum</span>
			            </div>
			            <div class="col-xs-6 col-md-3 placeholder">
			              <img data-src="holder.js/200x200/auto" class="img-responsive center-div" alt="Generic placeholder thumbnail">
			              <h4>Repairing</h4>
			              <span class="text-muted">Lorem Ipsum</span>
			            </div>
			            <div class="col-xs-6 col-md-3 placeholder">
			              <img data-src="holder.js/200x200/auto" class="img-responsive center-div" alt="Generic placeholder thumbnail">
			              <h4>Analysing</h4>
			              <span class="text-muted">Lorem Ipsum</span>
			            </div>
			            <div class="col-xs-6 col-md-3 placeholder">
			              <img data-src="holder.js/200x200/auto" class="img-responsive center-div" alt="Generic placeholder thumbnail">
			              <h4>Development</h4>
			              <span class="text-muted">Lorem Ipsum</span>
			            </div>
			        </div>
          		</div>
          	</div>
		</section>
		<div id="footer" class="navbar-fixed-bottom">
			<div class="container text-center"> 
				&copy; Idris 2015 (<a href="http://idrisdev.net">http://idrisdev.net</a>) - BIT Services
			</div>
		</div>
	</body>		
</html>
