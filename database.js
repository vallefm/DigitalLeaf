import mysql from 'mysql2'
import dotenv from 'dotenv'

// assigns the pool variables to those in the .env file
dotenv.config()

// 'pool' variables for SQL database (uses 'promise' to prevent stalling)
const pool = mysql.createPool({
    host: process.env.MYSQL_HOST,
    user: process.env.MYSQL_USER,
    password: process.env.MYSQL_PASSWORD,
    database: process.env.MYSQL_DATABASE
}).promise()

// function to get users from database (uses 'await' to wait for 'pool' to load in)
async function getUsers() {
    let [result] = await pool.query("SELECT * FROM users")
    return result;
}

export {getUsers}