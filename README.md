<h1 align="center">
  <br>
  <a href="https://github.com/Amir-Battal">
    <img src="https://www.jetbrains.com/guide/assets/csharp-logo-265a149e.svg" alt=C#" width="200">
    <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/1200px-Microsoft_.NET_logo.svg.png" alt=".NET" width="200">
  </a>
  <br>
  Sanad Management System // Backend
  <br>
</h1>

<h4 align="center">This project is Management System for Educational and Training Center.</h4>

<div align="center">

  ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
  ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
  ![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
  ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
</div>

<p align="center">
  <a href="#key-features">Key Features</a> •
  <a href="#erd">ERD</a> •
  <a href="#api-reference">API Reference</a> •
  <a href="#run-locally">Run Locally</a> •
  <a href="#credits">Credits</a> •
  <a href="#license">License</a>
</p>


## Key Features

* Users:
  - Create a user with multiple data such as Id, name, email, password.
  - The user is in a one-to-one relationship with the employee.
  - The user is in a many-to-many relationship with the activity.


* Employees:
  - Create an employee with multiple data such as Id, isCoach, Salary, Hours.
  - This employee is the same user, but if he is an employee, he has additional data.
  - The employee is in one-to-one relationship with the users.
  - The employee is in many-to-many relationship with the activity.


* Activities:
  - Create an activity with multiple data such as Id, Title, Description, Category, Budget.
  - The activity is in a many-to-many relationship with the users include more data such as bucketMoney, and isFavorite.
  - The activity is in a many-to-many relationship with the employees.


## ERD
![SanadManagementSystemERD](https://github.com/user-attachments/assets/cfd6b159-e79b-4a86-998f-4d47154940a0)



## API Reference

#### User API's
#### Get all users

```http
  GET /api/User
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |

#### Get all beneficiries user

```http
  GET /api/User/GetAllBeneficiaries
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |

#### Get user by Id

```http
  GET /api/User/id
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |
| `id` | `string` | **Required**. userId |


#### Create new user

```http
  POST /api/User
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. user data form |


<br />

#### Employee API's
#### Get all Employees

```http
  GET /api/Employee
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |

#### Get employee by Id

```http
  GET /api/Employee/id
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |
| `id` | `string` | **Required**. employeeId |


#### Create new employee

```http
  POST /api/Employee
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. employee data form |


<br />

#### Activity API's
#### Get all Activities

```http
  GET /api/Activity
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |

#### Get Activity by Id

```http
  GET /api/Activity/id
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |
| `id` | `string` | **Required**. activityId |


#### Create new activity

```http
  POST /api/Activity
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. activity data form |


<br />

#### Activity Employee API's
#### Get ActivityEmployee by employeeId

```http
  GET /api/ActivityEmployee/{employeeId}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |
| `id` | `string` | **Required**. employeeId |


#### Create new ActivityEmployee

```http
  POST /api/ActivityEmployee
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. activityEmployee data form |


<br />

#### User Activity API's
#### Get UserActivity by userId

```http
  GET /api/UserActivity/{userId}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |
| `id` | `string` | **Required**. userId |


#### Get Favorite UserActivity by userId

```http
  GET /api/UserActivity/GetUserFavActivity
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key if it is exist |
| `id` | `string` | **Required**. userId |


#### Create new UserActivity

```http
  POST /api/UserActivity
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. userActivity data form |


<br />

## Run Locally

Clone the project

```bash
  git clone https://github.com/Amir-Battal/SanadManagementSystem.git
```

Go to the project directory

```bash
  cd SanadManagementSystem
```

Run Project using Visual Studio or Rider from Green arrow button

To run Project you will to add your connection string to database,
this project use postgres Database management system 

connection string be like that
```bash
  Server=127.0.0.1;Port=5432;Database=SanadManagementSystem;User Id='';Password='';
```

## Credits

This software uses the following open source packages:

- [.NET](https://dotnet.microsoft.com/en-us/)
- [Asp.Net Core](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [Postgres](https://www.postgresql.org/)
- [Swagger](https://swagger.io/)


## License

Sanad

---

> Linkedin [Amir Battal](https://www.linkedin.com/in/amir-battal/) &nbsp;&middot;&nbsp;
> GitHub [@Amir-Battal](https://github.com/Amir-Battal) &nbsp;&middot;&nbsp;
