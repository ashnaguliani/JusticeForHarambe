<?php
// Send variables for the MySql database class
$database = mysql_connect('localhost', 'ksotebeer', 'legendofharambe') or die('Could not connect: ' .mysql_error());
mysql_select_db('ksotebeer') or die('Could not select database');

$query = "SELECT * FROM score_board ORDER BY score DESC LIMIT 5";
$result = mysql_query($query) or die('Query failed: ' .mysql_error());

$num_results = mysql_num_rows($result);

for($i = 0; $i < $num_results; $i++)
{
	$row = mysql_fetch_array($result);
	echo $row['username'] . "\t" . $row['score'] . "\t" . $row['distance'] . "\t" . $row['bananas'] . "\n";
}
?>
