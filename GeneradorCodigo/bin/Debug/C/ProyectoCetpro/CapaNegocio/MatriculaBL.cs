using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class MatriculaBL
	{
		public List<MatriculaBE> listar()
		{
			return new MatriculaDA().listar();
		}

		public MatriculaBE obtener(MatriculaBE oMatriculaBE)
		{
			return new MatriculaDA().obtener(oMatriculaBE);
		}

		public int insertar(MatriculaBE oMatriculaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new MatriculaDA().insertar(oMatriculaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(MatriculaBE oMatriculaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new MatriculaDA().actualizar(oMatriculaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(MatriculaBE oMatriculaBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new MatriculaDA().eliminar(oMatriculaBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
