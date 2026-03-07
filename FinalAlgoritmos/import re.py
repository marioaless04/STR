import re

def lexer(input_string):
    """
    Análisis léxico
    """
    token_specification = [
        ("BINARIO", r"0b[01]+"),    # Números binarios
        ("OCTAL", r"0o[0-7]+"),      # Números octales
        ("NEWLINE", r"\n"),        # Nueva línea
        ("ESPACIO", r"[ \t]+"),     # Espacios y tabulaciones
        ("ERROR", r"."),            # Cualquier otro carácter no reconocido
    ]
    tok_regex = "|".join(f"(?P<{pair[0]}>{pair[1]})" for pair in token_specification)
    tokens = []
    for match in re.finditer(tok_regex, input_string):
        kind = match.lastgroup
        value = match.group()
        if kind == "ESPACIO" or kind == "NEWLINE":
            continue
        elif kind == "ERROR":
            raise SyntaxError(f"Carácter inválido: {value}")
        tokens.append((kind, value))
    return tokens

def parser(tokens):
    """
    Análisis sintáctico
    """
    parsed_data = []
    for token_type, token_value in tokens:
        if token_type == "BINARIO":
            parsed_data.append(("BINARIO", token_value))
        elif token_type == "OCTAL":
            parsed_data.append(("OCTAL", token_value))
        else:
            raise SyntaxError(f"Token inesperado: {token_value}")
    return parsed_data

def translator(parsed_data):
    """
    Convierte los valores binarios y octales a decimales.
    """
    results = []
    for token_type, token_value in parsed_data:
        if token_type == "BINARIO":
            decimal_value = int(token_value[2:], 2)
            results.append((token_value, decimal_value))
        elif token_type == "OCTAL":
            decimal_value = int(token_value[2:], 8)
            results.append((token_value, decimal_value))
    return results

# Programa principal
if __name__ == "__main__":
    print("Compilador de números binarios y octales a decimales")
    input_string = input("Introduce los números binarios y octales separados por saltos de línea:\n")
    try:
        # Análisis léxico
        tokens = lexer(input_string)
        print("Tokens:", tokens)

        # Análisis sintáctico
        parsed_data = parser(tokens)
        print("Datos parseados:", parsed_data)

        # Traducción
        results = translator(parsed_data)
        print("Resultados:")
        for original, decimal in results:
            print(f"{original} → {decimal}")

    except SyntaxError as e:
        print(f"Error de sintaxis: {e}")
