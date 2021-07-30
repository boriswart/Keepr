<template>
  <div class="row">
    <div class="col-12 d-flex align-items-center justify-content-center">
      <div class="modal fade" id="KeepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <div class="col-8 d-flex justify-content-between m-auto  my-5">
                <h5 class="modal-title" id="exampleModalLabel">
                  Keep
                </h5>
                <i class="remove fa fa-trash text-danger mx-1" aria-hidden="true" @click="removeKeep(keep)" title="Remove Keep"> </i>
                <i class="edit fa fa-pencil text-primary mx-1" aria-hidden="true" @click="setActiveKeepEdit(keep.id)" title="Edit Keep"> </i>
              </div>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <!-- <div v-for="(k,i) in keeps" :key="i"> -->
              <div class="row">
                <div class="col-12 m-auto justify-content-between my-3">
                  <h5> {{ keep.name }}</h5>
                  {{ activeKeepEdit }}
                  <div class="row">
                    <div class="col-12 m-auto justify-content-between my-3">
                      <img :src="keep.img" v-if="keep.img" alt="" class="card-img-top my-3">
                      <div class="row">
                        <div class="col-12 m-auto  m-5">
                          <h6><p>{{ keep.description }}</p></h6>
                        </div>
                      </div>
                      <div class="row">
                      </div>
                      <form v-if="state.activeKeepEdit == keep.id" class="card m-2 p-2 bg-danger shadow">
                        <div class="row">
                          <div class="col-12 d-flex justify-content-center p-3">
                            <button type="button" class="submit-edit mx-3 btn btn-primary" @click="activeKeepEdit = keep.id">
                              Submit
                            </button>
                            <button type="button" class="cancel-edit mx-3 btn btn-primary" @click="activeKeepEdit = ''">
                              Cancel
                            </button>
                          </div>
                        </div>
                      </form>
                      <!-- </div> -->
                      <div class="row">
                        <div v-if="activeKeepEdit == keep.id" class="col-11">
                          <form @submit.prevent="editFormKeep(keep.id)">
                            <input type="text" class="form-control m-3" required="true" placeholder="Name" v-model="state.newKeep.Name">
                            <input type="text" class="form-control m-3" required="true" placeholder="Description" v-model="state.newKeep.Description">
                            <input type="text" class="form-control m-3" required="true" placeholder="Img-Url" v-model="state.newKeep.Img">
                            <button type="submit"
                                    class="btn"
                                    :disabled="!state.newKeep.Name"
                                    :class="{
                                      'btn-primary': state.newKeep.Name,
                                      'display-none': !state.newKeep.Name
                                    }"
                            >
                              Edit Keep
                            </button>
                            <div v-if="keep.creator" class="card-footer text-right">
                              <b>{{ keep.creator.name }}</b>
                              <img :src="keep.creator.picture" alt="keep creator image" class="rounded-circle elevation-1 mx-2" height="40">
                            </div>
                          </form>
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
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { accountService } from '../services/AccountService'
import { keepsService } from '../services/KeepsService'
export default {
  // props: {
  //   keep: { type: Object, required: true }
  // },
  setup() {
    const state = reactive({
      newKeep: { id: 0, Name: '', Description: '', Img: '' },
      activeKeepEdit: ''
    })
    return {
      state,
      keeps: computed(() => AppState.keeps),
      keep: computed(() => AppState.activeKeep),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      activeKeepEdit: computed(() => AppState.activeKeepEdit),
      setActiveKeepEdit(id) {
        AppState.activeKeepEdit = id
      },
      addKeep() {
        const newKeep = { name: state.newKeep.Name, description: state.newKeep.Description, Url: state.newKeep.Img }
        accountService.addKeep(newKeep)
        state.newKeep = {}
      },
      removeKeep(keepData) {
        if (confirm('do you really want to delete')) {
          keepsService.deleteKeep(keepData)
          state.activeKeepEdit = ''
        }
      },
      editKeep(keepData) {
        // AppState.account.contacts.push(contact)
        keepsService.updateKeep(keepData)
      },
      editFormKeep(id) {
        const kp = state.newKeep
        kp.Name = state.newKeep.Name
        kp.Description = state.newKeep.Description
        kp.Img = state.newKeep.Img
        kp.id = id
        keepsService.updateKeep(kp)
        AppState.activeKeep = kp
        state.newKeep = {}
        state.activeKeepEdit = ''
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
