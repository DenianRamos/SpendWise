
# 💸 SpendWise

**SpendWise** is your ultimate solution for managing expenses effortlessly! Whether you're tracking personal finances or managing a business budget, SpendWise provides a seamless and intuitive experience. With features to register, update, delete, and query expenses, you can stay on top of your financial game with ease. Say goodbye to financial stress and hello to smart spending with SpendWise!



## 📂 Project Structure

- **SpendWise.Application**: Contains the use cases for expense operations.
- **SpendWise.Communication**: Contains request and response classes used in communication between the API and clients.
- **SpendWise.Domain**: Contains domain entities and repositories.
- **SpendWise.Exception**: Contains custom exceptions used in the project.
- **SpendWise.Filters**: Contains exception filters for error handling.
- **SpendWise.Controllers**: Contains the API controllers.

## 🛠️ Dependencies

- **AutoMapper**: For object mapping.
- **FluentValidation**: For data validation.
- **Microsoft.Extensions.DependencyInjection**: For dependency injection.

## ⚙️ Configuration

### Dependency Injection

In the file `SpendWiseApplication/DependencyInjectionExtension.cs`, dependencies are configured as follows:

## Tools
![.NET](https://img.shields.io/static/v1?style=for-the-badge&message=.NET&color=512BD4&logo=.NET&logoColor=FFFFFF&label=) ![C#](https://img.shields.io/badge/C%23-51375e?logo=c-sharp&logoColor=white&style=for-the-badge) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white) ![MySQL](https://img.shields.io/static/v1?style=for-the-badge&message=MySQL&color=4479A1&logo=MySQL&logoColor=FFFFFF&label=)


## ❗ Exceptions

Custom exceptions are defined in the `SpendWise.Exception` namespace and are used to handle specific application errors.

## 🧪 Unit Tests

Unit tests are a crucial part of SpendWise to ensure the reliability and correctness of the application. The tests are designed to validate the functionality of various components, including use cases, controllers, and validators.

### Example: RegisterExpenseValidatorTests

The validation tests are defined in the file `Validators/Expenses/Register/RegisterExpenseValidatorTests.cs` and use FluentAssertions for assertions.



