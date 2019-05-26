using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class AulaBL
	{
		public List<AulaBE> listar()
		{
			return new AulaDA().listar();
		}

		public AulaBE obtener(AulaBE oAulaBE)
		{
			return new AulaDA().obtener(oAulaBE);
		}

		public int insertar(AulaBE oAulaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new AulaDA().insertar(oAulaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(AulaBE oAulaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new AulaDA().actualizar(oAulaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(AulaBE oAulaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new AulaDA().eliminar(oAulaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
