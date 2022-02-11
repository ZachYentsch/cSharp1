<template>
  <div class="row">
    <div class="col-2 p-0">
      <SideBar />
    </div>
    <div class="col-md-5 p-2">
      <img :src="account.picture" alt="" height="400" />
      <h3 class="text-center">{{ account.name }}</h3>
      <p>{{ account.biography }}</p>
      <span class="d-flex justify-content-around">
        <i class="mdi mdi-twitter"></i>
        <i class="mdi mdi-facebook"></i>
        <i class="mdi mdi-youtube"></i>
        <i class="mdi mdi-instagram"></i>
      </span>
      <!-- TODO -->
      <!-- LOCATION -->
      <button
        class="btn btn-outline-primary selectable btn-lg mt-3"
        data-bs-toggle="offcanvas"
        :data-bs-target="`#hireTrainer-${account.id}`"
      >
        Hire
      </button>
    </div>
    <div class="col-md-5 p-3">
      <Trick v-for="t in tricks" :key="t.id" :trick="t" />
    </div>
  </div>
  <div
    class="offcanvas text-dark"
    data-bs-scroll="true"
    :id="`hireTrainer-${account.id}`"
    tabindex="-1"
    aria-labelledby="offcanvasWithBothOptionsLabel"
  >
    <div class="offcanvas-header">
      <h5 class="offcanvas-title text-dark"></h5>
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
    </div>
    <div class="offcanvas-body">
      <div class="d-flex justify-content-between my-3">
        <button
          type="button"
          data-bs-dismiss=" modal"
          aria-label="close"
          class="btn btn-danger selectable"
        >
          <b>Cancel</b>
        </button>
        <button type="submit" class="btn btn-success text-uppercase selectable">
          <b>Submit</b>
        </button>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { computed, watchEffect } from '@vue/runtime-core'
import { accountService } from '../services/AccountService'
import { tricksService } from '../services/TricksService'
export default {
  setup() {
    const route = useRoute()
    watchEffect(async () => {
      if (route.name == "Profile") {
        await accountService.getProfile(route.params.id)
        await tricksService.getAllTricks("?creatorId=" + route.params.id)
      }
    })
    return {
      account: computed(() => AppState.account),
      tricks: computed(() => AppState.tricks),
      profile: computed(() => AppState.profile),
    }
  }
}
</script>


<style lang="scss" scoped>
</style>