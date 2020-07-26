'use strict';
const { Sequelize } = require('sequelize');
const sequelize = new Sequelize({
	dialect: 'sqlite',
	storage: './storage/database.sqlite'
});

const Tarea = sequelize.define('Tarea', {
	id: {
		primaryKey: true,
		type: Sequelize.BIGINT,
		autoIncrement: true,
	},
	titulo: {
		type: Sequelize.STRING
	},
	detalle: {
		type: Sequelize.STRING
	},
	valor: {
		type: Sequelize.STRING
	},
	fechaentrega: {
		type: Sequelize.STRING
	}
});

Tarea.sync();
module.exports = Tarea;