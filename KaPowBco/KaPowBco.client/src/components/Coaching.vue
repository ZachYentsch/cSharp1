<template>
  <div class="row">
    <div class="col-4">
      <img :src="user.picture" alt="" height="30" class="rounded" />
      <p>{{ user.name }}</p>
    </div>
    <div class="bg-dark col-8">
      <p>{{ coaching.description }}</p>
    </div>
    <i class="mdi mdi-trash-can selectable" @click="removeCoaching()"></i>
  </div>
</template>


<script>
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { coachingsService } from '../services/CoachingsService'
export default {
  props: {
    coaching: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      user: computed(() => AppState.user),

      async removeComment() {
        try {
          await coachingsService.removeCoaching(props.coaching.id)
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>