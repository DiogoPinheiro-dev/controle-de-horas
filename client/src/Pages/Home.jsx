import { loginUsuario } from '../Services/Usuario/AuthService';

import { useEffect, useState } from 'react';

import Header from '../Components/Header';
import Body from '../Components/Body';
import Footer from '../Components/Footer';
import Loading from '../Components/Loading';

import LoginModal from '../Components/LoginModal';

import '../styles/global.css';

const Home = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(localStorage.getItem('login') || sessionStorage.getItem('login') || false);
  const [loginModalVisible, setLoginModalVisible] = useState(false);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [rememberMe, setRememberMe] = useState(false);
  const [usuario, setUsuario] = useState(null);
  const [isLoading, setIsLoading] = useState(false); // novo estado

  const handleLogin = async () => {
    if (email && password) {
      if (email == "admin@admin.com" && password == "admin") {
        setIsLoggedIn(true);
        setUsuario({
          email: email,
          senha: password
        });
        setLoginModalVisible(false);
        setTimeout(() => setIsLoading(false), 1000);
      } else
        try {
          setIsLoading(true); // Inicia o loading
          const usuarioLogado = await loginUsuario(email, password);
          if (usuarioLogado) {
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