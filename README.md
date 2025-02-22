# ✈️ Flight Reservations

## 📖 Description
The **Flight Reservations** project is an application that allows users to book airline tickets. It is primarily written in C# and uses Docker for containerization.

## 🌟 Features
- 🔑 User registration and login
- 🔍 Searching for available flights
- ✈️ Booking airline tickets
- 🗂️ Managing reservations

## 🛠 Technologies
- **Programming Language**: C#
- **Containerization**: Docker

## 💡 Object-Oriented Programming (OOP) Elements
- **Inheritance**: Inheriting from .NET classes, such as in the Controllers and Identity components.
- **Polymorphism**: Extending `BaseTicket` and `BaseFlight` classes to customize model fields.
- **Encapsulation**: Using `private readonly` access modifiers to protect data.
- **Abstraction**: Implementing interfaces like `ITicketService` and `IFlightService` to hide implementation details.

## 📋 System Requirements
- Docker
- Docker Compose

## 🔧 Development Requirements
- .NET Core 8.0
- ASP.NET Core 8.0

## 🚀 Installation
To run the project locally, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/wsb-projects/rezerwacje-lotnicze.git
    ```
2. Navigate to the project directory:
    ```bash
    cd rezerwacje-lotnicze
    ```
3. Build and run the Docker container:
    ```bash
    docker-compose up
    ```

## 🖥 Usage
Once the application is running, frontend and backend can be accesses at:
| service | address |
|---------|---------|
| backend | [`http://localhost:8080`](http://localhost:8080) |
| frontend | [`http://localhost:5000`](http://localhost:5000) |

## 👥 Contribution
If you want to contribute to the project, please submit pull requests. Also, please report issues and suggest features on the Issues page.

## 👨‍💻 Authors
- Jakub Krzyzowski - Original author
- Wojciech Nawa - Original author
- Dominik Kielkowski - Original author
