<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
    <div class="row justify-content-center">
      <div class="col-3 border rounded m-3 img-fluid" v-for="keep in keeps" :key="keep.id">
        <h1>{{keep.name}}</h1>
        <h1>{{keep.description}}</h1>
        <h1>{{keep.img}}</h1>
        <img :src="keep.img" class="img-fluid"  alt="">
        <!-- <button @click="deleteCar(car.id)" class="btn btn-danger">Delete</button> -->
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
     this.$store.dispatch("getKeeps")
  },
  computed: {
    keeps(){
      return this.$store.state.publicKeeps
    }
  },
  component:{}
};
</script>

<style></style>
