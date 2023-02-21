import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

//Router imports
import { loginRouter } from './routes/login.js'
import { signupRouter } from './routes/signup.js'
import { forgotPasswordRouter } from './routes/forgot_Password.js'
import { homeRouter } from './routes/home.js'
import { scheduleRouter } from './routes/schedule.js'

const app = express()
const port = 8080
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

// Load static files
app.use(express.static(path.join(__dirname, 'public')))

//conver request to json, convert form requests to json
app.use(express.json())
app.use(express.urlencoded({extended: true}))

// Route handling
app.use('/login', loginRouter)
app.use('/signup', signupRouter)
app.use('/forgotPassword', forgotPasswordRouter)
app.use('/home', homeRouter)
app.use('/schedule', scheduleRouter)

// Home route
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname+'/public/views/index.html'))
})

// Error page
app.use((err, req, res, next)=>{
    console.error(err.stack)
    res.status(500).send('Something Broke!')
})

// App listening
app.listen(port, ()=>{
    console.log(`Server is running on http://localhost:${port}`);
})
