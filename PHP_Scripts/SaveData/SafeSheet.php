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
	// in schleife durch post-array durchgehen
	// fÃ¼r jeden eintragen key auslesen
	//  daten in assoziatives array speichern/dictionary key und value paar
	//	geht leider nicht, weil das script keine Daten erhÃ¤lt, sondern nach welchen sucht
	
	//	string query = 'insert into datenbank'
	
	//alt von Chris ein versuch es besser zu entwickeln
	//$data = [];
	//foreach($_POST as $key =>  $val)
	//{
	//	$data[$key] = $val;
	//}
	
	//$UserID			 =  $_POST['UserID'];
	//$SheetNr			 =  $_POST['SheetNr'];
	//$CharRace          =  $_POST['CharRace'];
	//$CharRaceAbility   =  $_POST['CharRaceAbility'];
	//$CharName          =  $_POST['CharName'];
	//$CharWeight        =  $_POST['CharWeight'];
	//$CharHeight        =  $_POST['CharHeight'];
	//$CharAge           =  $_POST['CharAge'];
	//$CharHairColor     =  $_POST['CharHairColor'];
	//$CharSkinColor     =  $_POST['CharSkinColor'];
	//$CharGender        =  $_POST['CharGender'];
	//$CharLanguage      =  $_POST['CharLanguage'];
	//$CharReligion      =  $_POST['CharReligion'];
	//$CharDestiny       =  $_POST['CharDestiny'];
	//$CharDestinyLevel  =  $_POST['CharDestinyLevel'];
	//$CharAmbition      =  $_POST['CharAmbition'];
	//$ModiAmount   	 =  $_POST['ModiAmount'];
	//$AbilityAmount     =  $_POST['AbilityAmount'];
	//$ItemAmount        =  $_POST['ItemAmount'];
	
	//$UserID			   = '9';
	//$SheetNr		   = '9';
	//$CharRace          = '9';
	//$CharRaceAbility   = '9';
	//$CharName          = '9';
	//$CharWeight        = '9';
	//$CharHeight        = '9';
	//$CharAge           = '9';
	//$CharHairColor     = '9';
	//$CharSkinColor     = '9';
	//$CharGender        = '9';
	//$CharLanguage      = '9';
	//$CharReligion      = '9';
	//$CharDestiny       = '9';
	//$CharDestinyLevel  = '9';
	//$CharAmbition      = '9';
	//$ModiAmount   	   = '9';
	//$AbilityAmount     = '9';
	//$ItemAmount        = '9';
		
	// Ã¼ber schleife den query-string selber zusammenbauen
	
	//$query = "INSERT INTO charcreate (";
	//foreach($data as $key =>  $val)
	//{
	//	$query .= "$key,"
	//}
	//// letztes komma wieder lÃ¶schen
	//substr($query,0,-1);
	//$query .= ") VALUES (";
	//
	//foreach($data as $key =>  $val)
	//{
	//	$query .= "'" + $val + "',";
	//}
	//substr($query,0,-1);
	//// letztes komma wieder lÃ¶schen
	//$query .= ")";
	

	//$query = "INSERT INTO charcreate ( UserID, CharCiv, CharName, CharWeight, CharHeight, CharAge, CharColor, CharLanguage, CharReligion, CharTraining, CharFeature, CharEducation, CharEnvironment) VALUES ('$userid', '$charciv','$charname', '$charweight','$charheight', '$charage','$charcolor', '$charlanguage','$charreligion','$chartraining','$charfeature','$chareducation','$charenvironment')";
	
	//$query = "INSERT INTO charcreate (UserID, SheetNr, CharRace, CharRaceAbility, CharName, CharWeight, CharHeight, CharAge, CharHairColor,CharSkinColor, CharGender, CharLanguage, CharReligion, CharDestiny, CharDestinyLevel, CharAmbition, ModiAmount, AbilityAmount, ItemAmount) VALUES ('$UserID', '$SheetNr', '$CharRace', '$CharRaceAbility', '$CharName', '$CharWeight', '$CharHeight', '$CharAge', '$CharHairColor', '$CharSkinColor', '$CharGender', '$CharLanguage', '$CharReligion', '$CharDestiny','$CharDestinyLevel', '$CharAmbition', '$ModiAmount', '$AbilityAmount', '$ItemAmount')";
	$query = "INSERT INTO charcreate(UserID) VALUES ('9')";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "Sheet Saved";
	}
	else
	{
		echo "lol";
	}
}
?>