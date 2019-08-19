import React, { Component } from 'react'
import { Form, Icon, Input, Button } from 'antd';
import '../estilos/login.css'

class Registro extends Component {
  handleSubmit = e => {
    e.preventDefault()
    this.props.form.validateFields((err, values) => {
      if (!err) {
          const datosuser = {NombreUsuario : values.usuario, Password : values.password}
          this.props.actionLogin(datosuser)
      }
    })
  }
  render() {
    const { getFieldDecorator } = this.props.form;
    return (
      <Form onSubmit={this.handleSubmit} className="login-form">
        <h1>Registro</h1>
        <Form.Item>
          {getFieldDecorator('usuario', {
            rules: [{ required: true, message: 'Debe ingresar un usuario' }],
          })(
            <Input
              prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
              placeholder="Usuario"
            />,
          )}
        </Form.Item>
        <Form.Item>
          {getFieldDecorator('password', {
            rules: [{ required: true, message: 'Debe ingresa la contraseña' }],
          })(
            <Input
              prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
              type="password"
              placeholder="Contraseña"
            />,
          )}
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit" className="login-form-button">
            Registrar
          </Button>
        </Form.Item>
      </Form>
    );
  }
}
export const RegistroForm = Form.create({ name: 'normal_login' })(Registro)
