import tkinter as tk
from tkinter import ttk

def process_investments(investments):
    exp_count = 0
    non_exp_count = 0
    equations = []

    for i in range(0, len(investments), 6):
        group = investments[i:i+6]
        if len(group) != 6:
            non_exp_count += 1
            continue

        first_sum = sum(group[0:2])
        second_sum = sum(group[2:4])
        third_sum = sum(group[4:6])
        
        if first_sum == 2 * second_sum - third_sum:
            exp_count += 1
            base = group[0]
            exponent = "x"
            second_term = group[1]
            equation = f"{base}^{exponent} = {second_term}"
            equations.append(equation)

    return exp_count, non_exp_count, equations

def sort_investments(investments):
    sorted_investments = sorted(investments, reverse=True)
    return sorted_investments

def search_investment(investments, month, position):
    index = (month - 1) * 6 + (position - 1)
    if index < len(investments):
        return investments[index]
    else:
        return None

def submit_callback():
    investments = [int(entry.get()) for entry in entry_fields]
    exp_count, non_exp_count, equations = process_investments(investments)
    sorted_investments = sort_investments(investments)
    exp_count_label.config(text=f"Veces de ecuaciones exponenciales: {exp_count}")
    non_exp_count_label.config(text=f"Veces de no ecuaciones exponenciales: {non_exp_count}")
    equations_list.delete(0, tk.END)
    for equation in equations:
        equations_list.insert(tk.END, equation)
    sorted_investments_label.config(text=f"Inversiones ordenadas: {sorted_investments}")

def search_callback():
    month = int(month_combobox.get())
    position = int(position_entry.get())
    result = search_investment(sorted_investments, month, position)
    search_result_label.config(text=f"Resultado de la búsqueda: {result}")

root = tk.Tk()
root.title("Aplicación de Escritorio")

# Creación de widgets
label1 = tk.Label(root, text="Ingrese las inversiones mensuales (en millones de dólares)")
label1.grid(row=0, column=0, columnspan=2, pady=10)

entry_fields = []
for i, month_name in enumerate(['Enero', 'Febrero', 'Marzo']):
    month_label = tk.Label(root, text=month_name)
    month_label.grid(row=i+1, column=0, padx=10)
    for j in range(1, 7):
        entry_field = tk.Entry(root)
        entry_field.grid(row=i+1, column=j, padx=5)
        entry_fields.append(entry_field)

submit_button = tk.Button(root, text="Enviar", command=submit_callback)
submit_button.grid(row=4, column=0, columnspan=2, pady=10)

exp_count_label = tk.Label(root, text="")
exp_count_label.grid(row=5, column=0, columnspan=2)

non_exp_count_label = tk.Label(root, text="")
non_exp_count_label.grid(row=6, column=0, columnspan=2)

equations_list = tk.Listbox(root, height=5, width=50)
equations_list.grid(row=7, column=0, columnspan=2, pady=5)

sorted_investments_label = tk.Label(root, text="")
sorted_investments_label.grid(row=8, column=0, columnspan=2)

# Búsqueda de inversión
label2 = tk.Label(root, text="Búsqueda de Inversión")
label2.grid(row=9, column=0, columnspan=2, pady=10)

month_combobox = ttk.Combobox(root, values=['Enero', 'Febrero', 'Marzo'])
month_combobox.grid(row=10, column=0, padx=5)

position_label = tk.Label(root, text="Posición:")
position_label.grid(row=10, column=1, padx=5)

position_entry = tk.Entry(root)
position_entry.grid(row=10, column=2, padx=5)

search_button = tk.Button(root, text="Buscar", command=search_callback)
search_button.grid(row=11, column=0, columnspan=2, pady=10)

search_result_label = tk.Label(root, text="")
search_result_label.grid(row=12, column=0, columnspan=2)

root.mainloop()
