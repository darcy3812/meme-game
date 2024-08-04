import { useState } from "react";

const GameCreateForm = (props) => {
  const [game, setGame] = useState({});
  const create = () => {
    console.log(game);
    console.log(JSON.stringify(game));
    props.connection.invoke("CreateGame", game);
  };

  return (
    <div>
      <h1>Game creation form</h1>
      <div>
        <div>
          <label>Name</label>
          <input
            type="text"
            value={game.name}
            defaultValue={""}
            onChange={(e) =>
              setGame((oldGame) => ({
                ...oldGame,
                gameSettings: {},
                name: e.target.value,
              }))
            }
          />
          <label>MaxPlayers</label>
          <input
            type="number"
            value={game.maxPlayers}
            onChange={(e) =>
              setGame((oldGame) => ({
                ...oldGame,
                gameSettings: {
                  ...oldGame.gameSettings,
                  maxPlayers: parseInt(e.target.value),
                },
              }))
            }
          />
          <label>MaxRounds</label>
          <input
            type="number"
            value={game.maxRounds}
            onChange={(e) =>
              setGame((oldGame) => ({
                ...oldGame,
                gameSettings: {
                  ...oldGame.gameSettings,
                  maxRounds: parseInt(e.target.value),
                },
              }))
            }
          />
          <label>MaxPoints</label>
          <input
            type="number"
            value={game.maxPoints}
            onChange={(e) =>
              setGame((oldGame) => ({
                ...oldGame,
                gameSettings: {
                  ...oldGame.gameSettings,
                  maxPoints: parseInt(e.target.value),
                },
              }))
            }
          />
        </div>
        <button onClick={() => create()}>Create</button>
      </div>
    </div>
  );
};

export default GameCreateForm;
