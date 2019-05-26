using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class SedeBL
	{
		public List<SedeBE> listar()
		{
			return new SedeDA().listar();
		}

		public SedeBE obtener(SedeBE oSedeBE)
		{
			return new SedeDA().obtener(oSedeBE);
		}

		public int insertar(SedeBE oSedeBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new SedeDA().insertar(oSedeBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(SedeBE oSedeBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new SedeDA().actualizar(oSedeBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(SedeBE oSedeBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new SedeDA().eliminar(oSedeBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
