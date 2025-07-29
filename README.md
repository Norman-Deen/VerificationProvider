# ✅ VerificationProvider

**VerificationProvider** is a modular ASP.NET Core Web API designed to handle secure verification tasks, such as email or phone number confirmation, token validation, and integration with external systems.  
This provider can be used as a microservice in a broader system requiring account verification and identity protection.

---

## 🚀 Features

- 🔐 Token-based verification endpoints
- 📩 Email or external verification logic support
- ⚙️ ASP.NET Core Web API (.NET 6+)
- ☁️ Hosted on Microsoft Azure
- 🧩 Designed for easy integration with external Account or Identity Providers
- 📄 Swagger (OpenAPI) support for testing

---

## 📂 Project Structure

```

VerificationProvider/
├── Controllers/         # API controllers
├── Models/              # DTOs and request/response models
├── Services/            # Core verification logic
├── Program.cs           # Main entry point
├── appsettings.json     # Configuration (e.g., SMTP or Azure settings)
└── VerificationProvider.csproj

````

---

## 🛠️ Getting Started

### Prerequisites
- [.NET 6 SDK+](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- (Optional) Azure Subscription (for deployment)

### Run locally

```bash
dotnet restore
dotnet run
````

Then open:

```
https://localhost:5001/swagger
```

---

## ☁️ Azure Hosting

This microservice is configured for Azure deployment and has been tested with:

* **Azure App Service** for hosting
* **Azure Application Insights** (optional)
* **Custom domains and HTTPS**

---

## 🔐 Usage Example

To verify a token:

```http
GET /api/verify?token=XYZ123
```

Expected response:

```json
{ "status": "success", "message": "Token verified." }
```

---

## 📄 License

This project was built as part of an educational assignment at EC Utbildning.
It is available for demonstration or personal use.

---

Created by **Nour Tinawi**
.NET Fullstack Developer & 3D Visual Designer
[LinkedIn](https://www.linkedin.com/in/nour-tinawi)

