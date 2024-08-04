import { useState } from "react";

const Login = (props) => {
  const [login, setLogin] = useState("");
  const postLogin = async () => {
    const res = await fetch("api/login", {
      method: "POST",
      body: JSON.stringify({ name: login }),
      headers: {
        "Content-Type": "application/json",
      },
    });
    console.log(res.status);
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
