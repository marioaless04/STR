import threading
import time
import random

# 1. Semáforo: Controla el flujo de trabajo entre hilos.
# Comienza en 0 para que el brazo esté bloqueado hasta que el sensor le de paso.
sem_brazo = threading.Semaphore(0)

# Simulación de un Mutex para proteger el acceso a los datos
mtx = threading.Lock()

def sensor_acquisition():
    package_id = 0
    print(f"{'='*50}")
    print(f"INICIANDO SISTEMA DE CATEGORIZACION CON SEMÁFOROS")
    print(f"{'='*50}\n")

    while package_id < 10:
        # Intervalo entre bultos (Simulando la cinta transportadora)
        time.sleep(1.5) 
        
        # Inicio del cronómetro
        start_time = time.time()
        package_id += 1
        
        with mtx:
            print(f"[SENSOR] Bulto detectado ID: {package_id}")

        # Simulación del "Cálculo de Ruta" (Algoritmo de clasificación) entre 20s - 30s
        processing_delay = random.uniform(0.020, 0.030)
        time.sleep(processing_delay)
        
        # Fin del proceso
        end_time = time.time()
        
        # Cálculo de latencia en milisegundos
        elapsed_ms = (end_time - start_time) * 1000
        
        # Validación del Deadline de 50ms
        status = "OK" if elapsed_ms < 50 else "FALLO - DEADLINE EXCEDIDO"
        
        with mtx:
            print(f"[CONTROL] Bulto {package_id} procesado en: {elapsed_ms:.2f} ms ({status})")
            print(f"[CONTROL] Liberando semáforo para el Actuador...")

        #SEÑALIZACIÓN: El semáforo incrementa su valor, permitiendo que el brazo actúe.
        sem_brazo.release() 
        print("-" * 40)
def actuador_brazo():
    """ Hilo independiente que representa el brazo mecánico """
    while True:
        # 3. ESPERA: El brazo se bloquea aquí hasta que el semáforo sea > 0
        sem_brazo.acquire() 
        
        with mtx:
            print(f"    [BRAZO] >>> Recibida señal del semáforo. Moviendo paquete...")
        
        # Simula el tiempo que tarda el brazo físico en moverse
        time.sleep(0.2) 
        
        with mtx:
            print(f"    [BRAZO] >>> Acción completada. Esperando nueva señal.")

if __name__ == "__main__":
   # Creamos dos hilos para demostrar procesamiento paralelo y sincronización
    t_sensor = threading.Thread(target=sensor_acquisition)
    t_brazo = threading.Thread(target=actuador_brazo, daemon=True) # Daemon para que cierre al terminar el principal

    t_brazo.start()
    t_sensor.start()

    t_sensor.join()
    print("\nSimulación finalizada exitosamente.")