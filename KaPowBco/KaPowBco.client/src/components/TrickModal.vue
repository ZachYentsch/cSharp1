<template>
  <div class="">
    <div class="row">
      <div class="col-12">
        <img :src="trick.contentUrl" alt="" class="img-fluid" />
      </div>
      <div class="col-12">
        <h5>{{ trick.steps }}</h5>
        <i
          title="Delete Trick"
          class="mdi mdi-trash-can text-danger selectable"
          @click="removeTrick()"
        ></i>
        <button
          class="btn btn-outline-primary"
          data-bs-toggle="offcanvas"
          :data-bs-target="`#editTrick-${trick.id}`"
        >
          Edit Trick
        </button>
      </div>
      <!-- TODO GeoLocation Here-->
      <!-- <div class="col-12">

      </div> -->
    </div>
  </div>
  <div
    class="offcanvas text-dark"
    data-bs-scroll="true"
    :id="`editTrick-${trick.id}`"
    tabindex="-1"
    aria-labelledby="offcanvasWithBothOptionsLabel"
  >
    <div class="offcanvas-header">
      <h5 class="offcanvas-title text-dark">{{ trick.name }}</h5>
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
    </div>
    <div class="offcanvas-body">
      <form @submit.prevent="editTrick()">
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
          <label for="description">Description:</label>
          <input
            type="text"
            placeholder="Description..."
            v-model="editable.steps"
            class="form-control"
            id="steps"
          />
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
          />
        </div>
        <div class="form-group">
          <label for="type">Type of Trick:</label>
          <select
            v-model="editable.type"
            name="type"
            id="type"
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
          <button
            type="submit"
            class="btn btn-success text-uppercase selectable"
          >
            <b>Submit</b>
          </button>
        </div>
      </form>
    </div>
  </div>
</template>


<script>
import { ref, watchEffect } from '@vue/runtime-core'
import { tricksService } from '../services/TricksService'
import { firebaseService } from '../services/FireBaseService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { Offcanvas } from 'bootstrap'
export default {
  props: {
    trick: { type: Object, required: true }
  },
  setup(props) {
    const editable = ref({})
    watchEffect(() => {
      editable.value = {}
    })
    return {
      editable,
      async editTrick() {
        try {
          const form = event.target
          const content = form.contentUrl
          const file = contentUrl.files[0]
          Pop.toast("Edit Successful")
          if (!file) { return }
          const url = await firebaseService.uploadFile(file, editable.value)
          editable.value.contentUrl = url
          await tricksService.editTrick(editable.value)
          Offcanvas.getOrCreateInstance(document.getElementById(`editTrick-${trick.id}`)).hide()
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log(error.message)
        }
      },
      async removeTrick() {
        try {
          await tricksService.removeTrick(props.trick.id)
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log(error.message)
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
</style>