import React, { Component } from 'react'
import TablaActividades from './tablaactividades'
import {FormularioActividadesForm} from './formularioactividad'
import { API_URL } from '../config'
import axios from 'axios'
export default class Actividades extends Component {
    constructor(props) {
        super(props)
        this.state = {
            usuario: this.props.usuario,
            actividades: [],
            panel: true
        }
    }
    componentDidMount() {
        this.llenarActividades()
    }
    llenarActividades = async () => {
        await axios({
            method: 'get',
            url: `${API_URL}/Actividad/Obtener?usuario=${this.state.usuario}`,
            data: [],
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
            .then(res => {
                let datos = res.data.data
                const actividades = datos.map(u => { return { key : u.idActividad ,acciones: 'aca va la url', actividad: u.descripcionActividad } })
                this.setState({ actividades })
            })
    }
    guardarActividad = async (datosActividad) => {
        await axios({
            method: 'post',
            url: `${API_URL}/Actividad/Crear`,
            data: datosActividad,
            headers: { 'Content-Type': 'application/json; charset=utf-8' }
        })
            .then(res => {
                if(res.data.code === 200){
                    const actividades = [...this.state.actividades, {key : Math.random(), acciones: 'aca va la url', actividad: datosActividad.DescripcionActividad}]
                    this.setState({ actividades })
                }
                console.log(res)
            })
    }
    render() {
        const { actividades, usuario, panel } = this.state
        return (
            <div>
                <FormularioActividadesForm actionfrom={this.guardarActividad} usuario={usuario} />
                {panel && <TablaActividades actividades={actividades}/>}
            </div>
        )
    }
}