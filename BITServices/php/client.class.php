<?php

	class Client {
		private $client_id;
		private $client_title;
		private $client_name;
		private $client_address;
		private $client_city;
		private $client_postcode;
		private $client_email;
		private $client_phone;
		private $client_mobile;
		private $client_active;
		public 	$client_list = array();

		function __constructor() { }

		public function getClient($emailIn)
		{
			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "SELECT * FROM clients WHERE email='".$emailIn."'";
			$result = $d->queryWithResult($sql);


			if($result->num_rows > 0)
			{
				while($row = $result->fetch_assoc()) 
				{
					$this->client_id = $row["client_id"];
					$this->client_title = $row["title"];
					$this->client_name = $row["name"];
					$this->client_address = $row["street_address"];
					$this->client_city = $row["city"];
					$this->client_postcode = $row["postcode"];
					$this->client_email = $row["email"];
					$this->client_phone = $row["phone"];
					$this->client_mobile = $row["mobile"];
					$this->client_active = $row["active"];
				}
			}
		}

		public function getClientNameById($id)
		{
			if($id == 0)
			{
				return "None";
			}

			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "SELECT name FROM clients WHERE client_id='".$id."'";
			$result = $d->queryWithResult($sql);

			if($result != null)
			{
				$row = $result->fetch_assoc();
				return $row['name'];
					
			} else 
			{
				return "unkown";
			}
		}

		function createNewClient($name,$email)
		{
			require_once('DAL.class.php');

			$d = new DAL();
			$sql = "INSERT INTO clients (name,email)
					VALUES('$name','$email')";

			$result = $d->executeNonQuery($sql);
			return $result;
		}

		function getClients()
		{
			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "SELECT * FROM clients";
			$result = $d->queryWithResult($sql);
			
			if($result->num_rows > 0)
			{
				while($row = $result->fetch_assoc()) 
				{
					array_push($this->client_list,
						array(
							"cl_id" => $row["client_id"],
							"cl_title" =>  $row["title"],
							"cl_name" =>  $row["name"],
							"cl_address" => $row["street_address"],
							"cl_city" =>  $row["city"],
							"cl_postcode" =>  $row["postcode"],
							"cl_email" =>  $row["email"],
							"cl_phone" =>  $row["phone"],
							"cl_mobile" =>  $row["mobile"],
							"cl_active" => $row['active']

						)
					);
				}
				return $this->client_list;
			} else {
				array_push($this->client_list,
						array(
							"cl_id" => "NULL",
							"cl_title" =>  "NULL",
							"cl_name" =>  "NULL",
							"cl_address" => "NULL",
							"cl_city" =>  "NULL",
							"cl_postcode" =>  "NULL",
							"cl_email" =>  "NULL",
							"cl_phone" =>  "NULL",
							"cl_mobile" =>  "NULL",
							"cl_active" => false
						)
					);
				return $this->client_list;
			}
		}
		
		
		function __set($name,$value){
			$this->$name = $value;
		}

		public function __get($name){
			if (isset($name)) 
			{
				return $this->$name;
			} else {
				echo "ERROR variable is null";
			}
		}

	}

?>