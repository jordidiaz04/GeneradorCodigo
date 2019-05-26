using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class UbigeoBL
	{
		public List<UbigeoBE> listar()
		{
			return new UbigeoDA().listar();
		}

		public UbigeoBE obtener(UbigeoBE oUbigeoBE)
		{
			return new UbigeoDA().obtener(oUbigeoBE);
		}

		public int insertar(UbigeoBE oUbigeoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new UbigeoDA().insertar(oUbigeoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(UbigeoBE oUbigeoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new UbigeoDA().actualizar(oUbigeoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(UbigeoBE oUbigeoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new UbigeoDA().eliminar(oUbigeoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
