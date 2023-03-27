import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

import { createSchedule } from "../../models/schedule";


const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    res.render(path.join(__dirname+'/../public/views/schedule'), {loggedIn: req.session.loggedIn, firstName: req.session.user.firstName})
})

export {router as scheduleRouter}