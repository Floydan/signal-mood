import C from './constants'
import React from 'react'
import { render } from 'react-dom'
import Smileys from './components/Smileys'
import './stylesheets/main.scss'

render(
	<Smileys/>,
  document.getElementById('react-container')
)
