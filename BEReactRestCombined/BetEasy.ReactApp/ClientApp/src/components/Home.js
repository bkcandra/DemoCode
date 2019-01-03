import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
    <div className="">
        <h1>Hello, world!</h1>
        
        <p>Simply navigate to racing to get start:</p>
        <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands</p>
    </div>
);

export default connect()(Home);
