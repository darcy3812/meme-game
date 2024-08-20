import { useState } from "react";
import authApi from "./api/auth";

const Login = (props) => {
  const [login, setLogin] = useState("");
  const postLogin = async () => {
    const res = await authApi.login(login);
    if (res.status === 200) {
      props.setIsLogged(true);
    }
  };
  return (
    <div>
      <input
        type="text"
        value={login}
        onChange={(e) => setLogin(e.target.value)}
      />
      <button onClick={() => postLogin()}>Login</button>
    </div>
  );
};

export default Login;
