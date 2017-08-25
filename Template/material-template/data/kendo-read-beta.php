<?php header('Access-Control-Allow-Origin: *'); ?>
<?php 
$callback = $_GET['callback'];
$task = file_get_contents('tasks.json');
$taskDecode = json_decode($task, true);
$req = $_GET['req'];
if ($req == 'read') {
	echo $callback . '(' . $task . ')';
} else if ($req == 'create') {
	$models = $_GET['models'];
	$modelsDecode = json_decode($models, true);

	$modelsBigestTaskID = 0;
	foreach ($taskDecode as $key => $entry) {
		if ($taskDecode[$key]['TaskID'] > $modelsBigestTaskID) {
			$modelsBigestTaskID = $taskDecode[$key]['TaskID'];
		}
	}
	$modelsDecode[0]['TaskID'] = ++$modelsBigestTaskID;
	
	//Add status name
	$taskDecode[$key + 1] = $modelsDecode[0];

	if ($modelsBigestTaskID && !file_put_contents('tasks.json', json_encode(array_values($taskDecode)))) {
		echo 'Create failed';
	}

	echo $callback . '(' . $models . ')';
} else if ($req == 'update') {
	$models = $_GET['models'];
	$modelsDecode = json_decode($models, true);

	foreach ($taskDecode as $key => $entry) {
		if ($taskDecode[$key]['TaskID'] == $modelsDecode[0]['TaskID']) {
			$taskDecode[$key] = $modelsDecode[0];
			break;
		}
	}

	if (!empty($taskDecode) && !file_put_contents('tasks.json', json_encode(array_values($taskDecode)))) {
		echo 'Update failed';
	}
	echo $callback . '(' . $models . ')';
} else if ($req == 'destroy') {
	$models = $_GET['models'];
	$modelsDecode = json_decode($models, true);

	foreach ($taskDecode as $key => $entry) {
		if ($taskDecode[$key]['TaskID'] == $modelsDecode[0]['TaskID']) {
			unset($taskDecode[$key]);
			break;
		}
	}

	if (!empty($taskDecode) && !file_put_contents('tasks.json', json_encode(array_values($taskDecode)))) {
		echo 'Delete failed';
	}
	
	echo $callback . '(' . $models . ')';
} else {
	echo $callback . '(' . $task . ')';
}

?>