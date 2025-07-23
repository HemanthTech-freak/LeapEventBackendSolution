# LeapEventSolution
# 🎟️ LeapEvent Fullstack Application (.NET + Angular 20)

LeapEvent is a fullstack web application that allows users to view upcoming events and analyze ticket sales summaries.  
Built with **ASP.NET Core 8**, **NHibernate**, **SQLite**, and **Angular 20 + Bootstrap**.

---

## 🧾 Features

### ✅ Backend (.NET 8)
- Clean architecture (API, Application, Domain, Persistence)
- SQLite database with NHibernate ORM
- Business logic layered with logging and validations
- Unit tests using **MSTest** + **Moq**

### ✅ Frontend (Angular 20)
- Bootstrap-themed UI 
- Standalone components 
- Events table with sorting
- Sales summary view (Top 5 by tickets & revenue)

---

## ⚙️ System Requirements

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js (v18+)](https://nodejs.org/)
- [Angular CLI v17+](https://angular.io/cli) (Angular 20 uses standalone architecture)
- Code Editor: [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

---

## Solution structure
LeapEvent/
├── LeapEventSolution/
  ├── LeapEvent.API/            # Web API (entry point)
  ├── LeapEvent.Application/    # Business logic layer
  ├── LeapEvent.Domain/         # Domain models, DTOs
  ├── LeapEvent.Infrastructure/ # Interfaces, Logging
  ├── LeapEvent.Persistence/    # NHibernate Repos
  ├── LeapEvent.Tests/          # Unit tests using MSTest
├── LeapEventUISolution
  ├── leap-events-ui/           # Angular 20 frontend

## 🧑‍💻 Getting Started

### 📦 1. Clone the Repository

```bash
git clone https://github.com/your-username/leapeventbackendsolution.git
git clone https://github.com/your-username/leapeventuisolution.git
cd leapevent
```
## 🔧 Backend Setup (.NET API)

### 📁 Step 1: Navigate to the Backend Folder

```bash
cd LeapEvent/LeapEvent/LeapEventSolution
```
### 📦 Step 2: Restore & Build

```bash
dotnet restore
dotnet build
```
### 🗃️ Step 3: Setup SQLite Database (Ensure the db file exists in below path)

```bash
LeapEvent.API/Data/SkillsAssessmentEvents.db
```
--If not, you can:

--Copy a pre-seeded version of SkillsAssessmentEvents.db

### ▶️ Step 4: Run the API

```bash
dotnet run --project LeapEvent.API
```
--Your API will be running at: https://localhost:7034/

<img width="1151" height="548" alt="image" src="https://github.com/user-attachments/assets/02c26564-1ab5-4309-9f8d-e08a54c7e841" />

### 📡 Step 5: Test Endpoints

--Use postman or swagger to test the endpoints

GET http://localhost:5000/api/events?days=30
GET http://localhost:5000/api/tickets/top-by-sales
GET http://localhost:5000/api/tickets/top-by-revenue


## 🌐 Frontend Setup (Angular 20)

### 📁 Step 1: Navigate to Frontend Folder

```bash
cd ../../../../leap-events-ui
```
### 📦 Step 2: Install Angular CLI

```bash
npm install -g @angular/cli
```
### 📦 Step 3: Install Dependencies

```bash
npm install
```
### ▶️ Step 4: Run the Angular App

```bash
ng serve --open
```
--App will launch at: http://localhost:4200
--Make sure the backend is running on https://localhost:7034/

<img width="1151" height="256" alt="image" src="https://github.com/user-attachments/assets/74315c59-b3eb-4ee3-9b87-88b03476221c" />


## 🧪 Running Unit Tests (MSTest)

### 📁 Navigate to test project

```bash
cd LeapEvent.Tests
```
### ▶️ Run all tests

```bash
dotnet test
```
<img width="659" height="302" alt="image" src="https://github.com/user-attachments/assets/d0baff51-2cac-4391-9b09-41266bf98745" />






