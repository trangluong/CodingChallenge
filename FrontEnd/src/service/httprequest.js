import axios from "axios";


const API_URL = process.env.VUE_APP_BASE_URL;
console.log(API_URL)

export default axios.create({
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});