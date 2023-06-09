import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'
import {
    getProjectDetails,
    deleteProject,
    getProjectUpdates,
    getUpdate,
    createProjectUpdate,
    deleteUpdate,
    getProjectTasks,
    createTask,
    getTask,
    deleteTask,
    setTaskStatus,
    addSubtask,
    getSubtasks,
    getProjectMembers,
} from '../models/projects.js'
import { log } from 'console'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

// Project
router.get('/:id', async (req, res) => {
    let [project] = await getProjectDetails(req.params.id)
    let updates = await getProjectUpdates(req.params.id)
    let members = await getProjectMembers(req.params.id)
    let user = req.session.user
    res.render(path.join(__dirname + '/../public/views/project'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        user,
        project,
        updates,
        members,
        context: 'project',
    })
})

// Delete project
router.get('/:id/delete', async (req, res) => {
    let [project] = await getProjectDetails(req.params.id)
    let user = req.session.user
    if (user.id == project.creator_id) {
        if (await deleteProject(project.id)) {
            res.status(410).redirect(`/${user.firstName}/projects`)
        } else {
            res.status(404).redirect(`/${user.firstName}/projects`)
        }
    } else {
        res.status(401).redirect(`/${user.firstName}/projects`)
    }
})

// Updates
router.post('/:id/update', async (req, res) => {
    let { header, content } = req.body
    if (await createProjectUpdate(req.params.id, req.session.user.id, header, content)) {
        res.status(201).redirect(`/project/${req.params.id}`)
    }
})

router.get('/:id/update/:updateId/delete', async (req, res) => {
    let [update] = await getUpdate(req.params.updateId)
    let user = req.session.user
    if (user.id == update.user_id) {
        if (await deleteUpdate(update.id)) {
            res.status(410).redirect(`/project/${req.params.id}`)
        } else {
            res.status(404).redirect(`/project/${req.params.id}`)
        }
    } else {
        res.status(401).redirect(`/project/${req.params.id}`)
    }
})

router.get('/:id/members', async (req, res) => {
    let [project] = await getProjectDetails(req.params.id)
    let updates = await getProjectUpdates(req.params.id)
    let members = await getProjectMembers(req.params.id)
    let user = req.session.user
    res.render(path.join(__dirname + '/../public/views/project'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        user,
        project,
        updates,
        members,
        context: 'members',
    })
})

// Tasks
router.get('/:id/tasks', async (req, res) => {
    let [project] = await getProjectDetails(req.params.id)
    let tasks = await getProjectTasks(req.params.id)
    let user = req.session.user
    res.render(path.join(__dirname + '/../public/views/tasks'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        project,
        user,
        tasks,
        context: 'project',
    })
})

// create task
router.post('/:id/tasks', async (req, res) => {
    let { title, details, dueDate } = req.body
    if (await createTask(title, details, dueDate, req.session.user.id, req.params.id)) {
        res.status(201).redirect(`/project/${req.params.id}/tasks`)
    }
})

// view task details
router.get('/:id/tasks/:taskid', async (req, res) => {
    let [project] = await getProjectDetails(req.params.id)
    let tasks = await getProjectTasks(req.params.id)
    let [task] = await getTask(req.params.taskid)
    let subtasks = await getSubtasks(req.params.taskid)
    let user = req.session.user
    res.render(path.join(__dirname + '/../public/views/tasks'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        project,
        user,
        tasks,
        task,
        subtasks,
        context: 'task',
    })
})

// mark task as in progress
router.get('/:id/tasks/:taskid/start', async (req, res) => {
    if (await setTaskStatus(req.params.taskid, 'in progress')) {
        res.status(201).redirect(`/project/${req.params.id}/tasks/${req.params.taskid}`)
    } else {
        res.status(401).redirect(`/project/${req.params.id}/tasks`)
    }
})

// mark task as new
router.get('/:id/tasks/:taskid/reset', async (req, res) => {
    if (await setTaskStatus(req.params.taskid, 'new')) {
        res.status(201).redirect(`/project/${req.params.id}/tasks/${req.params.taskid}`)
    } else {
        res.status(401).redirect(`/project/${req.params.id}/tasks`)
    }
})

// mark task as complete
router.get('/:id/tasks/:taskid/complete', async (req, res) => {
    if (await setTaskStatus(req.params.taskid, 'complete')) {
        res.status(201).redirect(`/project/${req.params.id}/tasks/${req.params.taskid}`)
    } else {
        res.status(401).redirect(`/project/${req.params.id}/tasks`)
    }
})

//delete task
router.get('/:id/tasks/:taskid/delete', async (req, res) => {
    let [task] = await getTask(req.params.taskid)
    let user = req.session.user
    if (user.id == task.creator_id) {
        if (await deleteTask(task.id)) {
            res.status(410).redirect(`/project/${req.params.id}/tasks`)
        } else {
            res.status(404).redirect(`/project/${req.params.id}/tasks`)
        }
    } else {
        res.status(401).redirect(`/project/${req.params.id}/tasks`)
    }
})

// Subtasks
router.post('/:id/tasks/:taskid/subtasks', async (req, res) => {
    let { subtask } = req.body
    if (await addSubtask(req.params.taskid, subtask)) {
        res.status(201).redirect(`/project/${req.params.id}/tasks/${req.params.taskid}`)
    } else {
        res.status(404).redirect(`/project/${req.params.id}/tasks/${req.params.taskid}`)
    }
})

export { router as projectRouter }
