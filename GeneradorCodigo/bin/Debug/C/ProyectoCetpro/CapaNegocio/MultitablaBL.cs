using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class MultitablaBL
	{
		public List<MultitablaBE> listar()
		{
			return new MultitablaDA().listar();
		}

		public MultitablaBE obtener(MultitablaBE oMultitablaBE)
		{
			return new MultitablaDA().obtener(oMultitablaBE);
		}

		public int insertar(MultitablaBE oMultitablaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new MultitablaDA().insertar(oMultitablaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(MultitablaBE oMultitablaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new MultitablaDA().actualizar(oMultitablaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(MultitablaBE oMultitablaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new MultitablaDA().eliminar(oMultitablaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
