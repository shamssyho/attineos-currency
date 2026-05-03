# Attineos Currency API

API REST développée en .NET pour gérer des currencies (cryptos, devises, etc.).

## 🚀 Technologies utilisées

- .NET 9
- Entity Framework Core
- SQLite
- Swagger (documentation API)

---

## 📁 Architecture

Le projet est structuré de manière simple :

- `Controllers` → gestion des endpoints HTTP
- `Services` → logique métier
- `Repositories` → accès aux données
- `Entities` → modèles de base de données
- `DTOs` → objets d'entrée API
- `Data` → DbContext (connexion base de données)

---

## ⚙️ Installation

### 1. Cloner le projet

```bash
git clone https://github.com/shamssyho/attineos-currency
cd attineos-currency
```
### 2. Installer les dépendances

```bash
dotnet restore
```

### 3. Appliquer la base de données

```bash
dotnet ef database update
```

## ▶️ Lancer le projet
```bash
dotnet run
```
