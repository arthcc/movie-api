## 🚀 MovieX API
Welcome to MovieX API, your go-to resource for accessing a rich repository of movie-related data. Whether you're a developer building a movie app, a data enthusiast exploring cinematic details, or a content creator looking to integrate movie information, MovieX has you covered.

#### 📋 Getting Started

1. Clone this repo:
```
git clone https://github.com/arthcc/movie-api
```

2. Open VisualStudio and run:
```
dotnet run
```
3. Available methods: 
```http
  GET /movie/
  GET movie/${genre}
  GET movie/${title}
  POST /Title, Genre, Runtime, Cast
  DELETE /Id 
```
## ⚙️ Required Parameters
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |

| `Genre`      | `string | **Required**. Movie Genre is required |
| `Title`      | `string | **Required**. Movie Title is required |
| `Cast`       | `string | **Required**. Cast name is required   |
| `Id`         | `Guid   | **Required**. Id is required          |
| `Runtime`    | `int    | **Required**.Runtime must be between 70-400 minutes  |

```
## 🛠️ Made With 


* [SQL Lite](https://www.sqlite.org/index.html) - SQL Lite
* [.NET Core](https://dotnet.microsoft.com) - .NET Core
* [EF](https://learn.microsoft.com/en-us/ef/) - Etinity Framework

 ## 📄 License

This project is under  MIT LICENSE  - see  [LICENSE.md](https://github.com/arthcc/movie-api/blob/master/LICENSE) for more details. 

