import React, { Component } from 'react'
import { Form, Input, Button } from 'antd';
import '../estilos/login.css'

class FormularioActividades extends Component {
    constructor(props) {
        super(props)
        this.state = {
            usuario: this.props.usuario
        }
    }
    handleSubmit = e => {
        e.preventDefault()
        this.props.form.validateFields((err, values) => {
            if (!err) {
                const datosactividad = { DescripcionActividad: values.descripcion, DetalleActividades: [], IdUsuario: this.state.usuario }
                this.props.actionfrom(datosactividad)
            }
        })
    }
    render() {
        const { getFieldDecorator } = this.props.form;
        return (
            <Form onSubmit={this.handleSubmit} className="login-form">
                <Form.Item>
                    {getFieldDecorator('descripcion', {
                        rules: [{ required: true, message: 'Debe ingresar la descripción para la actividad' }],
                    })(
                        <Input placeholder="Descripción" />,
                    )}
                </Form.Item>
                <Form.Item>
                    <Button type="primary" htmlType="submit" className="login-form-button">
                        Crear Actividad
          </Button>
                    {/* Or <a href="">Registrarse</a> */}
                </Form.Item>
            </Form>
        );
    }
}
export const FormularioActividadesForm = Form.create({ name: 'normal_login' })(FormularioActividades)
