import { AppState } from '../AppState'
// import Pop from '../utils/Notifier'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    AppState.vaults = []
    AppState.vault = {}
    const res = await api.get('api/vaults')
    // logger.log('gVaults', res.data)
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    AppState.vault = {}
    const res = await api.get(`api/vaults/${id}`)
    // logger.log('gVBId', res.data)
    AppState.vault = res.data
    logger.log('AppS-vt', AppState.vault)
  }

  async getKeepsByVault(vaultId) {
    AppState.keepVaults = []
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    // res.data.vaultId = vaultId
    // logger.log('vauktKeeps', res.data)
    AppState.vaultKeeps = res.data
  }

  async createVaultKeep(v, k) {
    await api.post(`api/vaults/${v}/keeps/${k}`)
  }

  async deleteVault(v) {
    await api.delete(`api/vaults/${v.id}`)
    // Pop.toast(`Deleted vault ${k.name}`)
  }

  async updateVault(vaultData) {
    const res = await api.put(`api/vaults/${vaultData.id}`, vaultData)
    AppState.activeVault = res.data
    // logger.log('put', res.data)
    // Pop.toast(`Updated vault ${k.name}`)
  }
}

export const vaultsService = new VaultsService()
