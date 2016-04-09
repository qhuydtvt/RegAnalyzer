<!DOCTYPE html>
<html lang="vi">

	<head>

		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<meta name="description" content="">
		<meta name="author" content="">

		<title>Tuyen sinh</title>

		<!-- Bootstrap Core CSS -->
		<link href="css/bootstrap.min.css" rel="stylesheet">
		<!-- Custom CSS -->
		<link href="css/clean-blog.min.css" rel="stylesheet">
		<!-- Custom Fonts -->
		<link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
		<link href='http://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>

	</head>
	<body>
		<?php
		$first_name = $_POST["firstName"];
		$last_name = $_POST["lastName"];
		$date_of_birth = $_POST["dOB"];
		$number = $_POST["number"];
		$facebook = $_POST["fb"];
		$job = $_POST["job"];
		$knowledge = $_POST["knowledge"];
		$study = $_POST["study"];
		$reason = $_POST["reason"];
		$feedback = $_POST["feedback"];
		$know_by = $_POST["knowBy"];
		$presenter = $_POST["presenter"];
		
		$conn = new mysqli('localhost', 'techkids_reg', 'techkids.edu.vn', 'techkids_register');
		$set = "SET NAMES 'UTF8'";
		mysqli_query ($conn, $set);
		$sql = "INSERT INTO `thong_tin`( `first_name`, `last_name`, `date_of_birth`, `number`, `facebook`, `jobs`, `knowlege`, `study`, `reason`, `feedback`, `know_by`, `presenter`) VALUES ('$first_name', '$last_name', '$date_of_birth', '$number', '$facebook', '$job', '$knowledge', '$study', '$reason', '$feedback', '$know_by', '$presenter')";
		mysqli_query($conn, $sql) ;
		
		
		?>
		
    <!-- Page Header -->
	
    <!-- Backgournd -->
    <header class="intro-header" style="background-image: url('img/home-bg.jpg')">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                    <div class="site-heading">
                        <h1>Tuyen sinh </h1>
                        <hr class="small">
                        <span class="subheading">Noi dung</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
	<!-- main -->
	<div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
			<div class="post-preview">
				<hr>
                <h2 class="post-title">
                    ĐĂng kí thành công
                </h2>
				<div class="post-preview"><a href="/index.php">Go back</a>
				</div>
			</div>
		</div>
	</div>
	<!-- Footer -->
	</body>
</html>

