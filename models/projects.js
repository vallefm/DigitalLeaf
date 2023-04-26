/** model containing SQL logic for routes:
 * {@link routes/home.js}
 * {@link routes/project.js}
 **/

import { conn } from '../connection.js'

const projectPrefix = 'prj'
const updatePrefix = 'upd'
const taskPrefix = 'tsk'
const subtaskPrefix = 'sub'

async function getUserProjects(userId) {
    let [result] = await conn.query(
        'select projects_users.project_id as projectId, projects.name as projectName, projects.team_id as teamId, projects.creator_id as creatorId, teams.name as teamName\
    from projects_users join projects \
    on projects_users.project_id = projects.id left join teams\
    on projects.team_id = teams.id\
    where projects_users.user_id = ?\
    ',
        [userId]
    )
    return result
}

async function getProjectDetails(projectId) {
    let [result] = await conn.query('select * from projects where id = ? limit 1', [projectId])
    return result
}

async function createProject(projectName, description, dueDate, creatorId) {
    let newProjectId = createProjectID(projectPrefix)
    description == '' ? (description = null) : description
    dueDate == '' ? (dueDate = null) : dueDate
    let teamId = null
    try {
        await conn.query('INSERT INTO projects VALUES (?, ?, ?, ?, ?, ?, ?, NOW())', [
            newProjectId,
            projectName,
            description,
            0,
            teamId,
            dueDate,
            creatorId,
        ])
        return true
    } catch (error) {
        console.log(error)
        return false
    }
}

function createProjectID(prefix) {
    let projectId = prefix + randomId()
    while (!checkProjectExists(projectId)) {
        projectId = prefix + randomId()
    }
    return projectId
}

async function checkProjectExists(projectId) {
    let [countData] = await conn.query('SELECT COUNT(*) as count FROM projects WHERE id = ?', [
        projectId,
    ])
    let count = countData[0]['count']
    if (count != 0) {
        return true
    }
    return false
}

async function deleteProject(projectId) {
    if (checkProjectExists(projectId)) {
        try {
            await conn.query('delete FROM projects WHERE id = ? limit 1', [projectId])
            return true
        } catch (error) {
            return false
        }
    }
}

// Updates
async function getProjectUpdates(projectId) {
    let [result] = await conn.query('select * from projects_updates where project_id = ?', [
        projectId,
    ])
    return result
}

async function getUpdate(updateId) {
    let [result] = await conn.query('select * from projects_updates where id = ?', [updateId])
    return result
}

async function createProjectUpdate(projectId, userId, header, content) {
    let newUpdateId = createUpdateId(updatePrefix)
    try {
        await conn.query('INSERT INTO projects_updates VALUES (?, ?, ?, ? , ?, NOW())', [
            newUpdateId,
            projectId,
            userId,
            header,
            content,
        ])
        return true
    } catch (error) {
        console.log(error)
        return false
    }
}

function createUpdateId(prefix) {
    let updateId = prefix + randomId()
    while (!checkUpdateIdExists(updateId)) {
        updateId = prefix + randomId()
    }
    return updateId
}

async function checkUpdateIdExists(updateId) {
    let [countData] = await conn.query(
        'SELECT COUNT(*) as count FROM projects_updates WHERE id = ?',
        [updateId]
    )
    let count = countData[0]['count']
    if (count != 0) {
        return true
    }
    return false
}

async function deleteUpdate(updateId) {
    if (checkUpdateIdExists(updateId)) {
        try {
            await conn.query('delete FROM projects_updates WHERE id = ? limit 1', [updateId])
            return true
        } catch (error) {
            return false
        }
    }
}

// Tasks
async function getProjectTasks(projectId) {
    let [result] = await conn.query('select * from tasks where project_id = ?', [projectId])
    return result
}

async function getTask(taskId) {
    let [result] = await conn.query('select * from tasks where id = ? limit 1', [taskId])
    return result
}

async function createTask(title, details, dueDate, creatorId, projectId) {
    let newTaskId = createTaskId(taskPrefix)
    dueDate == '' ? (dueDate = null) : dueDate
    try {
        await conn.query('INSERT INTO tasks VALUES (?, ?, ?, ?, ?, 0, ?, ?, NOW())', [
            newTaskId,
            title,
            dueDate,
            'new',
            details,
            creatorId,
            projectId,
        ])
        return true
    } catch (error) {
        console.log(error)
        return false
    }
}

function createTaskId(prefix) {
    let taskId = prefix + randomId()
    while (!checkTaskIdExists(taskId)) {
        taskId = prefix + randomId()
    }
    return taskId
}

async function checkTaskIdExists(taskId) {
    let [countData] = await conn.query('SELECT COUNT(*) as count FROM tasks WHERE id = ?', [taskId])
    let count = countData[0]['count']
    if (count != 0) {
        return true
    }
    return false
}

async function setTaskStatus(taskId, status) {
    if (checkTaskIdExists(taskId)) {
        try {
            await conn.query('UPDATE tasks SET status = ? WHERE id = ? limit 1', [status, taskId])
            return true
        } catch (error) {
            return false
        }
    }
}

async function deleteTask(taskId) {
    if (checkTaskIdExists(taskId)) {
        try {
            await conn.query('delete FROM tasks WHERE id = ? limit 1', [taskId])
            return true
        } catch (error) {
            return false
        }
    }
}

// add subtask
async function addSubtask(taskId, subtask) {
    let newSubtaskId = createSubtaskId(subtaskPrefix)
    try {
        await conn.query('INSERT INTO subtasks VALUES (?, ?, ?)', [newSubtaskId, subtask, taskId])
        return true
    } catch (error) {
        return false
    }
}

async function getSubtasks(taskId) {
    try {
        let [result] = await conn.query('select * from subtasks where task_id = ?', [taskId])
        return result
    } catch (error) {
        return error
    }
}

function createSubtaskId(prefix) {
    let taskId = prefix + randomId()
    while (!checkSubtaskIdExists(taskId)) {
        taskId = prefix + randomId()
    }
    return taskId
}

async function checkSubtaskIdExists(subtaskId) {
    let [countData] = await conn.query('SELECT COUNT(*) as count FROM subtasks WHERE id = ?', [subtaskId])
    let count = countData[0]['count']
    if (count != 0) {
        return true
    }
    return false
}

//Add Team Member
async function addProjectMember(projectId, userId) {
    try {
        await conn.query('INSERT INTO projects_users VALUES (?, ?)', [projectId, userId])
        return true
    } catch (error) {
        console.log(error)
        return false
    }
}

/**  generic random number generator up to 9-digits for id creation. Prepend relevant 3-letter tag to create complete id.
 * users: usr
 * teams: tem
 * projects: prj
 * tasks: tsk
 * subtask: stk
 * updates: upd
 * announcements: anc
 * message(for inbox): msg
 */

function randomId() {
    let id = Math.round(Math.random() * 100000000)
    return id.toString()
}

export {
    createProject,
    getUserProjects,
    getProjectDetails,
    deleteProject,
    getProjectUpdates,
    createProjectUpdate,
    getProjectTasks,
    createTask,
    getTask,
    setTaskStatus,
    deleteTask,
    getUpdate,
    deleteUpdate,
    addProjectMember,
    addSubtask,
    getSubtasks,
}
