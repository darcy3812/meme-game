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
        <div className="mx-auto my-0 max-w-5xl box-border flex flex-col gap-y-12 justify-center items-center">
            <div className="flex p-5 font-boom font-black text-big text-center justify-center bg-cyan-400 bg-clip-text text-transparent">
                Meme Game
            </div>
            <div className="flex flex-col w-main min-w-52 max-w-5xl p-5">
                <input
                    placeholder="Enter your nickname"
                    type="text"
                    className="box-border w-full h-14 mt-0 mx-0 mb-2.5 py-0 pr-0 pl-4 bg-white text-black text-base focus:border-2 focus:border-solid focus:border-red-400 focus:shadow-normal focus:outline-offset-0 focus:outline-none"
                    value={login}
                    onChange={(e) => setLogin(e.target.value)}
                />

                <button
                    className="bg-cyan-400 hover:bg-cyan-600 rounded-main border-none border-black border-2 px-2.5 py-1.5 text-darker text-xl font-normal text-wider leading-none text-center self-end h-14 w-full"
                    onClick={() => postLogin()}
                >
                    Login
                </button>
            </div>
        </div>
    );
};

export default Login;
