import React, { useState } from 'react';
import Header from '../components/Header';
import Hero from '../components/Hero';
import FeaturesSection from '../components/FeaturesSection';
import Footer from '../components/Footer';
import LoginModal from '../components/LoginModal';
import '../styles/global.css';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [loginModalVisible, setLoginModalVisible] = useState(false);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [rememberMe, setRememberMe] = useState(false);
  

  const handleLogin = () => {
    if (email && password) {
      setIsLoggedIn(true);
      setLoginModalVisible(false);
      alert(`Bem-vindo, ${email}! Login realizado com sucesso.`);
    }
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    alert('Logout realizado com sucesso!');
  };

  return (
    <>
      <div className="gradient-bg">
        <div className="container">
          <Header
            isLoggedIn={isLoggedIn}
            onLoginPress={() => setLoginModalVisible(true)}
            onLogoutPress={handleLogout}
          />
          <Hero />
          <FeaturesSection />
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

export default App;