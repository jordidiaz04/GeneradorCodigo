using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class ProfesionBL
	{
		public List<ProfesionBE> listar()
		{
			return new ProfesionDA().listar();
		}

		public ProfesionBE obtener(ProfesionBE oProfesionBE)
		{
			return new ProfesionDA().obtener(oProfesionBE);
		}

		public int insertar(ProfesionBE oProfesionBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new ProfesionDA().insertar(oProfesionBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(ProfesionBE oProfesionBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new ProfesionDA().actualizar(oProfesionBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(ProfesionBE oProfesionBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new ProfesionDA().eliminar(oProfesionBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
