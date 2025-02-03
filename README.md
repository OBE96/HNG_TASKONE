# HNG_TASK1
## Number Properties API
**Description:**


A .NET Web API that takes a number as input and returns interesting mathematical properties about it, along with a fun fact.

**Key Features**

Mathematical Properties:

- Checks if the number is prime.

- Checks if the number is perfect.

- Checks if the number is an Armstrong number.

- Determines if the number is odd or even.

- Calculates the sum of its digits.

Fun Fact:

- Provides a fun fact about the number, especially if it is an Armstrong number.

Error Handling:

- Returns a 400 Bad Request response for invalid inputs (e.g., non-numeric values).


CORS Support: 
- The API is configured to allow requests from all origins by default. You can customize the CORS policy to restrict access to specific origins if needed.

# SETUP INSTRUCTION

Follow these steps to set up and run the project locally.

Prerequisites
.NET SDK (version 6.0 or later) installed on your machine.

Steps to Run the Project

1.  Clone the Repository:
>>bash   
git clone https://github.com/OBE96/HNG_TASK_0.git      
cd my-repo

2.  Build the Project:
Run the following command to restore dependencies and build the project:
>>bash     
dotnet build

3. Run the Application:
Start the API using the following command:

>>bash     
dotnet run    
4. Access the API:

The API will be available at https://hng-task-0-xm9v.onrender.com/api/HNGTASKZERO .

You can test the API using a browser, Postman, or any HTTP client.


# API DOCUMENTATION

Endpoint
* https://hng-task-0-xm9v.onrender.com/api/HNGTASKZERO

Request
* No request body or parameters are required.

Response
* Status Code: 200 OK

Response Format:

json
![h1](https://github.com/user-attachments/assets/9b634503-c132-409f-abda-45d1684f1028)

Example Usage
1. Send a GET request to https://hng-task-0-xm9v.onrender.com/api/HNGTASKZERO

2.You will receive the following response:

json
![h1](https://github.com/user-attachments/assets/072a62e6-f202-42ca-86f2-78db43a1c47b)


# BACKLINK
https://hng.tech/hire/csharp-developers

