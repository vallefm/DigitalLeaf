const express = require('express')
const { appendFile } = require('fs')
const app = express()
const port = 3306

app.get('/', (req, res)=>{
    res.send('hello world')
})

app.listen(port, ()=>{
    console.log(`app is listening on port ${port}`);
})