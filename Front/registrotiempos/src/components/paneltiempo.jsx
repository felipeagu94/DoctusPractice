import React, { Component } from 'react'
import TablaTiempos from './tablatiempos'
import { FormularioTiemposForm } from './formulariotiempo'
import { Button, Icon } from 'antd';
import { API_URL } from '../config'
import axios from 'axios'
export default class Tiempos extends Component {
    constructor(props) {
        super(props)
        this.state = {
            actividad: this.props.actividad,
            tiempos: [],
            regresar: this.props.regresar
        }
    }
    componentDidMount() {
        this.llenarTiempos()
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
                const tiempos = datos.map(u => { return { key: u.idDetalleActividad, fecha: u.fecha, tiempo: `${u.tiempo} Horas` } })
                this.setState({ tiempos })
            })
    }
    actualizarActividad = async (datosActividad) => {
        console.log(datosActividad)
        await axios({
            method: 'post',
            url: `${API_URL}/Actividad/Actualizar`,
            data: datosActividad,
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
            .then(res => {
                if (res.data.code === 200) {
                    this.llenarTiempos()
                }
            })
    }
    render() {
        const { tiempos, actividad, regresar } = this.state
        return (
            <div>
                <FormularioTiemposForm actionfrom={this.actualizarActividad} actividad={actividad} />
                <TablaTiempos tiempos={tiempos} />
                <Button type="primary" onClick={regresar}><Icon type="left" />Regresar</Button>
            </div>
        )
    }
}