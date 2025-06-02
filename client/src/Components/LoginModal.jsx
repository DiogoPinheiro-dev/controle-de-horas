import React from 'react';
import '../styles/modal.css';

const LoginModal = ({ 
  visible, 
  onClose, 
  email, 
  setEmail, 
  password, 
  setPassword, 
  rememberMe, 
  setRememberMe,
  onLogin
}) => {
  if (!visible) return null;

  const handleSubmit = (e) => {
    e.preventDefault();
    onLogin();
  };

  return (
    <div 
      className="modal-overlay"
      onClick={onClose}
    >
      <div 
        className="modal-content"
        onClick={(e) => e.stopPropagation()}
      >
        <div className="modal-header">
          <h3 className="modal-title">Login</h3>
          <button onClick={onClose} className="close-button">
            <i className="fas fa-times"></i>
          </button>
        </div>

        <form onSubmit={handleSubmit} className="form">
          <div className="form-group">
            <label htmlFor="email" className="label">E-mail</label>
            <input
              type="email"
              id="email"
              className="input"
              placeholder="seu@email.com"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>

          <div className="form-group">
            <label htmlFor="password" className="label">Senha</label>
            <input
              type="password"
              id="password"
              className="input"
              placeholder="••••••••"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>

          <div className="form-options">
            <div className="remember-me">
              <input
                type="checkbox"
                id="remember"
                className="checkbox"
                checked={rememberMe}
                onChange={(e) => setRememberMe(e.target.checked)}
              />
              <label htmlFor="remember" className="checkbox-label">Lembrar-me</label>
            </div>

            <a href="#" className="forgot-password">Esqueceu a senha?</a>
          </div>

          <button
            type="submit"
            className="submit-button"
          >
            Entrar
          </button>
        </form>

        <div className="signup-container">
          <span className="signup-text">Não tem uma conta?</span>
          <a href="#" className="signup-link"> Solicite acesso</a>
        </div>
      </div>
    </div>
  );
};

export default LoginModal;