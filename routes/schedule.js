import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

//import { createSchedule } from "../../models/schedule";
 import {createSchedule} from "../models/schedule.js";


const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)


router.post('/addEvent', async (req, res) => {
  let { eventTitle, timeFrom, timeTo, activeDay, month, year} = req.body
  let user = req.session.user;
  if(await createSchedule(user, eventTitle, timeFrom, timeTo, activeDay, month+1, year)){
     
   console.log(req.body) 
  }
})

router.get('/', (req, res) => {
    res.render(path.join(__dirname+'/../public/views/schedule'), {loggedIn: req.session.loggedIn, firstName: req.session.user.firstName})
})

export {router as scheduleRouter}