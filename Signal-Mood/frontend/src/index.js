import C from './constants'
import React from 'react'
import { render } from 'react-dom'
import { HashRouter as Router, Route } from 'react-router-dom'; 
import Smileys from './components/Smileys'
import Stats from './components/Stats'
import './stylesheets/main.scss'

render(
  <Router>
      <div>
        <Route exact path="/" component={Smileys}/>
        <Route path="/stats" component={Stats}/>
      </div>
  </Router>,
  document.getElementById('react-container')
)