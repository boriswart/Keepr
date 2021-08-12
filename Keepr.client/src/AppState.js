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
    { id: 0, title: 'Item A', list: 1 },
    { id: 1, title: 'Item B', list: 1 },
    { id: 2, title: 'Item C', list: 2 }
  ])
})
