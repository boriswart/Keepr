<template>
  <KeepModal />
  <div class="card keep m-4 shadow size=200">
    <img :src="keep.img" class="card-image-top" v-if="keep.img" alt="" />
    <div class="col-8-lg">
      <button type="button"
              class="add btn btn-slide"
              data-toggle="modal"
              data-target="#KeepModal"
              title="showKeepModal"
              @click="state.setActiveKeep(keep)"
      >
        View
      </button>
      <div class="row"></div>
      <div class="card-body d-flex justify-content-between">
        <h5>{{ keep.name }}</h5>
        <img :src="keep.creator.picture" alt="keep creator image" class="rounded-circle elevation-1 mx-2" height="40">
      </div>
      <div class="card-footer d-flex justify-content-between text-right">
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
// import { keepsService } from '../services/KeepsService'

export default {
  props: {
    keep: { type: Object, required: true }
  },
  setup() {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      setActiveKeep(keep) {
        AppState.activeKeep = keep
        AppState.activeKeepEdit = ''
      }
    })
    return {
      state
    }
  }
}
</script>

<style>
.image{
  max-width: 200px;
  max-height:none;
  align-content: center;
}
</style>
