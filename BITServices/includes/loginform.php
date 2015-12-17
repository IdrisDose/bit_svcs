<div id="modal-login" class="popupContainer hidden">
	<section class="popupBody">
        <!--Login Form-->
		<div id="user_login" class="user_login">
			<form action='php/login.php' method='post' name='login' role='form'>
				<div class="login-header">            
                    <h2>Login to your account</h2>
                </div>

                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <input type="text" name="uname" placeholder="Username" class="form-control" autofocus>
                </div>
                <br />                    
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <input type="password" name="pword" placeholder="Password" class="form-control">
                </div>                    
                <br />
                <div class="row">
                    <div class="col-md-6 checkbox">
                        <label><input type="checkbox"> Stay signed in</label>                        
                    </div>
                    <div class="col-md-6">
                        <div class="action_btns text-center">
                            <button class="btn btn-cta-primary" type="submit">Login</button>
                            <button class="btn btn-cta-primary" type="button" class="pull-right" onclick="showPopup('login')">Back</button>
                        </div>                      
                    </div>
                </div>

                <hr>

                <h4>Forget your Password ?</h4>
                <p>no worries, <a class="color-green" href="#">click here</a> to reset your password.</p>
			</form>
            <br />
		</div>
    </section>
</div>

<div id="modal-signup" class="popupContainer hidden">
    <section class="popupBody">
        <!-- Signup Form -->
        <div id="user_register" class="user_register">
            <form action='php/register.php' method='post' name='signup'>
                <div class="login-header">            
                    <h2>Register your account</h2>
                </div>
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                    <input type="text" name="name" placeholder="Your name" class="form-control" autofocus required>
                </div>
                <br />
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <input type="text" name="uname" placeholder="Desired Username" class="form-control" required>
                </div>
                <br />
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                    <input type="text" name="email" placeholder="Email" class="form-control" required>
                </div>
                <br />                     
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <input type="password" name="pword" placeholder="Password" class="form-control" required>
                </div>                    
                <br />
                <div class="col-md-6 checkbox">
                    <label><input name="news-letter" type="checkbox"> Subscribe to newsletter</label>                        
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="action_btns text-center">
                            <button class="btn btn-cta-primary" type="submit">signup</button>
                            <button class="btn btn-cta-primary" type="button" class="pull-right" onclick="showPopup('signup')">Back</button>
                        </div>                      
                    </div>
                </div>

                <hr>

                <h4>Forget your Password ?</h4>
                <p>no worries, <a class="color-green" href="#">click here</a> to reset your password.</p>
            </form>
        </div>
    </section>
</div>