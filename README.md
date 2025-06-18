# BlogPublisher

**Graduation Project - ITI**

A Blog Website built using **ASP.NET MVC (.NET Framework)**.

---

## 🎯 Project Description

This project is a blog management platform that supports three main user roles:

- **Admin**: Manages users, authors, and content.
- **Author**: Creates, edits, and manages blog posts.
- **User**: Views posts and interacts with content.

---

## 🔐 Authentication

- Uses **cookies-based sessions** to handle login state for each role.
- Each role has different permissions and dashboard access.

---

## 🛠️ Technologies Used

- ASP.NET MVC
- Entity Framework
- SQL Server
- Razor Views
- Bootstrap (for UI)

---

## 👩‍💻 Team

This project was developed as part of the **ITI Graduation Project**.

---

## 📂 Structure

```plaintext
Controllers/
  - AdminController.cs
  - AuthorController.cs
  - AccountController.cs
Models/
  - ApplicationUser.cs
  - BlogPost.cs
  - Comment.cs
Views/
  - Admin/
  - Author/
  - Shared/
