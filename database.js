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

async function createUser(email, password, firstName, lastName) {
    let salt = await bcrypt.genSalt(10)
    let encryptedPass = await bcrypt.hash(password, salt)
    let userId = createUserID()


    await pool.query("SELECT user_id FROM users WHERE user_id = ?", [id])
}

function createUserID() {
    let userId = 'usr'+randomId()
    while (!checkIdExists(userId)){
        userId = 'usr'+randomId()
    }
    return userId
}

async function checkIdExists(id) {
    let exists = false
    let [countData] = await pool.query("SELECT COUNT(*) as count FROM users WHERE user_id = ?", [id])
    let count = countData[0]["count"]
    if (count != 0) {
        return false;
    }
    return true
}

async function checkEmailExists(email) {
    let exists = false
    let [countData] = await pool.query("SELECT COUNT(*) as count FROM users WHERE email = ?", [email])
    let count = countData[0]["count"]
    if (count != 0) {
        return false;
    }
    return true
}

// generic 8-digit random id generator. Prepend relevant 3-letter tag to create complete id (usr for users, tsk for task, etc.) 
function randomId() {
    let id = Math.round(Math.random()*10000000)
    return id.toString();
}

// exports functions for import in other files
export {getUsers, getUser, createUser, checkIdExists}
