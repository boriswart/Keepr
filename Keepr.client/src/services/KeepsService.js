import { AppState } from './AppState'
// import Pop from '../utils/Notifier'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log(res.data)
    AppState.keeps = res.data
  }

  async getKeepById(id) {
    AppState.contract = {}
    const res = await api.get(`api/keeps/${id}`)
    AppState.keep = res.data
  }

  async getKeepVaults(keepId) {
    AppState.keepVaults = []
    const res = await api.get(`api/keeps/${keepId}/vaults`)
    AppState.contractBids = res.data
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

  // async updateGroup(g) {
  //   await api.put(`api/groups/${g.id}`, g)
  //   Pop.toast(`Updated group ${g.name}`)
  // }

  // async deleteGroup(g) {
  //   await api.delete(`api/groups/${g.id}`)
  //   Pop.toast(`Deleted group ${g.name}`)
  // }

  // async joinGroup(g) {
  //   await api.post('api/groupmembers', {
  //     groupId: g.id
  //   })
  //   Pop.toast(`Joined group ${g.name}`)
  // }
}

export const keepsService = new KeepsService()
