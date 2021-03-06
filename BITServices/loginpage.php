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
	<body style="background: #f2f2f2;">
		<section id="header-container">
			<nav class="navbar navbar-inverse navbar-fixed-top">
		      <div class="container-fluid">
		        
		        <div class="navbar-header">
		          <a href="index.php" class="navbar-brand">
		            BIT Services - Login Page
		          </a> 
		        </div>
		      </div>
		    </nav>
		</section>
		<div class="spacer"></div>
		<div class="spacer"></div>
		<section id="body-container" class="container push-down">
			<div class="row">
            <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3">
                <form class="login-page" action='php/login.php' method='post' name='login' role='form'>
                    <div class="login-header">
                    	<a href="index.php"><img src="images/BitSvcs-logo.png" alt="Bit Services Logo" title="Bit Services" width="305" height="108"/></a>            
                        <h2>Login to your account</h2>
                    </div>
                    <?php
                        if(isset($_SESSION["ERROR_MESSAGE"]))
                        {
                            echo "<div id='error-message' class='alert alert-danger' role='alert'>
                                <span class='glyphicon glyphicon-alert'></span> <strong>Oh snap!</strong> {$_SESSION['ERROR_MESSAGE']}
                            </div>";
                            unset($_SESSION["ERROR_MESSAGE"]);
                        }elseif(isset($_SESSION["SUCCESS_MESSAGE"]))
                        {
                            echo "<div id='error-message' class='alert alert-success' role='alert'>
                                    {$_SESSION['SUCCESS_MESSAGE']}
                                  </div>";
                            unset($_SESSION["SUCCESS_MESSAGE"]);
                        }
                    ?>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <input type="text" name="uname" placeholder="Username" class="form-control">
                    </div>
                    <br />                    
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                        <input type="password" name="pword" placeholder="Password" class="form-control">
                    </div>                    
                    <br />
                    <div class="row">
                        <div class="col-md-6 checkbox">
                            <label><input type="checkbox"> Stay signed in</label>                        
                        </div>
                        <div class="col-md-6">
                            <button class="btn btn-cta-primary" type="submit">Login</button> 
                            <a class="btn btn-cta-primary" href="index.php">Home</a>                      
                        </div>
                    </div>

                    <hr>

                    <h4>Forget your Password ?</h4>
                    <p>no worries, <a class="" href="#">click here</a> to reset your password.</p>
                </form>            
            </div>
        </div>
		</section>

		<section id="footer-container">
			<div id="footer" class="navbar-fixed-bottom">
				<div class="container text-center"> 
					&copy; Idris 2015 (<a href="http://idrisdev.net">http://idrisdev.net</a>) - BIT Services
				</div>
			</div>
		</section>
	</body>		
</html>
