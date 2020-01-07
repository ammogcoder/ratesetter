import Vue from 'vue'
import App from './App.vue'
require ('bootstrap')
import  'bootstrap/dist/css/bootstrap.css'
import Axios from 'axios'

Vue.config.productionTip = false

Axios.defaults.baseURL = 'https://demoratesetapi.azurewebsites.net/'

new Vue({
  render: h => h(App),
}).$mount('#app')
