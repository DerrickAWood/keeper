<template>
  <div class="vault">
    <h1>WELCOME TO THE VAULT</h1>

    <div class="row justify-content-center">
      <div class="col-3 border rounded m-3" v-for="keep in vault" :key="keep.id">
        <h1>{{keep.name}}</h1>
        <h1>{{keep.description}}</h1>
        <img :src="keep.img" class="img-fluid"  alt="">
        <h1>{{keep.views}}</h1>
        <h1>{{keep.shares}}</h1>
        <h1>{{keep.keeps}}</h1>
        <!-- <button @click="deleteKeep(keep.id)" class="btn btn-danger">Delete</button> -->
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data(){
    return{
      vault: {}
    }
  },
  mounted() {
     this.$store.dispatch("getMyVault")
  },
  computed: {
    Vault(){
      return this.$store.state.vault
    }
  },
  methods: {
    // deleteKeep(keepId){
    //   this.$store.dispatch("deleteKeep", keepId)
    // },
  },
  component:{}
};
</script>

<style></style>
