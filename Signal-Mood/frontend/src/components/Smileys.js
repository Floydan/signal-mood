import React from 'react'
import axios from 'axios'

class Smileys extends React.Component {
    constructor(props){ 
        super(props)
        //this.handleClick = this.handleClick.bind(this)
    }
    handleClick(mood, e){
        e.preventDefault();

        axios.post('http://localhost:55663/api/mood/save/' + mood);

        console.log(mood);
        return false;
    }
    render(){
        return (
            <div className="smileys">
                <div className="smileys__smiley smileys__smiley--very-happy">
                    <a href="#" onClick={this.handleClick.bind(this, 0)}>😀</a>
                </div>
                <div className="smileys__smiley smileys__smiley--happy">
                    <a href="#" onClick={this.handleClick.bind(this, 1)}>🙂</a>
                </div>
                <div className="smileys__smiley smileys__smiley--unhappy">
                    <a href="#" onClick={this.handleClick.bind(this, 2)}>🙁</a>
                </div>
                <div className="smileys__smiley smileys__smiley--very-unhappy">
                    <a href="#" onClick={this.handleClick.bind(this, 3)}>😡</a>
                </div>
            </div>
        )
    }
}

export default Smileys