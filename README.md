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
  -> referenciar mysql.data na camada dao à partir da pasta de instalação.
  
- Schema do Banco em: 
  - https://github.com/JAyres88/PDV/tree/master/UTIL

- Procedures escritas em: 
  - https://github.com/JAyres88/PDV/tree/master/DAO/db 
  



https://www.youtube.com/watch?v=IQRCqbKlyA8

