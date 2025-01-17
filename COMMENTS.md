**Decisão da arquitetura utilizada**

Projeto desenvolvido utilizando as tecnologias solicitadas netCore, C# e Entity framework e PostgreSql, para atender os requisitos exigidos. Foi utilizado a arquitetura CQRS Command Query Responsability Segregation sendo que neste caso em específico o banco de gravação e leitura é o mesmo, pois como não foi fornecido requisitos não funcionais como a carga esperada de requisições para se tomar alguma outra alternativa para banco de leitura.

![CQRS pattern](https://www.macoratti.net/20/08/c_cqrs16.jpg)

Caso necesário, para uma alta carga de requisição e leituras, usar ElasticSearch ou MongoDb para o banco de leitura, também o deploy do projeto, com container Docker com disponibilidade 24/7 e zero de downtime em caso de uma atualização, para este caso, utilizar Kubernetes em EKS ou Amazon ECS.

Utilizado o Swagger como documentação da API, para auxílio no processo de desenvolvimento, documentação e teste, também ajuda em uma abordadem de desenvolvimento não full stack.

![Swagger](https://github.com/eduardojvendruscolo/orbita-challenge-full-stack-web/blob/master/images/swaggerEducationExample.png)

Utilizado o Postman para fazer requisições HTTP REST no backend, pois ele oferece diversas opções para automação de requisições também geração de massa de dados para testes, e variáveis padrões dele para ajuda nos cadastros/testes.

![Postman](https://github.com/eduardojvendruscolo/orbita-challenge-full-stack-web/blob/master/images/postman_tests.gif)

Em relação aos testes, também foi feito testes utilizando o Postman, pois o Postman também oferece o recurso de testes, aplicando testes em cima dos dados retornados também conferindo o status da requisição HTTP, os testes neste caso foram feitos de forma sequencial, inserindo um aluno, buscando, fazendo update e por fim remover.

![Teste](https://github.com/eduardojvendruscolo/orbita-challenge-full-stack-web/blob/master/images/postmanEducation.png)

**Lista de bibliotecas de terceiros utilizadas**

- Swashbuckle
- FluentValidation
- DependencyInjection
- Versioning

**O que você melhoraria se tivesse mais tempo**

- Colocar order by type em um Enum no caso de ASC e DESC
- Encontrar uma maneira de deixar de forma genérica o campo de ordenação no order by em AcademicStudentRepository.cs, e no caso de uma melhoria de performance extrema seja necessária avaliar o custo da requisição SQL e avaliar a criação de indiçes no banco de dados e otimização de consulta SQL.
- Em AcademicStudentService existem os métodos AcademicStudenAlreadyExists e AnotherStudenAlreadyExists, melhorar fazendo um predicado dinamico, para poder usar só uma função ao invés de duas, pois a única coisa que muda é o parametro da primary key.
- Criar componentes no front-end para listagem e paginação for genérica.
- As URLs de chamada de API no front-end, colocar em outro local ao invés do local da chamada do Axios.
- Validação no nome da pessoa, limitar tamanho e não deixar inserir caracteres especiais, e talvez obrigar informar nome e sobrenome.

**Quais requisitos obrigatórios que não foram entregues**
- Teste unitários não foram feitos, porém foi feito teste na camada da API com Postman.
