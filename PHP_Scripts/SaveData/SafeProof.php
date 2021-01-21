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
	
	$ProfDeath   	=  $_POST['ProfDeath'];
	$ProfDeathII   	=  $_POST['ProfDeathII'];
	$ProfLife   	=  $_POST['ProfLife '];
	$ProfLifeII   	=  $_POST['ProfLifeII '];
	$ProfFriend   	=  $_POST['ProfFriend '];
	$ProfFriendII   =  $_POST['ProfFriendII '];
	$ProfLonely   	=  $_POST['ProfLonely '];
	$ProfLonelyII   =  $_POST['ProfLonelyII '];
	$ProfMind   	=  $_POST['ProfMind '];
	$ProfMindII   	=  $_POST['ProfMindII '];
	$ProdDestiny   	=  $_POST['ProdDestiny '];
	$ProfDestinyII  =  $_POST['ProfDestinyII '];
	$ProfGreed   	=  $_POST['ProfGreed '];
	$ProfGreedII   	=  $_POST['ProfGreedII '];
	$ProfZero   	=  $_POST['ProfZero '];
	$ProfZeroII   	=  $_POST['ProfZeroII '];
	
	$query = "INSERT INTO proofs (ProfDeath, ProfDeathII, ProfLife, ProfLifeII, ProfFriend, ProfFriendII, ProfLonely, ProfLonelyII, ProfMind, ProfMindII, ProdDestiny, ProfDestinyII, ProfGreed, ProfGreedII, ProfNull, ProfNullII) VALUES ('$ProfDeath', '$ProfDeathII', '$ProfLife', '$ProfLifeII', '$ProfFriend', '$ProfFriendII', '$ProfLonely', '$ProfLonelyII', '$ProfMind', '$ProfMindII', '$ProdDestiny', '$ProfDestinyII', '$ProfGreed', '$ProfGreedII', '$ProfZero', '$ProfZeroII')";
	
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