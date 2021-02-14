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
	$ItemNr =  $_POST['ItemNr'];

	$query = "SELECT ItemNr, ItemName, ItemType, ItemWeight, ItemDescription FROM charcreate WHERE UserID='$UserID' AND SheetNr='$SheetNr' AND ItemNr='$ItemNr'";
	$result = mysqli_query($connection, $query);

	if (mysqli_num_rows($result) > 0) 
	{
  		// output data of each row
 	 	while($row = mysqli_fetch_assoc($result)) 
		{
    			echo $row["ItemNr"]."|".$row["ItemName"]."|".$row["ItemType"]."|".$row["ItemWeight"]."|".$row["ItemDescription"];
		}
	} 
	else 
	{
  		echo "0 results";
	}

}

?>