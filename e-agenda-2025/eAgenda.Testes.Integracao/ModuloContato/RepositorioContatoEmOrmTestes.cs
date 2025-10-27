﻿using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Testes.Integracao.ModuloContato
{
    [TestClass]
    public sealed class RepositorioContatoEmOrmTestes
    {
        private static readonly AppDbContext dbContext = AppDbContextFactory.CriarDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=E-agendaTesteDb;Integrated Security=True");
        private static readonly RepositorioContatoEmOrm repositorioContato = new RepositorioContatoEmOrm(dbContext);

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext.Database.EnsureCreated();

            dbContext.Tarefas.RemoveRange(dbContext.Tarefas);
            dbContext.Despesas.RemoveRange(dbContext.Despesas);
            dbContext.Categorias.RemoveRange(dbContext.Categorias);
            dbContext.Compromissos.RemoveRange(dbContext.Compromissos);
            dbContext.Contatos.RemoveRange(dbContext.Contatos);

            dbContext.SaveChanges();
        }
        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            // Arranjo
            Contato contato = new Contato(
                "Juninho Testes 2",
                "(49) 98533-3334",
                "testes@academiadoprogramador.net",
                "Academia do Programador",
                "Testador"
            );

            // Ação
            repositorioContato.CadastrarRegistro(contato);

            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contato.Id);

            // Asserção
            Assert.AreEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_RetornarNulo_Ao_SelecionarRegistroPorId_ComIdErrado()
        {
            // Arranjo
            Contato contato = new Contato(
                "Juninho Testes 2",
                "(49) 98533-3334",
                "testes@academiadoprogramador.net",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contato);

            // Ação
            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(Guid.NewGuid());

            // Asserção
            Assert.AreNotEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
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

            Contato contatoEditado = new Contato(
                "Pedrinho do Código",
                "(49) 99452-5234",
                "pedrinho_codigos@academiadoprogramador.net",
                "Academia do Programador",
                "Desenvolvedor"
            );

            // Ação
            bool registroEditado = repositorioContato.EditarRegistro(contatoOriginal.Id, contatoEditado);

            // Asserção
            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.IsTrue(registroEditado);
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
            bool registroExcluido = repositorioContato.ExcluirRegistro(contatoOriginal.Id);

            // Asserção
            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.IsTrue(registroExcluido);
            Assert.IsNull(contatoSelecionado);
        }
    }
}
