import { useForm } from "react-hook-form";
import authApi from "./api/auth";

const Login = (props) => {
    const postLogin = async (form) => {
        console.log(form);
        const res = await authApi.login(form.login);
        if (res.status === 200) {
            props.setIsLogged(true);
        }
    };
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();
    return (
        <div className="mx-auto my-0 max-w-5xl box-border flex flex-col gap-y-12 justify-center items-center">
            <div className="flex p-5 font-boom font-black text-big text-center justify-center bg-cyan-400 bg-clip-text text-transparent cursor-default">
                Meme Game
            </div>
            <div className="flex flex-col w-main min-w-52 max-w-5xl p-5 gap-y-3.5">
                <input
                    placeholder="Enter your nickname"
                    type="text"
                    className={`box-border rounded-main w-full h-14 mt-0 mx-0 mb-2.5 py-0 pr-0 pl-4 bg-white text-black text-base focus:outline-none ${
                        errors.login ? "border-2 border-red-400" : ""
                    }`}
                    {...register("login", {
                        required: true,
                        validate: (value) => !!value.trim(),
                    })}
                />

                <button
                    className="bg-cyan-400 hover:bg-cyan-600 rounded-main border-none border-black border-2 px-2.5 py-1.5 text-darker text-xl font-normal text-wider leading-none text-center self-end h-14 w-full active:scale-99"
                    onClick={handleSubmit(postLogin)}
                >
                    Login
                </button>
            </div>
        </div>
    );
};

export default Login;
