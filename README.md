#
📌 DIO - Trilha .NET - Fundamentos

Este repositório contém a solução para o desafio de projeto do módulo Fundamentos .NET da DIO (Digital Innovation One)
.
#
🚀 Desafio de Projeto

O objetivo foi desenvolver um sistema de estacionamento em C#, capaz de gerenciar veículos e realizar operações básicas como adicionar, remover e listar veículos.

O programa foi implementado como uma aplicação console em .NET, utilizando listas e operações interativas com o usuário.
#
📖 Contexto

O sistema simula o funcionamento de um estacionamento, permitindo:

Adicionar um veículo pela placa.

Remover um veículo, informando o tempo estacionado e calculando o valor a pagar.

Listar todos os veículos atualmente no pátio.

Encerrar o programa através de um menu interativo.
#
📌 Estrutura da Classe Estacionamento

A classe Estacionamento possui:

Variáveis

precoInicial (decimal) → valor fixo cobrado ao entrar.

precoPorHora (decimal) → valor por hora estacionado.

veiculos (List<string>) → lista com as placas dos veículos estacionados.

Métodos

AdicionarVeiculo() → adiciona um veículo à lista.

RemoverVeiculo() → remove um veículo, calcula e exibe o valor a pagar.

ListarVeiculos() → exibe todos os veículos estacionados.

#🖥️ Menu Interativo

O programa apresenta as seguintes opções no console:

Cadastrar veículo

Remover veículo

Listar veículos

Encerrar
#
🖥️ Exemplo de Uso
// Cadastro de veículo
Estacionamento est = new Estacionamento(precoInicial: 5, precoPorHora: 2);

est.AdicionarVeiculo(); // Usuário digita: ABC-1234
est.ListarVeiculos();   // Exibe: "Veículos estacionados: ABC-1234"

est.RemoverVeiculo();   // Usuário informa placa e horas
// Exibe valor calculado: precoInicial + (precoPorHora * horas)

#📚 Aprendizados

Criação de classes e métodos em C#.

Uso de listas (List<string>).

Interação com o usuário via console.

Aplicação de validações simples.

Implementação de menus interativos.

✍️ Desenvolvido como parte da Trilha .NET - DIO.
