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
        <div class="drop-zone"
             @drop="onDrop($event, 1)"
             @dragenter.prevent
             @dragover.prevent
        >
          <div v-for="item in getList(1)"
               :key="item.id"
               class="drag-el"
               draggable="true"
               @dragstart="startDrag($event, item)"
          >
            {{ item.title }}
          </div>
        </div>
        <!-- comment end -->
      </div>
    </div>
    <VaultModal />
  </div>
</template>

<script>
import { computed, ref, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
// import { vaultsService } from '../Services/VaultsService'

export default {
  props: {
    vault: { type: Object, required: true }
  },
  setup() {
    const getList = (list) => {
      return state.items.filter((item) => item.list === list)
    }

    const startDrag = (event, item) => {
      logger.log(item)
      event.dataTransfer.dropEffect = 'move'
      event.dataTransfer.effectAllowed = 'move'
      event.dataTransfer.setData('itemID', item.id)
    }

    const onDrop = (event, list) => {
      const itemId = event.dataTransfer.getData('itemID')
      // eslint-disable-next-line eqeqeq
      const item = state.items.find((i) => i.id == itemId)
      item.list = list
    }

    const state = reactive({
      items: computed(() => AppState.items),
      activeVault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      setActiveVault: computed((vault) => {
        AppState.activeVault = vault
        AppState.activeVaultEdit = ''
      })
    })

    return {
      state,
      getList,
      onDrop,
      startDrag
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
