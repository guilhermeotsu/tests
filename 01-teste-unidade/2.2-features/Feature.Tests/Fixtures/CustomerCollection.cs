using System;
using System.Collections.Generic;
using Bogus;
using Feature.Customer;
using Xunit;
using static Bogus.DataSets.Name;

namespace Tests.Fixtures
{
		// Fixtures são criadas antes das classes de testes e após executar todos os testes é chamado
		// o Dispose para destruir o objeto.
		// Class fixture utilizado para qndo quer armazenar algum tipo de estado entre
		// os testes de uma unica classe.
		// Compartilhamento de uma unica instancia entre os testes de uma classe
		public class CustomerTestFixture : IDisposable
		{
        public IEnumerable<Customer> GenerateValidCustomer()
				{
						var gender = new Faker().PickRandom<Gender>();

						var customers = new Faker<Customer>("pt_BR")
								.CustomInstantiator(c => new Customer(
														Guid.NewGuid(),
														c.Name.FirstName(gender),
														c.Name.LastName(gender),
														c.Date.Past(80, DateTime.Now.AddYears(-18)),
														string.Empty,
														true,
														DateTime.Now))
								.RuleFor(f => f.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName));

						return customers.Generate(10);
				}

				public Customer GenerateInvalidCustomer()
				{
						var gender = new Faker().PickRandom<Gender>();

						var customer = new Faker<Customer>("pt_BR")
								.CustomInstantiator(c => new Customer(
														Guid.NewGuid(),
														string.Empty,
														string.Empty,
														c.Date.Past(80, DateTime.Now.AddYears(-10)),
														string.Empty,
														false,
														DateTime.Now))
								.RuleFor(f => f.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName));

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

