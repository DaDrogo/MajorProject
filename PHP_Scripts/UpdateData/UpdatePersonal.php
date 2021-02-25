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
	$UserID		   	   =  $_POST['UserID'];
	$SheetNr	  	   =  $_POST['SheetNr'];
	$CharRace          =  $_POST['CharRace'];
	$CharRaceAbility   =  $_POST['CharRaceAbility'];
	$CharName          =  $_POST['CharName'];
	$CharWeight        =  $_POST['CharWeight'];
	$CharHeight        =  $_POST['CharHeight'];
	$CharAge           =  $_POST['CharAge'];
	$CharHairColor     =  $_POST['CharHairColor'];
	$CharSkinColor     =  $_POST['CharSkinColor'];
	$CharGender        =  $_POST['CharGender'];
	$CharLanguage      =  $_POST['CharLanguage'];
	$CharReligion      =  $_POST['CharReligion'];
	$CharDestiny       =  $_POST['CharDestiny'];
	$CharDestinyLevel  =  $_POST['CharDestinyLevel'];
	$CharAmbition      =  $_POST['CharAmbition'];
	$ModiAmount   	   =  $_POST['ModiAmount'];
	$AbilityAmount     =  $_POST['AbilityAmount'];
	$ItemAmount        =  $_POST['ItemAmount'];

	$query = "UPDATE charcreated SET UserID ='$UserID', SheetNr = '$SheetNr', CharRace = '$CharRace', CharRaceAbility = '$CharRaceAbility', CharName ='$CharName', CharWeight ='$CharWeight', CharHeight = '$CharHeight', CharAge = '$CharAge', CharHairColor = '$CharHairColor', CharSkinColor = '$CharSkinColor', CharGender = '$CharGender', CharLanguage = '$CharLanguage', CharReligion = '$CharReligion', CharDestiny = '$CharDestiny', CharDestinyLevel = '$CharDestinyLevel', CharAmbition = '$CharAmbition', ModiAmount = '$ModiAmount', AbilityAmount = '$AbilityAmount', ItemAmount = '$ItemAmount' WHERE UserID = '$UserID' AND SheetNr = '$SheetNr'";
	
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