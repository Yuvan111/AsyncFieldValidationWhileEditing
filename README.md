# Async Field Validation While Editing in Blazor

This repository demonstrates how to implement asynchronous field-level validation (e.g., checking username and email availability) in Blazor while the user is actively typing, complete with debouncing and pending status indicators.

Both **Blazor Server** and **Blazor WebAssembly (WASM)** implementations are provided.

---

## Projects Overview

- **`ServerApp`**: A Blazor Server application demonstrating async field validation with server-side interactive components.
- **`WASMApp`**: A Blazor Web App solution containing:
  - `WASMApp`: Host application project.
  - `WASMApp.Client`: Blazor WebAssembly client project containing the interactive `SignUp` page and availability checker service.

---

## Key Features

- **Asynchronous Validation**: Validates user input (such as unique username and email availability) asynchronously against a service (`IAvailabilityChecker`).
- **Debounced Input**: Uses debouncing on `@oninput` events to prevent excessive validation calls while the user types.
- **Visual Feedback**: Displays pending state indicators (e.g., *"Checking username availability…"*), validation error messages via `ValidationMessageStore`, and success messages upon submission.
- **Form Integration**: Integrates directly with Blazor's `EditContext`, `DataAnnotationsValidator`, and `ValidationSummary`.

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
