# Sistema de Estacionamento 🚗

Projeto desenvolvido como parte do desafio de Fundamentos em C# da DIO.
O objetivo é criar um sistema funcional de estacionamento, aplicando conceitos de Programação Orientada a Objetos, manipulação de listas e tratamento de entradas do usuário.

## Funcionalidades

* Adicionar veículos no estacionamento;
* Remover veículos e calcular o valor total com base no tempo estacionado;
* Listar veículos estacionados;
* Validação de entrada numérica para o tempo de permanência;
* Validação de placas de veículos no **padrão Mercosul** (AAA1A23);
* Forçar as placas para maiúsculo automaticamente.

## Tecnologias Utilizadas

* C#
* .NET 8
* Console Application

## Diferenciais Implementados

* Validação de placas no **padrão Mercosul**;
* Interface de console clara e interativa;
* Código modular e organizado em métodos (`AdicionarVeiculo`, `RemoverVeiculo`, `ListarVeiculos`).

## Pré-requisitos
Para rodar o projeto, é necessário ter o dotnet sdk instalado. Ajuste o csproje para a versão do dotnet instalada em seu computatador, caso não possua, baixe no link a baixo:
[Baixar o dotnet sdk mais recente]
(https://dotnet.microsoft.com/pt-br/download)

## Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/gabriel-ribeiro-dev/estaciona-desafio.git
```

2. Acesse a pasta do projeto:

```bash
cd estaciona-desafio
```
3. Acesse a pasta desafio fundamentos
4. Abra o cs proje
5. altere a tag >target framework para a versão correspondente a versão do dotnet instalado
6. Salve o arquivo
7. Execute o projeto:

```bash
dotnet run
```

8. Siga as instruções no console para adicionar, remover ou listar veículos.

## Observações

* O projeto foi feito utilizando conceitos fundamentais de C# e pode ser expandido para funcionalidades futuras, como persistência em arquivo ou integração com banco de dados.

