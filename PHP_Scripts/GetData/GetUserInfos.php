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
	
	
	$query_user = "SELECT UserCharSheets FROM userinfo WHERE UserID = '$UserID' ";
	$comeback = mysqli_query($connection, $query_user);
	if(mysqli_num_rows($comeback) > 0)
	{
		while($row = mysqli_fetch_assoc($comeback))
				{
					echo $row["UserCharSheets"];
				}
	}
	else
	{
		echo "0";
	}
}

?>