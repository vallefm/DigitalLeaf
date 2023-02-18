import express from 'express'
import {login} from '../models/authentication.js'
import session from 'express-session'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    res.sendFile(path.join(__dirname+'/../public/views/login.html'))
})

router.post('/', async (req, res) => {
    let {email, password} = req.body
    console.log(await login(email, password));
})

export {router as loginRouter}