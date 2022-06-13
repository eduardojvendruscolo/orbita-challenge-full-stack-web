**Decisão da arquitetura utilizada

Projeto desenvolvido utilizando as tecnologias solicitadas netCore, C# e Entity framework e PostgreSql, para atender os requisitos exigidos. Foi utilizado a arquitetura CQRS Command Query Responsability Segregation sendo que neste caso em específico o banco de gravação e leitura é o mesmo, pois como não foi fornecido requisitos não funcionais como a carga esperada de requisições para se tomar alguma outra alternativa para banco de leitura, talvez um ElasticSearch ou MongoDb etc, também como seria feito o deploy deste projeto, com container Docker com disponibilidade 24/7 e zero de downtime em caso de uma atualização, para este caso, talvez utilizar Kubernetes em EKS ou Amazon ECS.

**Lista de bibliotecas de terceiros utilizadas

- Swashbuckle
- FluentValidation
- DependencyInjection
- Versioning
- 
**O que você melhoraria se tivesse mais tempo

- Colocar order by type em um Enum no caso de ASC e DESC
- Encontrar uma maneira de deixar de forma genérica o campo de ordenação no order by em AcademicStudentRepository.cs, e no caso de uma melhoria de performance extrema seja necessária avaliar o custo da requisição SQL e avaliar a criação de indiçes no banco de dados e otimização de consulta SQL.
- Em AcademicStudentService existem os métodos AcademicStudenAlreadyExists e AnotherStudenAlreadyExists, melhorar fazendo um predicado dinamico, para poder usar só uma função ao invés de duas, pois a única coisa que muda é o parametro da primary key.

**Quais requisitos obrigatórios que não foram entregues
- Nem um
