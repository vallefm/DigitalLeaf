import express from "express";
import path from "path";
import { fileURLToPath } from "url";
import bcrypt from "bcryptjs";
import session from "express-session";

//Router imports
import { loginRouter } from "./routes/login.js";
import { logoutRouter } from "./routes/logout.js";
import { signupRouter } from "./routes/signup.js";
import { forgotPasswordRouter } from "./routes/forgot_Password.js";
import { homeRouter } from "./routes/home.js";
import { projectRouter } from "./routes/project.js"
import { teamRouter } from "./routes/team.js";
import { scheduleRouter } from "./routes/schedule.js";
import { createProjectRouter } from "./routes/create_project.js";

const app = express();
const port = 8080;
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename);
const secret = bcrypt.hashSync(bcrypt.genSaltSync())

app.use(
  session({
    secret: secret,
    cookie: { maxAge: 24 * 60 * 60 * 1000 },
    resave: false,
    saveUninitialized: false,
  })
)

// Load static files
app.use(express.static(path.join(__dirname, "public")))
app.set("view engine", "ejs")

//convert requests to json, convert form requests objects to json
app.use(express.json())
app.use(express.urlencoded({ extended: true }))

// Route handling
app.use("/login", loginRouter)
app.use("/signup", signupRouter)
app.use("/forgotPassword", forgotPasswordRouter)
app.use("/home", homeRouter)
app.use("/team", teamRouter)
app.use("/project", projectRouter)
app.use("/schedule", scheduleRouter)
app.use("/logout", logoutRouter)
app.use("/create_project", createProjectRouter)

// Home route
app.get("/", (req, res) => {
  if (!req.session.loggedIn) {
    req.session.loggedIn = false
  }
  res.render(path.join(__dirname + "/public/views/index"), {
    loggedIn: req.session.loggedIn,
  })
});

// Error page
app.use((err, req, res, next) => {
  console.error(err.stack);
  res.status(500).send("Something Broke!")
});

// App listening
app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`)
});
