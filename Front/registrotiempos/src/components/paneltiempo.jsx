import React, { Component } from 'react'
import TablaTiempos from './tablatiempos'
import { API_URL } from '../config'
import axios from 'axios'
export default class Tiempos extends Component {
    constructor(props) {
        super(props)
        this.state = {
            actividad: this.props.actividad,
            tiempos: []
        }
    }
    llenarTiempos = async () => {
        await axios({
            method: 'get',
            url: `${API_URL}/Actividad/ObtenerDetalles?actividad=${this.state.actividad}`,
            data: [],
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
            .then(res => {
                let datos = res.data.data
                const tiempos = datos.map(u => { return { key : u.IdDetalleActividad , fecha: u.fecha, tiempo: `${tiempo} Horas` } })
                this.setState({ tiempos })
            })
    }
    render() {
        const { tiempos } = this.state
        return (
            <div>
                <h1>Espacio Formulario</h1>
                <TablaTiempos tiempos={tiempos} />
            </div>
        )
    }
}