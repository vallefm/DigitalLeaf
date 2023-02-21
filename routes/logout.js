import express from 'express'
import path from 'path'
import { fileURLToPath } from 'url'

const router = express.Router()
const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

router.get('/', (req, res) => {
    req.session.loggedIn = false
    req.session.destroy()
    res.redirect('/')
})

export {router as logoutRouter}