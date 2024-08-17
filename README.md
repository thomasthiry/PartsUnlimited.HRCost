# Parts Unlimited - HR Cost

This application is used for a workshop on tests. It is a small web application used by an HR departments to manage the cost of employees.

## Database

The database can be created with this:

```powershell
docker-compose up -d
docker exec -it sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -C -U sa -P Evolve11! -i /database/Initialize.sql
```