import React, { Component } from 'react'
import { WrappedNormalLoginForm } from './login'

export default class Inicio extends Component {
    state = {
        user: ''
    }
    render() {
        const { user } = this.state
        return (
            <div className="container">
                {!user ? <WrappedNormalLoginForm /> : <h1>User on!</h1>}
            </div>
        )
    }
}