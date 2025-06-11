import { useEffect, useState } from 'react';

import Header from '../Components/Header';
import Body from '../Components/Body';
import Footer from '../Components/Footer';

import LoginModal from '../components/LoginModal';

import '../styles/global.css';

import { loginUsuario } from '../Services/Usuario/AuthService';

const Home = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [loginModalVisible, setLoginModalVisible] = useState(false);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [rememberMe, setRememberMe] = useState(false);
  const [usuario, setUsuario] = useState(null);

  const handleLogin = async () => {
    if (email && password) {
      try {
        const usuarioLogado = await loginUsuario(email, password);
        if (usuarioLogado) {
          setIsLoggedIn(true);
          setUsuario(usuarioLogado);
          setLoginModalVisible(false);
        } else {
          alert('E-mail ou senha inválidos.');
        }
      } catch (error) {
        alert('Erro ao realizar login.', error);
      }
    }
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    setUsuario(null);
    localStorage.removeItem('usuario');
    sessionStorage.removeItem('usuario');

  };

  useEffect(() => {
    if (usuario) {
      if (rememberMe)
        localStorage.setItem('usuario', JSON.stringify(usuario));

      else
        sessionStorage.setItem('usuario', JSON.stringify(usuario));
    }
  }, [usuario, rememberMe]);

  return (
    <>
      <div className="gradient-bg">
        <div className="container">
          <Header
            isLoggedIn={isLoggedIn}
            onLoginPress={() => setLoginModalVisible(true)}
            onLogoutPress={handleLogout}
          />
          <Body
            isLoggedIn={isLoggedIn}
            email={email}
          />
        </div>
        <Footer />

        <LoginModal
          visible={loginModalVisible}
          onClose={() => setLoginModalVisible(false)}
          email={email}
          setEmail={setEmail}
          password={password}
          setPassword={setPassword}
          rememberMe={rememberMe}
          setRememberMe={setRememberMe}
          onLogin={handleLogin}
        />
      </div>
    </>
  );
}

export default Home;