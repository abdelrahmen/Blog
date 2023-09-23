# Blog API

A Blog API that simplifies article management for bloggers. It provides essential features for creating and sharing content efficiently and also receive comments on articles.


## Features

- **Article Management**: Create, update, and delete articles.
- **Comment System**: Allow readers to engage with your content through comments.
- **Role-Based Access**: Differentiate between bloggers and readers with role-based access control.
- **Authentication**: Secure your API with user authentication using JWT tokens.

## Technologies Used

- **ASP.NET Core**: The foundation of our API.
- **Entity Framework Core**: For database management and operations.
- **JWT Authentication**: Secure user authentication and authorization.
- **Microsoft Identity Framework**: Manage users and roles.

## Getting Started

To get started with the Blog API, follow these steps:

1. Clone this repository.
2. Configure your database connection in `appsettings.json`.
3. Run database migrations to create the necessary tables.
4. Build and run the API.

You Will find the default blogger account Info in the AppDbContext Class in  the ```OnModelCreating``` Method

## Usage

The API offers a straightforward set of endpoints for managing articles and comments. Here are some common actions:

- Retrieve all articles
- Create a new article
- Update an existing article
- Delete an article
- Retrieve comments for an article
- Create a new comment
- Update a comment
- Delete a comment

For detailed API usage instructions, refer to the [API documentation](http://localhost:{port}/swagger).

## Contributing

We welcome contributions from the community! If you'd like to contribute, please follow these guidelines:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and ensure that tests (if any) pass.
4. Create a pull request with a clear description of your changes.


## Acknowledgments

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [JWT Authentication](https://jwt.io/)

Feel free to reach out if you have any questions or need support.

Happy blogging!
