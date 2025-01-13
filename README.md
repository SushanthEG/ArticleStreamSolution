# ArticleStreamSolution

This is a web application built with **Blazor**, displaying articles fetched from a remote API. It includes state management, error handling.


## **Technologies Used**

- **Blazor WebAssembly**: For building the UI components.
- **C#**: For server-side logic and component management.
- **.NET 8**: Framework for building web applications.
- **CSS**: For styling the components.
- **Dependency Injection**: For injecting services like `DisplayArticleService` and `NavigationManager`.

---

## **Project Structure**

- **Pages/**: Contains Razor components, including `DisplayArticlesList` for displaying articles.
- **Models/**: Contains `ArticleModel.cs` for article data structure.
- **Services/**: Contains services like `DisplayArticleService.cs` for fetching data and `IErrorLogger.cs` for logging errors.
- **Shared/**: Includes shared components like `MainLayout.razor` and `NavMenu.razor`.
- **wwwroot/**: Holds static assets like CSS and images.

---

## **Features**

- **Dynamic Article List**: Displays articles fetched from an API.
- **State Management**: Uses an enum to manage component states (loading, error, success).
- **Error Handling**: Handles errors during data fetching and provides retry options.
- **Responsive UI**: Ensures the UI is user-friendly on various devices.

---

## **Challenges and Solutions**

- **State Management**: I created a custom `ComponentState` enum to track component states and conditionally render UI elements.
- **Error Handling**: I implemented centralized error handling with user-friendly messages and retry options.
- **Asynchronous Data Fetching**: I used `OnInitializedAsync` to fetch data asynchronously and display a loading message while waiting for the data.

---

## **How to Run the Project**

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/ArticleStream.git
    ```

2. **Navigate to the project folder**:
    ```bash
    cd ArticleStream
    ```

3. **Restore NuGet packages**:
    ```bash
    dotnet restore
    ```

4. **Run the application**:
    ```bash
    dotnet run
    ```

5. Open a browser and go to `https://localhost:portnumber`.

---
