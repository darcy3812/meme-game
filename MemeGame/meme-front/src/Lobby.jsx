import { getSignalRConnection } from "./signalr";
import { useEffect, useState } from "react";
import GameCreateForm from "./GameCreateForm";
import { HubConnectionState } from "@microsoft/signalr";

const Lobby = () => {
    const [connection, setConnection] = useState();
    const [games, setGames] = useState([]);

    useEffect(() => {
        connect();
    }, []);

    const connect = async () => {
        const conn = await getSignalRConnection("/hub/lobby");

        conn.on("GameListNotification", (notification) =>
            setGames(notification.games)
        );

        conn.on("GameCreatedNotification", (notification) =>
            setGames((oldgames) => [...oldgames, notification])
        );

        if (conn.state == HubConnectionState.Connected) {
            setConnection(conn);
        }
    };

    const joinGame = (id) => {
        connection.invoke("JoinGame", id);
    };

    if (!connection) {
        return <h1>Connecting</h1>;
    }

    return (
        <div>
            <div
                style={{
                    display: "flex",
                    flexDirection: "column",
                    alignItems: "center",
                }}
            >
                <h1>Connected123123</h1>
                <GameCreateForm connection={connection}></GameCreateForm>
                <h1>Games:</h1>
                <ul>
                    {games.map((game) => (
                        <li key={game.name}>
                            <div
                                style={{
                                    display: "flex",
                                    flexDirection: "row",
                                    gap: "10px",
                                }}
                            >
                                <p>Name: {game.name}</p>
                                <p>UsersCount: {game.usersCount}</p>
                                <button onClick={() => joinGame(game.id)}>
                                    Join
                                </button>
                            </div>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default Lobby;
