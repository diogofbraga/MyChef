# Aula 08-04

# ASP.Net
brunobmo/ASP.NET-Training/tree/master/2019

## *Ferramentas necessarias*
- Framework .net != .net core
- dotnetcore 2.2
- sql server
- O que é o protocolo http -> Metodos
- Necessario ASP.Net COre app
- Ficheiro startup tem de ter query string a mandar para a bd sql server 


## Framework.net 
permite fazer varias coisas
- aplicacoes 
- web
- varias tecnologias

## ASP.NET Core v2.2

## Web API
Criamos uma api que depois permite ser migrado para web ou telemovel, o que quisermos
Podemos criar uma api que ja me cria os controlers etc

# Serviço MVC
- procura controlador -> home 
- procura action -> index
- pedido do metodo get está embebido no url 
- metodo login nao por exemplo 

# Controlador
Controlador vazio, devo chamar o mesmo nome
Route("api/[controller]")

[httpGet] (Parametro para filtrar http)Para testar este pedido uso o rested ou o post para testar esse get ou o que for
[httpPost] Todos os parametros do post vao estar embebidos no url

?codigo=1 para lhe passar um codigo
controlador tem de saber qual é o contexto que está a utilizar
Se lhe passar o context ele 
Posso meter um campo ser um data type (Int) e ele valida diretamente sem ser necessario ir comparar ou enviar para a bd
user.toArray() vai buscar todos os users na bd -> nao é preciso select nenhum

return OK(user) diz que correu tudo bem

adicionar
_context.user.Add(user) Adiciona um user
_context.SaveChanges(); -> Faz commit na bd

Alterar metodos Get

Adicionar o modelo para as tarefas
[JsonIgnore] -> Ignora o body do json recebido pelo url
[NotMapped] Se nao passar como é a bd
Mapped é se disser que é de 1->1 ou de 1->n ou de n-> n
Public virtual
So pusha os dados quando sao necessarios

Se acrescento uma nova classe tenho de cirar um DbSet user (classe) para ele saber como mapear essa classe na tabela da bd

FluentAPI 
Permite aceder a tudo atraves desta api

[HttpGet("getTasks/{codigo}")]

linguagem link simplifica acesso á bd
Nao preciso de utilziar linguagem sql para aceder á bd

var tasks = _context.task.where(s => s.userid = codigo) procura as tasks do user atraves do id


