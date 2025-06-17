import FeatureCard from './FeatureCard';
import '../styles/features.css';

const FeaturesSection = () => {
  return (
    <section className="features-grid">
      <FeatureCard 
        icon="fa-clock" 
        title="Registro de Horas" 
        description="Registre e acompanhe as horas trabalhadas de forma simples e intuitiva." 
      />
      <FeatureCard 
        icon="fa-chart-bar" 
        title="Cadastros e Controle de Projetos" 
        description="Cadastre seus projetos e todas suas dependências" 
      />
    </section>
  );
};

export default FeaturesSection;