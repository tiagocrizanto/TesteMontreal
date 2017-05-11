# Teste prático Montreal

Tecnologias utilizadas:

  - ASP NET Web API 2
  - Entity Framework 6
  - xUnit
  - Moq
  - Dapper
  - Swagger
   
# Sobre a aplicação
A aplicação foi desenvolvida utilizando DDD, onde, a solution folder *Modulo1* dentro de *Complex Domain* foi criada para representar um bounded context.
O xUnit foi utilizado como framework de testes. Sua escolha foi feita por ser simples de implementar, trabalhar somente com mocks evitando a necessidade de criação de stubs, fakes etc e por ser utilizado como framework de testes do ASP NET conforme pode ser verificado na página oficial https://github.com/aspnet

O Dapper é um micro ORM criado pelo StackOverflow e tem como princial foco a performance. Na página oficial é possível ver comparações com outros ORM's e micro ORM'm https://github.com/StackExchange/Dapper.

Este framework foi incluído no projeto como forma de dar possibilidades do desenvolvedor utilizar queries SQL e mapeá-las para objetos.
O Dapper foi utilizado como demonstração na aplicação através dos métodos ExemploGetTopX e ObterProdutosExcluindoRelacionamentos nas camadas de serviço e repositório. O método ExemploGetTopX Este método retorna "SELECT TOP X FROM PRODUTO" onde X é um valor recebido como parâmetro e o método ObterProdutosExcluindoRelacionamentos utiliza o dapper.contrib para retornar os produtos sem o relacionamento.

# Executando a aplicação
Visando simplificar a execução e evitar muitas configurações, a aplicação é executada no IIS express com um localdb que é criado e populado toda vez que a aplicação é executada. O método **SeedData** localizado no **Modulo1Context** é responsável por *dropar*, criar e popular o banco de dados a cada execução.

Os métodos retornam dados no padrão JSON e podem ser executados através da url no navegador passando os devidos parametros como o id de um produto.

obs: Um ponto de melhoria que não foi implementado por não contar na especificação é a utilização de *Token Based Authentication*, onde, cada requisição enviada para API é necessária a inclusão de um token de autenticação para ter sucesso nas requisições. 

A aplicação também conta com o Swagger (http://swagger.io/) que é um framework para ajuda a projetar, construir, documentar e consumir APIs RESTful.

Para utilizar basta executar o projeto e acessar a URL http://localhost:9665/swagger/ui/index
A área *HelpPage* no projeto Web API foi criada para facilitar a documentação do projeto e evitar que a documentação fique desatualizada com o decorrer do projeto. Nesta área a documentação do projeto é gerada automaticamente e caso ocorra mudanças em nomes de objetos, tipos de parametros, tipos de propriedades etc a documentação é atualizada. Nesta área também é a descrição de cada tipo de parâmetro recebido e retornado além de exemplos em como consumir e postar dados para a aplicação. O acesso é feito através da url http://localhost:9665/Help ou clicando no link API na página inicial do projeto.

# Executando os testes unitários
Os testes foram criados utilizando o xUnit. Para executa a bateria de testes unitários, basta acessar a aba Test Explorer no Visual Studio 2015 ou 2017 e clicar em *Run All*
Caso os testes não estejam disponíveis nesta aba recompile a aplicação.

# Obtendo dados da aplicação
Foram criados quatro métodos no controller ProdutosController
  - ObterProdutosExcluindoRelacionamentos - Referente ao item: Recuperar todos os Produtos excluindo os relacionamentos
  - ObterProdutosComRelacionamentos - Referente ao item: Recuperar todos os Produtos incluindo um relacionamento específico (Produto ou Imagem)
  - ObterProdutosSemRelacionamentosPorId - Referente ao item: Igual ao no 1 utilizando um id de produto específico
  - ObterProdutosComRelacionamentosPorId - Referente ao item: Igual ao no 1 utilizando um id de produto específico
  - ObterProdutosFilhosPorIdProduto - Referente ao item: Recupera a coleção de produtos filhos por um id de produto específico
  - ObterImagensPorIdProduto - Referente ao item: Recupera a coleção de Imagens para um id de produto específico

**Obtendo dados através do navegador**

**Recuperar todos os Produtos excluindo os relacionamentos**
```sh
http://localhost:9665/api/ObterProdutosExcluindoRelacionamentos
```
**Recuperar todos os Produtos incluindo um relacionamento específico (Produto ou Imagem)**
```sh
http://localhost:9665/api/ObterProdutosComRelacionamentos
```
**Recuperar todos os Produtos excluindo os relacionamentos por id de um produto**
```sh
http://localhost:9665/api/ObterProdutosSemRelacionamentosPorId/00000000-0000-0000-0000-000000000000
```
Onde: 00000000-0000-0000-0000-000000000000 é um GUID identificador do produto. Para efetuar o teste basta copiar um GUID no campo Id retornado pelo método **ObterProdutosExcluindoRelacionamentos**

**Recuperar todos os Produtos incluindo um relacionamento específico (Produto ou Imagem) por Id**
```sh
http://localhost:9665/api/ObterProdutosComRelacionamentosPorId/00000000-0000-0000-0000-000000000000
```
Onde: 00000000-0000-0000-0000-000000000000 é um GUID identificador do produto. Para efetuar o teste basta copiar um GUID no campo Id retornado pelo método **ObterProdutosComRelacionamentos**

**Recupera a coleção de produtos filhos por um id de produto específico**
```sh
http://localhost:9665/api/ObterProdutosFilhosPorIdProduto/00000000-0000-0000-0000-000000000000
```
Onde: 00000000-0000-0000-0000-000000000000 é um GUID identificador do produto. Para efetuar o teste basta copiar um GUID no campo Id retornado pelo método **ObterProdutosComRelacionamentos**

**Recupera a coleção de Imagens para um id de produto específico**
```sh
http://localhost:9665/api/ObterImagensPorIdProduto/00000000-0000-0000-0000-000000000000
```
Onde: 00000000-0000-0000-0000-000000000000 é um GUID identificador do produto. Para efetuar o teste basta copiar um GUID no campo Id retornado pelo método **ObterProdutosComRelacionamentos**

**Obtendo dados através do swagger**

Acessar a URL http://localhost:9665/swagger/ui/index e clicar em list operations. Serão listados todos os métodos disponíveis na API.

**Recuperar todos os Produtos excluindo os relacionamentos**

Clicar em GET /api/Produtos/ObterProdutosExcluindoRelacionamentos para expandir e em seguida clicar em Try it out e visualizar o resultado no item *Response Body*

**Recuperar todos os Produtos incluindo um relacionamento específico (Produto ou Imagem)**

Clicar em GET /api/Produtos/ObterProdutosComRelacionamentos e em seguida clicar em Try it out e visualizar o resultado no item *Response Body* e copiar o id do produto Galaxy S8

**Recuperar todos os Produtos excluindo os relacionamentos por id de um produto**

Clicar em GET /api/Produtos/ObterProdutosSemRelacionamentosPorId/{id} e na sessão Parameters informar o Id copiado do método anterior e colar no campo value e clicar em Try it out. Resultado no item *Response Body*

**Recuperar todos os Produtos incluindo um relacionamento específico (Produto ou Imagem) por Id**

Clicar em GET /api/Produtos/ObterProdutosComRelacionamentosPorId/{id} e na sessão Parameters usar o mesmo Id copiado do método anterior e colar no campo value e clicar em Try it out. Resultado no item *Response Body*


**Recupera a coleção de produtos filhos por um id de produto específico**

Clicar em GET /api/Produtos/ObterProdutosFilhosPorIdProduto/{id} e na sessão Parameters usar o mesmo Id copiado do método anterior e colar no campo value e clicar em Try it out. Resultado no item *Response Body*

**Recupera a coleção de Imagens para um id de produto específico**

Clicar em GET /api/Produtos/ObterImagensPorIdProduto/{id} na sessão Parameters usar o mesmo Id copiado do método anterior e colar no campo value e clicar em Try it out. Resultado no item *Response Body*


# CRUD através do swagger

Executar a aplicação acessar a URL http://localhost:9665/swagger

**Imagens***

**POST /api/Imagem/AdicionarImagem**

Utilizar o JSON como parametro
```sh
{ 
  "Id": "8b7aacd4-cfb2-4ca8-b5ff-af7698439c0c",
  "Tipo": "png",
  "IdProduto": "c56a4180-65aa-42ec-a945-5fd21dec0538"
}
```

**POST /api/Imagem/RetornarImagemPorId/{id}**

Utilizar o ID 8b7aacd4-cfb2-4ca8-b5ff-af7698439c0c como parametro

**POST /api/Imagem/AtualizarImagem**
Utilizar o JSON como parametro
```sh
{ 
  "Id": "8b7aacd4-cfb2-4ca8-b5ff-af7698439c0c",
  "Tipo": "jpg",
  "IdProduto": "c56a4180-65aa-42ec-a945-5fd21dec0538"
}
```

**POST /api/Imagem/ExcluirImagem/{id}**

Utilizar o ID 8b7aacd4-cfb2-4ca8-b5ff-af7698439c0c como parametro


**Produtos***

**POST /api/Produtos/AdicionarProduto**

Utilizar o JSON abaixo

Novo produto pai
```sh
{ 
  "Id": "f89562b6-d018-452c-a67a-3c3ffcd9e081",
  "Nome": "Novo produto adicionado",
  "Descricao": "Descrição do novo produto",
  "IdProdutoPai": null,
  "Imagens": 
	[{
		"Id": "d0d7e54e-899c-42c9-9d98-88f449ab4429",
		"Tipo": "png",
		"IdProduto": "f89562b6-d018-452c-a67a-3c3ffcd9e081"
	}]
}
```

Novo produto filho
```sh
{ 
  "Id": "f89562b6-aaaa-452c-a67a-3c3ffcd9e081",
  "Nome": "Produto filho adicionado",
  "Descricao": "Descrição produto filho adicionado",
  "IdProdutoPai": "f89562b6-d018-452c-a67a-3c3ffcd9e081",
  "Imagens": 
	[{
		"Id": "d0d7e54e-aaaa-42c9-9d98-88f449ab4429",
		"Tipo": "png",
		"IdProduto": "f89562b6-aaaa-452c-a67a-3c3ffcd9e081"
	}]
}
```

**POST /api/Produtos/RetornarProdutoPorId/{id}**
Utilizar o GUID f89562b6-d018-452c-a67a-3c3ffcd9e081 como parametro

**POST /api/Produtos/AtualizarProduto**

Utilizar o json abaixo

```sh
{ 
  "Id": "f89562b6-d018-452c-a67a-3c3ffcd9e081",
  "Nome": "Novo produto adicionado atualizado",
  "Descricao": "Descrição do novo produto atualizado",
  "IdProdutoPai": null
}
```

**POST /api/Produtos/ExcluirProduto/{id}**

Utilizar o ID 8b7aacd4-cfb2-4ca8-b5ff-af7698439c0c como parametro
