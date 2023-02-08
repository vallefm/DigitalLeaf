import express from 'express'
import {getUsers, getUser} from './database.js'

const app = express()

app.get('/users', async (req, res) => {
    let users = await getUsers()
    res.send(users)
})

app.get('/users/:id', async (req, res) => {
    let id = req.params.id
    let user = await getUser(id)
    res.status(201).send(user)
})

app.use((err, req, res, next)=>{
    console.error(err.stack)
    res.status(500).send('Something Broke!')
})

app.listen(8080, ()=>{
    console.log('Server is running on port 8080');
})