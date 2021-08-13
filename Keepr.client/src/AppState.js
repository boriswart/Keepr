import { reactive, ref } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  keep: {},
  activeKeep: {},
  activeKeepEdit: '',
  keeps: [],
  vault: {},
  vaults: [],
  activeVault: {},
  activeVaultEdit: '',
  vaultKeeps: [],
  items: ref([
    { id: 0, name: 'Item A', vkId: 1, kpId: 2 }
  ])
})
