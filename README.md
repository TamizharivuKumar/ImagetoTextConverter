# Image-to-Text Converter with ASP.NET Core, Angular, and Azure Cognitive Services

This project demonstrates an image-to-text converter application using ASP.NET Core, Angular, and Microsoft Azure Cognitive Services. Users can upload images, which are then processed by Azure’s Computer Vision API to extract text.

## Table of Contents

1. [Introduction](#introduction)
2. [Microsoft.Azure.CognitiveServices.Vision.ComputerVision](#microsoftazurecognitiveservicesvisioncomputervision)
3. [Features](#features)
4. [Prerequisites](#prerequisites)
5. [Setup](#setup)
   - [Backend (ASP.NET Core)](#backend-aspnet-core)
   - [Frontend (Angular)](#frontend-angular)
6. [Running the Application](#running-the-application)
7. [Conclusion](#conclusion)

## Introduction

In this project, we'll guide you through building an image-to-text converter application using ASP.NET Core for the backend, Angular for the frontend, and Microsoft's Azure Cognitive Services for the image processing. The application will enable users to upload images, process them with Azure's Computer Vision API, and display the extracted text.

## Microsoft.Azure.CognitiveServices.Vision.ComputerVision

The `Microsoft.Azure.CognitiveServices.Vision.ComputerVision` NuGet package allows .NET applications to interact with Azure's Computer Vision API. This package provides a client library to communicate with the API, which includes features for analyzing images, extracting text, and more.

### Key Components

- **`ComputerVisionClient`**: The main client class used to call Azure’s Computer Vision API endpoints.
- **`ReadInStreamAsync`**: A method that submits an image to Azure for text extraction and returns an operation location for tracking.
- **`GetReadResultAsync`**: A method that checks the status of the text extraction operation and retrieves the results once processing is complete.

### How It Works

1. **Submit Image for Processing**:
   - The image is sent to Azure’s Computer Vision API using `ReadInStreamAsync`.
   - The API returns an operation location URL where the processing status can be checked.

2. **Check Operation Status**:
   - The status of the text extraction operation is monitored using `GetReadResultAsync`.
   - Once processing is complete, the text extracted from the image is retrieved.

3. **Extract and Compile Text**:
   - The results are parsed to extract lines of text, which are then compiled into a single string.

This approach allows seamless integration with Azure’s powerful AI capabilities to perform complex image processing tasks with minimal setup.

## Features

- Image upload and preview
- Text extraction from images
- Display of extracted text
- Basic error handling for file types

## Prerequisites

- .NET SDK (6.0 or later)
- Node.js and npm
- Azure Cognitive Services subscription key and endpoint

## Setup

### Backend (ASP.NET Core)

1. **Create the ASP.NET Core Project:**
   - Use Visual Studio or the .NET CLI to create a new Web API project.

2. **Add NuGet Package:**
   - Install the `Microsoft.Azure.CognitiveServices.Vision.ComputerVision` package.

   ```sh
   dotnet add package Microsoft.Azure.CognitiveServices.Vision.ComputerVision
   ```

3. **Configure Azure Cognitive Services:**
   - Add your Azure subscription key and endpoint to the backend configuration.

4. **Implement Controllers and Services:**
   - Create a file upload controller to handle image uploads.
   - Implement a service to interact with the Computer Vision API.

5. **Configure CORS:**
   - Set up CORS in `Program.cs` to allow requests from the Angular frontend.

### Frontend (Angular)

1. **Create the Angular Project:**
   - Use Angular CLI to create a new project.

   ```sh
   ng new ImageToText
   cd ImageToText
   ```

2. **Set Up Components and Services:**
   - Create a file upload component to handle image uploads and display extracted text.
   - Implement a service to communicate with the backend API.

3. **Install Dependencies:**
   - Ensure `@angular/common` and `@angular/http` are installed and configured.

4. **Configure API URL:**
   - Set the backend API URL in the Angular service.

## Running the Application

1. **Run the ASP.NET Core Backend:**
   ```sh
   dotnet run
   ```

2. **Run the Angular Frontend:**
   ```sh
   ng serve
   ```

3. **Access the Application:**
   - Open your browser and navigate to `http://localhost:4200` to use the application.

## Conclusion

In this Repo, we built a functional image-to-text converter application using ASP.NET Core and Angular. The application leverages Azure's Computer Vision API to extract text from images, demonstrating the effective integration of cloud-based AI services with modern web technologies. This setup provides a solid foundation for building more complex applications involving real-time image processing and text extraction.
