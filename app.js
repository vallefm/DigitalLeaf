import express, { Router } from 'express'
import path from 'path'
import { fileURLToPath } from 'url'
import {getUsers, getUser, checkIdExists} from './database.js'

const app = express()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

app.use(express.static(path.join(__dirname, 'public')))

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname+'/public/views/index.html'))
})

app.use((err, req, res, next)=>{
    console.error(err.stack)
    res.status(500).send('Something Broke!')
})

app.use('/', Router)

app.listen(8080, ()=>{
    console.log('Server is running on port 8080');
})
