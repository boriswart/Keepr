<template>
  <VaultModal />
  <div class="card m-4 shadow">
    <button type="button"
            class="add btn btn-slide"
            data-toggle="modal"
            data-target="#VaultModal"
            title="showVaultModal"
            @click="state.setActiveVault(vault)"
    >
      View
    </button>
    <!-- <img :src="keep.img" v-if="keep.img" alt="" class="card-img-top"> -->
    <div class="row"></div>
    <div class="card-body d-flex justify-content-between">
      <h5>{{ vault.name }}</h5>
      <img :src="vault.creator.picture" alt="vault creator image" class="rounded-circle elevation-1 mx-2" height="40">
    </div>
    <div class="card-footer d-flex justify-content-between text-right">
    </div>
    <div class="VaultModal col rounded shadow">
      <VaultModal />
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'

export default {
  props: {
    vault: { type: Object, required: true }
  },
  setup(vault) {
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      setActiveKeep(vault) {
        AppState.activeVault = vault
        AppState.activeVaultEdit = ''
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
