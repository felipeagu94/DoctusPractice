import React, { Component } from 'react'
import TablaActividades from './tablaactividades'
import { FormularioActividadesForm } from './formularioactividad'
import Tiempos from './paneltiempo'
import { API_URL } from '../config'
import axios from 'axios'
export default class Actividades extends Component {
    constructor(props) {
        super(props)
        this.state = {
            usuario: this.props.usuario,
            actividades: [],
            panel: true,
            actividadActiva: 0
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
                const actividades = datos.map(u => { return { key: u.idActividad, acciones: u.idActividad, actividad: u.descripcionActividad, onclic: this.activarPanel } })
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
                if (res.data.code === 200) {
                    this.llenarActividades()
                }
            })
    }
    activarPanel = (event) => {
        const panel = false
        const actividadActiva = event.currentTarget.value
        this.setState({ panel, actividadActiva })
    }
    desactivarPanel = () => this.setState({ panel: true })
    render() {
        const { actividades, usuario, panel, actividadActiva } = this.state
        return (
            <div>
                {panel ? <h1>Actividades</h1> : <h1>Horas</h1>}
                {panel && <FormularioActividadesForm actionfrom={this.guardarActividad} usuario={usuario}/>}
                {panel ? <TablaActividades actividades={actividades}/> : <Tiempos actividad={actividadActiva} regresar={this.desactivarPanel} />}
            </div>
        )
    }
}