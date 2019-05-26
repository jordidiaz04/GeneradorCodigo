using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class AlumnoBL
	{
		public List<AlumnoBE> listar()
		{
			return new AlumnoDA().listar();
		}

		public AlumnoBE obtener(AlumnoBE oAlumnoBE)
		{
			return new AlumnoDA().obtener(oAlumnoBE);
		}

		public int insertar(AlumnoBE oAlumnoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new AlumnoDA().insertar(oAlumnoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(AlumnoBE oAlumnoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new AlumnoDA().actualizar(oAlumnoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(AlumnoBE oAlumnoBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new AlumnoDA().eliminar(oAlumnoBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
