import React from 'react';
import NavMenu from './NavMenu';


export default props => (
    <div>
        <div className="layout_header-wrapper">
            <NavMenu />
        </div>
        <div className="layout_content-wrapper">
            <div className="container content">
            {props.children}
            </div>
        </div>
    </div>
);


