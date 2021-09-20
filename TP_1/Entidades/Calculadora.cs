namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operacion pedida entre ambos operandos
        /// </summary>
        /// <param name="num1">Objeto tipo Operando</param>
        /// <param name="num2">Objeto tipo Operando</param>
        /// <param name="operador">Char que indica la operacion a realizar</param>
        /// <returns>double</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el operador recibido sea +, -, / o *. Caso contrario retornara +
        /// </summary>
        /// <param name="operador">Char a validar que debe indicar la operacion a realizar</param>
        /// <returns>char</returns>
        private static char ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '+':
                    return '+';
                case '-':
                    return '-';
                case '*':
                    return '*';
                case '/':
                    return '/';
                default:
                    return '+';
            }
        }

    }
}
