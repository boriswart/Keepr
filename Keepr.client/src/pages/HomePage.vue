<template>
  <!-- <div v-for="item in getList(2)"
             :key="item.id"
             class="drag-el"
             draggable="true"
             @dragstart="startDrag($event, item)"
        >
          {{ item.title }}
        </div> -->
  <div class="container-fluid">
    <div class="row">
      <div class="d-flex flex-wrap justify-content-between">
        <div class="col-lg-2 col-md-6 vault" v-for="v in vaults" :key="v.id">
          <div class="drop-zone">
            <div class="drag-el"
                 @drop="onDrop($event, 2)"
                 @dragenter.prevent
                 @dragover.prevent
                 draggable="true"
                 @dragstart="startDrag($event, v)"
            >
              <VaultCard :vault="v" />
            </div>
          </div>
        </div>
        <div class="col-lg-4" v-for="k in keeps" :key="k.id">
          <div class="drop-zone">
            <div class="drag-el"
                 @drop="onDrop($event, 2)"
                 @dragenter.prevent
                 @dragover.prevent
                 draggable="true"
                 @dragstart="startDrag($event, k)"
            >
              <KeepCard :keep="k" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { computed, onMounted, reactive, watchEffect } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
export default {
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

    onMounted(() => {
      keepsService.getKeeps()
      vaultsService.getVaults()
      // vaultsService.getVaultKeeps()
      watchEffect(() => AppState.keeps)
      watchEffect(() => AppState.vaults)
    })

    const state = reactive({
      items: computed(() => AppState.items)
    })

    return reactive({
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      items: computed(() => AppState.items),
      getList,
      onDrop,
      startDrag,
      computed: {
        listOne() {
          return this.items.filter(item => item.list === 1)
        },
        listTwo() {
          return this.items.filter(item => item.list === 2)
        }
      }
    })
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
