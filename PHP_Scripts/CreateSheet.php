<?php
$hostname = "localhost";
$database = "examplename";
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
	$cahrreligion = $_POST['cahrreligion'];
	
	$query = "INSERT INTO charsheet ( UserID, CharCiv, CharName, CharWeight, CharHeight, CharAge, CharColor, CharLanguage, CharReligion) VALUES ('$userid', '$charciv','$charname', '$charweight','$charheight', '$charage','$charcolor', '$charlanguage','$charreligion')";
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