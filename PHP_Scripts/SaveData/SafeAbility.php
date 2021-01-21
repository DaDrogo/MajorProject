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
	$UserID 	 	= $_POST['UserID'];
	$CharSheetNr 	= $_POST['CharSheetNr'];
	$AbiName 	 	= $_POST['AbiName'];
	$AbiType	 	= $_POST['AbiType'];
	$AbiExhaust	 	= $_POST['AbiExhaust'];
	$AbiEffect		= $_POST['AbiEffect'];	
	
	
	$query = "INSERT INTO abilitys (UserID, CharSheetNr, AbiName, AbiType, AbiExhaust, AbiEffect) VALUES ('$UserID', '$CharSheetNr', '$AbiName', '$AbiType', '$AbiExhaust', '$AbiEffect') ";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "Ability Saved";
	}
	else
	{
		echo "lol";
	}
}

?>