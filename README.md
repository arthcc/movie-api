## API de Fillmes
Uma API de filmes em .NET com as requisições POST, GET, FETCH
#### Mostrar todos os Itens

```http
  GET /filme/
```

#### Get item

```http
  GET filme/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int | **Obrigatório**. ID do Item |
