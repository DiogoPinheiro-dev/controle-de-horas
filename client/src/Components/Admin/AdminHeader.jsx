import { useNavigate } from "react-router-dom";

const AdminHeader = () => {
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem('login');
    sessionStorage.removeItem('login');
    navigate('/');
  };

  const handleGoHome = () => {
    navigate('/Admin');
  };

  return (
    <header style={{
      width: '100%',
      background: '#e5e7eb',
      padding: '1rem 0',
      display: 'flex',
      justifyContent: 'center',
      gap: 12,
      boxShadow: '0 2px 8px rgba(100,100,100,0.06)'
    }}>
      <button
        style={{
          background: '#9ca3af',
          color: '#fff',
          border: 'none',
          borderRadius: 6,
          padding: '0.5rem 1.2rem',
          fontWeight: 600,
          fontSize: 16,
          cursor: 'pointer',
          marginRight: 8
        }}
        onClick={handleGoHome}
      >
        Página Principal
      </button>
      <button
        style={{
          background: '#444',
          color: '#fff',
          border: 'none',
          borderRadius: 6,
          padding: '0.5rem 1.2rem',
          fontWeight: 600,
          fontSize: 16,
          cursor: 'pointer',
          marginRight: 24
        }}
        onClick={handleLogout}
      >
        Logout
      </button>
    </header>
  );
};

export default AdminHeader