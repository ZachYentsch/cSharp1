<template>
  <div class="details">
    <router-link
      :to="{ name: 'EventDetails', params: { id: towerEvent.id } }"
      :title="towerEvent.name"
    >
      <div class="card selectable text-light">
        <div class="position-relative w-100">
          <div class="gradient">
            <div class="position-absolute clip-text col-12">
              <p class="text-white bg-secondary">
                {{ trick.name }}
              </p>
              <div class="bg-dark d-flex justify-content-between">
                <img :src="trick.contentUrl" alt="" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </router-link>
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
.gradient:after {
  content: "";
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background: linear-gradient(
    180deg,
    rgba(82, 80, 80, 0),
    rgba(114, 112, 112, 0),
    rgba(83, 83, 83, 0.5),
    rgb(75, 73, 73)
  );
}
</style>