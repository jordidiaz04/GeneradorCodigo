using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class BloqueBL
	{
		public List<BloqueBE> listar()
		{
			return new BloqueDA().listar();
		}

		public BloqueBE obtener(BloqueBE oBloqueBE)
		{
			return new BloqueDA().obtener(oBloqueBE);
		}

		public int insertar(BloqueBE oBloqueBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new BloqueDA().insertar(oBloqueBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(BloqueBE oBloqueBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new BloqueDA().actualizar(oBloqueBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(BloqueBE oBloqueBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new BloqueDA().eliminar(oBloqueBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
