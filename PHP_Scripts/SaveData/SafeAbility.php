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
	$SheetNr		= $_POST['SheetNr'];
	$AbiNr 	 		= $_POST['AbiNr'];
	$AbiName 	 	= $_POST['AbiName'];
	$AbiType	 	= $_POST['AbiType'];
	$AbiSchool	 	= $_POST['AbiSchool'];
	$AbiRange		= $_POST['AbiRange'];
	$AbiCost		= $_POST['AbiCost'];
	$AbiLength		= $_POST['AbiLength'];
	$AbiEffect		= $_POST['AbiEffect'];
	
	
	
	$query = "INSERT INTO abilitys (UserID, SheetNr,AbiNr, AbiName, AbiType, AbiSchool,AbiRange,AbiCost,AbiLength, AbiEffect) VALUES ('$UserID', '$SheetNr','$AbiNr', '$AbiName', '$AbiType', '$AbiSchool','$AbiRange','$AbiCost','$AbiLength', '$AbiEffect') ";
	
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