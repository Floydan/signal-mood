import C from './constants'
import React from 'react'
import { render } from 'react-dom'
import Smileys from './components/Smileys'
import './stylesheets/main.scss'
import { mood } from './store/reducers'

const state = null;

const action = {
    type: C.SAVE_MOOD,
    payload: {
        "mood": 0
    }
}

const nextState = mood(state, action)

console.log(`
    initial state: ${state}
    action: ${JSON.stringify(action)}
    new state: ${JSON.stringify(nextState)}
`)

render(
	<Smileys/>,
  document.getElementById('react-container')
)
