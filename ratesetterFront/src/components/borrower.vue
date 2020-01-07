<template>
  <div>
    <!-- Table2 section -->
    <div id="burrower" class="mx-auto my-3 h-100" style="width: 600px;">
      <div class="bg-white rounded p-5">
        <h4>Welcome {{ username }}</h4>
        <p>
          Your role is a borrower and here are all the loans that you have
          requested.
        </p>
        <table id="table2" class="table table-bordered table-striped w-100">
          <thead class="">
            <tr>
              <th>Loan ID</th>
              <th>Loan Name</th>
              <th>Loan Amount</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in response" :key="item.loanId">
              <td>{{ item.loanId }}</td>
              <td>{{ item.loanName }}</td>
              <td>{{ item.loanAmount }}</td>
              <td>{{ item.loanStatus }}</td>
            </tr>
          </tbody>
        </table>
        <button
          class="mt-3 btn btn-info"
          type="submit"
          data-toggle="modal"
          data-target="#modelId"
        >
          Request New
        </button>

        <!-- Modal -->
        <div
          class="modal fade"
          id="modelId"
          tabindex="-1"
          role="dialog"
          aria-labelledby="modelTitleId"
          aria-hidden="true"
        >
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title">New Loan</h5>
                <button
                  type="button"
                  class="close"
                  data-dismiss="modal"
                  aria-label="Close"
                >
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <div class="row pt-3">
                  <div class="col-6">
                    <div class="form-group">
                      <label for="loanName">Loan Name:</label>
                      <input
                        v-model="loanName"
                        type="text"
                        class="form-control"
                        name="loanName"
                        id=""
                        aria-describedby="loanName"
                        placeholder="Enter loanName"
                      />
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="form-group">
                      <label for="amount">Amount:</label>
                      <input
                        v-model="amount"
                        type="number"
                        class="form-control"
                        name="amount"
                        id=""
                        aria-describedby="amount"
                        placeholder="Enter amount"
                      />
                    </div>
                  </div>
                </div>
              </div>
              <div class="modal-footer">
                <button
                  type="button"
                  class="btn btn-secondary"
                  data-dismiss="modal"
                >
                  Close
                </button>
                <button
                  type="submit"
                  @click.prevent="submitForm"
                  class="btn btn-primary"
                >
                  Save
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["username"],
  data() {
    return {
      response: [],
      amount: 0,
      loanName: ""
    };
  },
  methods: {
    submitForm() {
      const formData = {
        loanName: this.loanName,
        loanAmount: parseInt(this.amount, 10),
        requestedBy: this.username
      };
      axios
        .post(`requestloan`, formData)
        .then(res => {
          alert('Request sent successfully');
          return res.data;
          })
        .catch(err => (this.response2 = err));
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
