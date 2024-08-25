import { useState } from "react";
import "./Login.css";

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
        <div className="login-container">
            <div className="logo-box">Meme Game</div>
            <div className="login-box">
                <input
                    placeholder="Enter your nickname"
                    type="text"
                    className="login-input"
                    value={login}
                    onChange={(e) => setLogin(e.target.value)}
                />

                <button className="login-button" onClick={() => postLogin()}>
                    Login
                </button>
            </div>
        </div>
    );
};

export default Login;
