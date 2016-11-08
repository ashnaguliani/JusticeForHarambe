<?php
	$db = mysql_connect('localhost','ksotebeer','legendofharambe') or die('Could not connect: '.mysql_error());
	mysql_select_db('ksotebeer') or die('Could not select database');

	$username = mysql_real_escape_string($_GET['name'],$db);
	$Timestamp = mysql_real_escape_string($_GET['Timestamp'],$db);
	$bananas = mysql_real_escape_string($_GET['bananas'],$db);
	$distance = mysql_real_escape_string($_GET['distance'],$db);
	$score = mysql_real_escape_string($_GET['score']),$db);
	$hash = $_GET['hash'];

	$secretkey = "123456789";

	$real_hash = md5($username, $Timestamp, $bananas, $distance, $score, $secretkey);
	if($real_hash == $hash){
		// send variables for the mysql database class
		$query = "INSERT INTO score_board values ('$username','$Timestamp','$bananas','$distance','$score');";
		$result = mysql_query($query) or die('Query failed: ' .mysql_error());
	}
?>
