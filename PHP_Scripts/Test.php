<?php
$servername = "localhost";
$dbname = "Login";
$username = "kingdrogo";
$password = "12345";


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Username, Passport FROM login WHERE UserID='16'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "Name: ". $row["Username"]. "<br>" ;
    echo "Passport: " . $row["Passport"] ;

  }
} else {
  echo "0 results";
}

$conn->close();
?>