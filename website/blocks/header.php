<header class="container d-flex flex-wrap align-items-center justify-content-center justify-content-md-between py-3 mb-4 border-bottom">
      <a href="/" class="d-flex align-items-center col-md-3 mb-2 mb-md-0 text-dark text-decoration-none">
        <svg class="bi me-2" width="40" height="32" role="img" aria-label="Bootstrap"><use xlink:href="#bootstrap"></use></svg>
      </a>

      <ul class="nav col-12 col-md-auto mb-2 justify-content-center mb-md-0">
        <li><a href="/kurs/index.php" class="nav-link px-2 link-secondary">Главная</a></li>
        <li><a href="/kurs/about.php" class="nav-link px-2 link-dark">Контакты</a></li>
        
      </ul>

      <div class="col-md-3 text-end">
		<?php 	
		session_start();
		
		if ($_SESSION['user']):		
		?>
		<a class="btn btn-outline-primary" href="/kurs/vhod.php">Кабинет пользователя</a>
		<?php else: ?>
        <a class="btn btn-outline-primary" href="/kurs/vhod.php">Войти</a>
		<?php endif; ?>
      </div>
    </header>