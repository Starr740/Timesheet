<template>
    <div class="container-fluid mt-4">
      <h1 class="h1">eTimesheet</h1>
      <!-- <b-alert :show="loading" variant="info">Loading...</b-alert> -->
      <b-row>
        <b-col>
          <table class="table table-striped">
            <thead>
              <tr>
                <!-- <th>ID</th> -->
                <th>Date</th>
                <th>Task</th>
                <th>Description</th>
                <th>Time Spent</th>
                <th>&nbsp;</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="record in records" :key="record.id">
                <!-- <td>{{ record.id }}</td> -->
                <td> {{ record.date }}</td>
                <td>{{ record.task }}</td>
                <td>{{ record.description }}</td>
                <td>{{ record.hours }} hrs {{ record.minutes }} mins</td>
                <td class="text-right">
                  <a href="#" @click.prevent="updateFoodRecord(record)" v-b-modal.modal-1>Edit</a> -
                  <a href="#" @click.prevent="deleteFoodRecord(record.id)">Delete</a>
                </td>
              </tr>
            </tbody>
          </table>
          <br>
         <br>
            <b-button v-b-modal.modal-1>New</b-button>
            <br><br>
            <!-- <FormulateTable @submit="showAlert">
            <FormulateInput type="submit" name="Submit this table!"/>
           </FormulateTable> -->
            <!-- <div>
                <b-btn type="send" variant="success">Submit</b-btn>
              </div> -->
            <b-modal id="modal-1" title="Add Project" hide-footer>
  <!-- Content -->
            <form @submit.prevent="createFoodRecord">
              <!-- <b-form-group label="Member Id">
                <b-form-input type="number" v-model="model.teamId"></b-form-input>
              </b-form-group> -->
              <b-form-group label="Date" style="color: #28c69f">
                <b-form-input v-model="model.date"  type="date" class="form-control"></b-form-input>
              </b-form-group>
              <b-form-group label="Task">
                <b-form-input type="text" v-model="model.task"></b-form-input>
              </b-form-group>
              <b-form-group label="Description">
                <b-form-textarea type="text" v-model="model.description"></b-form-textarea>
              </b-form-group>
              <b-form-group label="Hours">
                <b-form-input v-model="model.hours"  type="number" class="form-control"></b-form-input>
              </b-form-group>
              <b-form-group label="Minutes">
                <b-form-input v-model="model.minutes"  type="number" class="form-control"></b-form-input>
              </b-form-group>
              <!-- <b-form-group label="Total" v-model="model.total">
                <div>{{ total }}</div>
              </b-form-group> -->
              <br>
              <div>
                <b-btn type="submit" variant="success">Save Record</b-btn>
              </div>
            </form>
          </b-modal>
        </b-col>
      </b-row>
    </div>
  </template>
  
  <script>
   let currDate = new Date().toLocaleDateString('en-GB');
    import api from '@/TimesheetApiService';
    export default {
      data() {
        return {
        result: {},
        model:{
        hours: '',
        minutes: ''
      },
          // loading: false,
          records: [],
          model: {}
        };
      },
      computed: {
       total:function()
     {
          return parseFloat(this.model.hours) + parseFloat(this.model.minutes/60);

     },
  },
      async created() {
        this.getAll()
      },
      methods: {
        async getAll() {
          this.loading = true
  
          try {
            this.records = await api.getAll()
          } finally {
            this.loading = false
          }
        },
        async updateFoodRecord(foodRecord) {
          // We use Object.assign() to create a new (separate) instance
          this.model = Object.assign({}, foodRecord)
        },
        async createFoodRecord() {
          const isUpdate = !!this.model.id;
  
          if (isUpdate) {
            await api.update(this.model.id, this.model)
          } else {
            await api.create(this.model)
          }
  
          // Clear the data inside of the form
          this.model = {}
  
          // Fetch all records again to have latest data
          await this.getAll()
        },
        async deleteFoodRecord(id) {
          if (confirm('Are you sure you want to delete this record?')) {
            // if we are editing a food record we deleted, remove it from the form
            if (this.model.id === id) {
              this.model = {}
            }
  
            await api.delete(id)
            await this.getAll()
          }
        }
      }
    }
  </script>