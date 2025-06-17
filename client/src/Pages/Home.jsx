import { loginUsuario } from '../Services/Usuario/AuthService';

import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import Header from '../Components/Header';
import Body from '../Components/Body';
import Footer from '../Components/Footer';
import Loading from '../Components/Loading';

import LoginModal from '../Components/LoginModal';

import '../styles/global.css';

const Home = () => {
  const navigate = useNavigate();
  const [isLoggedIn, setIsLoggedIn] = useState(
    !!(localStorage.getItem('login') || sessionStorage.getItem('login'))
  ); const [loginModalVisible, setLoginModalVisible] = useState(false);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [rememberMe, setRememberMe] = useState(false);
  const [usuario, setUsuario] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const handleLogin = async () => {
    if (email && password) {
      if (email === "admin@admin.com" && password === "admin") {
        if (rememberMe)
          localStorage.setItem('login', JSON.stringify(email));
        else
          sessionStorage.setItem('login', JSON.stringify(email));

        setIsLoggedIn(true);
        setUsuario({ email, senha: password });
        setLoginModalVisible(false);
        setTimeout(() => setIsLoading(false), 1000);
      } else {
        try {
          setIsLoading(true);
          const usuarioLogado = await loginUsuario(email, password);
          if (usuarioLogado) {
            if (rememberMe)
              localStorage.setItem('login', JSON.stringify(usuarioLogado.email));
            else
              sessionStorage.setItem('login', JSON.stringify(usuarioLogado.email));

            setIsLoggedIn(true);
            setUsuario(usuarioLogado);
            setLoginModalVisible(false);
            setTimeout(() => setIsLoading(false), 1000);
          } else {
            setIsLoading(false);
            alert('E-mail ou senha inválidos.');
          }
        } catch (error) {
          setIsLoading(false);
          alert('Erro ao realizar login.', error);
        }
      }
    }
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    setUsuario(null);
    localStorage.removeItem('login');
    sessionStorage.removeItem('login');

  };

  useEffect(() => {
    if (usuario) {
      if (rememberMe)
        localStorage.setItem('login', JSON.stringify(usuario.email));

      else
        sessionStorage.setItem('login', JSON.stringify(usuario.email));
    }
  }, [usuario, rememberMe]);

  useEffect(() => {
    if (isLoggedIn) {
      // Se for admin, redireciona para admin
      const login = localStorage.getItem('login') || sessionStorage.getItem('login');
      if (login && JSON.parse(login) === "admin@admin.com") {
        navigate('/Admin');
      }
    }
  }, [isLoggedIn, navigate]);

  return (
    <>

      <div className="gradient-bg" style={{ minHeight: '100vh', display: 'flex', flexDirection: 'column' }}>
        <div className="container main-content" style={{ flex: 1, display: 'flex', flexDirection: 'column' }}>
          <Header
            isLoggedIn={isLoggedIn}
            onLoginPress={() => setLoginModalVisible(true)}
            onLogoutPress={handleLogout}
          />
          {isLoading ? (
            <Loading />
          ) : (
            <Body isLoggedIn={isLoggedIn} />
          )}
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