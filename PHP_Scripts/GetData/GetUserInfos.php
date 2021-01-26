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

$sql = "SELECT CharRace, CharRaceAbility, CharName, CharWeight, CharHeight, CharAge, CharHairColor,CharSkinColor, CharGender, CharLanguage, CharReligion, CharDestiny, CharDestinyLevel, CharAmbition, ModiAmount, AbilityAmount, ItemAmount FROM login WHERE UserID=$UserID AND SheetNr='$SheetNr'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo $row["CharRace"]. "<br>" ;
    echo $row["CharRaceAbility"]. "<br>"  ;
	echo $row["CharName"]. "<br>" ;
    echo $row["CharWeight"]. "<br>"  ;
	echo $row["CharHeight"]. "<br>" ;
    echo $row["CharAge"]. "<br>"  ;
	echo $row["CharHairColor"]. "<br>" ;
    echo $row["CharSkinColor"]. "<br>"  ;
	echo $row["CharGender"]. "<br>" ;
    echo $row["CharLanguage"]. "<br>"  ;
	echo $row["CharReligion"]. "<br>" ;
    echo $row["CharDestiny"]. "<br>"  ;
	echo $row["CharDestinyLevel"]. "<br>" ;
    echo $row["CharAmbition"]. "<br>"  ;
	echo $row["ModiAmount"]. "<br>" ;
    echo $row["AbilityAmount"]. "<br>"  ;
	echo $row["ItemAmount"] ;

	}
} 
else {
  echo "0 results";
}

$conn->close();
?>