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

        const connection = $.hubConnection('/signalr/hubs');
        const moodHubProxy = connection.createHubProxy('moodHub');
        var self = this;

        moodHubProxy.on("addMessage", function (message) {
            self.getStats();
        });

        connection.start().done(function () {
           
        });
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
                        <div className="container">
                            <h1>Signal Mood</h1>
                            <div className="row">
                                <div className="col-xs-12 col-md-6">
                                    <div className="panel panel-info">
                                        <div className="panel-heading">Stats</div>
                                        <table className="table stats-table">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th><div className="stats-smiley">😀</div></th>
                                                    <th><div className="stats-smiley">🙂</div></th>
                                                    <th><div className="stats-smiley">🙁</div></th>
                                                    <th><div className="stats-smiley">😡</div></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                    {Object.keys(ratings).map((weekDay, i) => (
                                                        <StatsRow key={i} rating={ratings[weekDay].ratings} weekDay={weekDay} />
                                                    ))}
                                
                                            </tbody>
                                       </table>
                                   </div>
                                </div>
                           </div>
                       </div>
                  )}
            </div>
        )
     }
}

export default Stats