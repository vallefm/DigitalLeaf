import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

import { getUserProjects, createProject } from "../models/projects.js";

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/home', async (req, res) => {
    res.render(path.join(__dirname+'/../public/views/home_user'), {loggedIn: req.session.loggedIn, firstName: req.session.user.firstName})
})

router.get('/projects', async (req, res) => {
    let projects = await getUserProjects(req.session.user.id)
    res.render(path.join(__dirname+'/../public/views/projects'), {loggedIn: req.session.loggedIn, firstName: req.session.user.firstName, projects})
})

router.post('/projects/create', async (req, res) => {
    let {projectName, description, dueDate} = req.body
    if(await createProject(projectName, description, dueDate, req.session.user.id)){
        res.status(201).redirect(`/${req.session.user.firstName}/projects`)
    } 
})

export {router as userRouter}