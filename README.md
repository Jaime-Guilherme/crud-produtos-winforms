# CRUD de Produtos - Análise Orientada a Objetos

Sistema CRUD de gerenciamento de produtos desenvolvido em Windows Forms com C#, utilizando o padrão Modal para cadastro e edição.

## Sobre o Projeto

Este projeto foi desenvolvido como atividade da disciplina **Análise Orientada a Objetos**, com o objetivo de aplicar os conceitos de encapsulamento, separação de responsabilidades e boas práticas de programação.

## Funcionalidades

- Cadastro de novos produtos através de janela modal
- Edição de produtos existentes (modal)
- Exclusão de produtos
- Listagem dos produtos em DataGridView
- Validações básicas de campos obrigatórios
- Interface limpa e intuitiva

## Tecnologias Utilizadas

- C# .NET
- Windows Forms
- Visual Studio Code
- Padrão Modal (ShowDialog)
- Separação de responsabilidades (Form principal + Form de cadastro)

## Estrutura do Projeto
CrudProdutos/
├── Models/
│   └── Produtos.cs          # Classe de domínio (Produto)
├── Form1.cs                 # Tela principal com Grid
├── FrmCadastroProduto.cs    # Modal de cadastro e edição
├── Program.cs
└── .gitignore
text## Como Executar

1. Clone o repositório
2. Abra a pasta no Visual Studio Code
3. Execute o comando:

```bash
dotnet run
Requisitos

.NET SDK 6.0 ou superior

Autor
Jaime Guilherme Caceda
Disciplina: Análise Orientada a Objetos