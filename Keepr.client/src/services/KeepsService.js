import { AppState } from '../AppState'
// import Pop from '../utils/Notifier'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    AppState.keeps = []
    AppState.keep = {}
    const res = await api.get('api/keeps')
    logger.log('gKeeps', res.data)
    AppState.keeps = res.data
  }

  async getKeepById(id) {
    AppState.keep = {}
    const res = await api.get(`api/keeps/${id}`)
    logger.log('gKBId', res.data)
    AppState.keep = res.data
    logger.log('AppS-kp', AppState.keep)
  }

  async getKeepVaults(keepId) {
    AppState.keepVaults = []
    const res = await api.get(`api/keeps/${keepId}/vaults`)
    AppState.keepVaults = res.data
  }

  async deleteKeep(k) {
    await api.delete(`api/keeps/${k.id}`)
    // Pop.toast(`Deleted group ${k.name}`)
  }

  async updateKeep(keepData) {
    const res = await api.put(`api/keeps/${keepData.id}`, keepData)
    AppState.activeKeep = res.data
    logger.log('put', res.data)
    // Pop.toast(`Updated group ${k.name}`)
  }

  // async leaveGroup(g) {
  //   await api.delete(`api/groupmembers/${g.id}`)
  //   Pop.toast(`Left group ${g.name}`)
  //   // router.push({ name: 'Group', params: { id: g.id } })
  // }

  // async createGroup(group) {
  //   const res = await api.post('api/groups', group)
  //   Pop.toast(`Created group ${group.name}`)
  //   AppState.groups.push(res.data)
  // }

  // async joinGroup(g) {
  //   await api.post('api/groupmembers', {
  //     groupId: g.id
  //   })
  //   Pop.toast(`Joined group ${g.name}`)
  // }
}

export const keepsService = new KeepsService()
