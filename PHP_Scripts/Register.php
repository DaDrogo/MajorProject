<?php
$hostname = "localhost";
$database = "charsheet";
$database_username = "root";
$database_password = "";

$connection = mysqli_connect($hostname, $database_username, $database_password, $database);
if(mysqli_connect_errno())
{
	die("halt stop");
}
else
{
	$username = $_POST['username'];
	
	$passport = $_POST['passport'];
	
	//$query = "INSERT INTO 'login' ( Username, Passport) VALUES ($)";
	$query = "INSERT INTO login ( Username, Passport) VALUES ('$username', '$passport')";
	$result = mysqli_query($connection, $query);
	if($result)
	{
		
		$query = "SELECT UserID FROM login";
		$Comeback = mysqli_query($connection, $query);
		echo $Comeback;
	}
	else
	{
		echo "lol";
	}
}
?>