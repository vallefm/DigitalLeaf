/** model containing SQL logic for routes:
 * {@link routes/home.js}
 * {@link routes/project.js}
 **/

import { conn } from "../connection.js";

const projectPrefix = "prj";
const updatePrefix = "upd";
const taskPrefix = "tsk";

async function getUserProjects(userId) {
  let [result] = await conn.query(
    "select projects_users.project_id as projectId, projects.name as projectName, projects.team_id as teamId, teams.name as teamName\
    from projects_users join projects \
    on projects_users.project_id = projects.id left join teams\
    on projects.team_id = teams.id\
    where projects_users.user_id = ?\
    ",
    [userId]
  );
  return result;
}

async function getProjectDetails(projectId) {
  let [result] = await conn.query(
    "select * from projects where id = ? limit 1",
    [projectId]
  );
  return result;
}

async function createProject(projectName, description, dueDate, creatorId) {
  let newProjectId = createProjectID(projectPrefix);
  description == "" ? (description = null) : description;
  dueDate == "" ? (dueDate = null) : dueDate;
  let teamId = null;
  try {
    await conn.query(
      "INSERT INTO projects VALUES (?, ?, ?, ?, ?, ?, ?, NOW())",
      [newProjectId, projectName, description, 0, teamId, dueDate, creatorId]
    );
    return true;
  } catch (error) {
    console.log(error);
    return false;
  }
}

function createProjectID(prefix) {
  let projectId = prefix + randomId();
  while (!checkProjectExists(projectId)) {
    projectId = prefix + randomId();
  }
  return projectId;
}

async function checkProjectExists(projectId) {
  let [countData] = await conn.query(
    "SELECT COUNT(*) as count FROM projects WHERE id = ?",
    [projectId]
  );
  let count = countData[0]["count"];
  if (count != 0) {
    return true;
  }
  return false;
}

async function deleteProject(projectId) {
  if (checkProjectExists(projectId)) {
    try {
      await conn.query("delete FROM projects WHERE id = ? limit 1", [
        projectId,
      ]);
      return true;
    } catch (error) {
      return false;
    }
  }
}

// Updates
async function getProjectUpdates(projectId) {
  let [result] = await conn.query(
    "select * from projects_updates where project_id = ?",
    [projectId]
  );
  return result;
}

async function createProjectUpdate(projectId, userId ,header, content) {
  try {
    await conn.query("INSERT INTO projects_updates VALUES (?, ?, ? , ?, NOW())", [
      projectId,
      userId,
      header,
      content,
    ]);
    return true;
  } catch (error) {
    console.log(error);
    return false;
  }
}

// Tasks
async function getProjectTasks(projectId) {
  let [result] = await conn.query("select * from tasks where project_id = ?", [
    projectId,
  ]);
  return result;
}

async function createTask(title, dueDate, creatorId, projectId) {
  let newTaskId = createTaskId(taskPrefix);
  try {
    await conn.query("INSERT INTO tasks VALUES (?, ?, ? , ?, ?, ?, NOW())", [
      newTaskId,
      title,
      dueDate,
      'new',
      creatorId,
      projectId
    ]);
    return true;
  } catch (error) {
    console.log(error);
    return false;
  }
}

function createTaskId(prefix) {
  let taskId = prefix + randomId();
  while (!checkTaskIdExists(taskId)) {
    taskId = prefix + randomId();
  }
  return taskId;
}

async function checkTaskIdExists(taskId) {
  let [countData] = await conn.query(
    "SELECT COUNT(*) as count FROM tasks WHERE id = ?",
    [taskId]
  );
  let count = countData[0]["count"];
  if (count != 0) {
    return true;
  }
  return false;
}

async function deleteTask(taskId) {
  if (checkTaskIdExists(taskId)) {
    try {
      await conn.query("delete FROM tasks WHERE id = ? limit 1", [
        taskId,
      ]);
      return true;
    } catch (error) {
      return false;
    }
  }
}

/**  generic random number generator up to 9-digits for id creation. Prepend relevant 3-letter tag to create complete id.
 * users: usr
 * teams: tem
 * projects: prj
 * tasks: tsk
 * subtask: stk
 * update: upd
 * announcements: anc
 * message(for inbox): msg
 */

function randomId() {
  let id = Math.round(Math.random() * 100000000);
  return id.toString();
}

export {
  createProject,
  getUserProjects,
  getProjectDetails,
  deleteProject,
  getProjectUpdates,
  createProjectUpdate,
  getProjectTasks,
  createTask
};
