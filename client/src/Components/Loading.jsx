const Loading = ({ children }) => (
    <div className="gradient-bg">
        <div className="container">
            {children}
            <div style={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'center',
                height: '60vh',
                fontSize: '2rem'
            }}>
                <div className="spinner" style={{
                    border: '8px solid #f3f3f3',
                    borderTop: '8px solid #3498db',
                    borderRadius: '50%',
                    width: '60px',
                    height: '60px',
                    animation: 'spin 1s linear infinite',
                    marginBottom: '20px'
                }} />
                Carregando...
                <style>
                    {`
            @keyframes spin {
              0% { transform: rotate(0deg); }
              100% { transform: rotate(360deg); }
            }
          `}
                </style>
            </div>
        </div>
    </div>
);

export default Loading;