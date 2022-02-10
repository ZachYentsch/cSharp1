<template>
  <div class="card selectable text-light">
    <div class="position-relative w-100">
      <div class="position-absolute clip-text col-12">
        <p class="text-white bg-secondary">
          {{ trick.name }}
        </p>
      </div>
      <div class="bg-dark d-flex justify-content-between">
        <img :src="trick.contentUrl" alt="" class="rounded img-fluid" />
      </div>
    </div>
  </div>
</template>


<script>
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