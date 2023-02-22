import express from 'express'
import { createProject } from '../models/projects.js'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    res.render(path.join(__dirname+'/../public/views/create_project'))
    req.session.createProject = null;
})

router.post('/', async (req, res) => {
    let {} = req.body
    if(await createProject(projectName, description, date)){
        req.session.createProject = true;
        res.status(201).redirect('../project')
    } else {
        res.status(400).render(path.join(__dirname+'/public/views/create_project'), {fail: true})
    }
})

export {router as createProjectRouter }