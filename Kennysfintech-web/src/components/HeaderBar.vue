<script>

</script>

<template>
  <!-- navbar -->
  <nav class="navbar navbar-expand-lg fixed-top">
    <div class="container">
      <a class="navbar-brand me-auto" href="#">Logo</a>

      <div
        class="offcanvas offcanvas-end"
        tabindex="-1"
        id="offcanvasNavbar"
        aria-labelledby="offcanvasNavbarLabel"
      >
        <div class="offcanvas-header">
          <h5 class="offcanvas-title" id="offcanvasNavbarLabel">Logo</h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="offcanvas"
            aria-label="Close"
          ></button>
        </div>
        <div class="offcanvas-body">
          <ul class="navbar-nav justify-content-center flex-grow-1 pe-3">
            <li class="nav-item">
              <a class="nav-link mx-lg-2 active" aria-current="page" href="#">Home</a>
            </li>
            <li class="nav-item">
              <a class="nav-link mx-lg-2" href="#">About</a>
            </li>
            <li class="nav-item">
              <a class="nav-link mx-lg-2" href="#">Services</a>
            </li>
            <li class="nav-item">
              <a class="nav-link mx-lg-2" href="#">Portfolio</a>
            </li>
            <li class="nav-item">
              <a class="nav-link mx-lg-2" href="#">Contact</a>
            </li>
          </ul>
        </div>
      </div>
      <a href="#" class="login-button">Login</a>
      <button
        class="navbar-toggler pe-0"
        type="button"
        data-bs-toggle="offcanvas"
        data-bs-target="#offcanvasNavbar"
        aria-controls="offcanvasNavbar"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
    </div>
  </nav>
  <!-- End navbar -->

  <!-- Hero section -->
  <section class="hero-section">
    <div
      class="container d-flex align-items-center justify-content-center fs-1 text-white flex-column"
    >
      <h1>Responsive Navbar</h1>
      <h2>Bootstrap 5</h2>
    </div>
  </section>
  <!-- End Hero section -->
</template>

<style scoped>
.navbar {
  background-color: #fff;
  height: 80px;
  margin: 20px;
  border-radius: 16px;
  padding: 0.5rem;
}
.navbar-brand {
  font-weight: 500;
  color: #009970;
  font-size: 24px;
  transition: 0.3s color;
}
.navbar-nav .nav-link {
  color: black; /* Varsayılan metin rengi */
}

.navbar-nav .nav-link.active {
  font-weight: bold !important; /* Kalın metin */
}

.navbar-nav .nav-link:hover {
  color: inherit !important; /* Metin rengini korur */
  background-color: transparent !important; /* Arka plan rengini kaldırır */
}

.login-button {
  background-color: #009970;
  color: #fff;
  padding: 8px 20px;
  border-radius: 50px;
  text-decoration: none;
  transition: 0.3s background-color;
}

.login-button:hover {
  background-color: #00b383;
}

.navbar-toggler {
  border: none;
  font-size: 1.25rem;
}

.navbar-toggler:focus,
.btn-close:focus {
  box-shadow: none;
  outline: none;
}

.nav-link {
  color: #666777;
  font-weight: 500;
  position: relative;
}

.nav-link:hover,
.nav-link.active {
  color: #000;
}

@media (min-width: 991px) {
  .nav-link::before {
    content: '';
    position: absolute;
    bottom: 0;
    left: 50%;
    transform: translateX(-50%);
    width: 0;
    height: 2px;
    background-color: #009970;
    visibility: hidden;
    transition: 0.3s ease-in-out;
  }

  .nav-link:hover::before,
  .nav-link.active::before {
    width: 100%;
    visibility: visible;
  }
}

.hero-section {
  background: url(/src/assets/img/hero-bg.jpg) no-repeat center;
  background-size: cover;
  width: 100%;
  height: 100%;
  
}

.hero-section::before {
  background-color: rgba(0, 0, 0, 0.6);
  content: '';
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
}

.hero-section .container {
  height: 100vh;
  z-index: 1;
  position: relative;
}

.hero-section h1 {
  font-size: 1.5rem;
}

.hero-section h2 {
  font-size: 1.2rem;
}
</style>
