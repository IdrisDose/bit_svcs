<?php
	session_start();
	
	if(isset($_GET["page"])) {
		$url = $_GET['page'] . ".php";
		redirect($url);
	}
	
	function redirect($url){
		if(isset($_SESSION["logged_in"])){
			header("location:../$url");
		} else {
			header("location:../index.php");
		}
	}
	
?>