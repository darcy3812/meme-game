import axios from "axios";

const authApi = {
  login: async (login) => await axios.post("api/login", { name: login }),
  me: async () => await axios.get("api/me"),
};

export default authApi;
