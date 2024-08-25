import axiosBase from "./axiosBase";

const authApi = {
  login: async (login) => await axiosBase.post("api/login", { name: login }),
  me: async () => await axiosBase.get("api/me"),
};

export default authApi;
