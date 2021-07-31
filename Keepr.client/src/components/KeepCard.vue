<template>
  <KeepModal />
  <div class="card m-4 shadow">
    <button type="button"
            class="add btn btn-slide"
            data-toggle="modal"
            data-target="#KeepModal"
            title="showKeepModal"
            @click="state.setActiveKeep(keep)"
    >
      View
    </button>
    <img :src="keep.img" v-if="keep.img" alt="" class="card-img-top">
    <div class="card-body d-flex justify-content-center">
      <div class="row"></div>
      <h5>{{ keep.name }}</h5>
    </div>
    <div class="keepModal col rounded shadow">
      <KeepModal />
    </div>
    <div class="card-footer d-flex justify-content-between text-right">
      <b>{{ keep.creator.name }}</b>
      <img :src="keep.creator.picture" alt="keep creator image" class="rounded-circle elevation-1 mx-2" height="40">
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
  setup(keep) {
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
</style>
