
# 🏭 Factory Automation System – Chocolate Factory (University Database Project)

This repository hosts a full-stack **factory automation system** developed by a student team as part of a **Database course** at university. The project models a wholesale ordering platform for chocolate products with integrated stock tracking and automated ingredient calculation.

---

## 📌 Project Overview

The purpose of the project was to design and implement a database-driven system that streamlines the order and production processes for a factory. The system enables:

- Company clients to browse chocolate products and place bulk orders online.
- Backend logic to automatically calculate the required ingredients for each order.
- Stock tracking with alerts when ingredients fall below a minimum threshold.

The system simulates real-world challenges in inventory management and production planning, aligned with business logic.

---

## 👨‍💻 Team Contributions

The project was developed collaboratively by a university team, with contributions in areas such as:

- **Frontend Development**: Building a responsive user interface using Blazor WebAssembly and Bootstrap.
- **Backend API Development**: Creating RESTful services using Spring Boot (Java).
- **Database Design & MySQL Queries**: Structuring product, customer, and ingredient data.
- **Python Scripting**: Automating data scraping tasks to support backend processing and reporting.

---

## ⚙️ Tech Stack

| Component   | Technology Used                         |
|-------------|------------------------------------------|
| Frontend    | Blazor WebAssembly (.NET), Bootstrap     |
| Backend     | Spring Boot (Java), RESTful APIs         |
| Database    | MySQL                                    |
| Scripting   | Python (for automated data scraping)     |
| Data Format | CSV (for product/ingredient import)      |

---

## 🛠️ Features

- 🔍 **Product Search**: Search and view chocolate products.
- 📦 **Wholesale Ordering**: Clients can place large orders.
- ⚖️ **Ingredient Calculation**: Backend computes needed raw materials for production.
- 🚨 **Shortage Alerts**: Admins are notified if ingredient levels are insufficient.
- 🔒 **Role-Based Access**: Separate views and permissions for admins and clients.
- 📄 **CSV Import**: Upload and process data in CSV format.

---

## 📁 Folder Structure

```
factory-automation-project/
├── backend/         # Spring Boot backend project
├── frontend/        # Blazor WebAssembly UI
├── csv files/       # Sample product/ingredient data
└── README.md
```

---

## 🚀 How to Run

### 🖥 Backend (Spring Boot)
1. Navigate to the backend folder:
   ```bash
   cd backend
   ```
2. Start the backend server:
   ```bash
   ./mvnw spring-boot:run
   ```
3. Backend will run at: `http://localhost:8080`

✅ Ensure MySQL is running and update `application.properties` with the correct DB credentials.

---

### 🌐 Frontend (Blazor WebAssembly)
1. Navigate to the frontend folder:
   ```bash
   cd frontend
   ```
2. Start the Blazor app:
   ```bash
   dotnet run
   ```
3. Access the UI at: `https://localhost:7001`

---

## 📊 Sample Data

You can find example product and ingredient datasets inside the `csv files/` directory to quickly test the system.

---

## 🎓 Academic Context

This project was completed as part of a **Database course project**, in partnership with a **local chocolate production business**. It was developed collaboratively by a student team to simulate real-world inventory, ordering, and production workflows, providing practical experience with backend and frontend integration.

---

## 📜 License

This repository is shared for **educational purposes only**. It is not intended for commercial use.  
Licensed under the **MIT License**.
