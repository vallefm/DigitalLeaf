import { conn } from '../connection.js'







async function createSchedule(event_creator, eventName, eventTimeFrom, eventTimeTo,  day, month, year) {
 

    try {  
        await conn.query("INSERT INTO schedule (User_Id, event_name, event_time_from, event_time_to, event_day, event_month, event_year) VALUES (?, ?, ?, ?, ?, ?, ?)",
        [event_creator,eventName, eventTimeFrom, eventTimeTo, day,month,year ])
  
        
        return true
    } catch (error) {
        console.log(error);
        return false
    }
  }

  export  {createSchedule}