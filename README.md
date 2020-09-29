# AssetsManagement

# Descrição
API Para gerenciamento de patrimônio

## Executar
1. Ao baixar o projeto, alterar no arquivo "appsettings.json" para a instância do seu banco de dados.
2. Abrir o package manager console
3. Executar o comando "update-database" para criar o banco de dados com todas as entidades necessárias
4. executar o projeto
5. executar os endpoints via postman

## Enpoints
-   **Assets:**

GET api/assets- Obter todos os patrimônios

GET api/assets/{id} - Obter um patrimônio por ID

POST api/assets - Inserir um novo patrimônio

PUT api/assets/{id} - Alterar os dados de um patrimônio

DELETE assets/{id} - Excluir um patrimônio
-	**Users:**

GET api/user- Obter todos os usuários

GET api/user/{id} - Obter um usuário por ID

POST api/user - Inserir um novo usuário

PUT api/user/{id} - Alterar os dados de um usuário

DELETE api/user/{id} - Excluir um usuário
-	**Autenticação:**
URL: api/user/login
Body:
{
  "name": "admin",
 "email": "admin@admin.com",
 "password": "admin@123"
}

## Arquitetura
Migrations com entityframeworkcore para criação do banco de dados,
AspNetCore.Authentication.JwtBearer e AspNetCore.Authorization para criação do token e security dos métodos da controller
Annotations para validações do modelo

