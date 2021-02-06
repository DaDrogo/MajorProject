<?php
$hostname = "localhost";
$database = "charsheet";
$database_username = "kingdrogo";
$database_password = "12345";

// Create connection
$connection = mysqli_connect($hostname, $database_username, $database_password, $database);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

	$UserID			   =  $_POST['UserID'];
	$SheetNr		   =  $_POST['SheetNr'];

$sql = "SELECT CharRace, CharName FROM charcreate WHERE UserID='$UserID' AND SheetNr='$SheetNr'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo $row["CharName"]. "<br>" ;
    echo $row["CharRace"] ;

  }
} else {
  echo "0 results";
}

$conn->close();
?>