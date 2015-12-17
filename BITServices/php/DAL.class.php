<?php

class DAL
{	
	private $DB_HOST = 'localhost';
	private $DB_POST = '3307';
	private $DB_NAME = 'bit_svcs';
	private $DB_USER = 'root';
	private $DB_PASS = '';
	
	public $result = array();
	private $conn;

	public function __constructor()
	{

	}

	private function connectToDB()
	{
		$this->conn = new mysqli($this->DB_HOST,$this->DB_USER,$this->DB_PASS,$this->DB_NAME);
		if($this->conn->connect_error)
		{
			die("Connection failed: " . $this->conn->connection_error);
		}	
		
	}

	public function queryWithResult($query)
	{
		$this->connectToDB();
		$result = $this->conn->query($query);
		
		if($result != null)
		{			
			$this->conn->close();
			return $result;
		} else 
		{
			error_log("[MYSQL - DAL] Error Executing Query: {$this->conn->error}", 0);
			$this->conn->close();
			return $result;
		}
	}

	public function executeNonQuery($query)
	{
		$this->connectToDB();
		try{
			if($result = $this->conn->query($query))
			{	
				error_log("[MYSQL - DAL] Executed Query: {$query}", 0);
				$this->conn->close();
				return true;
			}
			else 
			{
				error_log("[MYSQL - DAL] Error Executing Query: {$this->conn->error}", 0);
				$this->conn->close();
				return false;
			}
		} catch (Exception $e)
		{
			error_log("[MYSQL - DAL] Error Executing Query: {$this->conn->error}", 0);
			$this->conn->close();
			return false;
		}

	}
	public function exists($query)
	{
		$this->connectToDB();
		try
		{
			$result = $this->queryWithResult($query);
			if($result->num_rows >= 1)
			{
				error_log("[MYSQL - DAL] Executed Query: {$query}", 0);
				$this->conn->close();
				return true;
			} else
			{
				error_log("[MYSQL - DAL] Executed Query: {$query}", 0);
				$this->conn->close();
				return false;
			}

		} catch (Exception $e)
		{
			error_log("[MYSQL - DAL] Error Executing Query: {$this->conn->error}", 0);
			$this->conn->close();
			return false;
		}
	}
}
?>