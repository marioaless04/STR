import threading
import time
import random

# Simulación de un Mutex para proteger el acceso a los datos
mtx = threading.Lock()

def sensor_acquisition():
    package_id = 0
    print(f"{'='*50}")
    print(f"INICIANDO SISTEMA DE CATEGORIZACION (PYTHON SRT)")
    print(f"{'='*50}\n")

    while package_id < 10:
        # Intervalo entre bultos (Simulando la cinta transportadora)
        time.sleep(1.0) 
        
        # Inicio del cronómetro para el Deadline (50ms)
        start_time = time.time()
        package_id += 1
        
        with mtx:
            print(f"[SENSOR] Bulto detectado ID: {package_id}")

        # Simulación del "Cálculo de Ruta" (Algoritmo de clasificación)
        # Simulamos un proceso que toma entre 20 y 30 ms
        processing_delay = random.uniform(0.020, 0.030)
        time.sleep(processing_delay)
        
        # Fin del proceso
        end_time = time.time()
        
        # Cálculo de latencia en milisegundos
        elapsed_ms = (end_time - start_time) * 1000
        
        # Validación del Deadline de 50ms
        status = "OK - DENTRO DE PLAZO" if elapsed_ms < 50 else "FALLO - DEADLINE EXCEDIDO"
        
        print(f"[CONTROL] Decisión bulto {package_id} tomada en: {elapsed_ms:.2f} ms")
        print(f"ESTADO: {status}")
        print("-" * 40)

if __name__ == "__main__":
    # Creación de la hebra de adquisición
    t1 = threading.Thread(target=sensor_acquisition)
    t1.start()
    t1.join()
    print("\nSimulación finalizada exitosamente.")