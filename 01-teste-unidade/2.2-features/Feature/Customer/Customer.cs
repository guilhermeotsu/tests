using System;
using Feature.Core;
using FluentValidation;

namespace Feature.Customer
{
		public class Customer : Entity
		{
				public string FirstName { get; }
				public string LastName { get; }
				public DateTime BirthDate { get; }
				public DateTime RegisterDate { get; }
				public string Email { get; }
				public bool Active { get; private set; }

				protected Customer(){}

				public Customer(
								Guid id,
								string firstName, 
								string lastName,
								DateTime birthDate,
								string email,
								bool active,
								DateTime registerDate)
				{
						Id = id;
						FirstName = firstName;
						LastName = lastName;
						BirthDate = birthDate;
						RegisterDate = registerDate;
						Email = email;
						Active = active;
				}

				public string FullName()
						=> $"{FirstName} {LastName}";

				public bool IsSpecial()
						=> RegisterDate < DateTime.Now.AddYears(-3) && Active;

				public void Inactive()
				{
						Active = false;
				}				

				public override bool IsValid()
				{
						ValidationResult = new CustomerValidation().Validate(this);

						return ValidationResult.IsValid;
				}
		}

		public class CustomerValidation : AbstractValidator<Customer>
		{
				public CustomerValidation()
				{
						RuleFor(q => q.FirstName)
								.NotEmpty().WithMessage("First name is empty")
								.Length(2, 150).WithMessage("Length of first must be between 2 and 150 char");

						RuleFor(q => q.LastName)
								.NotEmpty().WithMessage("LastName name is empty")
								.Length(2, 150).WithMessage("Length of first must be between 2 and 150 char");

						RuleFor(q => q.BirthDate)
								.NotEmpty().WithMessage("BirthDate name is empty")
								.Must(HaveMinumunAge)
								.WithMessage("Minimun age is 18 years");

						/* RuleFor(q => q.Email) */
						/* 		.NotEmpty().WithMessage("Email name is empty") */
						/* 		.EmailAddress().WithMessage("Email is envalid"); */

						RuleFor(q => q.Id)
								.NotEqual(Guid.Empty);
				}

				public static bool HaveMinumunAge(DateTime birthDate)
						=> birthDate <= DateTime.Now.AddYears(-18);
		}
}

