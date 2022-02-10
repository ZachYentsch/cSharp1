<template>
  <form @submit.prevent="createTrick()">
    <div class="form-group">
      <label for="name">Name:</label>
      <input
        type="text"
        placeholder="Name..."
        v-model="editable.name"
        class="form-control"
        id="name"
        required
      />
    </div>
    <div class="form-group">
      <label for="description">Description:</label>
      <input
        type="text"
        placeholder="Description..."
        v-model="editable.steps"
        class="form-control"
        id="steps"
        required
      />
    </div>
    <div class="form-group">
      <label for="coverImg">Image:</label>
      <input
        type="text"
        placeholder="Url..."
        v-model="editable.contentUrl"
        class="form-control"
        id="contentUrl"
        required
      />
    </div>
    <div class="form-group">
      <label for="type">Type of Content:</label>
      <select
        v-model="editable.contentType"
        name="contentTpe"
        id="contentType"
        required
        class="form-control"
      >
        <option disabled selected value="">Choose a Post Type</option>
        <option>Image</option>
        <option>Video</option>
      </select>
    </div>
    <div class="form-group">
      <label for="difficulty">Difficulty</label>
      <input
        min="1"
        max="10"
        type="number"
        v-model="editable.difficulty"
        class="form-control"
        id="difficulty"
        required
      />
    </div>
    <div class="form-group">
      <label for="type">Type of Trick:</label>
      <select
        v-model="editable.type"
        name="type"
        id="type"
        required
        class="form-control"
      >
        <option disabled selected value="">Choose a Trick Type</option>
        <option>Aerial</option>
        <option>Rail</option>
        <option>Surface</option>
        <option>Halfpipe</option>
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
import { tricksService } from '../services/TricksService'
import { Modal } from 'bootstrap'
import { router } from '../router'
import { logger } from '../utils/Logger'
export default {
  setup() {
    const editable = ref({})
    watchEffect(() => {
      editable.value = {}
    })
    return {
      editable,
      async createTrick() {
        try {
          const form = event.target
          const content = form.contentUrl
          const file = contentUrl.files[0]
          Pop.toast("Created Successfully")
          if (!file) { return }
          const url = await firebaseService.uploadFile(file, editable.value)
          editable.value.contentUrl = url
          await tricksService.createTrick(editable.value)
          Modal.getOrCreateInstance(document.getElementById('createTrick')).hide()
          Modal.getOrCreateInstance(document.getElementById('trickDetails'))
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