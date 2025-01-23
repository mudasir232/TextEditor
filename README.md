---

# Text Editor Project

Welcome to the **Text Editor** project! This is a lightweight, feature-rich text editor inspired by Microsoft Word. It provides all the essential tools for creating, editing, and formatting documents, powered by the **TinyMCE API**. Whether you're drafting a simple note or a complex document, this editor has you covered.

## Features
- **Rich Text Editing**: Bold, italics, underline, bullet points, numbering, and more.
- **TinyMCE Integration**: Utilizes the TinyMCE API for a seamless editing experience.
- **Database Connectivity**: Save and retrieve documents from a database.
- **Easy Setup**: Configure your API key and database connection in just a few steps.

---

## How It Works

This project uses the **TinyMCE API** to provide a rich text editing interface. The API key is free for a 7-day trial (no credit card required). Once you replace the default API key with your own, you can connect the editor to a database by configuring the `appsettings.json` file. The project uses a **NuGet Package Manager Console** to update the database schema and store/retrieve documents.

---

## Prerequisites

Before you begin, ensure you have the following:

1. **TinyMCE API Key**: Get a free API key from [TinyMCE](https://www.tiny.cloud/).
2. **.NET SDK**: Make sure you have the .NET SDK installed.
3. **Database**: Set up a local or remote database (e.g., SQL Server, MySQL).
4. **NuGet Package Manager**: Ensure you have NuGet installed in your development environment.

---

## Setup and Installation

### Step 1: Clone the Repository

Clone this repository to your local machine:

```bash
git clone https://github.com/your-username/texteditor.git
cd texteditor
```

### Step 2: Get Your TinyMCE API Key

1. Visit [TinyMCE](https://www.tiny.cloud/) and sign up for a free account.
2. Generate an API key (no credit card required).
3. Replace the placeholder API key in the project with your new key.

### Step 3: Configure the Database

1. Open the `appsettings.json` file in the project.
2. Update the connection string with your database details:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Your_Database_Connection_String"
   }
   ```
3. Save the file.

### Step 4: Update the Database Schema

1. Open the **NuGet Package Manager Console** in Visual Studio.
2. Run the following commands to update the database:
   ```bash
   Add-Migration InitialCreate
   Update-Database
   ```

### Step 5: Run the Project

1. Build the project to ensure all dependencies are installed.
2. Run the project using:
   ```bash
   dotnet run
   ```
3. Open your browser and navigate to `http://localhost:5000` (or the port specified in your setup).

---

## Usage

- **Create a New Document**: Start typing in the editor. Use the toolbar to format your text.
- **Save a Document**: Click the "Save" button to store your document in the database.
- **Retrieve a Document**: Use the "Load" feature to open a previously saved document.

---

## Troubleshooting

- **API Key Not Working**: Ensure you’ve replaced the placeholder key with your valid TinyMCE API key.
- **Database Connection Issues**: Double-check your connection string in `appsettings.json`.
- **Migration Errors**: Make sure your database is running and accessible.

---

## Contributing

Feel free to contribute to this project! If you find any bugs or have suggestions for improvements, please open an issue or submit a pull request.

---

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## Acknowledgments

- **TinyMCE**: For providing an excellent rich text editor API.
- **.NET Community**: For the tools and libraries that made this project possible.

---

Enjoy using the Text Editor! If you have any questions or need further assistance, feel free to reach out.

---
