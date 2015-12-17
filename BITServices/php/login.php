<?php
	session_start();

	include_once 'redirect.php';
	require_once 'DAL.class.php';
	include_once 'client.class.php';
	include_once 'employee.class.php';
	require_once 'login.class.php'; 


	$uname = $_POST["uname"];
	$pass = $_POST["pword"];
	$log = new Login();
	$login = $log->getLogin($uname,$pass);


	switch($login["login_type"])
	{
		case "CLIENT":
				$_SESSION["logged_in"] = true;

				$_SESSION["isClient"] = true;
				$_SESSION["isContractor"] =false;
				$_SESSION["isEmployee"] = false;
				$_SESSION["isSupervisor"] = false;

				include_once 'client.class.php';

				$client = new Client();
				$client->getClient($login["email"]);

				$_SESSION["client"] = array(
					"cl_id" => $client->client_id,
					"cl_title" => $client->client_title,
					"cl_name" => $client->client_name,
					"cl_address" => $client->client_address,
					"cl_city" => $client->client_city,
					"cl_postcode" => $client->client_postcode,
					"cl_email" => $client->client_email,
					"cl_phone" => $client->client_phone,
					"cl_mobile" => $client->client_mobile
				);
				session_write_close();
				header('location:../dashboard.php');
			break;

		case "EMPLOYEE":
				$_SESSION["logged_in"] = true;

				$_SESSION["isClient"] = false;
				$_SESSION["isContractor"] = true;
				$_SESSION["isEmployee"] = true;
				$_SESSION["isSupervisor"] = false;

				$employee = new Employee();
				$employee->getEmployee($login["email"]);

				$_SESSION["employee"] = array(
					"emp_id" => $employee->emp_id,
					"emp_title" => $employee->emp_title,
					"emp_name" => $employee->emp_name,
					"emp_email" => $employee->emp_email,
					"emp_phone" => $employee->emp_phone,
					"emp_role" => $employee->emp_role,
					"isSupervising" => $employee->isSupervising
				);
				session_write_close();
				header('location:../dashboard.php');
			break;
			
		case "SUPERVISOR":
				$_SESSION["logged_in"] = true;

				$_SESSION["isClient"] = false;
				$_SESSION["isContractor"] = true;
				$_SESSION["isEmployee"] = true;
				$_SESSION["isSupervisor"] = true;

				$employee = new Employee();
				$employee->getEmployee($login["email"]);

				$_SESSION["employee"] = array(
					"emp_id" => $employee->emp_id,
					"emp_title" => $employee->emp_title,
					"emp_name" => $employee->emp_name,
					"emp_email" => $employee->emp_email,
					"emp_phone" => $employee->emp_phone,
					"emp_role" => $employee->emp_role,
					"isSupervising" => $employee->isSupervising
				);
				session_write_close();
				header('location:../dashboard.php');
			break;
		default:
				header('location:../loginpage.php?failed');
			break;
	}
?>