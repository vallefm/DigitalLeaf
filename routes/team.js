import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

import { getUserInfo } from "../models/teams.js"

/*
router.get('/:id/teams', async(req, res) => {
    res.render(path.join(__dirname+'/../public/views/team'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        
        });
});
*/

// Router for 'team tab' within a project card
router.get('/teams', async (req, res) => {
    let teams = await getUserInfo(req.session.user.id)
    let searchUser = await getUserInfo(req.session.user.id)
    res.render(path.join(__dirname+'/../public/views/teams'), {
    loggedIn: req.session.loggedIn,
    firstName: req.session.user.firstName,
    teams,
    searchUser
    });
});


router.get('/search/:searchUser', async (req, res) => {
    let searchUser = await getUserInfo(req.session.user.id)
    res.render(path.join(__dirname+'/../public/views/teams'), {
        loggedIn: req.session.loggedIn,
        firstName: req.session.user.firstName,
        searchUser
    });
});




export {router as teamRouter}