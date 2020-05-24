<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->

    <form @submit.prevent="createKeep()">
    <div class="form-group">
      <label for="name">Name</label>
      <input type="text" name="name" class="form-control" placeholder="Enter name...." v-model="newKeep.name" />
    </div>
    <div class="form-group">
      <label for="img">img</label>
      <input type="text" name="img" class="form-control" placeholder="Enter imgUrl...." v-model="newKeep.img" />
    </div>
    <div class="form-group">
      <label for="description">Description</label>
      <input type="text" name="description" class="form-control" placeholder="Enter description...." v-model="newKeep.description" />
    </div>
    <button type="submit" class="btn btn-primary btn-lg">SUBMIT</button>
    </form>



    <div class="row justify-content-center">
      <div class="col-3 border rounded m-3" v-for="keep in keeps" :key="keep.id">
        <h1>{{keep.name}}</h1>
        <h1>{{keep.description}}</h1>
        <img :src="keep.img" class="img-fluid"  alt="">
        <h1>{{keep.views}}</h1>
        <h1>{{keep.shares}}</h1>
        <h1>{{keep.keeps}}</h1>
        <button @click="deleteKeep(keep.id)" class="btn btn-danger">Delete</button>
        <button @click="addMyKeep(keep.id)" class="btn btn-warning">Add to My-Keeps</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data(){
    return{
      newKeep: {}
    }
  },
  mounted() {
     this.$store.dispatch("getKeeps")
  },
  computed: {
    keeps(){
      return this.$store.state.publicKeeps
    }
  },
  methods: {
    deleteKeep(keepId){
      this.$store.dispatch("deleteKeep", keepId)
    },
    createKeep(){
      this.$store.dispatch("createKeep", this.newKeep);
    },
    addMyKeep(keepId){
      this.$store.dispatch("addMyKeep", keepId)
    }
  },
  component:{}
};
</script>

<style></style>
