import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { createSignalRContext } from 'react-signalr';
import Lobby from './Lobby';
import Login from './Login';

function App() {
  const [count, setCount] = useState(0);
  const [isLogged, setIsLogged] = useState(false);

  if (isLogged) {
    return <Lobby />
  }
  return <Login setIsLogged={setIsLogged} />
}

export default App
