<?php
	session_start();
  	if(!$_SESSION["logged_in"])
  	{
    	header("Location:php/logout.php");
  	}
	
  	include_once 'job.class.php';

  	$j = new Job();
	$job = $_POST["job"];
	$conf = $_POST["confirmation-check"];
	
	if($conf)
	{
		if($j->delJob($job))
		{
			$_SESSION["SUCCESS_MESSAGE"] = "<strong>Job Deleted!</strong> Database updated!";
			header("Location:../dashboard.php");
		} else {
			$_SESSION["ERROR_MESSAGE"] = " Job deleted failed - Invoice not paid";
			header("Location:../dashboard.php");
		}
	} else {

		$_SESSION["ERROR_MESSAGE"] = " Job deleted failed";
		header("Location:../dashboard.php");
	}
	
?>