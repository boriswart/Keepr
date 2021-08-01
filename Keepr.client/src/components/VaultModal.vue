<template>
  <div class="row">
    <div class="col-12 d-flex align-items-center justify-content-center">
      <div class="modal fade" id="VaultModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <div class="col-8 d-flex justify-content-between m-auto  my-5">
                <h5 class="modal-title" id="exampleModalLabel">
                  Vault
                </h5>
                <i class="remove fa fa-trash text-danger mx-1" aria-hidden="true" @click="removeKeep(vault)" title="Remove Vault"> </i>
                <i class="edit fa fa-pencil text-primary mx-1" aria-hidden="true" @click="setActiveVaultEdit(vault.id)" title="Edit Vault"> </i>
              </div>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <!-- <div v-for="(v,i) in vaults" :key="i"> -->
              <div class="row">
                <div class="col-12 m-auto justify-content-between my-3">
                  <h5> {{ vault.name }}</h5>
                  {{ activeVaultEdit }}
                  <div class="row">
                    <div class="col-12 m-auto justify-content-between my-3">
                      <!-- <img :src="keep.img" v-if="keep.img" alt="" class="card-img-top my-3"> -->
                      <div class="row">
                        <div class="col-12 m-auto  m-5">
                          <h6><p>{{ vault.description }}</p></h6>
                        </div>
                      </div>
                      <div class="row">
                      </div>
                      <!-- </div> -->
                      <div class="row">
                        <div v-if="activeVaultEdit == vault.id" class="col-11">
                          <form @submit.prevent="editFormVault(vault.id)">
                            <input type="text" class="form-control m-3" required="true" placeholder="Name" v-model="state.newVault.Name">
                            <input type="text" class="form-control m-3" required="true" placeholder="Description" v-model="state.newVault.Description">
                            <button type="submit"
                                    class="btn"
                                    :disabled="!state.newVault.Name"
                                    :class="{
                                      'btn-primary': state.newVault.Name,
                                      'display-none': !state.newVault.Name
                                    }"
                            >
                              Edit Vault
                            </button>
                          </form>
                        </div>
                        <div v-if="vault.creator" class="card-footer text-right">
                          <b>{{ vault.creator.name }}</b>
                          <img :src="vault.creator.picture" alt="vault creator image" class="rounded-circle elevation-1 mx-2" height="40">
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { computed, reactive, watchEffect } from '@vue/runtime-core'
import { AppState } from '../AppState'
// import { accountService } from '../services/AccountService'
// import { vaultsService } from '../services/VaultsService'
export default {
  setup() {
    const state = reactive({
      newVault: { id: 0, Name: '', Description: '' },
      vault: watchEffect(() => AppState.activeVault),
      activeVaultEdit: ''
    })
    return {
      state,
      vaults: computed(() => AppState.vaults),
      vault: computed(() => AppState.activeVault),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      activeVaultEdit: computed(() => AppState.activeVaultEdit),
      setActiveVaultEdit(id) {
        AppState.activeVaultEdit = id
      },
      addVault() {
        // const newVault = { name: state.newVault.Name, description: state.newVault.Description }
        // accountService.addVault(newVault)
        state.newVault = {}
      },
      removeVault(keepData) {
        if (confirm('do you really want to delete')) {
          // vaultService.deleteVault(vaultData)
          state.activeVaultEdit = ''
        }
      },
      editKeep(vaultData) {
        // vaultsService.updateVault(vaultData)
      },
      editFormVault(id) {
        const vt = state.newVault
        vt.Name = state.newVault.Name
        vt.Description = state.newVault.Description
        vt.id = id
        // vaultsService.updateVault(vt)
        AppState.activeVault = vt
        state.newVault = {}
        state.activeVaultEdit = ''
      }
    }
  }
}
</script>

<style>
.edit {
  transition: all .2s ease-in-out;
   -webkit-filter: drop-shadow(5px 5px 5px #222);
    filter:         drop-shadow(5px 5px 5px #222); }
.edit:hover {
  transform: scale(1.1); }
.remove {
  transition: all .2s ease-in-out;
   -webkit-filter: drop-shadow(5px 5px 5px #222);
    filter:         drop-shadow(5px 5px 5px #222); }
.remove:hover {
  transform: scale(1.1); }
.submit-edit {
  transition: all .2s ease-in-out;
   -webkit-filter: drop-shadow(5px 5px 5px #222);
    filter:         drop-shadow(5px 5px 5px #222); }
.submit-edit:hover {
  transform: scale(1.1); }
.cancel-edit {
  transition: all .2s ease-in-out;
   -webkit-filter: drop-shadow(5px 5px 5px #222);
    filter:         drop-shadow(5px 5px 5px #222); }
.cancel-edit:hover {
  transform: scale(1.1); }
.shadow{
  -webkit-filter: drop-shadow(5px 5px 5px #222);
    filter:         drop-shadow(5px 5px 5px #222);
}
.fa-trash{
  -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: rgb(247, 233, 75);
}
</style>
