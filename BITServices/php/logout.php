<?php
	session_start();
	unset($_SESSION["loggedin"]);
	if(isset($_SESSION["client"]) || isset($_SESSION['isClient']))
	{
		unset($_SESSION["client"]);
		unset($_SESSION['isClient']);
	}
	if(isset($_SESSION["employee"]) || isset($_SESSION['isEmployee']))
	{
		unset($_SESSION["employee"]);
		unset($_SESSION['isEmployee']);
	}
	session_unset(); //making sure all set variables are unset
	session_destroy();  // Makingsure the session has been destroyed
	
	header('location:../index.php');

	die(); // making sure the session is definatley dead.

?>