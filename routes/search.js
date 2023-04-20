import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

import { getUserInfo } from '../models/search.js'
import { addProjectMember, getProjectDetails } from '../models/projects.js'

// Router for 'team tab' within a project card
router.get('/:projectId', async (req, res) => {
    let [project] = await getProjectDetails(req.params.projectId)
    res.render(path.join(__dirname + '/../public/views/search'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        project,
    })
})

router.post('/:projectId/searchUsers', async (req, res) => {
    let [project] = await getProjectDetails(req.params.projectId)
    let searchUsers = await getUserInfo(req.body.searchUser)
    res.render(path.join(__dirname + '/../public/views/search'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        searchUsers,
        project,
    })
})

router.get('/:projectId/searchUsers/add/:userId', async (req, res) => {
    let projectId = req.params.projectId
    let userId = req.params.userId
    let result = await addProjectMember(projectId, userId)
    if (result == true) {
        res.redirect(`/project/${projectId}`)
    }
})

export { router as searchRouter }
