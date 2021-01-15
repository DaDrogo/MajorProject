<?php
$hostname = "localhost";
$database = "Login";
$database_username = "kingdrogo";
$database_password = "12345";

$connection = mysqli_connect($hostname, $database_username, $database_password, $database);
if(mysqli_connect_errno())
{
	die("halt stop");
}
else
{
	//bekommt zwei Daten als Input
	$user = "1";
	$pass = "9";
	
	//$user =  $_POST['username'];
	//$pass =  $_POST['passport'];
	
	//diese müssen getestet werden. Ob sie schon vorhanden sind
	//dafür hier alle Usernames aus login ziehen und abgleichen
	//falls noch nicht vorhanden gehe zu schritt 2 
	//falls vorhanden abbruch und wiedergeben, dass schon voranden
	//Hier testen()
		$queryt = "SELECT UserID FROM login  WHERE Username = '$user'";
		$Comeback = mysqli_query($connection, $queryt);
		if($Comeback)
		{
			if(mysqli_num_rows($Comeback) > 0)
			{
				echo "RegisterWrong";				
			}
			else
			{
				$query = "INSERT INTO login ( Username, Passport) VALUES ('$user', '$pass')";
				$result = mysqli_query($connection, $query);
				if($result)
				{
					echo "Succces";
				}
			}
		}
	//schritt2 füge den Input in die Datenbank ein.
	//gibt die ID wieder um den Spieler einzuloggen.
	//mit der ID/Username kann der User auf alles zugreifen
				
}
?>