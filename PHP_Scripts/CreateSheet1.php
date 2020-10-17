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
	$userid = $_POST['userid'];
	$charciv = $_POST['charciv'];
	$charname = $_POST['charname'];
	$charweight = $_POST['charweight'];
	$charheight = $_POST['charheight'];
	$charage = $_POST['charage'];
	$charcolor = $_POST['charcolor'];
	$charlanguage = $_POST['charlanguage'];
	$charreligion = $_POST['charreligion'];
	$chartraining = $_POST['chartraining'];
	$charfeature = $_POST['charfeature'];
	$chareducation = $_POST['chareducation'];
	$charenvironment = $_POST['charenvironment'];
	
	$query = "INSERT INTO charcreate ( UserID, CharCiv, CharName, CharWeight, CharHeight, CharAge, CharColor, CharLanguage, CharReligion, CharTraining, CharSign, CharEducation, CharEnvironment) VALUES ('$userid', '$charciv','$charname', '$charweight','$charheight', '$charage','$charcolor', '$charlanguage','$charreligion','$chartraining','$charfeature','$chareducation','$charenvironment')";
	$result = mysqli_query($connection, $query);
	if($result)
	{
		$results = mysqli_query($connection, $querys);
		echo $results;
		echo "ha";
	}
	else
	{
		echo "lol";
	}
}
?>