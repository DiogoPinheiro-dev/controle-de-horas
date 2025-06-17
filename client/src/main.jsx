import { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import App from './App.jsx';

import Home from './Pages/Home.jsx';
import ClienteHome from './Pages/ClienteHome.jsx';
import EmpresaHome from './Pages/EmpresaHome.jsx';
import GerenteHome from './Pages/GerenteHome.jsx';
import CoordenadorHome from './Pages/CoordenadorHome.jsx';
import AnalistaHome from './Pages/AnalistaHome.jsx';

import AdminHome from './Pages/AdminHome.jsx';
import CadastroDeRecurso from './Pages/CadastroDeRecurso.jsx';
import CadastroDeCliente from './Pages/CadastroDeCliente.jsx';
import CadastroDeEmpresa from './Pages/CadastroDeEmpresa.jsx';
import CadastroDeUsuario from './Pages/CadastroDeUsuario.jsx';

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
      },
      {
        path: '/Admin',
        element: <AdminHome />
      },
      {
        path: '/Admin/Cliente',
        element: <CadastroDeCliente />
      },
      {
        path: '/Admin/Recurso',
        element: <CadastroDeRecurso />
      },
      {
        path: '/Admin/Empresa',
        element: <CadastroDeEmpresa />
      },
      {
        path: '/Admin/Usuario',
        element: <CadastroDeUsuario />
      }
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
)
