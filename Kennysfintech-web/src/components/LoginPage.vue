<script>
import axios from 'axios'

export default {
  data() {
    return {
      username: '',
      password: ''
    }
  },

  methods: {
    login() {
      axios
        .post('https://localhost:7043/api/User/Login', {
          username: this.username,
          password: this.password
        })

        .then((res) => {
          console.log(res.data)
          this.$router.push({ name: 'HeaderBar' })
          localStorage.setItem(res.data.data.token)
        })

        .catch((err) => {
          console.log(err.response.data.message)
          alert(err.response.data.message)
        })
    }
  }
}
</script>

<template>
  <div class="d-flex justify-content-center align-items-center min-vh-100 bg-light">
    <div class="card p-0 shadow" style="max-width: 600px">
      <div class="row g-0">
        <div class="col-md-4 d-none d-md-block">
          <img src="@/assets/img/background.png" alt="Background" class="img-fluid h-100" />
        </div>
        <div class="col-md-8 p-4">
          <h2 class="fw-bold text-primary">UM <span class="text-dark">KA</span></h2>
          <p>Uygulamaya Giriş Yapmak İçin Kullanıcı Adı Ve Şifrenizi Yazın</p>

          <div class="form-floating mb-3">
            <input type="text" class="form-control" id="userName" placeholder="Kullanıcı Adı" v-model="username"
              required />
            <label for="userName"><i class="bi bi-envelope"></i> Kullanıcı Adı</label>
          </div>
          <div class="form-floating mb-3">
            <input type="password" class="form-control" id="password" placeholder="Password" v-model="password"
              required />
            <label for="password"><i class="bi bi-lock"></i> Şifre</label>
          </div>
          <button type="submit" class="btn btn-primary w-100" style="background-color: #6f42c1" @click="login()">
            Giriş
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<style>
.card {
  border: none;
}

.form-floating label {
  padding-left: 2.5rem;
}

.form-floating .form-control {
  padding-left: 2.5rem;
}

.bi {
  position: static;
  left: 15px;
  top: 18px;
  font-size: 1.2rem;
  color: #6c757d;
}

.text-primary {
  color: #6f42c1 !important;
}

</style>
