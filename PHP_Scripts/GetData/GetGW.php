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
	$UserID	=  $_POST['UserID'];
	$SheetNr =  $_POST['SheetNr'];

	$query = "SELECT AG, AGplus, AGminus, KR, KRplus, KRminus, AU, AUplus, AUminus, RE, REplus, REminus, GE, GEplus, GEminus, VE, VEplus, VEminus FROM basevalues WHERE UserID='$UserID' AND SheetNr='$SheetNr'";
	$result = mysqli_query($connection, $query);

	if (mysqli_num_rows($result) > 0) 
	{
  		// output data of each row
 	 	while($row = mysqli_fetch_assoc($result)) 
		{
    			echo $row["AG"]." ".$row["AGplus"]." ".$row["AGminus"]." ".$row["KR"]." ".$row["KRplus"]." ".$row["KRminus"]." ".$row["AU"]." ".$row["AUplus"]." ".$row["AUminus"]." ".$row["RE"]." ".$row["REplus"]." ".$row["REminus"]." ".$row["GE"]." ".$row["GEplus"]." ".$row["GEminus"]." ".$row["VE"]." ".$row["VEplus"]." ".$row["VEminus"];
		}
	} 
	else 
	{
  		echo "0 results";
	}

}
?>