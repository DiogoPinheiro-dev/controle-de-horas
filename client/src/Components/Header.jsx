import '../styles/header.css';

const Header = ({ isLoggedIn, onLoginPress, onLogoutPress }) => {
  return (
    <header className="header">
      <div className="logo-container">
        <div className="logo">
          TS
        </div>
        <h1 className="company-name">Tuning Sistemas</h1>
      </div>

      <div className="auth-section">
        {!isLoggedIn ? (
          <button
            onClick={onLoginPress}
            className="login-button"
          >
            <i className="fas fa-sign-in-alt button-icon"></i> Login
          </button>
        ) : (
          <button
            onClick={onLogoutPress}
            className="logout-button"
          >
            <i className="fas fa-sign-out-alt button-icon"></i> Logout
          </button>
        )}
      </div>
    </header>
  );
};

export default Header;