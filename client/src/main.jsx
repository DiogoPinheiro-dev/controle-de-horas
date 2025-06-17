import { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import App from './App.jsx';

import Home from './Pages/Home.jsx';
import ClienteHome from './Pages/ClienteHome.jsx';
import EmpresaHome from './Pages/EmpresaHome.jsx';
import GerenteHome from './Pages/GerenteHome.jsx';
import CoordenadorHome from './Pages/CoordenadorHome.jsx';
import AnalistaHome from './Pages/AnalistaHome.jsx'

const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        path: '/',
        element: <Home />,
      },
      {
        path: '/Cliente',
        element: <ClienteHome />
      },
      {
        path: '/Empresa',
        element: <EmpresaHome />
      },
      {
        path: '/Recurso/G',
        element: <GerenteHome />
      },
      {
        path: '/Recurso/C',
        element: <CoordenadorHome />
      },
      {
        path: '/Recurso/A',
        element: <AnalistaHome />
      }
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
)
