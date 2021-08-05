<template>
  <div class="col2">
    <div id="vault.id" class="card vault m-4 shadow size=100" ondrop="dragDrop(event)" ondragover="allowDrop(event)">
      <button type="button"
              class="add btn btn-slide"
              data-toggle="modal"
              data-target="#VaultModal"
              title="showVaultModal"
              @click="state.setActiveVault(vault)"
      >
        View
      </button>
      <div class="vault w-200">
        <img src="../assets/img/vault.jpg" width="200" height="200" alt="" class="vault size=65">
      </div>
    </div>
  </div>
  <VaultModal />
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
.image{
  max-height: 200px;
}
card.vault{
  background-image:url("https://image.shutterstock.com/z/stock-photo-front-view-of-light-gold-bank-vault-door-open-the-door-to-the-bank-vault-isolated-on-white-1584269443.jpg");
  height: 100;
}
</style>
