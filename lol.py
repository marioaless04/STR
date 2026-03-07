import random

def generar_poblacion(tamano_poblacion, longitud_cadena):
    poblacion = []
    for _ in range(tamano_poblacion):
        individuo = ''.join(random.choice('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,! ') for _ in range(longitud_cadena))
        poblacion.append(individuo)
    return poblacion

def calcular_fitness(individuo, objetivo):
    fitness = sum(1 for i, j in zip(individuo, objetivo) if i == j)
    return fitness

def seleccionar_padres(poblacion, objetivo):
    padres = random.choices(poblacion, weights=[calcular_fitness(individuo, objetivo) for individuo in poblacion], k=2)
    return padres

def cruzar(padre1, padre2):
    punto_cruce = random.randint(1, len(padre1) - 1)
    hijo1 = padre1[:punto_cruce] + padre2[punto_cruce:]
    hijo2 = padre2[:punto_cruce] + padre1[punto_cruce:]
    return hijo1, hijo2

def mutar(individuo, tasa_mutacion):
    for i in range(len(individuo)):
        if random.random() < tasa_mutacion:
            individuo = individuo[:i] + random.choice('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,! ') + individuo[i+1:]
    return individuo

def algoritmo_genetico(objetivo, tamano_poblacion, tasa_mutacion, generaciones_limite):
    poblacion = generar_poblacion(tamano_poblacion, len(objetivo))
    for generacion in range(generaciones_limite):
        poblacion = sorted(poblacion, key=lambda x: calcular_fitness(x, objetivo), reverse=True)
        mejor_individuo = poblacion[0]
        if mejor_individuo == objetivo:
            return mejor_individuo, generacion
        nueva_generacion = []
        # Elitismo: Mantener el mejor individuo sin cambios
        nueva_generacion.append(mejor_individuo)
        for _ in range((tamano_poblacion - 1) // 2):
            padre1, padre2 = seleccionar_padres(poblacion, objetivo)
            hijo1, hijo2 = cruzar(padre1, padre2)
            hijo1 = mutar(hijo1, tasa_mutacion)
            hijo2 = mutar(hijo2, tasa_mutacion)
            nueva_generacion.extend([hijo1, hijo2])
        poblacion = nueva_generacion

    poblacion = sorted(poblacion, key=lambda x: calcular_fitness(x, objetivo), reverse=True)
    return poblacion[0], generaciones_limite

objetivo = "Hello, World!"
tamano_poblacion = 200
tasa_mutacion = 0.05
generaciones_limite = 2000

resultado, generacion = algoritmo_genetico(objetivo, tamano_poblacion, tasa_mutacion, generaciones_limite)
print("Resultado:", resultado)
print("Generación:", generacion)

