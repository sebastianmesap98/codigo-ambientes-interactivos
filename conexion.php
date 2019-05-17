<?php


$dbname = 'UnityDB';
$dbuser = 'camilo';
$dbpass = 'Noviembre2018';
$dbhost = 'localhost';

//conectarce al servidor mysql  (servidor,user,pasword,NombreBD)
$conect = new mysqli($dbhost, $dbuser, $dbpass,$dbname);


// Check connection
if ($conect->connect_error) {
	die("Error: No se pudo conectar a MySQL." . $conect->connect_error);
}


$conexion = $_GET["conexion"];

if($conexion == "conectado")
{
	echo "sisas";
}





?>
