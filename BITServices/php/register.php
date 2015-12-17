<?php
	include_once 'login.class.php';
	session_start();
	$l = new Login();
	
	if(!isset($_POST['name']) || !isset($_POST['uname']) || !isset($_POST['email']) || !isset($_POST['pword']))
	{
		$_SESSION["ERROR_MESSAGE"] = "Registration Failed - You missed a field";
		header("Location:../register.php");
	}

	$name = $_POST['name'];
	$uname = $_POST['uname'];
	$email = $_POST['email'];
	$pword = $_POST['email'];

	$bool = $l->newLogin($name,$uname,$email,$pword);

	if($bool)
	{
		$_SESSION["SUCCESS_MESSAGE"] = "<strong>Registration Success!</strong> You may now login with your credentials.";
		header("Location:../loginpage.php?success");
		die();
	} else {
		$_SESSION["ERROR_MESSAGE"] = "Registration Failed - Username or Email already exists";
		header("Location:../register.php?failed");
		exit();
	}
?>