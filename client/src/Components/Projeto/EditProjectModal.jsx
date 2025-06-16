import { useState, useEffect } from 'react';

import { getAllEmpresas } from '../../Services/Empresa/GetServices.Js';

import { getAllClientes } from '../../Services/Cliente/GetServices.js';

import { getRecursosByTipo } from '../../Services/Recurso/GetServices.Js';

const EditProjectModal = ({ isOpen, onClose, onEdit, projeto, user, tipo }) => {
  const [nome, setNome] = useState(projeto?.nome || '');
  const [descricao, setDescricao] = useState(projeto?.descricao || '');
  const [dataFim, setDataFim] = useState(projeto?.dataFim ? formatDateInput(projeto.dataFim) : '');

  const [empresaId, setEmpresaId] = useState(projeto?.empresaId || '');
  const [clienteId, setClienteId] = useState(projeto?.clienteId || '');
  const [recursoId, setRecursoId] = useState(projeto?.recursoId || '');

  const [empresas, setEmpresas] = useState([]);
  const [recursos, setRecursos] = useState([]);
  const [clientes, setClientes] = useState([]);
  const [isLoadingEmpresas, setIsLoadingEmpresas] = useState(false);
  const [isLoadingRecursos, setIsLoadingRecursos] = useState(false);
  const [isLoadingClientes, setIsLoadingClientes] = useState(false);

  useEffect(() => {
    setNome(projeto?.nome || '');
    setDescricao(projeto?.descricao || '');
    setDataFim(projeto?.dataFim ? formatDateInput(projeto.dataFim) : '');
    setEmpresaId(projeto?.empresaId || '');
    setClienteId(projeto?.clienteId || '');
    setRecursoId(projeto?.recursoId || '');
  }, [projeto, isOpen]);

  function formatDateInput(dataInt) {
    if (!dataInt) return '';

    const str = dataInt.toString();

    if (str.length !== 8) return '';

    const ano = str.substring(0, 4);
    const mes = str.substring(4, 6);
    const dia = str.substring(6, 8);

    return `${ano}-${mes}-${dia}`;
  }

  const handleEmpresasDropdown = async () => {
    if (empresas.length === 0 && !isLoadingEmpresas) {
      setIsLoadingEmpresas(true);
      try {
        const data = await getAllEmpresas();
        setEmpresas(data);
      } catch {
        setEmpresas([]);
      }
      setIsLoadingEmpresas(false);
    }
  };

  const handleClientesDropdown = async () => {
    if (clientes.length === 0 && !isLoadingClientes) {
      setIsLoadingClientes(true);
      try {
        const data = await getAllClientes();
        setClientes(data);
      } catch {
        setClientes([]);
      }
      setIsLoadingClientes(false);
    }
  };

  const handleRecursosDropdown = async () => {
    if (recursos.length === 0 && !isLoadingRecursos) {
      setIsLoadingRecursos(true);
      try {
        const data = await getRecursosByTipo('G');
        setRecursos(data);
      } catch {
        setRecursos([]);
      }
      setIsLoadingRecursos(false);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const projetoEditado = {
      nome,
      descricao,
      dataFim: parseInt(dataFim.replace(/-/g, '')),
      empresaId: tipo === 'empresa' ? user.empresaId : parseInt(empresaId),
      gerenteId: parseInt(recursoId),
    };
    onEdit(projetoEditado);
    onClose();
  };

  if (!isOpen || !projeto) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div
        className="modal-content"
        style={{
          maxWidth: 340,
          width: '96vw',
          borderRadius: 14,
          boxShadow: '0 8px 32px rgba(44,62,80,0.18)',
          background: 'linear-gradient(135deg, #f8fafc 80%, #e3eafc 100%)',
          padding: '1.2rem 1rem',
          margin: '0 2vw'
        }}
        onClick={e => e.stopPropagation()}
      >
        <div className="modal-header" style={{ display: 'flex', alignItems: 'center', marginBottom: 18 }}>
          <h3 className="modal-title" style={{ flex: 1, fontWeight: 700, fontSize: 18, color: '#2d3a4a' }}>
            <i className="fas fa-edit" style={{ marginRight: 8, color: '#3498db' }}></i>
            Editar Projeto
          </h3>
          <button
            onClick={onClose}
            className="close-button"
            style={{
              background: 'none',
              border: 'none',
              fontSize: 20,
              color: '#888',
              cursor: 'pointer'
            }}
          >
            <i className="fas fa-times"></i>
          </button>
        </div>
        <form onSubmit={handleSubmit} className="row g-3">
          <div className="col-md-4">
            <label htmlFor="nome" className="form-label">Nome</label>
            <input
              type="text"
              className="form-control"
              id="nome"
              value={nome}
              onChange={e => setNome(e.target.value)}
              required
            />
          </div>
          <div className="col-md-8">
            <label htmlFor="descricao" className="form-label">Descrição</label>
            <input
              type="text"
              className="form-control"
              id="descricao"
              value={descricao}
              onChange={e => setDescricao(e.target.value)}
              required
            />
          </div>
          <div className="col-12">
            <label htmlFor="dataFim" className="form-label">Data Fim</label>
            <input
              type="date"
              className="form-control"
              id="dataFim"
              value={dataFim}
              onChange={e => setDataFim(e.target.value)}
              required
            />
          </div>
          {tipo !== 'empresa' && (
            <div className="col-md-6">
              <label htmlFor="empresaId" className="form-label">Id da Empresa</label>
              <select
                id="empresaId"
                className="form-select"
                value={empresaId}
                onChange={e => setEmpresaId(e.target.value)}
                onClick={handleEmpresasDropdown}
                required
                disabled={tipo === "empresa"}
              >
                <option value="">Selecione...</option>
                {isLoadingEmpresas ? (
                  <option disabled>Carregando...</option>
                ) : (
                  empresas.map(empresa => (
                    <option key={empresa.empresaId} value={empresa.empresaId}>
                      {empresa.nome}
                    </option>
                  ))
                )}
              </select>
            </div>
          )}
          {tipo !== 'cliente' && (
            <div className="col-md-6">
              <label htmlFor="clienteId" className="form-label">Id do Cliente</label>
              <select
                id="clienteId"
                className="form-select"
                value={clienteId}
                onChange={e => setClienteId(e.target.value)}
                onClick={handleClientesDropdown}
                required
                disabled={tipo === "cliente"}
              >
                <option value="">Selecione...</option>
                {isLoadingClientes ? (
                  <option disabled>Carregando...</option>
                ) : (
                  clientes.map(cliente => (
                    <option key={cliente.clienteId} value={cliente.clienteId}>
                      {cliente.nome}
                    </option>
                  ))
                )}
              </select>
            </div>
          )}
          <div className="col-md-6">
            <label htmlFor="recursoId" className="form-label">Id do Gerente</label>
            <select
              id="recursoId"
              className="form-select"
              value={recursoId}
              onChange={e => setRecursoId(e.target.value)}
              onClick={handleRecursosDropdown}
              required
            >
              <option value="">Selecione...</option>
              {isLoadingRecursos ? (
                <option disabled>Carregando...</option>
              ) : (
                recursos.map(recurso => (
                  <option key={recurso.recursoId} value={recurso.recursoId}>
                    {recurso.nome}
                  </option>
                ))
              )}
            </select>
          </div>
          <div className="col-12">
            <button type="submit" className="btn btn-primary" style={{ width: '100%' }}>
              Salvar Alterações
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default EditProjectModal;