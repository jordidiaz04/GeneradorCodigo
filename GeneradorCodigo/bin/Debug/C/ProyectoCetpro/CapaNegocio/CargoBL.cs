using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class CargoBL
	{
		public List<CargoBE> listar()
		{
			return new CargoDA().listar();
		}

		public CargoBE obtener(CargoBE oCargoBE)
		{
			return new CargoDA().obtener(oCargoBE);
		}

		public int insertar(CargoBE oCargoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CargoDA().insertar(oCargoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(CargoBE oCargoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CargoDA().actualizar(oCargoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(CargoBE oCargoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CargoDA().eliminar(oCargoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
