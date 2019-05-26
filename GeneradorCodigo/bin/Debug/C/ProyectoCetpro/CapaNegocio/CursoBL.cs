using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class CursoBL
	{
		public List<CursoBE> listar()
		{
			return new CursoDA().listar();
		}

		public CursoBE obtener(CursoBE oCursoBE)
		{
			return new CursoDA().obtener(oCursoBE);
		}

		public int insertar(CursoBE oCursoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CursoDA().insertar(oCursoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(CursoBE oCursoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CursoDA().actualizar(oCursoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(CursoBE oCursoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CursoDA().eliminar(oCursoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
