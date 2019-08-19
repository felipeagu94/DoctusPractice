import React from 'react'
import { Table } from 'antd';
const columns = [
    {
        title: 'Fecha',
        dataIndex: 'fecha',
        key: 'fecha',
    },
    {
        title: 'Tiempo',
        dataIndex: 'tiempo',
        key: 'tiempo',
    }
];
const TablaTiempos = ({ tiempos }) => {
    return (
        <Table dataSource={tiempos} columns={columns} />
    )
}
export default TablaTiempos