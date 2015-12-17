<?php
	class Login
	{

		private $uname;
		private $pass;
		private $login_type;

		function __constructor() { }

		public function getLogin($uname,$pass){
			require_once('DAL.class.php');
			$d = new DAL();
			$sql = "SELECT login_type,email FROM logins WHERE uname='".$uname."' AND pass ='" . $pass . "'";
			$result = $d->queryWithResult($sql);


			if($result->num_rows > 0)
			{
				return $result->fetch_assoc();
			} else {
				return "NULL";
			}
		}



		/**
		* Messy newLogin but seems to work?
		*/
		function newLogin($name,$uname,$email,$pword)
		{
			require_once('DAL.class.php');
			require_once('client.class.php');

			$c = new Client();
			$d = new DAL();

			$sql = "SELECT login_type,email FROM logins WHERE uname='".$uname."' OR email ='" . $email . "'";
			$bool = $d->exists($sql);

			if(!$bool)
			{
			
				$sql = "INSERT INTO logins (login_type, uname, email, pass) VALUES ('CLIENT','" . $uname ."','" . $email . "','" . $pword . "')";
				
				$result = $d->executeNonQuery($sql);
				$creatednewclient = $c->createNewClient($name,$email);
				
				if($result && $creatednewclient)
				{
					return true;

				} else {
					return false;
				}
			} else 
			{
				return false;
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