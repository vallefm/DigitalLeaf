import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

import { getUserProjects } from "../models/projects.js";

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

<<<<<<< HEAD
router.get('/', (req, res) => {
    res.render(path.join(__dirname+'/../public/views/home_user'))
=======
router.get('/', async (req, res) => {
    
    let projects = await getUserProjects(req.session.user.id)
    res.render(path.join(__dirname+'/../public/views/home_user'), {loggedIn: req.session.loggedIn, firstName: req.session.user.firstName, projects})
>>>>>>> origin
})

export {router as homeRouter}