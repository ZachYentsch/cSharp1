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
      <div class="card-text selectable" @click="goToProfile()">
        <img :src="trick.creator.picture" alt="" height="40" />
        <p>{{ trick.creator.name }}</p>
      </div>
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
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { useRouter } from 'vue-router'
export default {
  props: {
    trick: { type: Object, required: true }
  },
  setup(props) {
    const router = useRouter()
    return {
      account: computed(() => AppState.account),
      router,

      async goToProfile() {
        router.push({
          name: "Profile",
          params: { id: props.trick.creator.id }
        })
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>