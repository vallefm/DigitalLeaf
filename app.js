import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'
import bcrypt from 'bcryptjs'

//Router imports
import { loginRouter } from './routes/login.js'
import { signupRouter } from './routes/signup.js'
import { forgotPasswordRouter } from './routes/forgot_Password.js'
import { homeRouter } from './routes/home.js'

import { scheduleRouter } from './routes/schedule.js'

import session from 'express-session'
//>>>>>>> b2525fa3e7a0d6d9211e50ca6d25d279524237e0

const app = express()
const port = 8080
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)
const secret = bcrypt.hashSync(bcrypt.genSaltSync())

app.use(session({
    secret: secret,
    cookie: {maxAge: 24 * 60 * 60 * 1000},
    resave: false,
    saveUninitialized: false
}))

// Load static files
app.use(express.static(path.join(__dirname, 'public')))
app.set('view engine', 'ejs')

//convert requests to json, convert form requests objects to json
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
    res.render(path.join(__dirname+'/public/views/index'))
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
