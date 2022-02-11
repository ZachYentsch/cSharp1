<template>
  <div class="row">
    <div class="col-2 p-0">
      <SideBar />
    </div>
    <div class="col-md-10 mt-3">
      <div class="bg-secondary d-flex justify-content-between">
        <img :src="account.picture" alt="" />
        <h4 class="text-center">
          {{ account.name }}
          <i
            class="mdi mdi-pencil selectable"
            title="Edit Profile"
            data-bs-toggle="modal"
            data-bs-target="#editProfile"
          ></i>
        </h4>
        <h6>
          {{ account.facebook }} - {{ account.youtube }} -
          {{ account.twitter }} - {{ account.instagram }}
        </h6>
        <p>{{ account.biography }}</p>
      </div>
      <h3 class="text-center mt-5">Manage Tricks</h3>
      <div class="col-md-4" v-for="t in tricks" :key="t.id">
        <Trick :trick="t" />
      </div>
    </div>
  </div>
  <Modal id="editProfile" class="bg-dark">
    <template #modal-title>
      <h1 class="text-primary">Edit Profile:</h1></template
    >
    <template #modal-body>
      <EditProfile />
    </template>
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    return {
      account: computed(() => AppState.account),
      tricks: computed(() => AppState.myTricks)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
