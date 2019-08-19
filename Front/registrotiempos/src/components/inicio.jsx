import React, { Component } from 'react'
import { WrappedNormalLoginForm } from './login'
import Actividades from './actividades'
import { API_URL } from '../config'
import 'antd/dist/antd.css';
import axios from 'axios'

export default class Inicio extends Component {
    state = {
        usuario: '',
        idUsuario: ''
    }
    validarLogin = async (user) => {
        await axios({
            method: 'post',
            url: `${API_URL}/Usuario/login`,
            data: user,
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
        .then(res => {
            const usuario = res.data.data.message === 1 ? user.NombreUsuario : ''
            this.ObtenerIdUsuario(usuario).then( aw =>  this.setState({ usuario }))
        })
    }
    ObtenerIdUsuario = async (user) =>{
        await axios({
            method: 'get',
            url: `${API_URL}/Usuario/Obtener?usuario=${user}`,
            data: [],
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
        .then(res => {
            const idUsuario = res.data.data
            this.setState({ idUsuario })
        })
    }
    render() {
        const { usuario, idUsuario } = this.state
        return (
            <div className="container">
                {!usuario ? <WrappedNormalLoginForm actionLogin={this.validarLogin}/> : <Actividades usuario={idUsuario}/>}
            </div>
        )
    }
}