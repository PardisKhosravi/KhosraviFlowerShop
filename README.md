# KhosraviFlowerShop
An e-commerce web application for an online flower shop,
built as a university project during my Bachelor's degree.

## Tech Stack

- ASP.NET Core MVC
- Entity Framework Core (Code First with Migrations)
- SQL Server
- Bootstrap 5
- JavaScript / jQuery

## Architecture

The project follows a layered MVC architecture:

- **Controllers** — request handling and routing
- **Models / ViewModels** — separate view models to
  decouple the domain layer from the presentation layer
- **Areas** — separated admin panel from the customer-facing store
- **View Components** — reusable UI components
- **Migrations** — Code First database schema management

## Features

- Product catalogue and detail pages
- Shopping cart
- Admin panel for product management
- Full RTL (right-to-left) layout support for Persian UI

## Database

The database schema can be recreated by running `Script.sql`.

## Note

The application interface and product data are in Persian.
The codebase, structure, and documentation are in English.
