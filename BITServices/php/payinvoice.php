<?php
	session_start();
	if(!$_SESSION["logged_in"])
	{
	  header("Location:php/logout.php");
	}


	include_once 'invoice.class.php';

	$i = new Invoice();
	if(!isset($_POST["invoice"]))
	{
		$_SESSION["ERROR_MESSAGE"] = "Invoice Not Paid - No Invoice ID.";
		header("Location:../dashboard.php");
	}
	$inv_id = $_POST["invoice"];

	if($i->payInvoice($inv_id))
	{
		$_SESSION["SUCCESS_MESSAGE"] = "<strong>Payment Success!</strong> Payment is now processing.";
		header("Location:../dashboard.php");
	} else {
		$_SESSION["ERROR_MESSAGE"] = "Payment Failure - Failed to proccess payment.";
		header("Location:../dashboard.php");
	}
	
?>