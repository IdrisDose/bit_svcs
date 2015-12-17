<?php
	session_start();
	if(!$_SESSION["logged_in"])
	{
	  header("Location:php/logout.php");
	}

	if(!isset($_POST['jobdesc']) || !isset($_POST['priority']))
	{
		$message = "Job Creation failed";
		header("Location:../dashboard.php?message=$message");
	}

	if(isset($_POST['jobloc']))
	{
		$job_location = $_POST['jobloc'];
	}

	include_once 'job.class.php';

	$j = new Job();
	$REPLSTR = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	$job_desc = $_POST['jobdesc'];
	$job_priority = $_POST['priority'];
	$client_id = $_POST['client_id'];
	$employee_id = $_POST['staff_id'];
	$super_id = $_POST['super_id'];

	$client_name = str_replace(" ", "",$_POST['client_name']);
	$jobname = $client_name.str_replace(" ", "",rtrim($job_desc, $REPLSTR)).$client_id;

	if($j->requestNewJobA($jobname,$job_desc,$client_id,$job_priority,$job_location,$employee_id,$super_id))
	{
		$_SESSION["SUCCESS_MESSAGE"] = "<strong>Job Requested</strong> Email sent";
		header("Location:../dashboard.php");
	} else {
		$_SESSION["ERROR_MESSAGE"] = "Job Request Failed";
		header("Location:../dashboard.php");
	}
?>