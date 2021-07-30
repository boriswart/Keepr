<template>
  <div class="card m-4 shadow">
    <img :src="keep.img" v-if="keep.img" alt="" class="card-img-top">
    <div class="card-body">
      <h3>
        {{ keep.name }}
      </h3>
      <p>{{ keep.description }}</p>
    </div>
    <div class="card-footer text-right">
      <b>{{ keep.creator }}</b>
      <img :src="'keep.creator.picture'" alt="keep creator image" class="rounded-circle elevation-1 mx-2" height="40">
    </div>
  </div>
</template>

<script>
import { computed, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
export default {
  setup() {
    const route = useRoute()
    watchEffect(() => {
      const id = route.params.id
      if (!id) { return }
      AppState.keep = {}
      keepsService.getKeepById(id)
      // contractsService.getContractBids(id)
    })
    return {
      keep: computed(() => AppState.keep)
      // : computed(() => AppState.contractBids)
    }
  }
}
</script>

<style>
</style>
