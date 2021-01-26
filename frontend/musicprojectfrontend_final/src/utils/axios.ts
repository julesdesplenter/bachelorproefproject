import axios from 'axios'

const configHeaders = {
    "content-type": "application/json",
    "Accept": "application/json"
  };

axios.defaults.baseURL = 'http://music01bronze.westeurope.cloudapp.azure.com:9000/api/'
axios.defaults.headers.common['Content-Type'] = 'application/json';
axios.defaults.headers.common['Authorization'] = 'Bearer ' + localStorage.getItem('token')