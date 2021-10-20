function Button(props) {
	//const [counter, setCounter] = useState(0);
	return <button onClick={props.onClickFunction}>
    42
  </button>;
}

function Display(props){
  return (
    <div>{props.message}</div>
  )
}

function App() {
  const [text, setText] = useState("Orginal-text")
  const changeText = () => setText("Ny text")
  return (
    <div>
      <Button onClickFunction= {changeText}/>
      <Display message = {text}/>
    </div>
  )
}

ReactDOM.render(
  <App />,
  document.getElementById('mountNode'),
);
