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
	
	
	$query = "INSERT INTO items (UserID, SheetNr,ItemNr, ItemName, ItemType, ItemWeight, ItemDescription) VALUES ('$UserID', '$SheetNr','$ItemNr', '$ItemName', '$ItemType', '$ItemWeight', '$ItemDescription') ";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "Item Saved";
	}
	else
	{
		echo "lol";
	}
}

?>