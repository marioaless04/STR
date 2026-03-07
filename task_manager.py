class TaskManager:
    def __init__(self):
        self.tasks = {}  # Diccionario para almacenar tareas {id: {"title": ..., "description": ...}}

    def create_task(self, task_id, title, description):
        if not title:
            return "Error: El título no puede estar vacío"
        self.tasks[task_id] = {"title": title, "description": description}
        return "Tarea creada"

    def edit_task(self, task_id, new_title, new_description):
        if task_id not in self.tasks:
            return "Error: Tarea no encontrada"
        if not new_title:
            return "Error: El título no puede estar vacío"
        self.tasks[task_id]["title"] = new_title
        self.tasks[task_id]["description"] = new_description
        return "Tarea actualizada"

    def delete_task(self, task_id):
        if task_id not in self.tasks:
            return "Error: Tarea no encontrada"
        del self.tasks[task_id]
        return "Tarea eliminada"
