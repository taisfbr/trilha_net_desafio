# Envio Desafio - DIO - Trilha .NET - Fundamentos
## Descrição
Este projeto trata-se de um sistema de gerenciamento de estacionamento, permitindo a adição, listagem e remoção de veículos. As atualizações recentes melhoraram a validação das placas dos veículos e otimizaram os métodos de manipulação de veículos.

## Atualizações Recentes

### 1. Validação de Placas
- **Criação da Classe `ValidarPlaca`**:
  - Uma nova classe foi implementada para validar as placas dos veículos.
  - Utiliza uma expressão regular (Regex) para garantir que as placas sigam o formato: 3 letras seguidas por 4 números (ex.: ABC1234).

### 2. Método `AdicionarVeiculo`
- **Atualização**:
  - O método foi atualizado para instanciar a classe `ValidarPlaca`.
  - Implementação de um loop `while` para garantir que o usuário digite uma placa válida antes de continuar.
  - As placas são armazenadas na lista `veiculos` utilizando `ToUpper()` para manter a consistência no formato.

### 3. Método `ListarVeiculos`
- **Atualização**:
  - Agora utiliza um `foreach` para listar os veículos registrados.
  - Mostra a vaga correspondente onde cada carro está estacionado, melhorando a legibilidade da listagem.

### 4. Método `RemoverVeiculo`
- **Atualização**:
  - O método foi aprimorado para verificar se a quantidade de horas informada é válida.
  - Implementa a somatória do valor total pelo tempo que o veículo permaneceu no estacionamento, considerando tarifas previamente definidas.

## Funcionalidades
- Adicionar um veículo com validação de placa.
- Listar todos os veículos estacionados com suas respectivas vagas.
- Remover um veículo verificando a quantidade de horas e calculando o valor do estacionamento.

Update 04/03/2025 - Thomas Roodson
___
# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.
