# Integrasi Transaksi & Stok antara iPubers, Kementan, & BRI

Back-end System untuk manajemen transaksi dan Stok kios yang dibangun dengan .NET 9, menyediakan endpoint untuk autentikasi, pemrosesan transaksi, reversal transaksi, dan pengelolaan stok.

## 🚀 Features

- **Authentication** - Sistem autentikasi berbasis JWT token
- **Transaction Processing** - Endpoint untuk memproses transaksi kartan baru dan akan mengurangi stok kios
- **Transaction Reversal** - Endpoint untuk membatalkan transaksi yang sudah ada
- **Latest Data Stok** - Monitoring stok real-time

## 🛠️ Tech Stack

- **.NET 9** - Framework utama
- **ASP.NET Core Web API** - Web framework
- **C#** - Programming language
- **Entity Framework Core** - ORM (jika menggunakan database)
- **JWT Authentication** - Token-based authentication
- **Swagger/OpenAPI** - API documentation

## 📋 Prerequisites

- .NET 9 SDK
- Visual Studio 2022 atau VS Code
- SQL Server (atau database pilihan Anda)

## 🏃‍♂️ Quick Start

### 1. Clone Repository
```bash
git clone <repository-url>
cd <project-directory>
```

### 2. Install Dependencies
```bash
dotnet restore
```

### 3. Configuration
Update `appsettings.json` dengan konfigurasi yang sesuai:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string"
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key",
    "Issuer": "your-issuer",
    "Audience": "your-audience",
    "ExpirationMinutes": 60
  }
}
```

### 4. Database Migration (jika menggunakan EF Core)
```bash
dotnet ef database update
```

### 5. Run Application
```bash
dotnet run
```

API akan berjalan di: `https://localhost:7000` (atau port yang dikonfigurasi)

## 📚 API Documentation

### Base URL
- **Development**: `https://localhost:7000/api`
- **Production**: `https://your-domain.com/api`

### Authentication
Semua endpoint (kecuali authentication) memerlukan Bearer token di header:
```
Authorization: Bearer <your-jwt-token>
```

## 🔗 API Endpoints

### 1. Authentication
**POST** `/public/auth/login`

Authenticate user dan mendapatkan JWT token.

**Request Body:**
```json
{
  "username": "string",
  "password": "string"
}
```

**Response (200):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expires": "2024-12-31T23:59:59Z",
  "user": {
    "id": "string",
    "username": "string",
    "role": "string"
  }
}
```

**Response (401):**
```json
{
  "error": "Username & Password tidak cocok"
}
```

---

### 2. Create Transaction
**POST** `/transaction`

Membuat transaksi baru.

**Headers:**
```
Authorization: Bearer <token>
Content-Type: application/json
```

---

### 3. Reversal Transaction
**POST** `/transaction/reversal`

Membatalkan transaksi yang sudah ada.

**Headers:**
```
Authorization: Bearer <token>
Content-Type: application/json
```
---

### 4. Get Stock
**GET** `/lateststok`

Mendapatkan informasi stok produk.

**Headers:**
```
Authorization: Bearer <token>
```

## ⚠️ Error Handling

API menggunakan standard HTTP status codes:

- **200** - Success
- **201** - Created
- **400** - Bad Request
- **401** - Unauthorized
- **403** - Forbidden
- **404** - Not Found
- **409** - Conflict
- **500** - Internal Server Error

Format error response:
```json
{
  "statusCode": "Error message",
  "statusDesc": ["Additional error details"],
  "data":{}
  "timestamp": "2024-01-01T00:00:00Z",
  "path": "/api/endpoint"
}
```

## 🔐 Security

- JWT token-based authentication
- HTTPS enforced in production
- Rate limiting implemented
- Input validation pada semua endpoints
- SQL injection protection

## 📊 Monitoring & Logging

- Structured logging menggunakan Serilog
- Health check endpoint: `/health`
- Metrics endpoint: `/metrics`
- Request/Response logging untuk audit trail

## 🚀 Deployment

### Docker
```bash
docker build -t be-ipubers-kartan .
docker run -p 8080:8080 be-ipubers-kartan
```

### Environment Variables
```bash
ASPNETCORE_ENVIRONMENT=Production
CONNECTION_STRING=your-production-connection-string
JWT_SECRET_KEY=your-production-secret-key
```

## 📝 Development Guidelines

1. **Code Style**: Ikuti Microsoft C# coding conventions
2. **Branching**: Gunakan GitFlow workflow
3. **Testing**: Minimum 80% code coverage
4. **Documentation**: Update README untuk setiap perubahan API

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Version**: 1.0.0  
**Last Updated**: Juni 2025  
**Maintained by**: Digitalisasi Pemasaran
