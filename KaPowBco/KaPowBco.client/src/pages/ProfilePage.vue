<template>
  <div class="row">
    <div class="col-2 p-0">
      <SideBar />
    </div>
    <div class="col-md-5 p-2">
      <img :src="profile.picture" alt="" height="400" />
      <h3 class="text-center">{{ account.name }}</h3>
      <p>{{ profile.biography }}</p>
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
        Message
      </button>
    </div>
    <div class="col-md-5 p-3">
      <Trick v-for="t in tricks" :key="t.id" :trick="t" />
    </div>
  </div>
  <div
    class="offcanvas offcanvas-start text-dark"
    :id="`hireTrainer-${account.id}`"
    tabindex="-1"
    aria-labelledby="offcanvasWithBothOptionsLabel"
  >
    <div class="offcanvas-header">
      <h5 class="offcanvas-title text-dark">{{ profile.name }}</h5>
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
    </div>
    <div class="offcanvas-body">
      <div class="d-flex my-3 text-dark row">
        <div
          class="col-12 mt-3 bg-dark justify-content-between"
          v-for="c in coachings"
          :key="c.id"
        >
          <Coaching :coaching="c" />
        </div>
        <div class="col-12 align-items-center">
          <form @submit.prevent="createCoaching()">
            <div>
              <label for="body">Message:</label>
              <input
                type="text"
                class="form-control"
                placeholder="Message:"
                v-model="editable.description"
                required
              />
            </div>
            <button type="submit" class="btn btn-success">
              <i class="mdi mdi-plus"></i>
            </button>
            <button
              type="button"
              data-bs-dismiss=" modal"
              aria-label="close"
              class="btn btn-danger selectable"
            >
              <b>Cancel</b>
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { computed, watchEffect, ref } from '@vue/runtime-core'
import { accountService } from '../services/AccountService'
import { coachingsService } from '../services/CoachingsService'
import { tricksService } from '../services/TricksService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {
  setup() {
    const route = useRoute()
    const editable = ref({})
    watchEffect(async () => {
      if (route.name == "Profile") {
        await accountService.getProfile(route.params.id)
        await tricksService.getAllTricks("?creatorId=" + route.params.id)
      }
    })
    return {
      editable,
      account: computed(() => AppState.account),
      coachings: computed(() => AppState.coachings),
      tricks: computed(() => AppState.tricks),
      profile: computed(() => AppState.profile),

      async createCoaching() {
        try {
          editable.value.trainerId = route.params.id
          await coachingsService.createCoaching(editable.value)
          editable.value = {}
          Pop.toast('Message Created')
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.error(error)
        }
      },

      async removeCoaching() {
        try {
          await coachingsService.removeCoaching(props.coaching.id)
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log(error.message)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>