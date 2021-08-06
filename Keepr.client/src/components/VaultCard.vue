<template>
  <div class="col2">
    <div class="card vault m-4 shadow size=100">
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
        <img src="../assets/img/vault.jpg"
             :id="vault.id"
             width="200"
             height="200"
             alt=""
             class="vault size=65"
        >
        <!-- REVIEW Get list of keeps in vault also enable dorp-zone for drag and drop
        LV adding drag and drop to your Vue 3 Project -->
        <div class="drop-zone">
          <div v-for="keep in getVaultKeeps(vault.id)"
               :key="keep.id"
               class="drag-el"
               draggable="true"
               @dragstart="startDrag($event, keep)"
          >
            {{ keep.name }}
          </div>
        </div>
        <!-- comment end -->
      </div>
    </div>
    <VaultModal />
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
// import { vaultsService } from '../Services/VaultsService'

export default {
  props: {
    vault: { type: Object, required: true }
  },
  setup(vault) {
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      startDrag: computed((event, keep) => {
        logger.log(keep.id)
        event.dataTransfer.dropEffect = 'move'
        event.dataTransfer.effectAllowed = 'move'
        event.dataTransfer.setData('itemID', keep.id)
      }),
      setActiveKeep(vault) {
        AppState.activeVault = vault
        AppState.activeVaultEdit = ''
      }
    })
    return {
      state,
      getVaultKeeps(id) {
        return [2]
      }
      // TODO: create  getVaultKeep services
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

.drop-zone{
  width: 50%;
  margin: 50px;
  background-color:  info;
  padding: 10px;
  min-height: 10px;
}
.drag-el {
background-color: aqua;
color: dark;
padding: 5px;
min-height: 10px;
}
.drag-el:nth-last-of-type(1){
  margin-bottom: 0;
}

</style>
