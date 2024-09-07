import { useEffect, useState } from "react";
import Lobby from "./Lobby";
import Login from "./Login";
import authApi from "./api/auth";

function App() {
    const [isLogged, setIsLogged] = useState(false);
    useEffect(() => {
        checkAuth();
    }, []);

    const checkAuth = async () => {
        const res = await authApi.me();
        if (res.status === 200) {
            setIsLogged(true);
            return;
        }

        console.log("Not authed");
    };

    if (isLogged) {
        return <Lobby />;
    }
    return <Login setIsLogged={setIsLogged} />;
}

export default App;
