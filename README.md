For at få lavet de 2 nødvendige Databaser, skal man gøre som følger, når man står i Package Manger Console vinduet.:

1) For at få lavet (MsSQL) Databasen for Account WEb Api'et.

Add-Migration "NavnHer" -Project Account.Infrastructure -StartupProject Account.WebApi

Og når man efterfølgende skal lave Databasen kan man bruge denne kommando:

Update-Database -Project Account.Infrastructure -StartupProject Account.WebApi

2) For at få lavet (MySQL) Databasen for Audit Web Api'et.

Add-Migration "NavnHer" -Project Audit.Infrastructure -StartupProject Audit.WebApi

Og når man efterfølgende skal lave Databasen kan man bruge denne kommando:

Update-Database -Project Audit.Infrastructure -StartupProject Audit.WebApi
