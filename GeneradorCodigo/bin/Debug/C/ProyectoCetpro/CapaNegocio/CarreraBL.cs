using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class CarreraBL
	{
		public List<CarreraBE> listar()
		{
			return new CarreraDA().listar();
		}

		public CarreraBE obtener(CarreraBE oCarreraBE)
		{
			return new CarreraDA().obtener(oCarreraBE);
		}

		public int insertar(CarreraBE oCarreraBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CarreraDA().insertar(oCarreraBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(CarreraBE oCarreraBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CarreraDA().actualizar(oCarreraBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(CarreraBE oCarreraBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new CarreraDA().eliminar(oCarreraBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
