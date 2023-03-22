/** model containing SQL logic for routes:
 * {@link routes/home.js}
 * {@link routes/project.js}
 * {@link routes/team.js}
 **/

import { conn } from "../connection.js"


//Teams

  //Reviewed for post Team/Project Manager discussion split
  //Call to populate user card on search pagec when fully implemented
  async function getUserInfo(userEmail) {
    let result = await conn.query(
    "SELECT users.email as userEmail, users.first_name as firstName, users.last_name as lastName\
     FROM users WHERE users.email = ? limit 1",
    [userEmail]);
    return result;
  }

  async function checkIfUserExists(userId) {
    let [countData] = await conn.query(
      "SELECT COUNT(*) as count FROM users WHERE id = ?",
      [userId]
    );
    let count = countData[0]["count"];
    if (count != 0) {
      return true;
    }
    return false;
  }
  
  async function addTeamMember(projectId, userId) {
    let newTeamId = getTeamId(projectId)
      try {
        await conn.query(
          "INSERT INTO project_users VALUES (?, ?) "
          [newTeamId, userId]
          );
        return true;
      } catch (error) {
        return false;
      }
  }
  
  async function getTeamId(projectId) {
    let [result] = await conn.query("SELECT team_id FROM projects WHERE projectId = ? limit 1 ", [
      projectId]);
    return result;
  }

  async function getTeamMembers(projectId) {
    let [result] = await conn.query("SELECT user_id FROM project_users WHERE projectId = ?", [
        projectId]);
        return result;
  }

  async function getUsersTeamId(userId) {
    let [result] = await conn.query("SELECT team_id FROM teams_users WHERE user_id = ?", [
        userId]);
        return result;
  }

  async function getUsersTeams(userId) {
    let teamId = getUsersTeamId(userId)
    let [result] =  await conn.query("SELECT name FROM teams WHERE id = ?", [
        teamId]);
        return result;
  }
  
  
  function removeTeamMember() {}

  export {
    checkIfUserExists,
    getUserInfo,
    addTeamMember,
    getTeamId,
    getTeamMembers,
    getUsersTeamId,
    getUsersTeams,
    removeTeamMember
  }