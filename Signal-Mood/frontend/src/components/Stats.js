import React from 'react'
import axios from 'axios'
import StatsRow from './StatsRow'

class Stats extends React.Component {
    constructor(props){
        super(props)
        this.state = {
            weekDays: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
            data: [],
            ratings: null
        }
    }
    componentDidMount(){
        this.getStats();
    }
    setWeeKDaysData(data){
        var ratings = {};

        for(var i = 0; i < this.state.weekDays.length; i++){
            ratings[this.state.weekDays[i]] = {
                ratings: {
                    0: [],
                    1: [],
                    2: [],
                    3: []
                }
            };
        }

        for(var i = 0; i < data.length; i++){
            var dayOfWeek = data[i].DayOfWeek;
            var rating = data[i].Rating;

            ratings[dayOfWeek].ratings[rating].push(data[i]);
        }
        this.setState({ratings: ratings});
    }
    getStats(){
        var self = this;
        axios.post('/api/mood/stats')
            .then(function(response){
                self.setState({data: response.data});
                self.setWeeKDaysData(response.data);
            })
    }
    render(){
        const weekDays = this.state.weekDays
        const ratings = this.state.ratings;
        return (
            <div>
                {ratings === null ? (
                    null
                    ) : (
                        <table>
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>😀</th>
                                    <th>🙂</th>
                                    <th>🙁</th>
                                    <th>😡</th>
                                </tr>
                            </thead>
                            <tbody>
                                    {Object.keys(ratings).map((weekDay, i) => (
                                        <StatsRow key={i} rating={ratings[weekDay].ratings} weekDay={weekDay} />
                                    ))}
                                
                            </tbody>
                       </table>
                  )}
            </div>
        )
     }
}

export default Stats