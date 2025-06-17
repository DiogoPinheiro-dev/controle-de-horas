import { useEffect, useState } from 'react';
import { getAllClientes } from '../Services/Cliente/GetServices.Js';
import postCliente from '../Services/Cliente/PostServices.js';
import patchCliente from '../Services/Cliente/PatchServices.js';
import deleteCliente from '../Services/Cliente/DeleteServices.js';
import { getAllEmpresas } from '../Services/Empresa/GetServices.Js';

import AdminHeader from '../Components/Admin/AdminHeader.jsx';

import AddClienteModal from '../components/Admin/CadastroDeCliente/AddClienteModal';
import EditClienteModal from '../components/Admin/CadastroDeCliente/EditClienteModal';
import ClienteDetailsModal from '../components/Admin/CadastroDeCliente/ClienteDetailsModal';
import ClienteTable from '../components/Admin/CadastroDeCliente/ClienteTable';

const CadastroDeCliente = () => {
    const [clientes, setClientes] = useState([]);
    const [empresas, setEmpresas] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [isAddModalOpen, setIsAddModalOpen] = useState(false);
    const [isEditModalOpen, setIsEditModalOpen] = useState(false);
    const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false);
    const [clienteEditando, setClienteEditando] = useState(null);
    const [clienteDetalhes, setClienteDetalhes] = useState(null);

    useEffect(() => {
        fetchClientes();
        fetchEmpresas();
    }, []);

    const fetchClientes = async () => {
        setIsLoading(true);
        try {
            const data = await getAllClientes();
            setClientes(data || []);
        } catch {
            setClientes([]);
        }
        setIsLoading(false);
    };

    const fetchEmpresas = async () => {
        try {
            const data = await getAllEmpresas();
            setEmpresas(data || []);
        } catch {
            setEmpresas([]);
        }
    };

    const handleAddCliente = async (novoCliente) => {
        try {
            await postCliente({
                nome: novoCliente.nome,
                email: novoCliente.email,
                telefone: novoCliente.telefone,
                empresaId: novoCliente.empresaId ? parseInt(novoCliente.empresaId) : 0
            });
            setIsAddModalOpen(false);
            fetchClientes();
        } catch (e) {
            alert('Erro ao adicionar cliente: ' + e);
        }
    };

    const handleEditClienteClick = (cliente) => {
        setClienteEditando(cliente);
        setIsEditModalOpen(true);
    };

    const handleSaveEditCliente = async (clienteEditado) => {
        try {
            await patchCliente(clienteEditado.clienteId, {
                nome: clienteEditado.nome,
                telefone: clienteEditado.telefone,
                empresaId: clienteEditado.empresaId ? parseInt(clienteEditado.empresaId) : 0,
                usuarioId: clienteEditado.usuarioId ? parseInt(clienteEditado.usuarioId) : 0
            });
            setIsEditModalOpen(false);
            setClienteEditando(null);
            fetchClientes();
        } catch (e) {
            alert('Erro ao editar cliente: ' + e);
        }
    };

    const handleDeleteCliente = async (clienteId, empresaId) => {
        if (!window.confirm('Tem certeza que deseja excluir este cliente?')) return;
        try {
            await deleteCliente(clienteId, empresaId);
            fetchClientes();
        } catch (e) {
            alert('Erro ao excluir cliente: ' + e);
        }
    };

    const handleViewDetails = (cliente) => {
        setClienteDetalhes(cliente);
        setIsDetailsModalOpen(true);
    };

    return (
        <div style={{
            minHeight: '100vh',
            background: 'linear-gradient(135deg, #f3f4f6 60%, #e5e7eb 100%)',
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center'
        }}>
            <AdminHeader />
            <div style={{
                width: '100%',
                maxWidth: 900,
                margin: '0 auto',
                marginTop: 48,
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center'
            }}>
                <h2 style={{
                    color: '#444',
                    fontWeight: 700,
                    marginBottom: 32,
                    letterSpacing: 1,
                    textAlign: 'center'
                }}>
                    Cadastro de Cliente
                </h2>
                <button
                    style={{
                        width: 220,
                        padding: '0.8rem 0',
                        marginBottom: 18,
                        background: '#9ca3af',
                        color: '#fff',
                        border: 'none',
                        borderRadius: 8,
                        fontSize: 17,
                        fontWeight: 600,
                        cursor: 'pointer',
                        transition: 'background 0.2s'
                    }}
                    onClick={() => setIsAddModalOpen(true)}
                >
                    <i className="fas fa-plus" style={{ marginRight: 8 }}></i>
                    Adicionar Novo Cliente
                </button>
                <ClienteTable
                    clientes={clientes}
                    isLoading={isLoading}
                    onEdit={handleEditClienteClick}
                    onDelete={handleDeleteCliente}
                    onViewDetails={handleViewDetails}
                />
            </div>
            <AddClienteModal
                isOpen={isAddModalOpen}
                onClose={() => setIsAddModalOpen(false)}
                onAdd={handleAddCliente}
                empresas={empresas}
            />
            <EditClienteModal
                isOpen={isEditModalOpen}
                onClose={() => setIsEditModalOpen(false)}
                onEdit={handleSaveEditCliente}
                cliente={clienteEditando}
                empresas={empresas}
            />
            <ClienteDetailsModal
                isOpen={isDetailsModalOpen}
                onClose={() => setIsDetailsModalOpen(false)}
                cliente={clienteDetalhes}
            />
        </div>
    );
};

export default CadastroDeCliente;