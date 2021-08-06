<template>
  <div class="container-fluid-stretch">
    <div class="row">
      <!-- <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center"> -->
      <!-- <div class="row"> -->
      <div class="col-lg-2 col-md-6 vault" v-for="v in vaults" :key="v.id">
        <VaultCard :vault="v" />
      </div>
      <div class="col-lg-2 col-md-6 align-self-flex" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
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
    onMounted(() => {
      keepsService.getKeeps()
      vaultsService.getVaults()
      watchEffect(() => AppState.keeps)
      watchEffect(() => AppState.vaults)
    })
    return reactive({
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      computed: {
        listOne() {
          return this.items.filter(item => item.list === 1)
        },
        listTwo() {
          return this.items.filter(item => item.list === 2)
        },
        allowDrop(ev) {
          ev.preventDefault()
        },
        dragStart(ev) {
          ev.dataTransfer.setData('int', ev.target.id)
          logger.log('gotKeepId', ev)
        },
        dragDrop(ev) {
          ev.preventDefault()
          const data = ev.dataTransfer.getData('int')
          logger.log('vautId: ', ev.target.data.id)
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
