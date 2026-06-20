# 🛠️ Skill Management System

An application designed to manage, track, and audit skill competencies and employee proficiencies within an organization. 

---

## 📂 Repository Structure

This repository contains a standard .NET solution split into logical components to separate business concerns from data management and user interfaces:

* **SkillManagement.CoreBusiness** - Contains the primary domain models, objects, and core logic governing skills, categories, and tracking rules.
* **SkillManagement.UseCases** - Implements application-specific business rules and orchestrates the data flow to and from the core business entities.
* **SkillManagement.Plugins** - Houses data access components, infrastructure adapters, and data persistence drivers.
* **SkillManagement.WebApp** - The front-end user interface and presentation layer enabling user interaction with the management system.

---

## 🛠️ Prerequisites & Local Setup

### Prerequisites
To run and build this project locally, ensure you have the following installed:
* **Visual Studio** (2019 / 2022 recommended with .NET desktop or web development workloads)
* **.NET Framework** (Ensure the targeted version is installed via the Visual Studio Installer)
* **SQL Server** (LocalDB, Express, or an active instance configured in your application connection strings)

### 🚀 Getting Started

1. **Clone the Repository:**
   ```bash
   git clone [https://github.com/MRFekry/SkillManagement.git](https://github.com/MRFekry/SkillManagement.git)
   cd SkillManagement
