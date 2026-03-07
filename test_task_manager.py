import pytest
from task_manager import TaskManager

@pytest.fixture
def task_manager():
    return TaskManager()

# --- Pruebas para "Editar una tarea" ---
def test_edit_task_success(task_manager):
    task_manager.create_task(1, "Comprar pan", "Ir a la tienda")
    result = task_manager.edit_task(1, "Comprar pan y leche", "También comprar leche")
    assert result == "Tarea actualizada"
    assert task_manager.tasks[1]["title"] == "Comprar pan y leche"
    assert task_manager.tasks[1]["description"] == "También comprar leche"

def test_edit_task_not_found(task_manager):
    result = task_manager.edit_task(99, "Nueva tarea", "Descripción")
    assert result == "Error: Tarea no encontrada"

def test_edit_task_empty_title(task_manager):
    task_manager.create_task(1, "Estudiar", "Matemáticas")
    result = task_manager.edit_task(1, "", "Historia")
    assert result == "Error: El título no puede estar vacío"

# --- Pruebas para "Eliminar una tarea" ---
def test_delete_task_success(task_manager):
    task_manager.create_task(1, "Dormir temprano", "Ir a la cama a las 10 PM")
    result = task_manager.delete_task(1)
    assert result == "Tarea eliminada"
    assert 1 not in task_manager.tasks

def test_delete_task_not_found(task_manager):
    result = task_manager.delete_task(99)
    assert result == "Error: Tarea no encontrada"
