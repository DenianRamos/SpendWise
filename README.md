# SpendWise

## 📝 SpendWise - About the Project

SpendWise is an **API** developed with .NET 8, utilizing ***Domain-Driven Design*** **(DDD)** principles to provide an organized and efficient solution for personal expense management. The main goal is to allow users to record their expenses, including details such as title, date and time, description, amount, and payment type, with the data being securely stored in a MySQL database.

The API architecture is based on **REST**, using standard **HTTP** methods for efficient and simplified communication. Additionally, the API is documented with Swagger, offering an interactive graphical interface for developers to explore and test the endpoints easily.

Among the NuGet packages used, AutoMapper is responsible for mapping between domain objects and request/response objects, reducing the need for repetitive and manual code. FluentAssertions is used in unit tests to make assertions more readable, helping to write clear and understandable tests. For validations, FluentValidation is used to implement validation rules in a simple and intuitive way in request classes, keeping the code clean and easy to maintain. Finally, EntityFramework acts as an ORM (Object-Relational Mapper) that simplifies interactions with the database, allowing the use of .NET objects to manipulate data directly, without the need to deal with SQL queries.

## ✨ Features

- **Domain-Driven Design (DDD)**: Modular structure that facilitates understanding and maintaining the application domain.
- **Unit Testing**: Comprehensive tests with FluentAssertions to ensure functionality and quality.
- **Report Generation**: Ability to export detailed reports to PDF and Excel, offering effective visual analysis of expenses.
- **RESTful API with Swagger Documentation**: Documented interface that facilitates integration and testing by developers.

## 🛠️ Built With

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
 ![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
 ![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

## 🚀 Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

* Visual Studio version 2022+ or Visual Studio Code 
* Windows 10+ or Linux/MacOS with [.NET SDK][dot-net=sdk] installed
* MySQL Server

### Installation

1. Clone the repository:
```sh
 git clone https://github.com/DenianRamos/SpendWise.git
 ```

2. Fill in the information in the `appsettings.Development.json` file.

3. Run the API and enjoy your testing :)
<!-- Links -->
[dot-net=sdk]: https://dotnet.microsoft.com/en-us/download



