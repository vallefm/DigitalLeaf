import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

//import { createSchedule } from "../../models/schedule";
 import {createSchedule, getEvents} from "../models/schedule.js";




const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)


router.post('/addEvent', async (req, res) => {
  let { eventTitle, timeFrom, timeTo, activeDay, month, year} = req.body
  let user = req.session.user;
  if(await createSchedule(user, eventTitle, timeFrom, timeTo, activeDay, month, year)){
     
   console.log(req.body) 
  }
})

router.post('/getEvents', async (req, res) => {
  const user = req.session.user;
console.log("getEvents fireed")
  try {
    let { year, month, day} = req.body
    const events = await getEvents(user, year, month, day); // call a function to get events from the database
    
    res.status(200).json(events); // send the events as a JSON response
  } catch (error) {
    console.error(error);
    res.sendStatus(500);
  }
});


router.get('/', (req, res) => {
    res.render(path.join(__dirname+'/../public/views/schedule'), {loggedIn: req.session.loggedIn, firstName: req.session.user.firstName})
})

export {router as scheduleRouter}