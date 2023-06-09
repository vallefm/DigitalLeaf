/** model containing SQL logic for routes:
 * {@link routes/login.js}
 * {@link routes/signup.js}
 **/

import { conn } from '../connection.js'
import bcrypt from 'bcryptjs'



async function login(email, password){
    const SALT =   await bcrypt.genSalt(10)
    let result = {}
    if (await checkEmailExists(email) && await checkPasswordCorrect(email, password)) {
        result.status = true;
        result.user = await getUserInfo(email)
        return result
    } else {
        result.status = false;
        return result
    }
}

async function checkEmailExists(email) {
    
    let [countEmail] = await conn.query("SELECT COUNT(*) as count FROM users WHERE email = ?", [email])
    let count = countEmail[0]["count"]
    if (count <= 0) {
        return false
    }
    return true
}

async function checkPasswordCorrect(email, password) {
    let [[result]] = await conn.query("SELECT password FROM users WHERE email = ? LIMIT 1", [email])
    if (await bcrypt.compare(password, result.password)) {
        return true
    }
    return false
}

async function getUserInfo(email) {
    let [[result]] = await conn.query("SELECT id, first_name, last_name, email from users WHERE email = ?", [email])
    return result
}

async function createUser(firstName, lastName, email, password) {
    const SALT =   await bcrypt.genSalt(10)
    let encryptedPass = await bcrypt.hash(password, SALT)
    let newId = createUserID()
    try {  
        await conn.query("INSERT INTO users VALUES (?, ?, ?, ?, ?, NOW())", [newId, firstName, lastName, email, encryptedPass])
        return true
    } catch (error) {
        console.log(error);
        return false
    }
}

function createUserID() {
    let userId = 'usr'+randomId()
    while (!checkIdExists(userId)){
        userId = 'usr'+randomId()
    }
    return userId
}

async function checkIdExists(id) {
    let [countData] = await conn.query("SELECT COUNT(*) as count FROM users WHERE id = ?", [id])
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


export {login, createUser}