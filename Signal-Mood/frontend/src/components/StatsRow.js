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
                <td className="stats-table__row-title">{weekDay}</td>
                {Object.keys(rating).map((mood, i) => (
                    <td key={i} className="align-center">{rating[mood].length}</td>
                ))}
            </tr>
        )
    }
}

export default StatsRow