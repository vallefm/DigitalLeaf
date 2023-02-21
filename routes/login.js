import express from 'express'
import {login} from '../models/authentication.js'
import path from 'path'
import { fileURLToPath } from 'url'

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
    let result = await login(email, password)
    if (result.status) {
        req.session.user = {}
        req.session.user.id = result.user.id
        req.session.user.email = result.user.email
        req.session.user.firstName = result.user.first_name
        req.session.user.lastName = result.user.last_name
        res.redirect('/home')
    } else {
        console.log(result.status)
    }
})

export {router as loginRouter}