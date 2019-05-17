<?php


$dbname = 'UnityDB';
$dbuser = 'camilo';
$dbpass = 'Noviembre2018';
$dbhost = 'localhost';
$conect = new mysqli($dbhost, $dbuser, $dbpass,$dbname);

$UserId = $_REQUEST['UserId'];
$Pose = $_REQUEST['Pose'];
$Pot1 = $_REQUEST['Pot1'];
$Pot2 = $_REQUEST['Pot2'];
$Pot3 = $_REQUEST['Pot3'];
$Pot4 = $_REQUEST['Pot4'];
$Pot5 = $_REQUEST['Pot5'];
$Pot6 = $_REQUEST['Pot6'];
$Pot7 = $_REQUEST['Pot7'];
$Pot8 = $_REQUEST['Pot8'];
$Pot9 = $_REQUEST['Pot9'];

$datosEnviados = mysqli_query($conect, "INSERT INTO Animacion(UserId,Pose,Pot1,Pot2,Pot3,Pot4,Pot5,Pot6,Pot7,Pot8,Pot9) VALUES('$UserId','$Pose','$Pot1','$Pot2','$Pot3','$Pot4','$Pot5','$Pot6','$Pot7','$Pot8','$Pot9')");

echo $Pot1;


?>
