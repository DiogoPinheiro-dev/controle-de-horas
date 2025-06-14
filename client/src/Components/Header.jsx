import { useNavigate } from 'react-router-dom';
import { useState } from 'react';

import '../styles/header.css';

import Loading from './Loading';

const Header = ({ isLoggedIn, onLoginPress, onLogoutPress }) => {
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleHomeClick = () => {
    setLoading(true);
    setTimeout(() => {
      navigate('/'); // ou o caminho da sua Home
    }, 800); // tempo para mostrar o loading (ajuste se quiser)
  };

  return (
    <>
      {loading && <Loading />}
      <header className="header">
        <div className="logo-container">
          <div className="logo">
            TS
          </div>
          <h1 className="company-name">Tuning Sistemas</h1>
        </div>

        <div className="auth-section">
          {isLoggedIn ? (
            <>
              <button
                className="login-button"
                onClick={() => { handleHomeClick() }}
                style={{ marginRight: '1rem' }}
              >
                <i className="fas fa-home button-icon"></i> Home
              </button>
              <div className="user-info">
                <i className="fas fa-user-circle user-icon"></i>
                <div>
                  <div className="user-name">{JSON.parse(sessionStorage.getItem('login')) || JSON.parse(localStorage.getItem('login'))}</div>
                </div>
              </div>
              <button
                onClick={onLogoutPress}
                className="logout-button"
              >
                <i className="fas fa-sign-out-alt button-icon"></i> Logout
              </button>
            </>
          ) : (
            <button
              onClick={onLoginPress}
              className="login-button"
            >
              <i className="fas fa-sign-in-alt button-icon"></i> Login
            </button>
          )}
        </div>
      </header >
    </>
  );
};

export default Header;