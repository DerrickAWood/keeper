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
        <button @click="ViewVault(keep.id)" class="btn btn-primary">View Keeps</button>
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
     this.$store.dispatch("getVaults")
  },
  computed: {
    Vaults(){
      return this.$store.state.vaults
    }
  },
  methods: {
    createVault(){
      this.$store.dispatch("createVault", this.newVault);
    }
    // deleteKeep(keepId){
    //   this.$store.dispatch("deleteKeep", keepId)
    // },
  },
  component:{}
};
</script>

<style></style>
