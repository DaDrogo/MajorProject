<?php
$hostname = "localhost";
$database = "charsheet";
$database_username = "kingdrogo";
$database_password = "12345";

$connection = mysqli_connect($hostname, $database_username, $database_password, $database);
if(mysqli_connect_errno())
{
	die("halt stop");
}
else
{
	$UserID = $_POST['UserID'];
	$UserCharSheets = $_POST['UserCharSheets'];
	
	
	
	$query = "INSERT INTO userinfo (UserID, UserCharSheets) VALUES ('$UserID','$UserCharSheets') ";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "User Saved";
	}
	else
	{
		echo "lol";
	}
}

?>