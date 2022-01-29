using System;
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
        public Customer GenerateValidCustomer()
				{
						var gender = new Faker().PickRandom<Gender>();

						var customer = new Faker<Customer>("pt_BR")
								.CustomInstantiator(c => new Customer(
														Guid.NewGuid(),
														c.Name.FirstName(gender),
														c.Name.LastName(gender),
														c.Date.Past(80, DateTime.Now.AddYears(-18)),
														string.Empty,
														DateTime.Now))
								.RuleFor(f => f.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName));

						/* var customer = new Customer( */
						/* 				Guid.NewGuid(), */
						/* 				"Guilherme", */
						/* 				"Otsu", */
						/* 				DateTime.Now.AddYears(-23), */
						/* 				DateTime.Now); */

						return customer;
				}

				public Customer GenerateInvalidCustomer()
				{
						var customer = new Customer(
										Guid.NewGuid(),
										"",
										"",
										DateTime.Now.AddYears(-17),
										string.Empty,
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

