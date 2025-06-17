import { useNavigate } from 'react-router-dom';

import AdminHeader from '../Components/Admin/AdminHeader';

const AdminHome = () => {
    const navigate = useNavigate();

    return (
        <div style={{
            minHeight: '100vh',
            background: 'linear-gradient(135deg, #f3f4f6 60%, #e5e7eb 100%)',
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center'
        }}>
            <AdminHeader />
            <div style={{
                background: '#f8fafc',
                borderRadius: 16,
                boxShadow: '0 4px 24px rgba(100,100,100,0.10)',
                padding: '2.5rem 2rem',
                minWidth: 320,
                maxWidth: 400,
                width: '100%',
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                marginTop: 48
            }}>
                <h2 style={{
                    color: '#444',
                    fontWeight: 700,
                    marginBottom: 32,
                    letterSpacing: 1
                }}>
                    Área Administrativa
                </h2>
                <button
                    style={{
                        width: '100%',
                        padding: '0.9rem 0',
                        marginBottom: 18,
                        background: '#e5e7eb',
                        color: '#222',
                        border: 'none',
                        borderRadius: 8,
                        fontSize: 18,
                        fontWeight: 600,
                        cursor: 'pointer',
                        transition: 'background 0.2s'
                    }}
                    onClick={() => navigate('/Admin/Recurso')}
                >
                    Cadastro de Recurso
                </button>
                <button
                    style={{
                        width: '100%',
                        padding: '0.9rem 0',
                        marginBottom: 18,
                        background: '#d1d5db',
                        color: '#222',
                        border: 'none',
                        borderRadius: 8,
                        fontSize: 18,
                        fontWeight: 600,
                        cursor: 'pointer',
                        transition: 'background 0.2s'
                    }}
                    onClick={() => navigate('/Admin/Cliente')}
                >
                    Cadastro de Cliente
                </button>
                <button
                    style={{
                        width: '100%',
                        padding: '0.9rem 0',
                        marginBottom: 18,
                        background: '#9ca3af',
                        color: '#fff',
                        border: 'none',
                        borderRadius: 8,
                        fontSize: 18,
                        fontWeight: 600,
                        cursor: 'pointer',
                        transition: 'background 0.2s'
                    }}
                    onClick={() => navigate('/Admin/Empresa')}
                >
                    Cadastro de Empresa
                </button>
                <button
                    style={{
                        width: '100%',
                        padding: '0.9rem 0',
                        background: '#6b7280',
                        color: '#fff',
                        border: 'none',
                        borderRadius: 8,
                        fontSize: 18,
                        fontWeight: 600,
                        cursor: 'pointer',
                        transition: 'background 0.2s'
                    }}
                    onClick={() => navigate('/Admin/Usuario')}
                >
                    Cadastro de Usuário
                </button>
            </div>
        </div>
    );
};

export default AdminHome