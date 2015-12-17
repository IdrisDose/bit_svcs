<?php
	session_start();
	if(!$_SESSION["logged_in"])
	{
	  header("Location:php/logout.php");
	}
  	include_once 'invoice.class.php';
	include_once 'job.class.php';

	$i = new Invoice();
	$j = new Job();

	$job_id = $_POST["job"];
	$inv_desc = $_POST["invdesc"];
	$client_id = $j->getClientIDinJob($job_id);
	$inv_amount = number_format($_POST["invamount"], 2, '.', '');



	echo "$job_id - $inv_desc - $inv_amount - $client_id";


	

	if($i->creatNewInvoice($job_id,$inv_desc,$inv_amount,$client_id))
	{
		$_SESSION["SUCCESS_MESSAGE"] = "<strong>Invoice Created</strong> Database updated!";
		header("Location:../dashboard.php");
	} else {
		$_SESSION["ERROR_MESSAGE"] = "Invoice Creation failed";
		header("Location:../dashboard.php");
	}
	
?>