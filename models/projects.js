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

export { getUserProjects };
