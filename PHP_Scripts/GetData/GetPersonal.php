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

	// CharDestinyLevel, 

	$query = "SELECT  CharName, CharWeight, CharHeight, CharAge, CharHairColor, CharSkinColor, CharGender, CharLanguage, CharReligion, CharRace, CharRaceAbility, CharDestiny, CharDestinyLevel, CharAmbition FROM charcreated WHERE UserID='$UserID' AND SheetNr='$SheetNr'";
	$result = mysqli_query($connection, $query);

	if (mysqli_num_rows($result) > 0) 
	{
  		// output data of each row
 	 	while($row = mysqli_fetch_assoc($result)) 
		{
			//."|".$row["CharDestinyLevel"]
    			echo $row["CharName"]."|".$row["CharWeight"]."|".$row["CharHeight"]."|".$row["CharAge"]."|".$row["CharHairColor"]."|".$row["CharSkinColor"]."|".$row["CharGender"]."|".$row["CharLanguage"]."|".$row["CharReligion"]."|".$row["CharRace"]."|".$row["CharRaceAbility"]."|".$row["CharDestiny"]."|".$row["CharDestinyLevel"]."|".$row["CharAmbition"];
		}
	} 
	else 
	{
  		echo "0 results";
	}

}
?>