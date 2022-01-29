using System;
using Feature.Customer;
using Xunit;

namespace Tests.Fixtures
{
		// Fixtures são criadas antes das classes de testes e após executar todos os testes é chamado
		// o Dispose para destruir o objeto.
		// Class fixture utilizado para qndo quer armazenar algum tipo de estado entre
		// os testes de uma unica classe.
		// Compartilhamento de uma unica instancia entre os testes de uma classe
		public class CustomerTestFixture : IDisposable
		{
        public Customer GenerateValidCustomer()
				{
						var customer = new Customer(
										Guid.NewGuid(),
										"Guilherme",
										"Otsu",
										DateTime.Now.AddYears(-23),
										DateTime.Now);

						return customer;
				}

				public Customer GenerateInvalidCustomer()
				{
						var customer = new Customer(
										Guid.NewGuid(),
										"",
										"",
										DateTime.Now.AddYears(-17),
										DateTime.Now);

						return customer;
				}

        public void Dispose() { }
		}

		// Class fixture collectio utilizado para qndo quer armazenar algum tipo de estado entre
		// os testes de varias classes em comum, para isso necessario adicionar [CollectionDefinition]
		// nas classes que se vai testar
		// Compartilhamento de uma unica instancia entre os testes de varias classe
		[CollectionDefinition(nameof(CustomerCollection))]
		public class CustomerCollection : ICollectionFixture<CustomerTestFixture> { }
}

