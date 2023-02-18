import mysql from 'mysql2'
import dotenv from 'dotenv'

// assigns the connection pool variables to those in the .env file
dotenv.config()

// create connection 'pool' for SQL database (uses 'promise' to prevent stalling)
const conn = mysql.createPool({
    host: process.env.MYSQL_HOST,
    user: process.env.MYSQL_USER,
    password: process.env.MYSQL_PASSWORD,
    database: process.env.MYSQL_DATABASE
}).promise()

// export 
export {conn}