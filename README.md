## Projeto JomedAPI

O projeto "JomedAPI" é uma aplicação que permite a gestão completa de médicos e pacientes, oferecendo funcionalidades de criação, consulta, atualização e exclusão (CRUD). A API facilita o agendamento e cancelamento de consultas, utilizando o ID do médico e o ID do paciente como chaves estrangeiras, além de um datetime para especificar o horário da consulta.
A API também permite a desativação de médicos e pacientes. Desativar um médico ou paciente não os exclui permanentemente, apenas os marca como inativos, possibilitando sua reativação futura.
Para realizar o login, é necessário autenticar-se utilizando JSON Web Tokens (JWT). O sistema assegura que apenas usuários autenticados possam acessar e manipular os dados, uma vez que o token JWT deve ser incluído nas requisições para autenticação.
Para as requisições do método DELETE, o usuário autenticado precisa ter a Role de Administrador.
Para cadastrar médicos e pacientes, é necessário fornecer um endereço completo, que inclui dados como rua, número e bairro, entre outros.

| :placard: Vitrine.Dev | Guilherme Henrique            |
| --------------------- | ----------------------------- |
| :sparkles: Nome       | JomedAPI                      |
| :label: Tecnologias   | ASP.NET, .NET, C#, SQL Server |
| :inbox_tray: Download | Download App (em breve)       |

## Detalhes do projeto

> - **Cadastrar, Alterar, Deletar, Inativar, Ativar e Listar médicos: Permite a criação, atualização, exclusão e listagem de médicos.**
> - **Cadastrar, Alterar, Deletar, Inativar, Ativar e Listar pacientes: Permite a criação, atualização, exclusão e listagem de pacientes.**
> - **Cadastrar e Deletar usuários: Permite a criação para a autenticação e deleção de usuários.**
> - **Agendar uma consulta.**
> - **Cancelar uma consulta.**
> - **Login com JWT: As operações POST, PUT e DELETE requerem autenticação via JWT, obtido através do endpoint /Login.**

As requisições com os verbos POST e PUT precisam ser autenticadas com o Jwt obtido através do endpoint de `/Login`, cadastrado através do `POST /Usuarios` (livre de autenticação).
<br>
As requisições para o verbo DELETE precisa ser autenticada com a Role do usuário sendo `Administrador`. O usuário ao ser criado é cadastrado com a Role de `Usuario`.

## Escalamento do projeto

- Implementado os conceitos de repository, para a clareza do código, desenvolvimento guiado via testes (TDD). ✅
- Implementado 52 testes para garantir a qualidade do código. ✅
- Implementado segurança de login, com o JWT. ✅
- Implementado a ativação dos médicos e pacientes. ✅
- Implementado a autenticação do usuário com funções (`Usuario` e `Administrador`) onde somente o Administrador pode fazer requisições DELETE. ✅
- Criar as telas com windows forms para realizar as operações.
- Implementar um app com Flutter para o consumo da API.

## Configurando o projeto

Faça um clone do repositório em seu diretório de preferencia, adicione o arquivo `appsettings.json` na raiz do projeto JomedAPI, você pode utilizar o modelo disponibilizado [Aqui][appsettings].<br>
Faça a alteração da chave do JWT, e a alteração da connection string do seu banco de dados SQL Server. Na raiz do projeto execute o comando `dotnet ef migrations add "Criando as migrações para o banco de dados."`, e depois `dotnet ef database update`.
Dessa forma o banco de dados estará atualizado para rodar a aplicação.

## Login

- `POST /Login`: Essa rota recebe através do corpo da requisição um JSON com os dados de `login` e `senha` do usuário cadastrado no banco de dados.

  ```json
  {
    "email": "guilherme@gmail.com",
    "senha": "123456"
  }
  ```

  A resposta será um [HTTP 200][http200] junto com o token utilizando o JWT, o qual deve ser incluído nas futuras requisições, para assim evitar o retorno do código [HTTP 403][http403].
  Não valida caso seja passado o login ou a senha vazio ou incorretos retornando [HTTP 400][http400] com a mensagem de erro `E-mail inválido` ou `Senha inválida.`.
  Caso o usuário não seja localizado com o login, retorna [HTTP 404][http404] com a mensagem de erro `Usuário não encontrado`.

<br>

## Usuários

- `POST /Usuarios`: Essa rota recebe através do corpo da requisição um JSON com os dados de `login`, `senha` e `confirmarSenha` do usuário para cadastrar no banco de dados.

  ```json
  {
    "email": "user@example.com",
    "senha": "string",
    "confirmarSenha": "string"
  }
  ```

  Caso esteja tudo correto, a resposta será um [HTTP 200][http200] com o JSON do usuário cadastrado.
  Não valida caso seja passado o login, senha ou a confirmação da senha vazio ou incorretos retornando [HTTP 400][http400] e a mensagem de erro de qual campo não foi validado.
  E caso o e-mail já esteja cadastrado, retorna [HTTP 400][http400] com a mensagem de erro `Usuário já cadastrado.`.

- `DELETE /Usuarios/{id}`: Essa rota tem a finalidade de deletar o cadastro do usuário, passando o `id`.
  Caso o usuário seja encontrado, é deletado e retornado um [HTTP 204][http204], informando que a requisição foi bem sucedida mas não retornou nada. Mas se não for encontrado, é retornado um [HTTP 404][http404] e a mensagem `Usuário não encontrado`.
  <br> Para fazer essa requisição, o usuário logado precisa ter a Role `Administrador`.

<br>

## Médicos

- `POST /Medicos`: Essa rota tem a finalidade de cadastrar um médico e recebe através do corpo da requisição um JSON com os dados: `nome`,`email`,`telefone`,`crm`,`especialidade` e `endereço`.

  ```json
  {
    "nome": "Pedro de Lara",
    "email": "pedro-lara@yahoo.com",
    "telefone": "6532658982",
    "crm": "985236",
    "especialidade": "GINECOLOGIA",
    "endereco": {
      "logradouro": "Rua dos bobos",
      "bairro": "bairro dos bobos",
      "cep": "12345678",
      "cidade": "Cidade dos bobos",
      "uf": "MG",
      "numero": "0",
      "complemento": ""
    }
  }
  ```

  Os valores da especialidade são valores enumerados conforme a regra de negócio do projeto, aqui no caso são quatro
  possibilidades sendo elas: `ORTOPEDIA`,`CARDIOLOGIA`,`GINECOLOGIA` e `DERMATOLOGIA`.
  O endereço deve ser passado como um objeto, contendo os campos de `logradouro`,`bairro`,`cep`,`cidade`,`uf`,`numero`
  e `complemento`.
  A resposta em caso de sucesso é um [HTTP 200][http200] com o JSON do médico criado. O dto de criação de médico possui uma série de validações dos dados, o qual não é criado caso esteja errado.
  No caso de erro, é retornado o [HTTP 400][http400] e a mensagem de erro de qual campo não foi validado.

- `POST /Medicos/{id}/ativar`: Essa rota tem a finalidade de ativar o cadastro um médico inativo com o `id` informado.
  Caso o médico com o `id` informado não for encontrado, retorna o [HTTP 404][http404] com a mensagem `Médico não encontrado.`.
  Caso o médico com o `id` informado já esteja ativo, retorna o [HTTP 400][http400] com a mensagem `Médico já está ativo.`.
  Se não, ativa o médico e retorna o [HTTP 200][http200] com os dados do médico ativado.

- `GET /Medicos`: Essa rota tem a finalidade de listar os médicos cadastrados. A resposta é um [HTTP 200][http200] com o JSON da lista de médicos cadastrados.

  ```json
  [
    {
      "Id": 1,
      "Nome": "string",
      "Email": "user@.com",
      "Telefone": "4823953-1037",
      "Crm": "string",
      "Especialidade": 0,
      "Endereco": {
        "Logradouro": "stringstri",
        "Bairro": "string",
        "Cep": "92950534",
        "Cidade": "string",
        "Uf": "2N",
        "Numero": 0,
        "Complemento": "string"
      },
      "Ativo": true
    }
  ]
  ```

- `GET /Medicos/{id}`: Essa rota tem a finalidade de detalhar o cadastro do médicos, passando o `id` do médico.

  ```json
  {
    "Id": 3,
    "Nome": "string",
    "Email": "user@.com",
    "Telefone": "4823953-1037",
    "Crm": "string",
    "Especialidade": 0,
    "Endereco": {
      "Logradouro": "stringstri",
      "Bairro": "string",
      "Cep": "92950534",
      "Cidade": "string",
      "Uf": "2N",
      "Numero": 0,
      "Complemento": "string"
    },
    "Ativo": true
  }
  ```

  A resposta é um um [HTTP 200][http200] e o JSON com os dados do médico cadastrado com o `id` informado.
  Caso o médico não seja encontrado, é [HTTP 404][http404] e a mensagem `Médico não encontrado`.

- `PUT /Medicos/{id}`: Essa rota tem a finalidade de alterar o cadastro do médico, passando o `id`, e no corpo da requisição o JSON com os dados que desejamos alterar.

  ```json
  {
    "nome": "Maria Joaquina",
    "telefone": "19982210064"
  }
  ```

  A resposta será um [HTTP 200][http200] e o JSON com os dados do médico com o `id` informado alterado. No caso, a resposta seria a seguinte:

  ```json
  {
    "Id": 1,
    "Nome": "Maria Joaquina",
    "Email": "asdesa@example.com",
    "Telefone": "19982210064",
    "Crm": "414717",
    "Especialidade": 0,
    "Endereco": {
      "Logradouro": "stringstri",
      "Bairro": "string",
      "Cep": "78970-452",
      "Cidade": "string",
      "Uf": "2I",
      "Numero": 0,
      "Complemento": "string"
    },
    "Ativo": true
  }
  ```

  Caso não seja encontrado o médico com o `id` informado, a resposta é [HTTP 404][http404] e a mensagem `Médico não encontrado`.

- `PUT /Medicos/{id}/atualizarEndereco`: Essa rota tem a finalidade de alterar o endereço do médico, passando o `id`, e no corpo da requisição o JSON com os campos do endereço que desejamos alterar.

  ```json
  {
    "bairro": "Jardim Bela Vista",
    "numero": 50
  }
  ```

  A resposta será um [HTTP 200][http200] e o JSON com os dados do médico com o `id` informado com o endereço alterado. No caso, a resposta seria a seguinte:

  ```json
  {
    "Id": 1,
    "Nome": "Maria Joaquina",
    "Email": "asdesa@example.com",
    "Telefone": "19982210064",
    "Crm": "414717",
    "Especialidade": 0,
    "Endereco": {
      "Logradouro": "stringstri",
      "Bairro": "Jardim Bela Vista",
      "Cep": "78970-452",
      "Cidade": "string",
      "Uf": "2I",
      "Numero": 50,
      "Complemento": "string"
    },
    "Ativo": true
  }
  ```

  Caso não seja encontrado o médico com o `id` informado, a resposta é [HTTP 404][http404] e a mensagem `Médico não encontrado`.
  No caso de erro, é retornado o [HTTP 400][http400] e a mensagem de erro de qual campo não foi validado.

- `DELETE /Medicos/{id}`: Essa rota tem a finalidade de deletar o cadastro do médico, passando o `id` do médico.
  Caso o médico seja encontrado, é deletado e retornado um [HTTP 204][http204], informando que a requisição foi bem sucedida mas não retornou nada. Mas se não for encontrado, é retornado um [HTTP 404][http404] e a mensagem `Médico não encontrado`.
  <br> Para fazer essa requisição, o usuário logado precisa ter a Role `Administrador`.

- `DELETE /Medicos/{id}/inativar`: Essa rota tem a finalidade de inativar o cadastro do médico, passando o `id` do médico.
  Caso o médico seja encontrado, é inativado e retornado um [HTTP 204][http204], informando que a requisição foi bem sucedida mas não retornou nada. Mas se não for encontrado, é retornado um [HTTP 404][http404] e a mensagem `Médico não encontrado`.
  <br> Para fazer essa requisição, o usuário logado precisa ter a Role `Administrador`.

<br>

## Pacientes

- `POST /Pacientes`: Essa rota tem a finalidade de cadastrar um paciente e recebe através do corpo da requisição um JSON com os dados: `nome`,`email`,`cpf`,`telefone`, e `endereço`.

  ```json
  {
    "nome": "José da Silva",
    "email": "jose@example.com",
    "cpf": "456418901-03",
    "telefone": "7393686-8266",
    "endereco": {
      "logradouro": "stringstri",
      "bairro": "string",
      "cep": "88479-104",
      "cidade": "string",
      "uf": "ui",
      "numero": 0,
      "complemento": "string"
    }
  }
  ```

  O endereço deve ser passado como um objeto, contendo os campos de `logradouro`,`bairro`,`cep`,`cidade`,`uf`,`numero` e `complemento`.
  A resposta em caso de sucesso é um [HTTP 200][http200] com o JSON do paciente criado. O dto de criação de paciente possui uma série de validações dos dados, o qual não é criado caso esteja errado.
  No caso de erro, é retornado o [HTTP 400][http400] e a mensagem de erro de qual campo não foi validado.

- `POST /Pacientes/{id}/ativar`: Essa rota tem a finalidade de ativar o cadastro um paciente inativo com o `id` informado.
  Caso o paciente com o `id` informado não for encontrado, retorna o [HTTP 404][http404] com a mensagem `Paciente não encontrado.`.
  Caso o paciente com o `id` informado já esteja ativo, retorna o [HTTP 400][http400] com a mensagem `Paciente já está ativo.`.
  Se não, ativa o paciente e retorna o [HTTP 200][http200] com os dados do paciente ativado.

- `GET /Pacientes`: Essa rota tem a finalidade de listar os pacientes cadastrados. A resposta é um [HTTP 200][http200] com o JSON da lista de pacientes cadastrados.

  ```json
  [
    {
      "Id": 1,
      "Nome": "jose@example.com",
      "Email": "user@example.com",
      "Cpf": "307430070-40",
      "Telefone": "6233311-7635",
      "Endereco": {
        "Logradouro": "stringstri",
        "Bairro": "string",
        "Cep": "15741927",
        "Cidade": "string",
        "Uf": "EF",
        "Numero": 0,
        "Complemento": "string"
      },
      "Ativo": true
    }
  ]
  ```

- `GET /Pacientes/{id}`: Essa rota tem a finalidade de detalhar o cadastro do paciente com o `id` informado.

  ```json
  {
    "Id": 10,
    "Nome": "string",
    "Email": "user@example.com",
    "Cpf": "307430070-40",
    "Telefone": "6233311-7635",
    "Endereco": {
      "Logradouro": "stringstri",
      "Bairro": "string",
      "Cep": "15741927",
      "Cidade": "string",
      "Uf": "EF",
      "Numero": 0,
      "Complemento": "string"
    },
    "Ativo": true
  }
  ```

  A resposta é um um [HTTP 200][http200] e o JSON com os dados do paciente cadastrado com o `id` informado. Caso o paciente não seja encontrado, é [HTTP 404][http404] e a mensagem `Paciente não encontrado`.

- `PUT /Pacientes/{id}`: Essa rota tem a finalidade de alterar o cadastro do paciente, passando o `id`, e no corpo da requisição o JSON com os dados que desejamos alterar.

  ```json
  {
    "nome": "Pedrinho",
    "email": "novo@email.com"
  }
  ```

  A resposta será um [HTTP 200][http200] e o JSON com os dados do paciente com o `id` informado alterado. No caso, a resposta seria a seguinte:

  ```json
  {
    "Id": 10,
    "Nome": "Pedrinho",
    "Email": "novo@email.com",
    "Cpf": "320554985-44",
    "Telefone": "8717457-9546",
    "Endereco": {
      "Logradouro": "stringstri",
      "Bairro": "string",
      "Cep": "15741927",
      "Cidade": "string",
      "Uf": "EF",
      "Numero": 0,
      "Complemento": "string"
    },
    "Ativo": true
  }
  ```

  Caso não seja encontrado o paciente com o `id` informado, a resposta é [HTTP 404][http404] e a mensagem `Paciente não encontrado`.

- `PUT /Pacientes/{id}/atualizarEndereco`: Essa rota tem a finalidade de alterar o endereço do paciente, passando o `id`, e no corpo da requisição o JSON com os campos do endereço que desejamos alterar.

  ```json
  {
    "logradouro": "Rua Alterada",
    "bairro": "Com",
    "cidade": "Sucesso"
  }
  ```

  A resposta será um [HTTP 200][http200] e o JSON com os dados do paciente com o `id` informado com o endereço alterado. No caso, a resposta seria a seguinte:

  ```json
  {
    "Id": 10,
    "Nome": "Pedrinho",
    "Email": "novo@email.com",
    "Cpf": "320j554&985-44",
    "Telefone": "8717457-9546",
    "Endereco": {
      "Logradouro": "Rua Alterada",
      "Bairro": "Com",
      "Cep": "15741927",
      "Cidade": "Sucesso",
      "Uf": "EF",
      "Numero": 0,
      "Complemento": "string"
    },
    "Ativo": true
  }
  ```

  Caso não seja encontrado o paciente com o `id` informado, a resposta é [HTTP 404][http404] e a mensagem `Paciente não encontrado`.
  No caso de erro, é retornado o [HTTP 400][http400] e a mensagem de erro de qual campo não foi validado.

- `DELETE /Pacientes/{id}`: Essa rota tem a finalidade de deletar o cadastro do paciente com o `id` do informado.
  Caso o paciente seja encontrado, é deletado e retornado um [HTTP 204][http204], informando que a requisição foi bem sucedida mas não retornou nada. Mas se não for encontrado, é retornado um [HTTP 404][http404] e a mensagem `Paciente não encontrado`.
  <br> Para fazer essa requisição, o usuário logado precisa ter a Role `Administrador`.

- `DELETE /Pacientes/{id}/inativar`: Essa rota tem a finalidade de inativar o cadastro do paciente com o `id` do informado.
  Caso o paciente seja encontrado, é inativado e retornado um [HTTP 204][http204], informando que a requisição foi bem sucedida mas não retornou nada. Mas se não for encontrado, é retornado um [HTTP 404][http404] e a mensagem `Paciente não encontrado`.
  <br> Para fazer essa requisição, o usuário logado precisa ter a Role `Administrador`.

<br>

## Consultas

- `POST /Consultas`: Essa rota tem a finalidade de cadastrar uma consulta para um paciente. Deve ser passado no corpo da requisição um JSON com os campos do `idMedico`, `idPaciente`, e a `data`. Exemplo:

  ```json
  {
    "idMedico": 7,
    "idPaciente": 1,
    "data": "2024-05-27T15:52:07.117Z"
  }
  ```

  A data deve obrigatóriamente ser uma data futura, caso o contrario a resposta será um JSON [HTTP 400][http400] e a mensagem `A data deve ser futura.`.
  Caso não seja encontrado o médico com o `id` informado, a resposta é [HTTP 404][http404] e a mensagem `Médico não encontrado`.
  Caso não seja encontrado o paciente com o `id` informado, a resposta é [HTTP 404][http404] e a mensagem `Paciente não encontrado`.
  Temos aqui uma validação da regra de negócio de horário da clínica, o qual deve ser um dia da semana e estar entre as 7 e 18h.
  
  ```C#
    private bool ValidaData(DateTime data)
    {
        int hora = data.Hour;
        DayOfWeek diaDaSemana = data.DayOfWeek;
        if ((hora >= 7 && hora <= 18) && (diaDaSemana != DayOfWeek.Saturday && diaDaSemana != DayOfWeek.Sunday)) return true;
        return false;
    }
  ```

  Em caso de sucesso, a resposta será um JSON com os dados da consulta cadastrada:

  ```json
    { 
      "Id": 19,
      "MedicoId": 53,
      "PacienteId": 181,
      "Data": "2024-06-03T10:00:58Z"
    }
  ```

- `GET /Consultas`: Essa rota tem a finalidade de listar as consultas dos pacientes cadastradas. A resposta é um [HTTP 200][http200] com o JSON da lista de consultas.

  ```json
  [
    {
      "Id": 19,
      "MedicoId": 53,
      "PacienteId": 181,
      "Data": "2024-06-03T10:00:58Z"
    },
    {
      "Id": 20,
      "MedicoId": 54,
      "PacienteId": 185,
      "Data": "2024-06-04T15:00:58Z"
    },
    {
      "Id": 21,
      "MedicoId": 53,
      "PacienteId": 185,
      "Data": "2024-06-05T15:00:58Z"
    }
  ]
  ```

- `DELETE /Consultas/{id}`: Essa rota tem a finalidade de cancelar uma consulta cadastrada com o `id` informado. Deve ser passado no corpo da requisição um JSON com o campo de `motivoCancelamento`, o qual também é um enum e deve
  ser `PACIENTE_CANCELOU`, `MEDICO_CANCELOU`, `MUDANCA_HORARIO` ou `OUTROS`.
  A coluna `Cancelado` da consulta passa a ser `true` e o motivo passa a ser o informado no JSON de cancelamento.
  <br> Para fazer essa requisição, o usuário logado precisa ter a Role `Administrador`.

  ```json
  {
    "motivoCancelamento": 1
  }
  ```

  A resposta da requisição acima será um código [HTTP 204][http204], informando que a requisição foi bem sucedida, porém não retornou nada.
  Caso a consulta não for encontrada, é retornado um [HTTP 404][http404] e a mensagem `Consulta não encontrada`

<br>

## Windows Forms

A entrada no sistema começa na tela de login, o qual faz uma requisição para `/Login` com os dados do formulário. Apresenta os erros de login caso possua ou abre a tela principal do sistema.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/login.png)

A API retorna um JWT com os dados do usuário, o qual é armazenado pelo sistema para fazer as requisições, a fim de evitar o erro [HTTP 401][http401] e o [HTTP 403][http403] caso o usuário não seja `Administrador`.

<br>

Ao clicar no botão "cadastrar" na tela de login, abre a tela para o cadastro de usuários, que faz a requisição para /Usuarios enviando os dados do formulário. 
Ao cadastrar um novo usuário, esse terá a Role como `Usuario`.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/cadastrar.png)

Caso tenha erros, é exibido no label de mensagem, e em caso de sucesso é mostrado uma mensagem de sucesso e redirecionado para a tela de login e preenchendo o campo de e-mail com o e-mail cadastrado.

<br>

Ao fazer o login corretamente, é aberto da tela principal do sistema.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/principal.png)

Aqui temos o menu, onde é possivel fazer o gerenciamento dos cadastros de consultas, médicos e pacientes. Abaixo tem a informação da função do usuário logado e o seu e-mail.

<br>

Na tela de cadastro de pacientes é possivel fazer a inclussão, alteração e caso o usuário logado seja um `Administrador` a exclusão e inativação dos pacientes.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/pacientes.png)

Os icones de `exclusão` e `ativo` ficam invisíveis se o usuário não for administrador.<br>

Ao selecionar ou buscar um paciente, os dados são preenchidos no formulário, e o menu é alterado para um modo de edição.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/pacientesEdicao.png)

O CEP tem um autopreenchimento via API do [viacep][viacep].

<br>

Ao clicar na lupa do formulário é aberto a tela de busca de pacientes, o qual pode ser feito filtros por `ativo/inativo`, `Id`, `Nome`,`Cpf` ou `E-mail`.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/buscar.png)

Ao selecionar o paciente, o formulário de cadastro de pacientes é preenchido no modo de edição.

<br>

A tela de cadastro de consultas permite realizar a consulta, inclusão e exclusão das consultas ativas.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/cadastroConsultas.png)

Ao clicar em novo é formulário é desbloqueado para a inclusão da nova consulta.
<br>
Ao clicar duas vezes sobre uma consulta, o formulário é preenchido com os dados da consulta selecionada e caso o usuáriro seja um `Administrador` é liberado o icone do menu para a exclusão.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/cadastroConsultaEdicao.png)

Ao clicar no icone de exclusão, a tela de cancelamento de consulta é aberta, solicitando que seja informado o motivo do cancelamento da consulta.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/cancelarConsultas.png)

<br>

Ao clicar no icone de lupa do menu, é aberto a tela de busca de consultas, o qual possui os campos de `data`, `especialidade`, `nome do médico`, `CPF do paciente` e `nome do paciente` para filtro.

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Forms/buscarConsultas.png)

## Imagens

![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/swagger1.png)
![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/swagger2.png)
![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/schemas.png)
![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/medicos.png)
![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/pacientes.png)
![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/consultas.png)
![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/usuarios.png)
![](https://github.com/guih1886/jomedAPI/blob/main/JomedAPI/Assets/Images/testes.png)

<!-- Links -->

[http200]: https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/200
[http204]: https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/204
[http400]: https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/400
[http401]: https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/401
[http403]: https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/403
[http404]: https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/404
[appsettings]: https://raw.githubusercontent.com/guih1886/jomedAPI/main/JomedAPI/Assets/appsettings.json
[viacep]: https://viacep.com.br/