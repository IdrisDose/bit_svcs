<?php
	session_start();
  	if(!$_SESSION["logged_in"])
  	{
    	header("Location:php/logout.php");
  	}
	
  	include_once 'job.class.php';

  	$j = new Job();
	$job = $_POST["job"];
	$empid = $_POST["staff_id"];
	$conf = $_POST["chk-conf"];

	if($conf){
		if($j->assignJob($job,$empid))
		{
			$_SESSION["SUCCESS_MESSAGE"] = "<strong>Job Assigned</strong> Database updated!";
			header("Location:../dashboard.php?");
		} else {
			$_SESSION["ERROR_MESSAGE"] = "Job assignment failed";
			header("Location:../dashboard.php");
		}
	} else {
			$_SESSION["ERROR_MESSAGE"] = "Job assignment failedd - Checkbox not ticked";
			header("Location:../dashboard.php");
	}
	
?>