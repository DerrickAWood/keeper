<template>
  <div class="dashboard container-fluid">
    <h1>WELCOME TO THE KEEPR</h1>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->

    <form @submit.prevent="createKeep()">
      <div class="form-group">
        <label for="name">Name</label>
        <input
          type="text"
          name="name"
          class="form-control"
          placeholder="Enter name...."
          v-model="newKeep.name"
        />
      </div>
      <div class="form-group">
        <label for="img">img</label>
        <input
          type="text"
          name="img"
          class="form-control"
          placeholder="Enter imgUrl...."
          v-model="newKeep.img"
        />
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <input
          type="text"
          name="description"
          class="form-control"
          placeholder="Enter description...."
          v-model="newKeep.description"
        />
      </div>
      <button type="submit" class="btn btn-primary btn-lg">SUBMIT</button>
    </form>

    <div class="row justify-content-center">
      <div class="col-md-3 border rounded m-3" v-for="keep in keeps" :key="keep.id">
        <h1>{{keep.name}}</h1>
        <h1>{{keep.description}}</h1>
        <img :src="keep.img" class="img-fluid" alt />
        <div class="row m-2">
        <button @click="deleteKeep(keep.id)" class="btn btn-danger m-2">Delete</button>
        <div class="dropdown m-2">
            <button
              class="btn btn-secondary dropdown-toggle"
              type="button"
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Add To Vault</button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <button
                @click.prevent="addToVault(vault.id, keep.id)"
                class="dropdown-item btn btn-primary btn-sm"
                v-for="vault in Vaults"
                :key="vault.id"
              >
                <div v-if="$auth.user.sub == vault.userId">{{vault.name}}</div>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newKeep: {}
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
    this.$store.dispatch("setBearer", this.$auth.bearer);
    console.log(this.$auth.user.sub);
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps;
    },
    Vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    },
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
    },
    // ANCHOR just got access to keepid, get 400, do i need userid?
    addToVault(vaultId, keepId, userId) {
      let newVaultKeep = {
        keepId: keepId,
        vaultId: vaultId,
        userId: this.$auth.user.sub
      };
      console.log(newVaultKeep);
      this.$store.dispatch("addToVault", newVaultKeep);
    }
  },
  component: {}
};
</script>

<style></style>
