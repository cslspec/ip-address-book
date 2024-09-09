IP Address Book
===============

This project is a simple IP address book application. Core functionality and UI is built with .NET 8. The UI is built with WinForm which only runs on Windows.

## How to setup the project ##

If not already installed, download and install .NET Desktop Runtime 8. You can view the installed .NET runtimes by issuing:  
`dotnet --list-runtimes`

The .NET Desktop Runtime 8 is available from several sources. One option is to download directly from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

Open the IPAddressBook folder. Type `dotnet run` and the application opens a new Window.

## Features ##

* Add and remove IP address.
* Ensure valid IP address.
* Name and notes field.
* List all stored IP addresses.
* Search for an IP address.
* Search using CIDR notation.
* Support both IPv4 or IPv6.
* Store addresses in SQLite database.

Please note there is no support for adding IP addresses with CIDR notation.

## Design Decisions ##

The application is built in a Layered Architecture:
1. The presentation layer is in the IPAddressBook project.
2. The business layer is in the IPAddressBook.Logic projects.
3. The persistence layer is in the IPAddressBook.Model project.
4. The database layer is in the IPAddressBook.Data project.

The presentation layer is built using the latest .NET WinForms technology. Since it strictly conforms to a layered application architecture, it is easy to add or substitute a presentation layer. This could for example be a command line or web interface.

The business layer takes advantage of .NET classes for validation and other generic business tasks. It does not use dependencies injection since the application is just a proof of concept.

The persistence layer is based on the Entity Core Framework. This generic framework makes it possible to substitute the underlying data storage from SQLite with one of the other Entity Core Framework supported providers, for example Microsoft SQL Server of MongoDB.
