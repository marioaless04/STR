from flask import Flask, render_template, request

app = Flask(__name__)

def process_investments(investments):
    exp_count = 0
    non_exp_count = 0
    equations = []

    for i in range(0, len(investments), 6):
        group = investments[i:i+6]
        if len(group) != 6:
            non_exp_count += 1
            continue

        # Sumas de acuerdo a la estructura especificada
        first_sum = sum(group[0:2])
        second_sum = sum(group[2:4])
        third_sum = sum(group[4:6])
        
        # Verificación de la condición inicial para la ecuación exponencial
        if first_sum == 2 * second_sum - third_sum:
            exp_count += 1
            # Construir la ecuación exponencial
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

@app.route('/')
def index():
    # Establecer el valor inicial de los campos de entrada a 0 y agregar min="0"
    return render_template('index.html', initial_value=0)

@app.route('/result', methods=['POST'])
@app.route('/result', methods=['POST'])
def result():
    investments = [int(x) for x in request.form.getlist('investment') if int(x) >= 0]  # Filtrar números negativos
    exp_count, non_exp_count, equations = process_investments(investments)
    
    # Ordenar las inversiones de mayor a menor
    sorted_investments = sort_investments(investments)

    return render_template('result.html', exp_count=exp_count, non_exp_count=non_exp_count, equations=equations, sorted_investments=sorted_investments)

    return render_template('result.html', exp_count=exp_count, non_exp_count=non_exp_count, equations=equations, sorted_investments_str=sorted_investments_str)

@app.route('/search', methods=['POST'])
def search():
    month = int(request.form['month'])
    position = int(request.form['position'])
    # Obtener la lista de inversiones ordenadas directamente
    sorted_investments = [int(x) for x in request.form.getlist('sorted_investment')]
    
    # Buscar la inversión por posición
    result = search_investment(sorted_investments, month, position)
    
    return render_template('search.html', month=month, position=position, result=result)


if __name__ == '__main__':
    app.run(debug=True)
