import React from 'react'
import { Table, Button } from 'antd';
const columns = [
    {
        title: 'Acciones',
        dataIndex: 'acciones',
        key: 'acciones',
        render: (text, record) => (
            <span>
              <Button type="link" onClick={record.onclic} value={record.acciones}>Agregar Horas</Button>
            </span>
          )
    },
    {
        title: 'Actividad',
        dataIndex: 'actividad',
        key: 'actividad'
    }
];
const TablaActividades = ({ actividades }) => {
    return (
        <Table dataSource={actividades} columns={columns} />
    )
}
export default TablaActividades
