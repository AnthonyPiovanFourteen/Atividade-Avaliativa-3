# GRUPO
LEONARDO - RA2010317
ANTHONY - RA1987602
WENDELL - RA2004501

# PetShop API

API para gestão de animais de estimação e seus donos.

## Funcionalidades

- Cadastro, listagem, atualização e remoção de donos de pets
- Cadastro, listagem, atualização e remoção de animais
- Associação entre animais e seus donos
- Documentação via Swagger

## Tecnologias Utilizadas

- ASP.NET Core 8.0 (ou a versão do seu projeto, ex: .NET 8+)
- Entity Framework Core
- SQLite para persistência de dados
- Swagger (Swashbuckle) para documentação da API

## Pré-requisitos

- .NET SDK (compatível com a versão do projeto)
- Git (opcional, para controle de versão)

## Como Executar

1.  **Clone o repositório** (se aplicável) ou certifique-se de que tem todos os arquivos do projeto.
2.  **Navegue até a pasta do projeto `PetShopAPI`** usando um terminal.
3.  **Restaure as dependências** (geralmente automático com `dotnet run`, mas pode ser feito com `dotnet restore`).
4.  **Aplique as Migrations:** Para criar o banco de dados e as tabelas:
    ```
    dotnet ef database update
    ```
    *Se for a primeira vez ou se houver alterações nos modelos que ainda não têm uma migração, crie uma primeiro: `dotnet ef migrations add NomeDaMigracao`*
5.  **Execute o comando:**
    ```
    dotnet run
    ```
6.  **Acesse a documentação Swagger:** Abra seu navegador e vá para a URL indicada no console (ex: `http://localhost:5199/swagger`).

## Endpoints Disponíveis

### Donos
- `GET /api/Donos` - Retorna todos os donos
- `GET /api/Donos/{id}` - Retorna um dono específico e seus animais
- `POST /api/Donos` - Cadastra um novo dono
- `PUT /api/Donos/{id}` - Atualiza dados de um dono
- `DELETE /api/Donos/{id}` - Remove um dono

### Animais
- `GET /api/Animais` - Retorna todos os animais
- `GET /api/Animais/{id}` - Retorna um animal específico
- `GET /api/Animais/PorDono/{donoId}` - Retorna todos os animais de um dono
- `POST /api/Animais` - Cadastra um novo animal
- `PUT /api/Animais/{id}` - Atualiza dados de um animal
- `DELETE /api/Animais/{id}` - Remove um animal

## Exemplos de Uso (JSON)

### Cadastrar um dono
`POST /api/Donos`
{
  "nome": "José Silva",
  "cpf": "123.456.789-00",
  "telefone": "(11) 98765-4321",
  "email": "jose@email.com"
}

### Cadastrar um Animal
`POST /api/Animal`
{
  "nome": "Totó",
  "especie": "Cachorro",
  "raca": "Poodle",
  "idade": 3,
  "peso": 8.5,
  "donoId": 1
}

