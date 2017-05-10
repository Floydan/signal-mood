import React from 'react'

class StatsRow extends React.Component {
    constructor(props){
        super(props)
    }
    render(){
        const rating = this.props.rating;
        const weekDay = this.props.weekDay;
        return (
            <tr>
                <td>{weekDay}</td>
                {Object.keys(rating).map((mood, i) => (
                    <td key={i}>{rating[mood].length}</td>
                ))}
            </tr>
        )
    }
}

export default StatsRow