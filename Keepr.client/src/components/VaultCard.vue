<template>
  <VaultModal />
  <div class="card vault m-4 shadow size=100">
    <div class="col-2-lg">
      <button type="button"
              class="add btn btn-slide"
              data-toggle="modal"
              data-target="#VaultModal"
              title="showVaultModal"
              @click="setActiveVault(vault)"
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
        <div v-for="vk in state.vaultKeeps" :key="vk.id">
          <div class="drop-zone"
               @drop="onDrop($event, vault.id)"
               @dragenter.prevent
               @dragover.prevent
          >
            <div class="drag-el"

                 draggable="true"
                 @dragstart="startDrag($event, vk)"
            >
              {{ vk.name }}
            </div>
          </div>
        </div>
        <!-- comment end -->
      </div>
    </div>
  </div>
</template>

<script>
import { computed, watchEffect, reactive, watch } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { vaultsService } from '../services/VaultsService'
// import { vaultsService } from '../Services/VaultsService'

export default {
  props: {
    vault: { type: Object, required: true }
  },
  setup(vault) {
    const getList = (list) => {
      return state.items.filter((item) => item.list === list)
    }
    watchEffect(() => {
      vaultsService.getKeepsByVault(vault.vault.id)
      watchEffect(() => logger.log('vaultKeeps', AppState.vaultKeeps))
      // logger.log('APsKeeps', AppState.keeps)
      // logger.log('APsVaults', AppState.vaults)
    })

    const startDrag = (event, item) => {
      event.dataTransfer.dropEffect = 'move'
      event.dataTransfer.effectAllowed = 'move'
      event.dataTransfer.setData('itemID', item.id)
      logger.log(item.id)
    }

    const onDrop = (event, vk) => {
      const keepId = event.dataTransfer.getData('itemID')
      // const item = state.items.find((i) => i.id == itemId)
      // item.list = list
      logger.log('vk_vCard', vk, keepId)
      vaultsService.getKeepsByVault(vk)
      // eslint-disable-next-line eqeqeq
      if (AppState.vaultKeeps.find((k) => k.id == keepId)) {
        logger.log('Do Nothing')
      } else {
        logger.log('create vautkeep:', keepId)
        vaultsService.createVaultKeep(vk, keepId)
      }
    }

    const setActiveVault = (vault) => {
      AppState.activeVault = vault
      AppState.activeVaultEdit = ''
    }

    const state = reactive({
      items: computed(() => AppState.items),
      activeVault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      vaultKeeps: computed(() => AppState.vaultKeeps),
      keeps: computed(() => AppState.keeps)
    })

    return {
      state,
      getList,
      onDrop,
      startDrag,
      setActiveVault
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

/* .drop-zone{
  width: 50%;
  margin: 50px;
  background-color:  info;
  padding: 10px;
  min-height: 10px;
} */
.drag-el {
background-color: info;
color: dark;
padding: 1px;
min-height: 10px;
}
.drag-el:nth-last-of-type(1){
  margin-bottom: 0;
}
</style>
