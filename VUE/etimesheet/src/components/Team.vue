<template>
    <div class="container-fluid mt-4">
      <h1 class="h1" style="color: #28c69f">
        <b-icon icon="people"></b-icon>Project Teams</h1>
      <!-- <b-alert :show="loading" variant="info">Loading...</b-alert> -->
      <b-row>
        <b-col>
          <table class="table table-striped">
            <thead>
              <tr>
                <!-- <th>ID</th> -->
                <th>Name</th>
                <th>Coordinator ID</th>
                <th>&nbsp;</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="record in records" :key="record.id">
                <td>{{ record.id }}</td>
                <td>{{ record.name}}</td>
                <td>{{ record.coordinatorid }}</td>
                <td class="text-right">
                <a href="#" @click.prevent="updateFoodRecord(record)" v-b-modal.modal-1><b-icon icon="pencil-square"></b-icon>Edit</a> - 
                <a href="#" @click.prevent="deleteFoodRecord(record.id)"><b-icon icon="trash-fill"></b-icon>Delete</a>
              </td>
              </tr>
            </tbody>
          </table>
        </b-col>
      </b-row>
      <br>
      <br>
      <b-button v-b-modal.modal-1>Create Team</b-button>
<b-modal id="modal-1" title="Add member" hide-footer >
            <form @submit.prevent="createFoodRecord">
              <!-- <b-form-group label="Project" style="color: #28c69f">
                <b-form-input type="number" v-model="model.name"></b-form-input>
                <b-form-select>
                  <option v-for="item in records" :key="item.name">{{ item.name }}</option>
                </b-form-select> -->
                <!-- <b-form-select placeholder="Select Project" v-model="model.name">              
                  <option value="1">Informatics</option>
                  <option value="2">Oxygen Alliance</option>
                  <option value="3">Open O2</option>
                </b-form-select>
              </b-form-group> -->
              <!-- <b-form-group label="Project" style="color: #28c69f">
              <b-form-select label="Select Project" v-model="model.projectId">              
                  <option value="1">Informatics</option>
                  <option value="2">Oxygen Alliance</option>
                  <option value="3">Open O2</option>
                </b-form-select>
                </b-form-group> -->
              <b-form-group label=" Team Name" style="color: #28c69f">
                <b-form-input type="text" v-model="model.name"></b-form-input>
              </b-form-group>
              <b-form-group label="Coordinator ID" style="color: #28c69f">
                <b-form-input rows="4" v-model="model.coordinatorid" type="number"></b-form-input>
              </b-form-group>
              <!-- <b-form-group label="Project" style="color: #28c69f"> -->
                <!-- <b-form-select>
                  <option v-for="item in records" :key="item.projectId">{{ item.projectId }}</option>
                </b-form-select> -->
                <!-- <b-form-input type="number" v-model="model.projectId"></b-form-input> -->
              <!-- </b-form-group> -->
              <br>
              <div>
                <b-btn type="submit" variant="success">Save Record</b-btn>
              </div>
            </form>
</b-modal>
    </div>
  </template>
  
  <script>
    // import api from '@/ProjectTeamsApiService';
  
    export default {
      props: ['id'],
      data() {
        return {
          // loading: false,
          records: [],
          model: {}
        };
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