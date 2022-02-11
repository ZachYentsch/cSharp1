<template>
  <form @submit.prevent="editProf()">
    <div class="form-group">
      <label for="name">Name:</label>
      <input
        type="text"
        placeholder="Name..."
        v-model="editable.name"
        class="form-control"
        id="name"
      />
    </div>
    <div class="form-group">
      <label for="biography">Biography:</label>
      <input
        type="text"
        placeholder="Biography..."
        v-model="editable.biography"
        class="form-control"
        id="biography"
      />
    </div>
    <div class="form-group">
      <label for="picture">Picture:</label>
      <input
        type="text"
        v-model="editable.picture"
        placeholder="Profile Picture Url..."
        class="form-control"
        id="picture"
      />
    </div>
    <div class="form-group">
      <label for="bannerImg">Profile Picture:</label>
      <input
        type="text"
        placeholder="BannerPicture Url..."
        v-model="editable.bannerImg"
        class="form-control"
        id="bannerImg"
      />
    </div>
    <div class="form-group">
      <label for="Facebook">Facebook</label>
      <input
        placeholder="Facebook..."
        type="text"
        v-model="editable.facebook"
        class="form-control"
        id="Facebook"
      />
    </div>
    <div class="form-group">
      <label for="instagram">Instagram</label>
      <input
        placeholder="Instagram..."
        type="text"
        v-model="editable.instagram"
        class="form-control"
        id="instagram"
      />
    </div>
    <div class="form-group">
      <label for="youtube">Youtube</label>
      <input
        placeholder="Youtube..."
        type="text"
        v-model="editable.youtube"
        class="form-control"
        id="youtube"
      />
    </div>
    <div class="form-group">
      <label for="twitter">Twitter</label>
      <input
        type="text"
        placeholder="Twitter..."
        v-model="editable.twitter"
        class="form-control"
        id="twitter"
      />
    </div>
    <div class="form-group">
      <label for="isAvailable">Available:</label>
      <select
        v-model="editable.isAvailable"
        placeholder="Are You Available..."
        name="isAvailable"
        id="isAvailable"
        class="form-control"
      >
        <option disabled selected value="">Choose Your Available Status</option>
        <option>true</option>
        <option>false</option>
      </select>
    </div>
    <div class="form-group">
      <label for="isTrainer">Trainer Profile:</label>
      <select
        placeholder="Trainer Profile..."
        v-model="editable.isTrainer"
        name="isTrainer"
        id="isTrainer"
        class="form-control"
      >
        <option disabled selected value="">Are You A Trainer</option>
        <option>true</option>
        <option>false</option>
      </select>
    </div>
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
  </form>
</template>


<script>
import { ref, watchEffect } from '@vue/runtime-core'
import Pop from '../utils/Pop'
import { Modal } from 'bootstrap'
import { logger } from '../utils/Logger'
import { accountService } from '../services/AccountService'
export default {
  setup() {
    const editable = ref({})
    watchEffect(() => {
      editable.value = {}
    })
    return {
      editable,
      async editProf() {
        try {
          await accountService.editAccount(editable.value)
          Modal.getOrCreateInstance(document.getElementById('editProfile')).hide()
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log(error.message)
        }
      }
    }
  }
}
</script>