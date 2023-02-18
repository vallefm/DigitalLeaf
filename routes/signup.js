import express from 'express'
import { createUser } from '../models/authentication.js'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    res.sendFile(path.join(__dirname+'/../public/views/signup.html'))
})

router.post('/', async (req, res) => {
    let {firstName, lastName, email, password} = req.body
    console.log(await createUser(firstName, lastName, email, password))
})

export {router as signupRouter}