import mysql from 'mysql2'
import dotenv from 'dotenv'
import bcrypt from 'bcryptjs'

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
    let [result] = await pool.query("SELECT user_id FROM users")
    return result
}

async function getUser(id) {
    let [result] = await pool.query("SELECT user_id FROM users WHERE user_id = ?", [id])
    return result;
}

async function createUser(email, password) {
    salt = await bcrypt.genSalt(10)
    encryptedPass = await bcrypt.hash(password, salt)

    await pool.query("SELECT user_id FROM users WHERE user_id = ?", [id])
}

async function checkIdExists(id) {
    let exists = false
    let count = await pool.query("SELECT user_id FROM users WHERE user_id = ?", [id])
}

function randomId() {
    let id = Math.round(Math.random()*100000000)
    return id
}

export {getUsers, getUser, createUser}