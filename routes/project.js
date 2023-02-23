import express from "express";
import path from "path";
import { fileURLToPath } from "url";
import { getProjectDetails } from "../models/projects.js";

const router = express.Router();
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

router.get("/:id", async (req, res) => {
  let [project] = await getProjectDetails(req.params.id);
  res.render(path.join(__dirname + "/../public/views/project"), {
    loggedIn: req.session.loggedIn,
    firstName: req.session.user.firstName,
    project,
  });
});

export { router as projectRouter };
