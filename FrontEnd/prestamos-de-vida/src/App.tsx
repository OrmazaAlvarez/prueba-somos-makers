import { useState } from 'react'
import './App.css'

// Tipos de usuario y préstamo
interface User {
  id: string;
  name: string;
  role: 'user' | 'admin';
}

interface LoanRequest {
  id: string;
  userId: string;
  amount: number;
  reason: string;
  status: 'pendiente' | 'aprobado' | 'rechazado';
}

// Simulación de usuario autenticado y préstamos (mock)
const mockUser: User = { id: '1', name: 'Juan Pérez', role: 'user' };
const mockAdmin: User = { id: '2', name: 'Admin', role: 'admin' };

function App() {
  const [user, setUser] = useState<User | null>(mockUser); // Cambia a mockAdmin para probar admin
  const [loans, setLoans] = useState<LoanRequest[]>([]);
  const [amount, setAmount] = useState('');
  const [reason, setReason] = useState('');
  const [error, setError] = useState('');

  // Validación y envío de solicitud
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    const numAmount = Number(amount);
    if (!numAmount || numAmount <= 0) {
      setError('El monto debe ser mayor a 0.');
      return;
    }
    if (!reason.trim()) {
      setError('Debes ingresar un motivo.');
      return;
    }
    const newLoan: LoanRequest = {
      id: crypto.randomUUID(),
      userId: user!.id,
      amount: numAmount,
      reason,
      status: 'pendiente',
    };
    setLoans([...loans, newLoan]);
    setAmount('');
    setReason('');
  };

  // Admin: cambiar estado
  const handleStatusChange = (id: string, status: 'aprobado' | 'rechazado') => {
    setLoans(loans.map(l => l.id === id ? { ...l, status } : l));
  };

  // Filtrar préstamos según usuario
  const visibleLoans = user?.role === 'admin' ? loans : loans.filter(l => l.userId === user?.id);

  return (
    <div className="container">
      <h1>Gestión de Préstamos</h1>
      <div className="user-info">
        <span>Usuario: <b>{user?.name}</b> ({user?.role})</span>
        {/* Aquí iría el login/logout real */}
      </div>
      {user?.role === 'user' && (
        <form className="loan-form" onSubmit={handleSubmit}>
          <h2>Solicitar préstamo</h2>
          <input
            type="number"
            placeholder="Monto"
            value={amount}
            onChange={e => setAmount(e.target.value)}
            min={1}
            required
          />
          <input
            type="text"
            placeholder="Motivo"
            value={reason}
            onChange={e => setReason(e.target.value)}
            required
          />
          <button type="submit">Enviar solicitud</button>
          {error && <div className="error">{error}</div>}
        </form>
      )}
      <div className="loans-list">
        <h2>{user?.role === 'admin' ? 'Todas las solicitudes' : 'Mis solicitudes'}</h2>
        {visibleLoans.length === 0 && <p>No hay solicitudes.</p>}
        <ul>
          {visibleLoans.map(loan => (
            <li key={loan.id} className={`loan-item status-${loan.status}`}>
              <div>
                <b>Monto:</b> ${loan.amount} <b>Motivo:</b> {loan.reason}
                <span className={`status ${loan.status}`}>{loan.status}</span>
              </div>
              {user?.role === 'admin' && loan.status === 'pendiente' && (
                <div className="actions">
                  <button onClick={() => handleStatusChange(loan.id, 'aprobado')}>Aprobar</button>
                  <button onClick={() => handleStatusChange(loan.id, 'rechazado')}>Rechazar</button>
                </div>
              )}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default App
