import { conn } from '../connection.js'

  async function createSchedule(event_creator, eventName, eventTimeFrom, eventTimeTo,  day, month, year) {

    try {
        await conn.query("INSERT INTO schedule (User_Id, event_name, event_time_from, event_time_to, event_day, event_month, event_year) VALUES (?, ?, ?, ?, ?, ?, ?)",
        [event_creator.id,eventName, eventTimeFrom, eventTimeTo, day,month,year ])

        return true
    } catch (error) {
        console.log(error);
        return false
    }
  }

  
  async function getEvents(event_creator, year, month, day) {

    try {
      let [result] =  await conn.query("SELECT * FROM  schedule WHERE User_Id = ? AND event_year = ? AND event_month = ? AND event_day = ?",
        [event_creator.id, year, month, day ])
        console.log(event_creator.id + ' ' + year + ' ' + month + ' ' + day);
        console.log(result)
        return result
    } catch (error) {
        console.log(error);
       
    }
  }


  export  { createSchedule, getEvents };
