import express from 'express'
import { createUser } from '../models/authentication.js'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    res.render(path.join(__dirname+'/../public/views/signup'))
    req.session.signup = null;
})

router.post('/', async (req, res) => {
    let {firstName, lastName, email, password} = req.body
    if(await createUser(firstName, lastName, email, password)){
        req.session.signup = true;
        res.status(201).redirect('../login')
    } else {
        res.status(400).render(path.join(__dirname+'/../public/views/signup'), {fail: true})
    }
})

export {router as signupRouter}