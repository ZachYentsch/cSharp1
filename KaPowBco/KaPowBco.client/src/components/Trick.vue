<template>
  <div
    class="card border border-secondary shadow-0"
    style="background-color: #d9d9d9"
  >
    <div class="bg-image hover-overlay ripple" data-mdb-ripple-color="light">
      <img
        :src="trick.contentUrl"
        class="img-fluid rounded-top selectable"
        data-bs-toggle="modal"
        :data-bs-target="`#trickDetails-${trick.id}`"
      />
      <a href="#!">
        <div
          class="mask"
          style="background-color: rgba(251, 251, 251, 0.15)"
        ></div>
      </a>
    </div>

    <div class="card-body">
      <h5 class="card-title">{{ trick.name }}</h5>
      <p class="card-text">
        {{ trick.steps }}
      </p>
    </div>
  </div>
  <Modal :id="`trickDetails-${trick.id}`">
    <template #modal-title>
      <h1 class="text-primary">{{ trick.name }}</h1></template
    >
    <template #modal-body><TrickModal :trick="trick" /> </template>
  </Modal>
</template>


<script>
import { onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: {
    trick: { type: Object, required: true }
  },
  setup() {
    return {
    }
  }
}
</script>


<style lang="scss" scoped>
</style>