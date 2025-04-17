
# 🏡 Property Finder - Backend

This is the **backend** of the Property Finder system — a real estate web application developed using **ASP.NET Core**. The system allows users to list, browse, and book properties, supporting both owners and tenants.

---

## 📦 Project Structure

```
├── Configurations/           # Entity Framework configurations
├── Contexts/                 # Database context
├── Controllers/              # API endpoints
├── DTOs/                     # Data Transfer Objects
├── Entities/                 # Core data models (EF Entities)
├── Migrations/               # EF Core migrations
├── appsettings.json          # App config
```

---

## 📌 Core Features

- 🔐 **Authentication** for users via JWT
- 🏠 **Property listing** and **image storage**
- 📅 **Booking system** with contracts
- 👥 **Owner and Tenant** roles
- 📤 RESTful API controllers

---

## 🧱 Key Models

### 🧾 `Contract.cs`
- Holds contract terms and validity
- Linked to bookings

### 🏠 `Residence.cs`
- Main property entity
- Includes room count, rent, and address info
- Supports pictures and linked to a user

### 📌 `Booking.cs`
- Associates a property, user, and contract with a booking date

---

## 🚀 How to Run

### 📍 Prerequisites
- [.NET 6 SDK+](https://dotnet.microsoft.com/en-us/download)
- SQL Server or LocalDB

### 🧪 Run Locally

```bash
# Restore packages
dotnet restore

# Apply migrations
dotnet ef database update

# Run the project
dotnet run
```

### 🌍 Access API

Once running, access endpoints at:

```
https://localhost:5001/api/[controller]
```

Example:
```
GET https://localhost:5001/api/Residence
```

---

## 🔐 Authentication

The backend uses JWT tokens.

- 🔑 **Login**: `POST /api/Auth/login`
- 🆕 **Sign Up**: `POST /api/SignUp`

---

## 🧑‍💻 Developer

**Mahmoud Ahmed Alam Eldin**  
Huawei ICT Student Ambassador  
King Salman International University  

📎 GitHub: [mahmoud1053](https://github.com/mahmoud1053)

---

## 📃 License

MIT License
