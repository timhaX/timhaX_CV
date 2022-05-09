<!DOCTYPE html>
<html lang="ru">
 <head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width. initial-scale=1.0"> 
	<!совместимость с мобильным устройством>
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	<!совместимость с браузером edge>
	<link rel="stylesheet" href="/kurs/css/style.css">
	<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css">
	<title>Веб сайт</title>
 
 </head>
 <body>
<?php require "blocks/header.php"?>
	<div class="container mt-5">
		<h3 class="mb-5">Наши услуги</h3>
		
	<div class="d-flex flex-wrap">
		<div class="card mb-4 rounded-3 shadow-sm">
		<div class="card-header py-3">
			<h4 class="my-0 fw-normal">Домашний интернет</h4>
		</div>
		<div class="card-body">
			<img src="img/1.png" class="img-thumbnail">
			<ul class="list-unstyled mt-3 mb-4">
			<li>1000 мбит/сек</li>
			<li>Динамический ip</li>
			<li>От 500 р/мес</li>
			<li>Поддержка 24/7</li>
			</ul>
			<a class="w-100 btn btn-lg btn-outline-primary" href="/kurs/pc.php">Подробнее</a>
		</div>
		</div>
	
		<div class="card mb-4 rounded-3 shadow-sm">
		<div class="card-header py-3">
			<h4 class="my-0 fw-normal">Мобильный интернет</h4>
		</div>
		<div class="card-body">
			<img src="img/2.png" class="img-thumbnail">
			<ul class="list-unstyled mt-3 mb-4">
			<li>Безлимит</li>
			<li>Поддержка 5G</li>
			<li>От 650 р/мес</li>
			<li>Поддержка 24/7</li>
			</ul>
			<a class="w-100 btn btn-lg btn-outline-primary" href="/kurs/mob.php">Подробнее</a>
		</div>
		</div>
	
	
		<div class="card mb-4 rounded-3 shadow-sm">
		<div class="card-header py-3">
			<h4 class="my-0 fw-normal">Телевидение
			</h4>
		</div>
		<div class="card-body">
			<img src="img/3.png" class="img-thumbnail">
			<ul class="list-unstyled mt-3 mb-4">
			<li>220 каналов</li>
			<li>Подписка ivi</li>
			<li>от 550 р/мес</li>
			<li>Поддержка 24/7</li>
			</ul>
			<a class="w-100 btn btn-lg btn-outline-primary" href="/kurs/tv.php">Подробнее</a>
		</div>
		</div>
	</div>		
	</div>
	<?php require "blocks/footer.php"?>
 </body>
</html>