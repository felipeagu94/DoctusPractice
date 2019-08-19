import React, { Component } from 'react'
import { WrappedNormalLoginForm } from './login'
import Actividades from './actividades'
import { RegistroForm } from './registro'
import { API_URL } from '../config'
import 'antd/dist/antd.css';
import axios from 'axios'
import { Row, Col } from 'antd';

export default class Inicio extends Component {
    state = {
        usuario: '',
        idUsuario: '',
        panel: true
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
                this.ObtenerIdUsuario(usuario).then(aw => this.setState({ usuario }))
            })
    }
    crearUsuario = async (user) => {
        await axios({
            method: 'post',
            url: `${API_URL}/Usuario/Crear`,
            data: user,
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
            .then(res => {
                const usuario = res.data.data.message === 0 ? user.NombreUsuario : ''
                this.ObtenerIdUsuario(usuario).then(aw => {
                    this.setState({ usuario })
                    this.setState({ panel: true })
                })
            })
    }
    ObtenerIdUsuario = async (user) => {
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
    activarRegistro = () => this.setState({ panel: false })
    render() {
        const { usuario, idUsuario, panel } = this.state
        return (
            <div className="container">
                <Row type="flex" justify="center" align="top">
                    {!panel ? <Col span={10}><RegistroForm actionLogin={this.crearUsuario} /></Col> 
                       : !usuario ? <Col span={10}><WrappedNormalLoginForm actionLogin={this.validarLogin} signUp={this.activarRegistro}/></Col> 
                        : <Col span={18}><Actividades usuario={idUsuario} /></Col>}
                </Row>
            </div>
        )
    }
}