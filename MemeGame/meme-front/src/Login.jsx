import { useState } from "react"

const Login = (props) => {
    const [login, setLogin] = useState("");
    const postLogin = () => {
        fetch("api/login", {
            method: "POST",
            body: JSON.stringify({ name: login }),
            headers: {
                "Content-Type": "application/json",
            },
        }).then(r => {
            //props.setIsLogged(true)
            fetch("api/Games", {
                method: "POST",
                body: JSON.stringify({
                    name: "string",
                    gameSettings: {
                        maxPlayers: 0,
                        secondsToAnswer: 0,
                        endGameCondition: 0,
                        maxRounds: 10,
                        maxPoints: 10
                    }
                }),                
                headers: {
                    "Content-Type": "application/json",
                },
            }).then(r => props.setIsLogged(true))
        })
    }
    return <div>
        <input type="text" value={login} onChange={(e) => setLogin(e.target.value)} />
        <button onClick={() => postLogin()}>Login</button>
    </div>
}

export default Login;