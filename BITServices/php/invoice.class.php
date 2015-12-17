<?php 
	class invoice{

		private $invoice_id;
		private $invoice_details;
		private $invoice_status;
		private $job_id;
		private $client_id;
		private $invoice_list = array();

		function __constructor(){	}

		public function getInvoices($cl_id)
		{
			require_once('DAL.class.php');

			$d = new DAL();
			$sql = "SELECT * FROM invoices WHERE client_id='".$cl_id."'";
			$result = $d->queryWithResult($sql);
			

			if($result->num_rows > 0)
			{
				while($row = $result->fetch_assoc()) 
				{
					array_push($this->invoice_list,
						array(
								"inv_id" => $row["invoice_id"],
								"inv_details" => $row["invoice_details"],
								"inv_status" => $row["invoice_status"],
								"inv_amount" => $row["invoice_amount"],
								"job_id" => $row["job_id"]
							)
						);
				}
					return $this->invoice_list;
			} else {
					$this->invoice_list = array(
							array(
								"inv_id" => "NULL",
								"inv_details" => "NULL",
								"inv_status" => "NULL",
								"inv_amount" => "0.00",
								"job_id" => "NULL"
							)
						);
				return $this->invoice_list;
				
			}
		}

		public function getInvoicesE()
		{
			require_once('DAL.class.php');

			$d = new DAL();
			$sql = "SELECT invoice_id,invoice_details,invoice_status,invoice_amount,job_name FROM invoices, jobs WHERE invoices.job_id = jobs.job_id";
			$result = $d->queryWithResult($sql);
			

			if($result->num_rows > 0)
			{
				while($row = $result->fetch_assoc()) 
				{
					array_push($this->invoice_list,
						array(
								"inv_id" => $row["invoice_id"],
								"inv_details" => $row["invoice_details"],
								"inv_status" => $row["invoice_status"],
								"inv_amount" => $row["invoice_amount"],
								"job_name" => $row["job_name"]
							)
						);
				}
					return $this->invoice_list;
			} else {
					$this->invoice_list = array(
							array(
								"inv_id" => "NULL",
								"inv_details" => "NULL",
								"inv_status" => "NULL",
								"inv_amount" => "0.00",
								"job_name" => "NULL"
							)
						);
				return $this->invoice_list;
				
			}
		}
		
			
		function creatNewInvoice($job_id,$inv_desc,$inv_amount,$client_id)
		{
			require_once('DAL.class.php');

			$d = new DAL();
			$sql = "INSERT INTO invoices (invoice_details,invoice_status,invoice_amount,job_id,client_id)
  					VALUES('$inv_desc','UNPAID',$inv_amount,$job_id,$client_id)";
			$result = $d->executeNonQuery($sql);
			return $result;
		}

		function payInvoice($inv_id)
		{
			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "UPDATE invoices
					SET invoice_status = 'PAID'
					WHERE invoice_id = $inv_id";
			$result = $d->executeNonQuery($sql);
			return $result;
		}

		public function __set($name,$value){
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