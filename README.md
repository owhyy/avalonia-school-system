# Avalonia school system management app

Simple app built with Avalonia MVVM and Entity Framework Core, on a Sqlite database.

Allows adding and viewing students, courses, groups, marks and absences. Largely incomplete and basic.

## Images

![Login screen](./img/login)

## Import test data

To make testing easier, you can run the following command, which will create the database, run the migrations, and import some fake data.

Before running, make sure you have `sqlite3` installed.

```sh
bash ./utils/fake_import.sh
```

You can generate other fake data using something like https://www.mockaroo.com/.

## Installation and running

I have tested and successfuly run this app on Artix Linux and Ubuntu 23.04. Windows and Mac were not tested. If you manage to run it on either, let me know.

This project uses dotnet version 7.0. Other requirements can be installed with NuGet.

