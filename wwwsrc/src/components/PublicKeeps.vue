<template>
  <div class="PublicKeeps">
    <div class="row justify-content-center">
      <div class="col-3 border rounded m-3 img-fluid" v-for="keep in keeps" :key="keep.id">
        <h1>{{keep.name}}</h1>
        <h1>{{keep.description}}</h1>
        <img :src="keep.img" class="img-fluid"  alt="">
        <!-- <button @click="deleteCar(car.id)" class="btn btn-danger">Delete</button> -->
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "PublicKeeps",
  data() {
    return {
      newKeep: {}
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps")
  },
  computed: {
    keeps(){
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    // createCar(){
    //   this.newCar.productionYear = +this.newCar.productionYear;
    //   this.newCar.price = +this.newCar.price;
    //   this.$store.dispatch("createCar", this.newCar);
    // },
    // deleteCar(carId){
    //   this.$store.dispatch("deleteCar", carId)

    // }
  },
  components: {}
};
</script>


<style scoped>
</style>