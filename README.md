# Sistema de Categorización de Bultos en Tiempo Real (STR) 📦⏱️
---
## 📌 Descripción del Proyecto
Este proyecto consiste en el diseño y simulación de un **Sistema de Tiempo Real (STR)** para la clasificación automatizada de paquetes en una línea de transporte de alta eficiencia. El sistema garantiza una respuesta determinista ante señales ópticas y de pesaje, asegurando que los actuadores mecánicos operen dentro de márgenes temporales críticos para evitar fallos en la cadena de producción.

## ⚙️ Especificaciones Técnicas (Restricciones Temporales)
El pilar fundamental de esta solución es su comportamiento predecible bajo las siguientes métricas de tiempo real:
* **Plazo Máximo (Deadline):** 50 ms. (Tiempo límite para procesar la señal y decidir la ruta).
* **Latencia Mínima:** 5 ms. (Para garantizar la estabilidad de las lecturas sensoriales).
* **Mecanismo de Control:** Implementación de **Exclusión Mutua (Mutex)** para proteger el acceso concurrente al búfer circular de datos.

## 🛠️ Tecnologías y Metodologías
* **Lenguaje de Programación:** Python 3.x (Utilizando la librería `threading` para concurrencia).
* **Modelado:** Diagramas UML (Casos de Uso, Secuencia y Estados) generados mediante **LaTeX (TikZ)**.
* **Control de Versiones:** Git / GitHub.
* **Arquitectura:** Procesamiento paralelo con segmentación de hilos (Hebras de Adquisición y Decisión).

## 📂 Estructura del Repositorio
* `main.py`: Código fuente de la simulación del sistema.
* `/docs`: Documentación técnica en formato PDF y código fuente `.tex`.
* `README.md`: Este archivo con la descripción del proyecto.

## 🚀 Instrucciones de Ejecución
Para ejecutar la simulación y verificar el cumplimiento de los deadlines en tiempo real:

1. Asegúrese de tener Python 3 instalado.
2. Clone el repositorio:
   ```bash
   git clone [https://github.com/marioaless04/STR.git](https://github.com/marioaless04/STR.git)
