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

async function createProject(projectName, description) {
  let newProjectId = createProjectID()
  let setProgress = 0
  let teamId = 'placeholder'
  let creatorId = 'placeholder'
  try {
    await conn.query("INSERT INTO projects VALUES (?, ?, ?, ?, ?, ?, NOW())", [newProjectId, projectName, description, setProgress, teamId, creatorId ])
    return true
  } catch (error) {
    return false
  }

}

function createProjectID() {
  let projectId = 'prj'+randomId()
  while (!checkIdExists(projectId)){
    projectId = 'prj'+randomId()
  }
  return projectId
}

async function checkIdExists(id) {
  let exists = false
  let [countData] = await conn.query("SELECT COUNT(*) as count FROM users WHERE id = ?", [id])
  let count = countData[0]["count"]
  if (count != 0) {
      return false;
  }
  return true
}

// generic 8-digit random id generator. Prepend relevant 3-letter tag to create complete id (usr for users, tsk for task, etc.) 
function randomId() {
  let id = Math.round(Math.random()*10000000)
  return id.toString();
}

export { createProject, getUserProjects, getProjectDetails};
