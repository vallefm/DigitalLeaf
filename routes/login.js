/** SQL queries handled in
 * {@link ../models/authentication}
 */

import express from 'express'
import {login} from '../models/authentication.js'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    if (req.session.signup){
        req.session.signup = false
        res.status(201).render(path.join(__dirname+'/../public/views/login'),{signup: true})
    }
    res.status(200).render(path.join(__dirname+'/../public/views/login'),{signup: req.session.signup})
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
        req.session.loggedIn = true;
        res.redirect(`/${req.session.user.firstName}/home`)
    } else {
        res.status(400).render(path.join(__dirname+'/../public/views/login'),{signup: req.session.signup, fail: true})
    }
})

export {router as loginRouter}