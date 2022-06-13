**Decisão da arquitetura utilizada**

Projeto desenvolvido utilizando as tecnologias solicitadas netCore, C# e Entity framework e PostgreSql, para atender os requisitos exigidos. Foi utilizado a arquitetura CQRS Command Query Responsability Segregation sendo que neste caso em específico o banco de gravação e leitura é o mesmo, pois como não foi fornecido requisitos não funcionais como a carga esperada de requisições para se tomar alguma outra alternativa para banco de leitura.

![CQRS pattern](https://www.macoratti.net/20/08/c_cqrs16.jpg)

Caso necesário, para uma alta cargad e requisição e leituras, um ElasticSearch ou MongoDb para o banco de leitura, também como seria feito o deploy deste projeto, com container Docker com disponibilidade 24/7 e zero de downtime em caso de uma atualização, para este caso, talvez utilizar Kubernetes em EKS ou Amazon ECS.

Utilizado o Swagger como documentação da API, para auxílio no processode desenvolvimento, teste e talvez ajuda em uma abordadem de desenvolvimento não full stack.

![Swagger](https://github.com/eduardojvendruscolo/orbita-challenge-full-stack-web/blob/master/images/swaggerEducationExample.png)

Utilizado o Postman para fazer requisições Rest no backend, pois ele oferece diversas opções para automação de requisições também geração de massa de dados para testes, e variáveis padrões dele para ajuda nos cadastros.

![Postman](https://github.com/eduardojvendruscolo/orbita-challenge-full-stack-web/blob/master/images/postmanEducation.png)

**Lista de bibliotecas de terceiros utilizadas**

- Swashbuckle
- FluentValidation
- DependencyInjection
- Versioning

**O que você melhoraria se tivesse mais tempo**

- Colocar order by type em um Enum no caso de ASC e DESC
- Encontrar uma maneira de deixar de forma genérica o campo de ordenação no order by em AcademicStudentRepository.cs, e no caso de uma melhoria de performance extrema seja necessária avaliar o custo da requisição SQL e avaliar a criação de indiçes no banco de dados e otimização de consulta SQL.
- Em AcademicStudentService existem os métodos AcademicStudenAlreadyExists e AnotherStudenAlreadyExists, melhorar fazendo um predicado dinamico, para poder usar só uma função ao invés de duas, pois a única coisa que muda é o parametro da primary key.

**Quais requisitos obrigatórios que não foram entregues**
- Teste unitários
