<template>
  <div>
    <!-- Table section -->
    <div id="lender" class="mx-auto my-3 h-100" style="width: 600px;">
      <div class="bg-white rounded p-5">
        <h4>Welcome {{ username }}</h4>
        <p>
          Your role is a lender and here are all the loans which you can fund
        </p>
        <table id="table1" class="table table-bordered table-striped w-100">
          <thead class="">
            <tr>
              <th>Loan ID</th>
              <th>Loan Name</th>
              <th>Loan Amount</th>
              <th>Status</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            <tr
              :id="index"
              v-for="(item, index) in response"
              :key="item.loanId"
            >
              <td>{{ item.loanId }}</td>
              <td>{{ item.loanName }}</td>
              <td>{{ item.loanAmount }}</td>
              <td>{{ item.loanStatus }}</td>
              <td>
                <button
                  @click.prevent="fund(item.loanId)"
                  type="submit"
                  class="btn btn-info btn-sm"
                  :disabled="item.loanStatus == 'pending' ? false : true"
                >
                  Fund
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ['username'],
  data() {
    return {
      response: [],
      response2: []
    };
  },
  methods: {
    fund(id) {
      const formData = {
        loanId: id,
        fundedBy: this.username
      };
      axios
        .post(`fundloan`, formData)
        .then(res => {
          alert('Loan funded successfully}')
          return res;
        })
        .catch(err => this.response2 = err);
    }
  },
  created() {
    axios
      .get(`loans/${this.username}`)
      .then(res => (this.response = res.data))
      .catch(error => (this.response = error));
  }
};
</script>

<style>
#table1 tr td:last-child {
  border: 0 !important;
  background: white !important;
}
</style>
