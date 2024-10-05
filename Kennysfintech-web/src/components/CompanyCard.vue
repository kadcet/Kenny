<script>

import axios from "axios";

export default {
  data() {
    return {
      companies:[],
      invoice:[],
      selectedCompanyCode:0,
      
      
      
      
    };
  },
  created() {
    this.getAllFirm();
    
  },


  methods: {
    async getAllFirm() {
      try {
        const response = await axios.get(
          "https://localhost:7043/api/Company/GetAllCompany"
        );
        this.companies = response.data.data;
      } catch (error) {
        console.error("Veri çekme hatası:", error);
      }
    },

    GetInvoice() {

      console.log(this.selectedCompanyCode);
      axios
        .get("https://localhost:7043/api/Company/GetByIdCompany?code=" + this.selectedCompanyCode)
        .then((res) => {
          console.log(res);
          this.invoice = res.data.data;
        })
        .catch((err) => {
          console.log(err.response.data.message);
          alert(err.response.data.message);
        });

   
  },
},
}
</script>

<template>
  <!-- header -->
  <div class="header">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-8">
          <div class="form-floating col-6 mb-3">
          </div>
        </div>
        <div class="col-4  d-flex justify-content-end">
          <select v-model="selectedCompanyCode" class="form-select" id="inputGroupSelect03" aria-label="Example select with button addon" @change="GetInvoice()">
            <option selected>Firma Seçin...</option>
            <option v-for="(firm,ndx) in companies" :key="ndx" :value="firm.compCode">
              {{ firm.companyName }} 
            </option>
          </select>
        </div>
      </div>
    </div>
  </div>
  <!-- End header -->

  <table class="table table-striped table-bordered">
            <thead class="table-dark">
              <tr>
                <th>Id</th>
                <th>Company Code</th>
                <th>Company Name</th>
                <th>IOC</th>
                <th>Invoice Date</th>
                <th>Invoice Number</th>
                <th>DC</th>
                <th>Amount</th>
                <th>Payment</th>
                <th>Balance</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(inv,cod) in invoice" :key="cod" :value="inv.companyCode" >
                <td>{{ inv.id }}</td>
                <td>{{ inv.companyCode }}</td>
                <td>{{ inv.companyName }}</td>
                <td>{{ inv.IOC }}</td>
                <td>{{ inv.invoiceDate }}</td>
                <td>{{ inv.invoiceNumber }}</td>
                <td>{{ inv.DC }}</td>
                <td>{{ inv.invoiceAmount }}</td>
                <td>{{ inv.payment }}</td>
                <td>{{ inv.balance }}</td>
                <td>
                  <button class="btn btn-primary btn-sm">Edit</button>
                  <button class="btn btn-danger btn-sm">Delete</button>
                </td>
              </tr>
            </tbody>
          </table>
</template>

<style scoped>
.form-floating label {
  padding-left: 2.5rem;
}

.form-floating .form-control {
  padding-left: 2.5rem;
}

.text-primary {
  color: #6f42c1 !important;
}

.header {
  display: flex;
  width: 100%;
  background-color: #f8f9fa;
  padding-top: 10px;
  padding-bottom: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);

}
</style>
