<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-4 col-md-6" v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-4 col-md-6" v-for="v in vaults" :key="v.id">
          <VaultCard :vault="v" />
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
      vaults: computed(() => AppState.vaults)
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
