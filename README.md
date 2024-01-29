# Przykłady ze szkolenia Blazor 8

## Wprowadzenie

Witaj w repozytorium z materiałami do szkolenia **Blazor 8**.

Do rozpoczęcia tego kursu potrzebujesz następujących rzeczy:

1. [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

2. Sklonuj repozytorium Git

```bash
git clone https://github.com/sulmar/usuconcept-zus-blazor
```

3. Utwórz bazę danych

```bash
sqlcmd -S (localdb)\MSSQLLocalDB -d master -E -i sql-server-sakila-schema.sql
```

4. Załadowuj przykładowane dane

```bash
sqlcmd -S (localdb)\MSSQLLocalDB -d sakila -E -i sql-server-sakila-insert-data.sql
```
