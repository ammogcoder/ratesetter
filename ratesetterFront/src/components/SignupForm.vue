<template>
  <main>
    <div v-if="found == false" class="mx-auto my-3 h-100" style="width: 600px;">
      <div class="bg-white rounded p-5 shadow">
        <h3 class="mt-0 font-weight-bold">User Login</h3>
        <div class="row pt-3">
          <div class="col-6">
            <div class="form-group">
              <label for="username">Username:</label>
              <input
                v-model="userData.username"
                type="text"
                class="form-control"
                name="username"
                id=""
                aria-describedby="username"
                placeholder="Enter Username"
              />
            </div>
          </div>

          <div class="col-6">
            <div class="form-group">
              <label for="password">Password:</label>
              <input
                v-model="userData.password"
                type="password"
                class="form-control"
                name="password"
                id=""
                placeholder="Enter Password"
              />
            </div>
          </div>
        </div>

        <p class="small text-danger">{{ message }}</p>
        <button
          class="mt-3 btn btn-info btn-lg"
          @click.prevent="matchUserData"
          type="submit"
        >
          User Login
        </button>
      </div>
    </div>
    <div v-if="found">
      <Lender :username="userData.username" v-if="role == 'lender'" />
      <Borrower :username="userData.username" v-else />
    </div>
  </main>
</template>

<script>
import Borrower from "./borrower.vue";
import Lender from "./lender.vue";

export default {
  data() {
    return {
      users: [
        {
          username: "davyJones",
          password: "n9G%YE6nnhWG",
          role: "lender"
        },
        {
          username: "jackTaylor",
          password: "vhU51&17XZaW",
          role: "borrower"
        },
        {
          username: "captainSparrow",
          password: "76%Q7xOG3nPK",
          role: "lender"
        },
        {
          username: "johnGibbs",
          password: "P0$6nq4z2AKN",
          role: "borrower"
        }
      ],
      userData: {
        username: "",
        password: ""
      },
      message: "",
      response: "",
      found: false,
      role: "",
    };
  },
  methods: {
    matchUserData() {
      let users = this.users;
      for (var i = 0; i < this.users.length; i++) {
        if (
          this.userData.username == users[i].username &&
          this.userData.password == users[i].password
        ) {
          this.found = true;
          this.role = users[i].role;
    
        }
      }
      if (this.found == false) {
        this.message = "Invalid username or password please check";
      }
      // this.resetForm();
    },
    resetForm() {
      this.userData.username = "";
      this.userData.password = "";
    },
    submitted() {
      this.isSubmitted = true;
    }
  },

  components: {
    Lender,
    Borrower
  }
};
</script>

<style></style>
