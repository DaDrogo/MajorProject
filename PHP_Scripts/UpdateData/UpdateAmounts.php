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
	$SheetNr =  $_POST['SheetNr'];
	$ModiAmount = $_POST['ModiAmount'];
	$AbilityAmount = $_POST['AbilityAmount'];
	$ItemAmount = $_POST['ItemAmount'];
	
	$query = "UPDATE charcreate SET ModiAmount ='$ModiAmount' AND AbilityAmount ='$AblilityAmount' AND ItemAmount='$ItemAmount'  WHERE UserID = '$UserID' AND UserCharSheets = '$SheetNr'";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "gelungen";
	}
	else
	{
		echo "lol";
	}
}

?>