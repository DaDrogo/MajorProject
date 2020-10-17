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
	//bekommt zwei Daten als Input
	//$user = "1";
	//$pass = "9";
	
	$user =  $_POST['username'];
	$pass =  $_POST['passport'];
	
	//diese müssen getestet werden. Ob sie vorhanden sind
	//dafür wird die UserID gezogen von dem User mit dem exakten namen und passport
	//WARNUNG: hier könnte genauer gearbeitet werden und getestet werden, wo der Fehler liegt
	//Hier testen()
		$query_user = "SELECT UserID FROM login  WHERE Username = '$user'";
		$comeback_1 = mysqli_query($connection, $query_user);
		if(mysqli_num_rows($comeback_1) > 0)
		{
			$query_pass = "SELECT UserID FROM login  WHERE Username = '$user' && Passport = '$pass'";
			$Comeback = mysqli_query($connection, $query_pass);
			if(mysqli_num_rows($Comeback) > 0)
			{
				while($row = mysqli_fetch_assoc($Comeback))
				{
					echo $row["UserID"];
				}				
			}
			else
			{
				echo "WrongPass";
			}
		}
		else
		{
			echo "WrongUser";
		}
	//schritt2 füge den Input in die Datenbank ein.
	//gibt die ID wieder um den Spieler einzuloggen.
	//mit der ID/Username kann der User auf alles zugreifen
				
}
?>