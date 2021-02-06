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
	$UserID = $_POST['UserID'];
	$SheetNr =  $_POST['SheetNr'];
	$AG   		=  $_POST['AG'];
	$AGplus   	=  $_POST['AGplus'];
	$AGminus   	=  $_POST['AGminus '];
	$KR   		=  $_POST['KR '];
	$KRplus   	=  $_POST['KRplus '];
	$KRminus   	=  $_POST['KRminus '];
	$AU   		=  $_POST['AU '];
	$AUplus   	=  $_POST['AUplus '];
	$AUminus   	=  $_POST['AUminus '];
	$RE   		=  $_POST['RE '];
	$REplus   	=  $_POST['REplus '];
	$REminus   	=  $_POST['REminus '];
	$GE   		=  $_POST['GE '];
	$GEplus   	=  $_POST['GEplus '];
	$GEminus   	=  $_POST['GEminus '];
	$VE   		=  $_POST['VE '];
	$VEplus   	=  $_POST['VEplus '];
	$VEminus   	=  $_POST['VEminus '];

	$query = "INSERT INTO basevalues (AG, AGplus, AGminus, KR, KRplus, KRminus, AU, AUplus, AUminus, RE, REplus, REminus, GE, GEplus, GEminus, VE, VEplus, VEminus) VALUES ('$AG', '$AGplus', '$AGminus', '$KR', '$KRplus', '$KRminus', '$AU', '$AUplus', '$AUminus', '$RE', '$REplus', '$REminus', '$GE', '$GEplus', '$GEminus', '$VE', '$VEplus', '$VEminus')";
	
	$result = mysqli_query($connection, $query);
	if($result)
	{
		echo "Values Saved";
	}
	else
	{
		echo "lol";
	}
}
?>