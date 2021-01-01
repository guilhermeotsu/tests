using System;
using System.Collections.Generic;

namespace Demo
{
    public abstract class Pessoa
    {
        public string Nome { get; protected set; }
        public string Apelido { get; set; }
    }

    public class Funcionario : Pessoa
    {
        public Funcionario(string nome, decimal salario)
        {
            Nome = string.IsNullOrEmpty(nome) ? "Fulano" : nome;
            DefinirSalario(salario);
        }
        public decimal Salario { get; private set; }
        public IList<string> Habildades { get; set; }
        public NivelProfissional Senioridade { get; set; }

        private void DefinirSalario(decimal salario)
        {
            if (salario < 500)
                throw new Exception("Salario inferior ao permitido!");

            Salario = salario;

            if (salario < 2000)
                Senioridade = NivelProfissional.Junior;
            else if (salario >= 2000 && salario < 8000)
                Senioridade = NivelProfissional.Pleno;
            else
                Senioridade = NivelProfissional.Senior;
        }

        private void DefinirHabilidade()
        {
            var habilidades = new List<string>
            {
                "Lógica Programação",
                "OOP"
            };

            Habildades = habilidades;

            switch (Senioridade)
            {
                case NivelProfissional.Pleno:
                    Habildades.Add("TDD");
                    break;
                case NivelProfissional.Senior:
                    Habildades.Add("TDD");
                    habilidades.Add("Microservices");
                    break;
            }
        }
    }

    public enum NivelProfissional
    {
        Junior,
        Pleno,
        Senior
    }
}
