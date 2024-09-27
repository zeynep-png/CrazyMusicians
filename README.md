# Crazy Musicians API

## Project Overview
The **Crazy Musicians API** is a playful and entertaining project built using ASP.NET Core Web API. It allows for managing a group of eccentric musicians with their unique quirks and abilities. The API supports basic CRUD (Create, Read, Update, Delete) operations on the musician data.

This API is perfect for learning and practicing web development skills, offering various ways to handle data efficiently, apply routing strategies, and include validation mechanisms.

## Features

- **GET Endpoints** for retrieving musician data.
- **POST Endpoint** to add new musicians.
- **PUT Endpoint** for updating existing musician details.
- **PATCH Endpoint** to partially update specific musician attributes.
- **DELETE Endpoint** to remove a musician from the list.
- **Search Functionality** using [FromQuery] for filtering based on specific criteria.

## Technology Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core (for data handling)
- In-memory database (for demo purposes)

---

## API Endpoints

### 1. **GET All Musicians**

- **URL:** `/api/musicians`
- **Method:** `GET`
- **Description:** Fetch all musicians with their fun attributes.
  
#### Sample Response:
```json
[
  {
    "id": 1,
    "name": "Ahmet Çalgı",
    "job": "Famous Instrument Player",
    "funFact": "Always plays the wrong notes, but still very entertaining"
  },
  ...
]
```

### 2. **GET Specific Musician by ID**

- **URL:** `/api/musicians/{id}`
- **Method:** `GET`
- **Description:** Retrieve a single musician by their unique ID.

#### Sample Response:
```json
{
  "id": 3,
  "name": "Cemil Akor",
  "job": "Crazy Chordist",
  "funFact": "Often changes chords, but is surprisingly talented"
}
```

### 3. **Search Musicians by Name**

- **URL:** `/api/musicians/search`
- **Method:** `GET`
- **Description:** Search for musicians by their name using the [FromQuery] parameter.
- **Query Parameter:** `?name=Ahmet`

#### Sample Response:
```json
[
  {
    "id": 1,
    "name": "Ahmet Çalgı",
    "job": "Famous Instrument Player",
    "funFact": "Always plays the wrong notes, but still very entertaining"
  }
]
```

### 4. **Create a New Musician**

- **URL:** `/api/musicians`
- **Method:** `POST`
- **Description:** Add a new musician to the database.
  
#### Sample Request:
```json
{
  "name": "New Musician",
  "job": "Creative Job",
  "funFact": "Something fun and quirky"
}
```

#### Sample Response:
```json
{
  "id": 11,
  "name": "New Musician",
  "job": "Creative Job",
  "funFact": "Something fun and quirky"
}
```

### 5. **Update a Musician's Details (Full Update)**

- **URL:** `/api/musicians/{id}`
- **Method:** `PUT`
- **Description:** Fully update an existing musician's details.
  
#### Sample Request:
```json
{
  "name": "Updated Musician Name",
  "job": "Updated Job",
  "funFact": "Updated fun fact"
}
```

#### Sample Response:
```json
{
  "id": 5,
  "name": "Updated Musician Name",
  "job": "Updated Job",
  "funFact": "Updated fun fact"
}
```

### 6. **Partially Update a Musician's Fun Fact**

- **URL:** `/api/musicians/{id}/funfact`
- **Method:** `PATCH`
- **Description:** Partially update a specific musician's fun fact.

#### Sample Request:
```json
{
  "funFact": "New quirky fact"
}
```

#### Sample Response:
```json
{
  "id": 2,
  "name": "Zeynep Melodi",
  "job": "Popular Melody Writer",
  "funFact": "New quirky fact"
}
```

### 7. **Delete a Musician**

- **URL:** `/api/musicians/{id}`
- **Method:** `DELETE`
- **Description:** Delete a musician by their ID.

#### Sample Response:
```json
{
  "message": "Musician with ID 6 deleted successfully"
}
```

---

## Validations
To ensure data integrity and proper API usage, the following validations are enforced:

- **Name:** Must be a non-empty string.
- **Job:** Must be a valid string describing the musician’s role.
- **Fun Fact:** Should be a short, non-empty string describing the musician's fun characteristic.


