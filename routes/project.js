import express from "express";
import path from "path";
import { fileURLToPath } from "url";
import { getProjectDetails, deleteProject } from "../models/projects.js";

const router = express.Router();
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);



router.get("/:id", async (req, res) => {
  let [project] = await getProjectDetails(req.params.id);
  let user = req.session.user
  res.render(path.join(__dirname + "/../public/views/project"), {
    loggedIn: req.session.loggedIn,
    firstName: req.session.user.firstName,
    project,
    user
  });
});

router.get("/:id/tasks", async (req, res) => {
  let [project] = await getProjectDetails(req.params.id);
  let user = req.session.user
  res.render(path.join(__dirname + "/../public/views/tasks"), {
    loggedIn: req.session.loggedIn,
    firstName: req.session.user.firstName,
    project,
    user
  });
});

router.get("/:id/delete", async (req, res) => {
  let [project] = await getProjectDetails(req.params.id);
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

});

export { router as projectRouter };
