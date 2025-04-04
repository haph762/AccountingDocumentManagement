import axios from "axios";

const API_BASE_URL = "https://localhost:7078/api"; // Thay đổi nếu API chạy cổng khác

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export default api;
