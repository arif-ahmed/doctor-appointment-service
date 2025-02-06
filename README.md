# 🏥 Appointment Management API 🚀

A simple RESTful API built with **ASP.NET Core** to manage patient appointments for a healthcare clinic. The API provides secure endpoints for user authentication and appointment management, ensuring that only authorized users can access or modify appointment data.

## 📋 Table of Contents

1. [Project Overview](#project-overview)
2. [Key Features](#key-features)
3. [Data Models](#data-models)
4. [Authentication & Security](#authentication--security)
5. [API Endpoints](#api-endpoints)
6. [Roadmap & Estimation](#roadmap--estimation)
7. [Setup & Installation](#setup--installation)
8. [Testing the API](#testing-the-api)
9. [Potential Risks & Mitigations](#potential-risks--mitigations)
10. [Evaluation Criteria](#evaluation-criteria)

## 🏥 Project Overview

The **Appointment Management API** is designed to help clinics manage patient appointments effectively. It allows:
- 📋 **Creating**, **retrieving**, **updating**, and **deleting** appointments.
- 🔐 **Securing endpoints** using JWT-based authentication.
- 🗂️ Managing **users**, **appointments**, and **doctors** data seamlessly.

## ⚡ Key Features

### 🔐 User Authentication
- **Register a User** `POST /register` – Register new users with username & password.
- **Login** `POST /login` – Authenticate users and return a JWT token for secure API access.

### 📆 Appointment Management (JWT Protected)
- **Create Appointment** `POST /appointments` – Add new appointments with patient & doctor details.
- **Get All Appointments** `GET /appointments` – Fetch all appointments.
- **Get Appointment by ID** `GET /appointments/{id}` – Retrieve specific appointment details.
- **Update Appointment** `PUT /appointments/{id}` – Modify appointment details.
- **Delete Appointment** `DELETE /appointments/{id}` – Remove an appointment.

## 🗂️ Data Models

### 👤 User
- `UserID` (Auto-generated)
- `Username`
- `Password` (Hashed for security)

### 👨‍⚕️ Doctor
- `DoctorID` (Auto-generated)
- `DoctorName`

### 📋 Appointment
- `AppointmentID` (Auto-generated)
- `PatientName`
- `PatientContactInfo`
- `AppointmentDateTime`
- `DoctorID`

## 🔐 Authentication & Security

- ✅ **JWT-Based Authentication:** Secures all appointment-related endpoints.
- ✅ **Password Hashing:** User passwords are securely hashed.
- ✅ **Authorization Header:** Requires `Bearer <JWT_TOKEN>` for protected routes.

## 📊 API Endpoints

### 🔐 Authentication
- **POST `/register`** – Register a new user.
- **POST `/login`** – Authenticate and receive a JWT token.

### 📋 Appointment Management (Requires JWT Token)
- **POST `/appointments`** – Create an appointment.
- **GET `/appointments`** – Retrieve all appointments.
- **GET `/appointments/{id}`** – Get appointment details by ID.
- **PUT `/appointments/{id}`** – Update appointment details.
- **DELETE `/appointments/{id}`** – Delete an appointment.

## 🗺️ Roadmap & Estimation

### **Phase 1: Project Setup & Initial Configuration (1-2 Days)**
- Set up the ASP.NET Core Web API project.
- Install required NuGet packages (EF Core, JWT, etc.).
- Configure MSSQL database.

### **Phase 2: Authentication Module (2-3 Days)**
- User Registration & Login implementation.
- JWT token generation & middleware setup.

### **Phase 3: Appointment Management Module (4-5 Days)**
- CRUD operations for appointments.
- Apply JWT authorization to endpoints.

### **Phase 4: Database Integration (2-3 Days)**
- Design User, Doctor, Appointment models.
- Implement EF Core migrations & seed data.

### **Phase 5: Validation & Error Handling (2 Days)**
- Input validation (e.g., future appointment dates).
- Error handling for invalid inputs and unauthorized access.

### **Phase 6: Testing (3 Days)**
- Write unit tests using XUnit/NUnit.
- Manual testing with Postman.

### **Phase 7: Documentation (1 Day)**
- Prepare API documentation (this README).

### **Phase 8: Final Review & Submission (1 Day)**
- Code review, refactoring, and final submission.

### ⏱️ Estimation Summary

| **Phase**                        | **Estimated Time** |
|:---------------------------------|:------------------:|
| Project Setup                    | 1-2 Days          |
| Authentication Module            | 2-3 Days          |
| Appointment Management           | 4-5 Days          |
| Database Integration             | 2-3 Days          |
| Validation & Error Handling      | 2 Days            |
| Testing (Automated & Manual)     | 3 Days            |
| Documentation                    | 1 Day             |
| Final Review & Submission        | 1 Day             |
| **Total Estimated Time**         | **16–20 Days**    |
