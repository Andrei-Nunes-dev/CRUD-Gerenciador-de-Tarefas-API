
# CRUD_Tarefas_API
Uma API para gerenciar as operações de criar, visualizar, editar e deletar as tarefas de uma aplicação de Gerenciamento de Tarefas.

## Executando a API
Para executar a API foi utilizado o Microsoft Visual Studio 2022, e foi executado em Http.

**Obs:** Quando a API for executada é para o SwaggerUI abrir uma janela de forma automática. A URL deve ser: "http://localhost:5097/swagger/index.html", sendo a porta definida no arquivo "launchSettings.json" do projeto.

## Métodos e URLs de acesso
|Método|Descrição  |
|--|--|
|GET| Retorna informações de um ou mais tarefas|
|POST| Cria uma nova tarefa  |
|PUT|  Atualiza os dados de uma tarefa|
|DELETE|  Remove uma tarefa do sistema|

![Imgur Image](https://imgur.com/eE2BVOZ,jpg)


## Detalhes de Implementação

### .NET 6.0 e Pacotes utilizados

   > Microsoft.AspNet.WebApi.Cors  5.3.0    
   > Microsoft.EntityFrameworkCore 6.0.6
   > Microsoft.EntityFrameworkCore.Design 6.0.6 
   > Microsoft.EntityFrameworkCore.Tools 6.0.6    
   >  Pomelo.EntityFrameworkCore.MySql   6.0.1    
   > Swashbuckle.AspNetCore 6.6.2 

- O Microsoft.EntityFrameworkCore, Design e Tools são usados para gerenciar e mapear os objetos-relacionais e também gerenciar as Migrations.
- O Microsoft.AspNet.WebApi.Cors é usado para permitir que a aplicação se conecte a API
- Pomelo.EntityFrameworkCore.MySql é usado para conectar a API ao MySQL
- Swashbuckle.AspNetCore é uma ferramenta do Swagger para gerar a documentação da API.
- **Obs:** Decidiu-se utilizar versões mais antigas do .NET e dos pacotes devido a problemas de compatibilidade que estavam ocorrendo entre as versões mais novas do Pomelo e o .NET durante a configuração do "DBContext".

### MySQL
- Para usar o MySQL foi criado um usuário de ID "root" e senha "senhaDesafio123%".
- A base de dados "to_do_list" precisa ser criada direto pelo MySQL.
- A tabela "tarefas" pode ser criada tanto pelo MySQL como também utilizando o Migrations no terminal do projeto no Microsoft Visual Studio Microsoft Visual Studio 2022.
- Para gerar a tabela pelo terminal, usa-se os comandos "add-migration InitialCreate" e "update-database".

### Possíveis melhorias
- Estabelecer diferentes status de respostas para os métodos. No momento a API retorna apenas os status 200 para "Sucesso" e 404 para "Não encontrado".
- Validar os dados enviados pela aplicação. No momento a validação dos dados depende da implementação da API.
- Adicionar um atributo de data para quando a tarefa foi criada.


[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)
   


  
