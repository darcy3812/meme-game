import { createSignalRContext } from "react-signalr";
import { getSignalRConnection } from "./signalr";

const Lobby = () => {

    const test = () => getSignalRConnection("https://localhost:5173/hub/gameHub").then(conn => conn.invoke("Test"));
    return <div>

        <button onClick={() => test()}>test</button>
    </div>

}

export default Lobby;