/** model containing SQL logic for routes:
 * {@link routes/home.js}
 * {@link routes/project.js}
 **/

import { conn } from "../connection.js";

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
  let [result] = await conn.query("select * from projects where id = ? limit 1", [projectId]);
  return result;
}

async function createProject(projectName, description, dueDate, creatorId) {
  let newProjectId = createProjectID()
  description == '' ? description = null : description
  dueDate == '' ? dueDate = null : dueDate 
  let teamId = null
  try {
    await conn.query("INSERT INTO projects VALUES (?, ?, ?, ?, ?, ?, ?, NOW())", [newProjectId, projectName, description, 0, teamId, dueDate, creatorId])
    return true
  } catch (error) {
    console.log(error);
    return false
  }
}

function createProjectID() {
  let prefix = 'prj'
  let projectId = prefix+randomId()
  while (!checkProjectExists(projectId)){
    projectId = prefix+randomId()
  }
  return projectId
}

async function checkProjectExists(projectId) {
  let [countData] = await conn.query("SELECT COUNT(*) as count FROM projects WHERE id = ?", [projectId])
  let count = countData[0]["count"]
  if (count != 0) {
      return true;
  }
  return false
}

async function deleteProject(projectId) {
  if(checkProjectExists(projectId)){
  try {
    await conn.query("delete FROM projects WHERE id = ? limit 1", [projectId])
    return true
  } catch (error) {
    return false
  }
  }
}


/**  generic random number generator up to 9-digits for id creation. Prepend relevant 3-letter tag to create complete id.
 * users: usr
 * teams: tem
 * projects: prj
 * tasks: tsk
 * subtask: stk
 * announcements: anc
 * message(for inbox): msg
 */

function randomId() {
  let id = Math.round(Math.random()*100000000)
  return id.toString();
}

export { createProject, getUserProjects, getProjectDetails, deleteProject};
