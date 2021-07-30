<template>
  <KeepModal />
  <div class="card m-4 shadow">
    <img :src="keep.img" v-if="keep.img" alt="" class="card-img-top">
    <div class="card-body">
      <!-- <router-link :to="{name: 'Keep', params: {id: keep.id}}"> -->
      {{ keep.name }}
      <!-- </router-link> -->
    </div>
    <div class="card-footer text-right">
      <b>{{ keep.creator.name }}</b>
      <img :src="keep.creator.picture" alt="keep creator image" class="rounded-circle elevation-1 mx-2" height="40">
    </div>
  </div>

  <div class="row d-flex justify-content-center">
    <div class="keepModal col-9 p-3 rounded shadow my-5">
      <KeepModal />
      <button type="button"
              class="add btn btn-slide"
              data-toggle="modal"
              data-target="#KeepModal"
              title="showKeepModal"
              @click="state.setActiveKeep(keep)"
      >
        Active Keep
      </button>
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
