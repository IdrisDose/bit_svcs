<?php
	session_start();
  	if(!$_SESSION["logged_in"])
  	{
    	header("Location:php/logout.php");
  	}
	
  	include_once 'job.class.php';

  	$j = new Job();
	$job = $_POST["job"];
	$conf = $_POST["chk-conf"];
	if($conf)
	{
		$bool = 0;
	} else { $bool = 1; }

	if($j->activeJob($job,$bool))
	{
		$_SESSION["SUCCESS_MESSAGE"] = "<strong>Job Updated!</strong> Database updated!";
		header("Location:../dashboard.php?");
	} else {
		$_SESSION["ERROR_MESSAGE"] = " Job Update failed";
		header("Location:../dashboard.php");
	}
?>