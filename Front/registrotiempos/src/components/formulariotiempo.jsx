import React, { Component } from 'react'
import { Form, Input, Button } from 'antd';
import '../estilos/login.css'

class FormularioTiempos extends Component {
    constructor(props) {
        super(props)
        this.state = {
            actividad: this.props.actividad
        }
    }
    handleSubmit = e => {
        e.preventDefault()
        this.props.form.validateFields((err, values) => {
            if (!err) {
                const datosactividad = { IdActividad: this.state.actividad, DetalleActividades: [{ fecha: values.fecha, tiempo: values.horas }] }
                this.props.actionfrom(datosactividad)
            }
        })
    }
    render() {
        const { getFieldDecorator } = this.props.form;
        return (
            <Form onSubmit={this.handleSubmit} className="tiempos-form">
                <Form.Item>
                    {getFieldDecorator('fecha', {
                        rules: [{ required: true, message: 'Debe ingresar la fecha para la actividad' }],
                    })(
                        <Input type="date" placeholder="Fecha" />,
                    )}
                </Form.Item>
                <Form.Item>
                    {getFieldDecorator('horas', {
                        rules: [{ required: true, message: 'Debe ingresar la cantidad de horas para la actividad' }],
                    })(
                        <Input type="number" max="8" min="1" placeholder="Horas" />,
                    )}
                </Form.Item>
                <Form.Item>
                    <Button type="primary" htmlType="submit" className="login-form-button">
                        Agregar
                    </Button>
                    {/* Or <a href="">Registrarse</a> */}
                </Form.Item>
            </Form>
        );
    }
}
export const FormularioTiemposForm = Form.create({ name: 'normal_login' })(FormularioTiempos)
