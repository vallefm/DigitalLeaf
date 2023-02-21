import express from 'express'
import {login} from '../models/authentication.js'
import path from 'path'
import { fileURLToPath } from 'url'
import e from 'express'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    res.render(path.join(__dirname+'/../public/views/login'))
    if (req.session.signup) {
        console.log("Account created.");
    } 
})

router.post('/', async (req, res) => {
    let {email, password} = req.body
    console.log(await login(email, password));
})

export {router as loginRouter}