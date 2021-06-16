# This project is used for testing Angeloid Web API

## Setup instruction

> Follow this instruction to setup your test project with your Web API project

- Go to outside of your Web API project folder type:

```
dotnet new sln -o angel
cd angel
```

- Copy your Web API project to inside the Solution **angel**
- Clone this project inside of **angel** too
- After cloned, follow this step:

```
dotnet new sln add Angeloid/Angeloid.csproj
dotnet new sln add AngeloidTest/AngeloidTest.csproj
cd AngeloidTest
dotnet add reference ../Angeloid/Angeloid.csproj
```

## Before code
- **_Only change code in your task!!_**
- Careful about the project name and folder path