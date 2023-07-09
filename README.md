## API de Fillmes
Uma API de filmes em .NET com as requisições POST, GET,
#### Métodos até agora

```http
  GET /filme/
  POST /Titulo, Genero, Duração, Elenco
```

#### Get item

```http
  GET filme/${Genero}
  GET filme/${Titulo}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Genero`      | `string | **Obrigatório**. Genero do Filme |
| `Titulo`      | `string | **Obrigatório**. Titulo do Filme |
