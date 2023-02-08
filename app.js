import express from 'express'
import {getUsers} from './database.js'

const app = express()

app.get('/test', (req, res) => {
    res.send('test')
})

app.use((err, req, res, next)=>{
    console.error(err.stack)
    res.status(500).send('Something Broke!')
})

app.listen(3306, ()=>{
    console.log('Server is running on port 3306');
})