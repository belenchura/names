# Nombres-MS

### Endpoint: Obtener Nombres Filtrados

- **Método**: GET
- **URL**: `/api/names`
- **Descripción**: Este endpoint permite obtener una lista de nombres filtrados según los parámetros proporcionados.

#### Parámetros de Consulta
- `gender`: (Opcional) Género del nombre.
  - Ejemplo: `"M"` para masculino, `"F"` para femenino.
- `nameStartsWith`: (Opcional) Filtra nombres que comienzan con un carácter específico.
  - Ejemplo: `"A"` para nombres que inician con "A".
- Ejemplo: `GET /api/names?gender=M&nameStartsWith=A`

#### Respuesta
- **Código de Respuesta**: `200 OK`
- **Cuerpo de Respuesta**:
  ```json
  [
      "Adrian",
      "Alejandro",
      "Alvaro",
      ...
  ]

## Tecnologías Usadas
- **.NET 8.0**: LTS
- **C#**: Lenguaje de programación
- **Swagger**: Para documentación de la API
- **XUnit**: Para pruebas unitarias
- **Moq**: Para simulaciones en pruebas

## Installation

1. Clona el repositorio:
   ```bash
   git clone https://github.com/belenchura/names.git
