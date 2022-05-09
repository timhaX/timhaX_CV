<?php
session_start();

if ($_SESSION['user']) {
    header('Location: /kurs/profile.php');
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
	<link rel="stylesheet" href="/kurs/css/main.css">
	<title>Авторизация</title>
 
 </head>
<body>
<div class="container mt-5">
    <form action="/kurs/vendor/signin.php" method="post">
        <label>Логин</label>
        <input type="text" name="login" placeholder="Введите свой логин">
        <label>Пароль</label>
        <input type="password" name="password" placeholder="Введите пароль">
        <button type="submit">Войти</button>
        <p>
            У вас нет аккаунта? - <a href="register.php">зарегистрируйтесь</a>!
        </p>
		<p>
            Вернуться на <a href="index.php">главную</a>!
        </p>
        <?php
            if ($_SESSION['message']) {
                echo '<p class="msg"> ' . $_SESSION['message'] . ' </p>';
            }
            unset($_SESSION['message']);
        ?>
    </form>
</div>
</body>
</html>