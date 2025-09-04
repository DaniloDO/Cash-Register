# CashRegister Console Application  

The CashRegister application is a **console-based system built in C#** that simulates the core functionality of a retail till.  
It allows recording deposits, withdraws, voiding transactions, and managing transaction history while maintaining a real-time balance.  

This project is designed with **object-oriented principles** and **scalable architecture in mind** aiming to evolve into a **layered architecture** (Domain, Application, Infrastructure).  

Some technical aspects showcased is this project:
- **OOP fundamentals** such as encapsulation, abstraction, and separation of concerns.  
- Use of **design patterns** like the Factory Pattern to centralize transaction creation.  
- An **action-based structure**, where each class has a single responsibility (e.g., starting transactions, viewing status, voiding transactions). 

---

## Features  

- **Interactive Menu System**  
  Provides a user-friendly way to navigate actions such as adding transactions, viewing till status, or voiding entries.  

- **Real-Time Till Balance**  
  Automatically recalculates and updates after each transaction.  

- **Transaction Management**  
  Supports deposits, withdrawals, and void operations, with each transaction carrying a unique ID, timestamp, type, and amount.  

- **Transaction History**  
  Displays a clear, formatted list of all past activity.  

- **Input Validation**  
  Prevents invalid transaction types and amounts from being processed.  

---

## Technical Highlights  

- **Built With:** C# (.NET)  

- **Design Patterns & Principles:**  
  - **Factory Pattern** for centralized and consistent transaction creation.  
  - **Command Pattern** for encapsulating each user action as an independent, reusable class.
  - **Encapsulation** of till balance and transaction history inside `Till`, exposing only what is necessary.  
  - **Single Responsibility Principle** across actions and domain entities.  
  - **Read-only transaction list**, ensuring immutability from outside components.  

- **Extensibility**  
  The architecture makes it simple to:  
  - Add new **transaction types** by extending the factory.  
  - Introduce new **menu actions** by implementing a new command class.  
  - Expand functionality (e.g., reporting, exporting) with minimal changes to existing code.  

---

## Roadmap  

Planned enhancements include:  
- Additional validation rules (e.g., preventing refunds without prior sales).  
- Reporting features (summaries, revenue analysis).  
- Persistence layer to save transactions to a database or file.  
- Migration into a fully layered solution (Domain, Application, Infrastructure).  
- Improved CLI menus with structured navigation and better formatting.  

---

## Running the Application:  

1. Clone the repository:  
   ```bash
   git clone https://github.com/yourusername/CashRegister.git
   cd CashRegister

2. Build the project:   
   ```bash
   dotnet build

3. Run the console app    
   ```bash
   dotnet run --project CashRegister.ConsoleApp

