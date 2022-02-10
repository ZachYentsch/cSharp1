<template>
  <div v-if="user.isAuthenticated">
    <div class="row">
      <div class="col-2 p-0">
        <SideBar />
      </div>
      <div class="col-10">
        <div class="bg-secondary d-flex justify-content-between">
          <h2 class="selectable" @click="getAllTricks()">All</h2>
          <h2 class="selectable" @click="filterTricks('Aerial')">Aerial</h2>
          <h2 class="selectable" @click="filterTricks('Rail')">Rail</h2>
          <h2 class="selectable" @click="filterTricks('Surface')">Surface</h2>
          <h2 class="selectable" @click="filterTricks('Halfpipe')">Halfpipe</h2>
        </div>
        <div class="row mt-5">
          <Trick
            class="col-md-3 d-flex justify-content-center mx-3"
            v-for="t in filteredTricks"
            :key="t.id"
            :trick="t"
          >
          </Trick>
        </div>
      </div>
    </div>
  </div>
  <div v-else class="row loginBg">
    <div class="col-12 p-5 text-center">
      <div><h2>Welcome To</h2></div>
      <h1 class="c1">K</h1>
      <h1 class="c2">A</h1>
      <h1 class="c3">P</h1>
      <h1 class="c4">O</h1>
      <h1 class="c5">W</h1>
      <h1 class="c6">W</h1>
      <img
        src="https://static.vecteezy.com/system/resources/previews/000/623/284/original/mountain-logo-vector-illustration.jpg"
        alt=""
        class="m-5"
        height="150"
        style="filter: opacity(30%)"
      />
    </div>
    <div class="col-12 d-flex align-items-center justify-content-center">
      <button class="btn btn-primary btn-lg selectable" @click="login()">
        Login
      </button>
    </div>
  </div>
</template>

<script>
import { onMounted, computed, ref } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
import { tricksService } from '../services/TricksService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {
  name: 'Home',
  setup() {
    const loading = ref(true)
    onMounted(async () => {
      try {
        await tricksService.getAllTricks()
        loading.value = false
      } catch (error) {
        logger.log(error.message)
        Pop.toast(error.message, 'Error')
      }
    })

    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      filteredTricks: computed(() => AppState.filteredTricks),
      trick: computed(() => AppState.tricks),

      filterTricks(type) {
        let filteredTricks = AppState.tricks.filter(t => t.type == type)
        logger.log(filteredTricks)
        AppState.filteredTricks = filteredTricks
      },
      async getAllTricks() {
        try {
          await tricksService.getAllTricks()
        } catch (error) {
          logger.log(error.message)
        }
      },
      async login() {
        AuthService.loginWithPopup()
      }

    }
  },
}
</script>

<style scoped lang="scss">
.loginBg {
  background-image: url("https://th.bing.com/th/id/R.4b413559e9f7ee6f9abd17762533a183?rik=L%2f0N1k6IIEJ%2fPw&riu=http%3a%2f%2fwallpapercave.com%2fwp%2fYkLpZ3U.jpg&ehk=EKXFBej6WSDe82FOu01L4%2bdRTSraijBFYoQMA7PXBis%3d&risl=&pid=ImgRaw&r=0");
  min-height: 100vh;
  background-size: cover;
}

h1 {
  font-size: 26px;
  transform-origin: bottom;
  height: 600px;
  width: 50px;
  left: 600px;
  top: 100px;
  position: absolute;
}
.c1 {
  transform: rotate(9deg);
}
.c2 {
  transform: rotate(18deg);
}
.c3 {
  transform: rotate(27deg);
}
.c4 {
  transform: rotate(36deg);
}
.c5 {
  transform: rotate(45deg);
}
.c6 {
  transform: rotate(54deg);
}
</style>
