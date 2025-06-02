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
        title="Relatórios" 
        description="Gere relatórios detalhados para análise de produtividade e gestão." 
      />
    </section>
  );
};

export default FeaturesSection;