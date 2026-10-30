[README.md](https://github.com/user-attachments/files/34185203/README.md)
# 🏪 Store Management System

<div align="center">

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)

A full-featured **Store Management System** built with ASP.NET Core MVC, following a clean **3-Layer Architecture**. It covers everything from inventory and product management to sales and purchase orders — all with role-based authentication.

</div>

---

## ✨ Features

- 🔐 **Authentication & Authorization** — ASP.NET Identity with role-based access (Admin / User)
- 📦 **Product Management** — Add, edit, delete, and track products with images and units
- 🗂️ **Category Management** — Organize products into categories
- 🧾 **Sales Orders** — Create and manage customer sales orders with order details
- 🛒 **Purchase Orders** — Manage supplier purchase orders and stock replenishment
- 👥 **Customer Management** — Full CRUD for customer records
- 🏭 **Supplier Management** — Manage supplier information
- 📊 **Inventory Tracking** — Track stock levels and inventory transactions
- 🌱 **Database Seeding** — Auto-seeds default roles and admin user on startup

---

## 🏗️ Architecture

The project follows a clean **3-Layer Architecture** separating concerns across four projects:

```
StoreManagementSystem.sln
│
├── 📁 BL (Core)                  → Domain Models & Seeders
│   ├── Models/
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── Customer.cs
│   │   ├── Supplier.cs
│   │   ├── SalesOrder.cs / SalesOrderDetail.cs
│   │   ├── PurchaseOrder.cs / PurchaseOrderDetail.cs
│   │   ├── InventoryTransaction.cs
│   │   ├── ProductUnit.cs / Unit.cs
│   │   └── ApplicationUser.cs
│   └── Seeders/
│       └── DbSeeder.cs
│
├── 📁 DAL (Infrastructure)        → Data Access Layer
│   ├── Contexts/
│   │   └── StoreDbContext.cs
│   ├── Interface/
│   │   └── IGenericRepository.cs
│   └── Migrations/
│
├── 📁 UserInterface (Business)    → Business Logic Layer
│   ├── Interfaces/
│   ├── Services/
│   │   ├── ProductService.cs
│   │   ├── CategoryService.cs
│   │   ├── CustomerService.cs
│   │   ├── SupplierService.cs
│   │   ├── SalesOrderService.cs
│   │   └── PurchaseOrderService.cs
│   ├── Repositories/
│   └── DTO/
│
└── 📁 StoreManagementSystem       → Presentation Layer (ASP.NET Core MVC)
    ├── Controllers/
    │   ├── AccountController.cs
    │   ├── ProductController.cs
    │   ├── CategoryController.cs
    │   ├── CustomerController.cs
    │   ├── SupplierController.cs
    │   ├── SalesOrderController.cs
    │   └── PurchaseOrderController.cs
    ├── Views/
    ├── ViewModels/
    └── Provider/
```

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|---|---|---|
| **ASP.NET Core MVC** | .NET 8.0 | Web framework |
| **Entity Framework Core** | 9.0.9 | ORM & database access |
| **EF Core SQL Server** | 9.0.9 | SQL Server provider |
| **ASP.NET Core Identity** | Built-in | Authentication & Roles |
| **SQL Server** | — | Database |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Developer edition)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/StoreManagementSystem.git
cd StoreManagementSystem
```

### 2. Configure the Database Connection

Open `appsettings.json` and update the connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=Store;Integrated Security=true;TrustServerCertificate=True;"
  }
}
```

### 3. Apply Migrations

```bash
cd StoreManagementSystem
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

Or press **F5** in Visual Studio.

> 🌱 On first run, the app will **automatically seed** the database with default roles (`Admin`, `User`) and an admin account.

---

## 🔑 Default Admin Credentials

| Field | Value |
|---|---|
| **Username / Email** | `admin@store.com` *(or as configured in DbSeeder)* |
| **Password** | *(as configured in DbSeeder)* |

> ⚠️ **Important:** Change the default admin password after first login in a production environment.

---

## 📂 Project Structure Summary

| Layer | Project Name | Responsibility |
|---|---|---|
| **Domain** | `Core` (BL) | Models, entities, domain seeders |
| **Data Access** | `Infrastructure` (DAL) | DbContext, generic repository, migrations |
| **Business Logic** | `Business` (UserInterface) | Services, DTOs, business rules |
| **Presentation** | `StoreManagementSystem` | MVC Controllers, Views, ViewModels |

---

## 🤝 Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/YourFeature`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin feature/YourFeature`
5. Open a Pull Request

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

<div align="center">
Made with ❤️ using ASP.NET Core
</div>
