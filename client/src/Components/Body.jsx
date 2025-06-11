import { getRecursosByEmail } from '../Services/Recurso/GetServices.js';
import { getEmpresasByEmail } from '../Services/Empresa/GetServices.js';
import { getClientesByEmail } from '../Services/Cliente/GetServices.js';

import Hero from './Hero.jsx';
import FeaturesSection from './FeaturesSection.jsx';

import { useEffect, useState } from 'react';

const Body = ({ isLoggedIn, email }) => {
    const [tipo, setTipo] = useState('');

    useEffect(() => {
        const getTipo = async () => {
            var recurso = await getRecursosByEmail(email);
            if (recurso != null) setTipo(recurso.tipo);

            var empresa = await getEmpresasByEmail(email);
            if (empresa != null) setTipo('E');

            var cliente = await getClientesByEmail(email);
            if (cliente != null) setTipo('C');
        };
        getTipo();
    }, [email]);

    return (
        <>
            {
                isLoggedIn ? (
                    tipo == 'A' || tipo == 'G' || tipo == 'C' ? (
                        <p>Recurso: {tipo}</p>

                    ) : tipo == 'E' ? (
                        <p>Empresa</p>

                    ) : tipo == 'C' ? (
                        <p>Cliente</p>

                    ) : <p>{tipo}</p>
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