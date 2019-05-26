using System;
using System.Collections.Generic;
using System.Transactions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
	public class PersonalBL
	{
		public List<PersonalBE> listar()
		{
			return new PersonalDA().listar();
		}

		public PersonalBE obtener(PersonalBE oPersonalBE)
		{
			return new PersonalDA().obtener(oPersonalBE);
		}

		public int insertar(PersonalBE oPersonalBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new PersonalDA().insertar(oPersonalBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int actualizar(PersonalBE oPersonalBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new PersonalDA().actualizar(oPersonalBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}

		public int eliminar(PersonalBE oPersonalBE)
		{
			int result = 0;
			var option = new TransactionOptions
			{
				IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
				Timeout = TimeSpan.FromSeconds(60),
			};
			using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, option))
			{
				result = new PersonalDA().eliminar(oPersonalBE);
				if(result != 0) transactionScope.Complete();
				return result;
			}
		}
	}
}
