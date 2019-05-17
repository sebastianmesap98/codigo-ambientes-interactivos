<?php


$dbname = 'UnityDB';
$dbuser = 'camilo';
$dbpass = 'Noviembre2018';
$dbhost = 'localhost';
$conect = new mysqli($dbhost, $dbuser, $dbpass,$dbname);



$ID = mysqli_query($conect, "SELECT MAX(UserId) FROM Animacion");

    
while($fila = mysqli_fetch_array($ID)){
    
    $MaxId = $fila["MAX(UserId)"];
    
}


$nuevoID = $MaxId+1;

echo $nuevoID;

?>
