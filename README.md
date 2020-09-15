# PDV
Projeto PDV

- Formulários utilizam o advanced datagridview do davidegironi, baixar e instalar através do nuget.
https://github.com/davidegironi/advanceddatagridview

- Install mysql connector 8.0.20: 
https://downloads.mysql.com/archives/c-net/ 

- Criar 4 projetos separados dentro de uma solução. Adicionar as classes e em seguida as dependências: 
  -> projeto main referencia BLL - MODEL.
  -> projeto BLL referencia DAO e MODEL 
  -> projeto DAO referencia MODEL

- Adicionar string de conexão para o MySQL.

- Create da Base em UTIL e Upload dos Dados Iniciais por csv, utilizar ferramenta de import do workbench para ter acesso à seleção de Formatação de Linguagem UTF, seguir precedência dos relacionamentos para Upload.



