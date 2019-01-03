import React from 'react';
import { Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export default props => (
    <Navbar>
        <Navbar.Header >
            <Navbar.Brand>
                <a href="/">
                    <img src="../Content/images/BetEasy.png" alt="homeLogo" />
                </a>
            </Navbar.Brand>
        </Navbar.Header>
        <Nav>
            <LinkContainer to={'/nexttojump'}>
                <NavItem>
                    <div class="nav_glyph">
                        <span class="cb-icon">
                            <img src="../Content/images/icon-racing.png" alt="racing"></img>
                        </span>
                    </div>
                    Racing
              </NavItem>
            </LinkContainer>
                <NavItem href="/race">
                    <div class="nav_glyph">
                        <span class="cb-icon">
                            <img src="../Content/images/icon-racing.png" alt="racing"></img>
                        </span>
                    </div>
                    Horse Price
              </NavItem>
        </Nav>
    </Navbar>
);


