import { Outlet, Navigate } from 'react-router-dom'
import { useAuth } from '../Services/AuthService'

function PublicRoutes() {
    const token = useAuth()
    return token ? <Navigate to='/categories' /> : <Outlet />
}

export default PublicRoutes