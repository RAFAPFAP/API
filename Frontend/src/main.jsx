import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import Category from './Category/CategoryComponent'
import Post from './Post/PostComponent'
import {
  BrowserRouter as Router,
  createBrowserRouter,
  Route,
  RouterProvider,
  Routes,
} from "react-router-dom";
import SignIn from './Security/login'
import { User } from './Security/UsersComponent'
import { PostForViewer } from './Post/PostForViewer'
import PrivateRoutes from './Security/PrivateRoutes'
import PublicRoutes from './Security/PublicRoutes'

const router = createBrowserRouter([
  {
    path: "/posts/viewer",
    element: <PostForViewer></PostForViewer>,
  },
  {
    path: "/login",
    element: <SignIn></SignIn>,
  },
  {
    path: "/users",
    element: <User></User>,
  },
  {
    path: "/categories",
    element: <Category />
  },
  {
    path: "/posts",
    element: <Post />
  },
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <Router>
     <Routes>
      <Route element={<PrivateRoutes />}>
        <Route element={<Category />} path='/categories' />
        <Route element={<Post />} path='/posts' />
        <Route element={<User />} path='/users' />
      </Route>
      <Route element={<PublicRoutes />}>
        <Route element={<SignIn />} path='/login' />
      </Route>
    </Routes>
    </Router>
  </React.StrictMode>
)
