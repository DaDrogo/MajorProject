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
	$UserID			   =  $_POST['UserID'];
	$SheetNr		   =  $_POST['SheetNr'];

$sql = "SELECT AG, AGplus, AGminus, KR, KRplus, KRminus, AU, AUplus, AUminus, RE, REplus, REminus, GE, GEplus, GEminus, VE, VEplus, VEminus FROM basevalues WHERE UserID=$UserID AND SheetNr='$SheetNr'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo $row["AG"]. "<br>" ;
    echo $row["AGplus"]. "<br>"  ;
	echo $row["AGminus"]. "<br>" ;
    echo $row["KR"]. "<br>"  ;
	echo $row["KRplus"]. "<br>" ;
    echo $row["KRminus"]. "<br>"  ;
	echo $row["AU"]. "<br>" ;
    echo $row["AUplus"]. "<br>"  ;
	echo $row["AUminus"]. "<br>" ;
    echo $row["RE"]. "<br>"  ;
	echo $row["REplus"]. "<br>" ;
    echo $row["REminus"]. "<br>"  ;
	echo $row["GE"]. "<br>" ;
    echo $row["GEplus"]. "<br>"  ;
	echo $row["GEminus"]. "<br>" ;
    echo $row["VE"]. "<br>"  ;
	echo $row["VEplus"]. "<br>"  ;
	echo $row["VEminus"] ;

	}
} 
else {
  echo "0 results";
}

$conn->close();
?>