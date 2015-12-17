<?php

	class Employee {
		private $emp_id;
		private $emp_title;
		private $emp_name;
		private $emp_email;
		private $emp_phone;
		private $emp_role;
		private $isSupervising;	
		private $isActive;
		private $isAdmin;
		public $staff_list = array();

		function __constructor(){ }

		
		public function getEmployee($emailIn)
		{
			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "SELECT * FROM employees WHERE email='".$emailIn."'";
			$result = $d->queryWithResult($sql);


			if($result->num_rows > 0)
			{
				while($row = $result->fetch_assoc()) 
				{
					$this->emp_id = $row['employee_id'];
					$this->emp_title = $row['title'];
					$this->emp_name = $row['name'];
					$this->emp_email = $row['email'];
					$this->emp_phone = $row['phone'];
					$this->emp_role = $row['role'];
					$this->isSupervising = $row['isSupervising'];
					$this->isActive = $row['isActive'];
					$this->isAdmin = $row['isAdmin'];

				}
			}
		}

		public function getEmployeeNameById($id)
		{
			if($id == 0)
			{
				return "None";
			}

			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "SELECT * FROM employees WHERE employee_id='".$id."'";
			$result = $d->queryWithResult($sql);

			if($result != null)
			{
				while($row = $result->fetch_assoc()) 
				{
					return $row['name'];
				}
			} else 
			{
				return "unkown";
			}
		}

		function getStaff()
		{
			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "SELECT * FROM employees";
			$result = $d->queryWithResult($sql);
			
			if($result->num_rows > 0)
			{
				while($row = $result->fetch_assoc()) 
				{
					array_push($this->staff_list,
						array(
							"emp_id" => $row["employee_id"],
							"emp_title" => $row["title"],
							"emp_name" => $row["name"],
							"emp_email" => $row["email"],
							"emp_phone" => $row["phone"],
							"emp_role" => $row["role"],
							"isSupervisor" => $row['isSupervising'],
							"active" => $row['isActive'],
							"isadmin" => $row['isAdmin']
						)
					);
				}
				return $this->staff_list;
			} else {
				array_push($this->staff_list,
						array(
							"emp_id" => "NULL",
							"emp_title" => "NULL",
							"emp_name" => "NULL",
							"emp_email" => "NULL",
							"emp_phone" => "NULL",
							"emp_role" => "NULL",
							"isSupervisor" => "NULL",
							"active" => false,
							"isadmin" => false,
						)
					);
				return $this->staff_list;
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