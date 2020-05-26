<template>
  <div class="vault">
    <h1>WELCOME TO THE VAULT</h1>

    <form @submit.prevent="createVault()">
      <div class="form-group">
        <label for="name">Name</label>
        <input type="text" name="name" class="form-control" placeholder="Enter vault name...." v-model="newVault.name" />
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <input type="text" name="description" class="form-control" placeholder="Enter Description...." v-model="newVault.description" />
      </div>
      <button type="submit" class="btn btn-primary btn-lg">SUBMIT</button>
    </form>

     <div class="row justify-content-center">
      <div class="col-3 border rounded m-3" v-for="vault in Vaults" :key="vault.id">
        <h1>{{vault.name}}</h1>
        <h1>{{vault.description}}</h1> 
        <button @click="deleteVault(vault.id)" class="btn btn-danger">Delete</button>


        <button @click.prevent="viewVaultKeeps(vault.id)" type="button" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-xl">View Keeps</button>
          <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
              <div class="modal-content">
                 <!-- @click.prevent="viewVaultKeeps(vault.id)" -->
                <div class="dropdown-item" v-for="vaultKeep in VaultKeeps" :key="vaultKeep.id">
                  <h1> {{vaultKeep}} </h1>
                </div>
              </div>
            </div>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data(){
    return{
      newVault: {}
    }
  },
  mounted() {
     this.$store.dispatch("getKeeps")
     this.$store.dispatch("getVaults")
     this.$store.dispatch("getVaultKeeps")
  },
  computed: {
    Keeps(){
      return this.$store.state.publicKeeps
    },
    Vaults(){
      return this.$store.state.vaults
    },
    VaultKeeps(){
      return this.$store.state.vaultKeeps
    }
  },
  methods: {
    createVault(){
      this.$store.dispatch("createVault", this.newVault);
    },
    deleteVault(vaultId){
      this.$store.dispatch("deleteVault", vaultId)
    },
    
    // ANCHOR cannot access VaultKeeps vaultId even though in debugger has it, though it is inside an array.

   viewVaultKeeps(vaultId){
     debugger
      // this.$store.dispatch("viewVaultKeeps", vaultId)
      if(vaultId == this.VaultKeeps.vaultId){
        console.log("something")
      }
    }
  },
  component:{}
};
</script>

<style></style>
