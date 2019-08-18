import React, { Component } from 'react'
import { WrappedNormalLoginForm } from './login'
import { API_URL } from '../config';
import axios from 'axios';

export default class Inicio extends Component {
    state = {
        usuario: ''
    }
    validarLogin = async (user) => {
        console.log(user)
        await axios({
            method: 'post',
            url: `${API_URL}/Usuario/login`,
            data: user,
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
        .then(res => {
            const usuario = res.data.data.message === 1 ? user.NombreUsuario : ''
            this.setState({ usuario })
            console.log(this.state.usuario)
        })
    }
    render() {
        const { usuario } = this.state
        return (
            <div className="container">
                {!usuario ? <WrappedNormalLoginForm actionLogin={this.validarLogin}/> : <h1>User on!</h1>}
            </div>
        )
    }
}