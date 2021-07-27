<template>
  <div class="card m-4 shadow">
    <img :src="keep.img" v-if="keep.img" alt="" class="card-img-top">
    <div class="card-body">
      <h3>
        {{ keep.name }}
      </h3>
      <p>{{ keep.description }}</p>
      <div>
        <router-link :to="{name: 'keep', params: {id: keep.id}}">
          keep details
        </router-link>
      </div>
    </div>
    <div class="card-footer text-right">
      <b>{{ keep.creator.name }}</b>
      <img :src="keep.creator.picture" alt="keep creator image" class="rounded-circle elevation-1 mx-2" height="40">
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: {
    keep: { type: Object, required: true }
  },
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style>
</style>
