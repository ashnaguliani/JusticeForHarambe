<?php
	$db = mysql_connect('localhost','ksotebeer','legendofharambe') or die('Could not connect: '.mysql_error());
	mysql_select_db('ksotebeer') or die('Could not select database');

	$username = mysql_real_escape_string($_GET['username'],$db);
	//$Timestamp = mysql_real_escape_string($_GET['Timestamp'],$db);
	$bananas = mysql_real_escape_string($_GET['bananas'],$db);
	$distance = mysql_real_escape_string($_GET['distance'],$db);
	$score = mysql_real_escape_string($_GET['score']),$db);
	$hash = $_GET['hash'];

	$secretkey = "911911911";

	$real_hash = md5($username . $bananas . $distance . $score . $secretkey); //got rid of Timestamp for now
	if($real_hash == $hash){
		// send variables for the mysql database class
		$query = "INSERT INTO score_board VALUES ('$username','$bananas','$distance','$score');";
		$result = mysql_query($query) or die('Query failed: ' .mysql_error());
	}
?>
