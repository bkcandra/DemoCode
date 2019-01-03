import React, {Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/RaceData';


class FetchData extends Component {
  

    componentWillMount() {
        // This method runs when the component is first added to the page
        this.data = this.props.requestRaceData();
    }

    componentDidMount() {
        // update every 5 minutes
        this.interval = setInterval(() => {
            this.props.requestRaceData();
        }, 300000);
    }

    render() {
        return (
            <div>
                <div class="ntj_container">
                    <div class="ntj_wrapper--multi">
                        <div class="ntj_wrapper-header">
                            <a href="/racing-betting/today">Next to Jump</a>
                        </div>
                        <div class="ntj_filters">
                            <button class="ntj_filter-item ntj_filter-item--is-active" type="button">all</button>
                            <button class="ntj_filter-item button img-horserace" type="button">
                            </button>
                            <button class="ntj_filter-item button img-greyhound" type="button">
                            </button>
                            <button class="ntj_filter-item button img-harness" type="button">
                            </button>
                        </div>
                    </div>
                    <div class="ntj_events-list">
                        {renderForecastsTable(this.props)}
                    </div>
                </div>
            </div>
        );
    }
}

class Countdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            days: 0,
            hours: 0,
            min: 0,
            sec: 0,
        }
    }

    componentWillMount() {
            const date = this.calculateCountdown(this.props.endDate);
            date ? this.setState(date) : this.stop();
    }
    componentDidMount() {
        // update every second
        this.interval = setInterval(() => {
            const date = this.calculateCountdown(this.props.endDate);
            date ? this.setState(date) : this.stop();
        }, 1000);
    }

    componentWillUnmount() {
        this.stop();
    }

    calculateCountdown(endDate) {
        let diff = (Date.parse(endDate) - Date.parse(new Date())) / 1000;
        diff = diff + (55 * 86400); // their api is not updated. lets modify for test purposes
        if (diff <= 0) return false;

        const timeLeft = {          
            days: 0,
            hours: 0,
            min: 0,
            sec: 0,
            millisec: 0,
            class: ""
        };
        if (diff <= 60 * 5) {
            timeLeft.class = "countdown-imminent";
        }

        // calculate time difference between now and expected date
        if (diff >= 86400) { // 24 * 60 * 50
            timeLeft.days = Math.floor(diff / 86400);
            diff -= timeLeft.days * 86400;
        }
        if (diff >= 3600) { // 60 * 60
            timeLeft.hours = Math.floor(diff / 3600);
            diff -= timeLeft.hours * 3600;
        }
        if (diff >= 60) {
            timeLeft.min = Math.floor(diff / 60);
            diff -= timeLeft.min * 60;
        }
        timeLeft.sec = diff;
        return timeLeft;
    }

    stop() {
        clearInterval(this.interval);
    }

    addLeadingZeros(value) {
        value = String(value);
        while (value.length < 2) {
            value = '0' + value;
        }
        return value;
    }

    render() {
        const countDown = this.state;
        return <span className={"countdown " + countDown.class}>
            {countDown.days ? this.addLeadingZeros(countDown.days) + "d " : ""} {countDown.hours ? this.addLeadingZeros(countDown.hours) + "h " : ""} {countDown.min ? this.addLeadingZeros(countDown.min) + "m " : ""} {this.addLeadingZeros(countDown.sec) + "s"}
            </span>
    }


}

function renderForecastsTable(props) {
    return (
        <div>
            {
                props.raceData.map(item => 
                    <div key={item.EventID} className="ntj_event">
                        <a href="/racing-betting/greyhound-racing/gawler/20181028/race-12-1101747-31639244" className="ntj_event-container">
                            <div className={"ntj_eventImage img img-"+getImage(item.EventType.EventTypeID)}>
                                
                            </div>
                            <div className="ntj_eventContent_container">
                                <div className="ntj_eventContent">
                                    <div className="ntj_eventContent_venue">
                                        {item.Venue.Venue}
                                    </div>
                                    <div className="ntj_eventContent_race">
                                        Race {item.RaceNumber}
                                    </div>
                                </div>
                                <div className="ntj_eventTimer">
                                        <Countdown endDate={item.AdvertisedStartTime} />                                    
                                </div>
                            </div>
                        </a>
                    </div>
                )}
        </div>
    );
}

function getImage(eventTypeId) {
    if (eventTypeId === 1)
        return 'horserace';
    else if (eventTypeId === 2)
        return "harness";
    else if (eventTypeId === 3)
        return "greyhound";
    
}



export default connect(
    state => state.racingData,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchData);