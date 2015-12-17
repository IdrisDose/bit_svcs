<?php

class job{
	private $job_id;
	private $job_details;
	private $client_id;
	private $emp_id;
	private $super_id;
	private $job_list = array();

	function __constructor(){	}

	public function getJobs($cl_id)
	{
		require_once('DAL.class.php');
		require_once('employee.class.php');
		$d = new DAL();
		$e = new Employee();
		$sql = "SELECT * FROM jobs WHERE client_id='".$cl_id."'";
		$result = $d->queryWithResult($sql);
		
		if($result->num_rows > 0)
		{
			while($row = $result->fetch_assoc()) 
			{
				array_push($this->job_list,
					array(
						"job_id" => $row["job_id"],
						"job_name" => $row["job_name"],
						"job_details" => $row["job_details"],
						"employee" => $e->getEmployeeNameById($row["employee_id"]),
						"priority" => $row["priority"],
						"location" => $row['job_location'],
						"active" => $row['active']
					)
				);
			}
			return $this->job_list;
		} else {
			array_push($this->job_list,
					array(
						"job_id" => "NULL",
						"job_name" => "NULL",
						"job_details" => "NULL",
						"employee" => "NULL",
						"priority" => "NULL",
						"location" => "NULL",
						"active" => false
					)
				);
			return $this->job_list;
		}
	}

	public function getJobsE($e_id)
	{
		require_once('DAL.class.php');
		require_once('client.class.php');
		require_once('employee.class.php');
		$d = new DAL();
		$c = new Client();
		$e = new Employee();

		$sql = "SELECT * FROM jobs WHERE employee_id='".$e_id."'";
		$result = $d->queryWithResult($sql);

		if($result->num_rows > 0)
		{
			while($row = $result->fetch_assoc()) 
			{
				array_push($this->job_list,
						array(
						"job_id" => $row["job_id"],
						"job_name" => $row["job_name"],
						"job_details" => $row["job_details"],
						"client" => $c->getClientNameById($row['client_id']),
						"employee" => $e->getEmployeeNameById($row["employee_id"]),
						"priority" => $row["priority"],
						"location" => $row['job_location'],
						"client_id" => $row['client_id'],
						"active" => $row['active']
					)
				);
			}
			return $this->job_list;
		} else {
			array_push($this->job_list,
					array(
						"job_id" => "NULL",
						"job_name" => "NULL",
						"job_details" => "NULL",
						"client" => "NULL",
						"employee" => "NULL",
						"priority" => "NULL",
						"location" => "NULL",
						"active" => false
					)
				);
			return $this->job_list;
		}
	}

	public function getJobsAll()
	{
		require_once('DAL.class.php');
		require_once('client.class.php');
		require_once('employee.class.php');
		$d = new DAL();
		$c = new Client();
		$e = new Employee();

		$sql = "SELECT * FROM jobs";
		$result = $d->queryWithResult($sql);

		if($result->num_rows > 0)
		{
			while($row = $result->fetch_assoc()) 
			{
				array_push($this->job_list,
						array(
						"job_id" => $row["job_id"],
						"job_name" => $row["job_name"],
						"job_details" => $row["job_details"],
						"client" => $c->getClientNameById($row['client_id']),
						"employee" => $e->getEmployeeNameById($row["employee_id"]),
						"priority" => $row["priority"],
						"location" => $row['job_location'],
						"client_id" => $row['client_id'],
						"active" => $row['active']
					)
				);
			}
			return $this->job_list;
		} else {
			return "NULL";
		}
	}

	function getClientIDinJob($job_id)
	{
		require_once('DAL.class.php');

		$d = new DAL();
		$sql = "SELECT client_id FROM jobs WHERE job_id='".$job_id."'";
		$result = $d->queryWithResult($sql);
		
		if($result->num_rows > 0)
		{
			while($row = $result->fetch_assoc()) 
			{
				return $row['client_id'];
			}
		} else {
			return "NULL";
		}
	}

	function requestNewJob($jobname,$job_desc,$client_id,$job_priority,$job_location)
	{

		require_once('DAL.class.php');

		$d = new DAL();
		$sql = "INSERT INTO jobs (job_name,job_details,client_id,priority,job_location)
				VALUES('{$jobname}','{$job_desc}',{$client_id},'{$job_priority}','{$job_location}')";

		$result = $d->executeNonQuery($sql);
		return $result;
	}

	function assignJob($jID, $eID)
	{
		require_once('DAL.class.php');

		$d = new DAL();
		$sql = "UPDATE jobs SET employee_id={$eID} WHERE job_id={$jID}";
		$result = $d->executeNonQuery($sql);
		return $result;
	}

	function activeJob($jID, $active)
	{
		require_once('DAL.class.php');

		$d = new DAL();
		$sql = "UPDATE jobs SET active={$active} WHERE job_id={$jID}";
		$result = $d->executeNonQuery($sql);
		return $result;
	}

	function delJob($jID)
	{
		require_once('DAL.class.php');

		$d = new DAL();
		$sql = "DELETE FROM jobs WHERE job_id={$jID}";
		$result = $d->executeNonQuery($sql);
		return $result;
	}

	function requestNewJobA($jobname,$job_desc,$client_id,$job_priority,$job_location,$emp_id,$super_id)
	{

		require_once('DAL.class.php');

		$d = new DAL();
		$sql = "INSERT INTO jobs (job_name,job_details,client_id,priority,job_location,employee_id,supervisor_id)
				VALUES('$jobname','$job_desc',$client_id,'$job_priority','$job_location',$emp_id,$super_id)";

		$result = $d->executeNonQuery($sql);
		return $result;
	}

	function __set($name,$value){
		$this->$name = $value;
	}

	public function __get($name){
		if(isset($this->$name))
		{
			return $this->$name;
		} else {
			echo "ERROR " . $this->$name . " is null";
		}
	}
}

?>