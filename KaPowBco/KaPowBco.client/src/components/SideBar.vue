<template>
  <div class="col-10 bg-secondary sidebar">
    <ul>
      <li>
        <router-link
          class="d-flex justify-content-center selectable"
          :to="{ name: 'Home' }"
        >
          <div class="d-flex flex-column align-items-center p-3">
            <h5 class="text-light rounded">Home</h5>
          </div>
        </router-link>
      </li>
      <li>
        <router-link
          class="d-flex justify-content-center selectable"
          :to="{ name: 'Account' }"
        >
          <div class="d-flex flex-column align-items-center p-3">
            <h5 class="text-light rounded">Account</h5>
          </div>
        </router-link>
      </li>
      <li>
        <button
          class="btn btn-outline-success"
          data-bs-toggle="modal"
          data-bs-target="#createPost"
          v-if="account.id"
        >
          <p>Create Post <i class="mdi mdi-plus"></i></p>
        </button>
      </li>
    </ul>
    <div class="dropdown my-2 my-lg-0 mx-0">
      <button
        class="btn btn-success dropdown-toggle"
        type="button"
        id="dropDownMenu"
        data-bs-toggle="dropdown"
        aria-expanded="false"
      >
        Manage
      </button>
      <ul class="dropdown-menu" aria-labelledby="dropDownMenu">
        <div
          class="dropdown-menu p-0 list-group w-100"
          aria-labelledby="authDropdown"
        >
          <router-link :to="{ name: 'Account' }">
            <div class="list-group-item list-group-item-action hoverable">
              <small>Manage Account </small>
            </div>
          </router-link>
          <div
            class="list-group-item list-group-item-action hoverable text-danger"
            @click="logout()"
          >
            <i class="mdi mdi-logout"></i>
            <small>logout </small>
          </div>
        </div>
      </ul>
    </div>
  </div>
  <Modal id="createPost">
    <template #modal-title>Create Post</template>
    <template #modal-body> </template>
  </Modal>
</template>


<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed } from 'vue'
export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.sidebar {
  height: 100vh;
}
</style>