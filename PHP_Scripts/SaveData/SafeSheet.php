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
	// für jeden eintragen key auslesen
	//  daten in assoziatives array speichern/dictionary key und value paar
	//	geht leider nicht, weil das script keine Daten erhält, sondern nach welchen sucht
	
	//	string query = 'insert into datenbank'
	
	//alt von Chris ein versuch es besser zu entwickeln
	//$data = [];
	//foreach($_POST as $key =>  $val)
	//{
	//	$data[$key] = $val;
	//}
	
	$UserID			   =  $_POST['UserID		  '];
	$SheetNr		   =  $_POST['SheetNr		  '];
	$CharRace          =  $_POST['CharRace        '];
	$CharRaceAbility   =  $_POST['CharRaceAbility '];
	$CharName          =  $_POST['CharName        '];
	$CharWeight        =  $_POST['CharWeight      '];
	$CharHeight        =  $_POST['CharHeight      '];
	$CharAge           =  $_POST['CharAge         '];
	$CharHairColor     =  $_POST['CharHairColor   '];
	$CharSkinColor     =  $_POST['CharSkinColor   '];
	$CharGender        =  $_POST['CharGender      '];
	$CharLanguage      =  $_POST['CharLanguage    '];
	$CharReligion      =  $_POST['CharReligion    '];
	$CharFeature       =  $_POST['CharFeature     '];
	$CharEducation     =  $_POST['CharEducation   '];
	$CharEnvironment   =  $_POST['CharEnvironment '];
	$CharTraining      =  $_POST['CharTraining    '];
	$CharDestiny       =  $_POST['CharDestiny     '];
	$CharAmbition      =  $_POST['CharAmbition    '];
	$ModiAmount   	   =  $_POST['ModiAmount	  '];
	$AbilityAmount     =  $_POST['AbilityAmount   '];
	$ItemAmount        =  $_POST['ItemAmount      '];
		
	// über schleife den query-string selber zusammenbauen
	
	//$query = "INSERT INTO charcreate (";
	//foreach($data as $key =>  $val)
	//{
	//	$query .= "$key,"
	//}
	//// letztes komma wieder löschen
	//substr($query,0,-1);
	//$query .= ") VALUES (";
	//
	//foreach($data as $key =>  $val)
	//{
	//	$query .= "'" + $val + "',";
	//}
	//substr($query,0,-1);
	//// letztes komma wieder löschen
	//$query .= ")";
	

	//$query = "INSERT INTO charcreate ( UserID, CharCiv, CharName, CharWeight, CharHeight, CharAge, CharColor, CharLanguage, CharReligion, CharTraining, CharFeature, CharEducation, CharEnvironment) VALUES ('$userid', '$charciv','$charname', '$charweight','$charheight', '$charage','$charcolor', '$charlanguage','$charreligion','$chartraining','$charfeature','$chareducation','$charenvironment')";
	
	$query = "INSERT INTO charcreate (UserID, SheetNr, CharRace, CharRaceAbility, CharName, CharWeight, CharHeight, CharAge, CharHairColor, CharSkinColor, CharGender, CharLanguage, CharReligion, CharFeature, CharEducation, CharEnvironment, CharTraining, CharDestiny, CharAmbition, ModiAmount, AbilityAmount, ItemAmount) VALUES ('$UserID', '$SheetNr', '$CharRace', '$CharRaceAbility', '$CharName', '$CharWeight', '$CharHeight', '$CharAge', '$CharHairColor', '$CharSkinColor', '$CharGender', '$CharLanguage', '$CharReligion', '$CharFeature', '$CharEducation', '$CharEnvironment', '$CharTraining', '$CharDestiny', '$CharAmbition', '$ModiAmount', '$AbilityAmount', '$ItemAmount')";
	
	
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