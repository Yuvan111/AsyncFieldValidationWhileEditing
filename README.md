# Async Field Validation While Editing in Blazor

This repository demonstrates .NET 11 asynchronous field validation in Blazor while the user edits a sign-up form.

Both **Blazor Server** and **Blazor WebAssembly (WASM)** implementations are provided.

---

## Projects Overview

- **`ServerApp`**: A Blazor Server application demonstrating async field validation with server-side interactive components.
- **`WASMApp`**: A Blazor Web App solution containing:
  - `WASMApp`: Host application project.
  - `WASMApp.Client`: Blazor WebAssembly client project containing the interactive `SignUp` page and availability checker service.

---

## Key Features

- Uses `AsyncValidationAttribute` with `DataAnnotationsValidator`.
- Displays framework-managed pending and faulted states through `EditContext`.
- Cancels and supersedes an outstanding field check when the value changes.
- Allows username and email checks to run and settle independently.

## Values to Try

| Field | Taken | Faulted |
|---|---|---|
| Username | `admin` or `takenuser` | `error` |
| Email | `taken@example.com` | `error@example.com` |

Most username checks take 3 seconds and email checks take 2 seconds. For the same-field supersession scenario, enter `takenuser` (5 seconds), then replace it with `newuser` (1 second).

---

## Prerequisites

- [.NET 11 SDK](https://dotnet.microsoft.com/) (`11.0.100-rc.1.26431.118` or later) pinned via `global.json`.

---

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd AsyncFieldValidationWhileEditing
```

### 2. Run Blazor Server App

```bash
cd ServerApp
dotnet run
```

Navigate to `http://localhost:5000` (or the URL shown in your terminal) and open the **Sign up** page (`/signup`).

### 3. Run Blazor WebAssembly App

```bash
cd WASMApp/WASMApp
dotnet run
```

Navigate to the application URL and open the **Sign up** page (`/signup`).
