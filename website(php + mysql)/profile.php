<?php
session_start();
if (!$_SESSION['user']) {
    header('Location: /kurs/');
}
?>

<!doctype html>
<html lang="ru">
 <head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width. initial-scale=1.0"> 
	<!совместимость с мобильным устройством>
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	<!совместимость с браузером edge>
	<link rel="stylesheet" href="/kurs/css/style.css">
	<link rel="stylesheet" href="/kurs/css/main.css">
	<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css">
	<title>Веб сайт</title>
 
 </head>
<body>
	<form>
	<a href="index.php" class="btn btn-outline-primary">Главная</a>
	<p> </p>
	<a href="zayavka.php" class="btn btn-outline-primary">Оставить заявку на подключение</a>
        <img src="<?= $_SESSION['user']['avatar'] ?>" width="200" alt="">
        <h2 style="margin: 10px 0;"><?= $_SESSION['user']['full_name'] ?></h2>
        <a href="#"><?= $_SESSION['user']['email'] ?></a>
        <a href="vendor/logout.php" class="logout">Выход</a>
		
    </form>
</body>
</html>