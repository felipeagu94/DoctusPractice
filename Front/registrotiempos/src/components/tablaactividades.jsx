import React from 'react'
import { Table } from 'antd';
const columns = [
    {
        title: 'Acciones',
        dataIndex: 'acciones',
        key: 'acciones',
    },
    {
        title: 'Actividad',
        dataIndex: 'actividad',
        key: 'actividad',
    }
];
const TablaActividades = ({ actividades }) => {
    return (
        <Table dataSource={actividades} columns={columns} />
    )
}
export default TablaActividades
