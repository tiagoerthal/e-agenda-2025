﻿using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Testes.Integracao.ModuloContato
{
    [TestClass]
    public sealed class RepositorioContatoEmOrmTestes
    {
        private static readonly AppDbContext dbContext = AppDbContextFactory.CriarDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=E-agendaDb;Integrated Security=True");
        private static RepositorioContatoEmOrm repositorioContato = new RepositorioContatoEmOrm(dbContext);

        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            Contato contato = new Contato(
                "Juninho Testes 2",
                "(49) 98533-3334",
                "testes@academiadoprogramador.net",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contato);

            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contato.Id);

            // Asserção
            Assert.AreEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_RetornarNulo_Ao_SelecionarRegistroPorId_ComIdErrado()
        {
            Contato contato = new Contato(
                "Juninho Testes 2",
                "(49) 98533-3334",
                "testes@academiadoprogramador.net",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contato);

            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(Guid.NewGuid());

            // Asserção
            Assert.AreNotEqual(contato, contatoSelecionado);
        }
        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
        {
            // Padrão AAA
            // Arranjo
            Contato contatoOriginal = new Contato(
                "Juninho Testes",
                "(49) 98533-3334",
                "testes@academiadoprogramador.net",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contatoOriginal);

            Contato contatoEditado = new Contato(
                "Pedrinho do Código",
                "(49) 99452-5234",
                "pedrinho_codigos@academiadoprogramador.net",
                "Academia do Programador",
                "Desenvolvedor"
            );

            // Ação
            repositorioContato.EditarRegistro(contatoOriginal.Id, contatoEditado);

            // Asserção
            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.AreEqual(contatoOriginal, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_ExcluirRegistro_ComSucesso()
        {
            // Arranjo
            Contato contatoOriginal = new Contato(
                "Juninho Testes",
                "(49) 98533-3334",
                "testes@academiadoprogramador.net",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contatoOriginal);

            // Ação
            repositorioContato.ExcluirRegistro(contatoOriginal.Id);

            // Asserção
            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.IsNull(contatoSelecionado);
        }
    }
}
