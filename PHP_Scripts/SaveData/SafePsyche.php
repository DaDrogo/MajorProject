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
	$UserID 	 = $_POST['UserID'];
	$CharSheetNr = $_POST['CharSheetNr'];
	$ModiNr		 = $_POST['ModiNr'];
	$ModiName	 = $_POST['ModiName'];
	$ModiPotenz	 = $_POST['ModiPotenz'];
	$ModiLvl	 = $_POST['ModiLvl'];
	
	
	$query = "INSERT INTO modifications (UserID, CharSheetNr, ModiNr, ModiName, ModiPotenz, ModiLvl) VALUES ('$UserID', '$CharSheetNr', '$ModiNr', '$ModiName', '$ModiPotenz', '$ModiLvl')";
	
	
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "Modi Saved";
	}
	else
	{
		echo "lol";
	}
}

?>