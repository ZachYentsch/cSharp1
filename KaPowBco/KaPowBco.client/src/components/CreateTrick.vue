<template>
  <form @submit.prevent="submitTower()">
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
        v-model="editable.description"
        class="form-control"
        id="description"
        required
      />
    </div>
    <div class="form-group">
      <label for="coverImg">Image:</label>
      <input
        type="text"
        placeholder="Image Url..."
        v-model="editable.coverImg"
        class="form-control"
        id="coverImg"
        required
      />
    </div>
    <div class="form-group">
      <label for="location">Location</label>
      <input
        type="text"
        placeholder="Location..."
        v-model="editable.location"
        class="form-control"
        id="location"
        required
      />
    </div>
    <div class="form-group">
      <label for="capacity">Capacity:</label>
      <input
        type="Number"
        min="10"
        v-model="editable.capacity"
        class="form-control"
        id="capacity"
        required
      />
    </div>
    <div class="form-group">
      <label for="startDate">Start Date:</label>
      <input
        type="Date"
        v-model="editable.startDate"
        class="form-control"
        id="startDate"
        required
      />
    </div>
    <div class="form-group">
      <label for="type">Type of Event:</label>
      <select
        v-model="editable.type"
        name="type"
        id="type"
        required
        class="form-control"
      >
        <option disabled selected value="">Choose an Event Type</option>
        <option>sport</option>
        <option>digital</option>
        <option>concert</option>
        <option>convention</option>
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
import { TowerEvent } from '../models/TowerEvent'
import Pop from '../utils/Pop'
import { tricksService } from '../services/TricksService'
import { Modal } from 'bootstrap'
import { router } from '../router'
import { logger } from '../utils/Logger'
export default {
  props: {
    trick: { type: Object, default: () => new Trick() }
  },
  setup(props) {
    const editable = ref({})
    watchEffect(() => {
      editable.value = { ...props.trick }
    })
    return {
      editable,
    }
  }
}
</script>


<style lang="scss" scoped>
</style>