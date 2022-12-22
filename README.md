# JournalEntry

## Configuração do projeto
* Linguagem: C#
* Verção: Net6
* Tipo: Asp.Net Core Api


## Configuracao do Container de Banco SqlServer

~~~~Docker
docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
~~~~

