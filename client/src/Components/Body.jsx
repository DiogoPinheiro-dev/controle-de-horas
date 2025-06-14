import { getRecursosByEmail } from '../Services/Recurso/GetServices.js';
import { getEmpresasByEmail } from '../Services/Empresa/GetServices.js';
import { getClientesByEmail } from '../Services/Cliente/GetServices.js';

import Hero from './Hero.jsx';
import FeaturesSection from './FeaturesSection.jsx';

import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Body = ({ isLoggedIn }) => {
    const [tipo, setTipo] = useState("");
    const [email] = useState(JSON.parse(sessionStorage.getItem('login')) || JSON.parse(localStorage.getItem('login')));
    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
            if (email) {
                try {
                    let data = await getClientesByEmail(email);
                    if (!data || data.length === 0) data = await getEmpresasByEmail(email);
                    if (!data || data.length === 0) data = await getRecursosByEmail(email);

                    if (data && data.length > 0) {
                        if (data[0].tipo) {
                            if (data[0].tipo === "A" || data[0].tipo === "G" || data[0].tipo === "C") setTipo(data[0].tipo);
                        } else {
                            if (data[0].telefone) setTipo("Cliente");
                            else setTipo("Empresa");
                        }
                    } else setTipo('Nenhum dado encontrado');

                } catch (error) {
                    console.error('Erro ao buscar dados:', error);
                    setTipo('Erro ao buscar dados');
                }
            }
        };

        if (isLoggedIn) {
            fetchData();
        }
    }, [isLoggedIn, email]);


    console.log(tipo);

    return (
        <>
            {
                isLoggedIn ? (
                    tipo === "A" ? (navigate(`/Recurso/${tipo}`)) :
                        tipo === "G" ? (navigate(`/Recurso/${tipo}`)) :
                            tipo === "C" ? (navigate(`/Recurso/${tipo}`)) :
                                tipo === "Empresa" ? (navigate(`/${tipo}`)) :
                                    tipo === "Cliente" ? (navigate(`/${tipo}`)) :
                                        tipo === 'Nenhum dado encontrado' ? (navigate('/')) : null
                ) : (
                    <>
                        <Hero />
                        <FeaturesSection />
                    </>
                )
            }
        </>
    )
}

export default Body