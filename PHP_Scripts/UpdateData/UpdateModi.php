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
	$SheetNr 	 = $_POST['SheetNr'];
	$ModiNr		 = $_POST['ModiNr'];
	$ModiName	 = $_POST['ModiName'];
	$ModiPotenz	 = $_POST['ModiPotenz'];
	$ModiLvl	 = $_POST['ModiLvl'];

	
	$query = "UPDATE items SET ModiName ='$ModiName' AND ModiPotenz ='$ModiPotenz' AND ModiLvl='$ModiLvl' WHERE ModiNr = '$ModiNr' AND UserID = '$UserID' AND SheetNr = '$SheetNr'";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "Modifikation geupdatet";
	}
	else
	{
		echo "lol";
	}
}

?>