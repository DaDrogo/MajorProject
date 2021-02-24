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
	$SheetNr= $_POST['SheetNr'];
	$ItemNr	= $_POST['ItemNr'];
	$ItemName = $_POST['ItemName'];
	$ItemType = $_POST['ItemType'];
	$ItemWeight = $_POST['ItemWeight'];
	$ItemDescription = $_POST['ItemDescription'];
	
	$query = "UPDATE items SET ItemName ='$ItemName' , ItemType ='$ItemType' , ItemWeight='$ItemWeight' , ItemDescription='$ItemDescription' WHERE UserID = '$UserID' AND SheetNr = '$SheetNr' AND ItemNr = '$ItemNr'";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "Item geupdatet";
	}
	else
	{
		echo "lol";
	}
}

?>