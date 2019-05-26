using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class ProfesorBL
	{
		public List<ProfesorBE> listar()
		{
			return new ProfesorDA().listar();
		}

		public ProfesorBE obtener(ProfesorBE oProfesorBE)
		{
			return new ProfesorDA().obtener(oProfesorBE);
		}

		public int insertar(ProfesorBE oProfesorBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new ProfesorDA().insertar(oProfesorBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(ProfesorBE oProfesorBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new ProfesorDA().actualizar(oProfesorBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(ProfesorBE oProfesorBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new ProfesorDA().eliminar(oProfesorBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
