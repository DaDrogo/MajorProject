<?php
$hostname = "localhost";
$database = "charsheet";
$database_username = "root";
$database_password = "";

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
	
	//	string query = 'insert into datenbank'
	
	$data = [];
	foreach($_POST as $key =>  $val)
	{
		$data[$key] = $val;
	}
	$userid = $_POST['userid'];
	//$charciv = $_POST['charciv'];
	//$charname = $_POST['charname'];
	//$charweight = $_POST['charweight'];
	//$charheight = $_POST['charheight'];
	//$charage = $_POST['charage'];
	//$charcolor = $_POST['charcolor'];
	//$charlanguage = $_POST['charlanguage'];
	//$charreligion = $_POST['charreligion'];
	//$chartraining = $_POST['chartraining'];
	//$charfeature = $_POST['charfeature'];
	//$chareducation = $_POST['chareducation'];
	//$charenvironment = $_POST['charenvironment'];
	
	array 0 
	
	// über schleife den query-string selber zusammenbauen
	
	$query = "INSERT INTO charcreate (";
	foreach($data as $key =>  $val)
	{
		$query += "$key,"
	}
	// letztes komma wieder löschen
	
	$query += ") VALUES (";
	
	foreach($data as $key =>  $val)
	{
		$query += "'" + $val + "',";
	}
	
	// letztes komma wieder löschen
	query += ")";


	//$query = "INSERT INTO charcreate ( UserID, CharCiv, CharName, CharWeight, CharHeight, CharAge, CharColor, CharLanguage, CharReligion, CharTraining, CharFeature, CharEducation, CharEnvironment) VALUES ('$userid', '$charciv','$charname', '$charweight','$charheight', '$charage','$charcolor', '$charlanguage','$charreligion','$chartraining','$charfeature','$chareducation','$charenvironment')";
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "ha";
	}
	else
	{
		echo "lol";
	}
}
?>