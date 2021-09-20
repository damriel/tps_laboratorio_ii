namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Asigna un valor al atributo numero, previa validacion
        /// </summary>
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Convierte el número recibido de binario a decimal
        /// </summary>
        /// <param name="binario">String que contiene un valor numerico en binario</param>
        /// <returns>string</returns>
        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int resultado = 0;
                int multiplo = 1;
                char caracter;
                for (int i = binario.Length-1; i >= 0; i--)
                {
                    if(binario[i]=='1')
                    {
                        resultado += multiplo; 
                    }
                    multiplo *= 2;
                }
                return resultado.ToString();
            }
            return "Valor inválido";
        }

        /// <summary>
        /// Convierte el numero recibido de decimal a binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>string</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";
            int numeroEntero = (int)numero;
            while(numeroEntero >= 2)
            {
                binario = (numeroEntero % 2).ToString() + binario;
                numeroEntero = numeroEntero / 2;
            }
            if (numeroEntero == 1)
                binario = "1" + binario;

            return binario;
        }

        /// <summary>
        /// Convierte el numero decimal recibido a binario (sobrecarga)
        /// </summary>
        /// <param name="numero">String que contiene el valor numerico decimal a convertir</param>
        /// <returns>string</returns>
        public static string DecimalBinario(string numero)
        {
            double numeroDouble;
            if (double.TryParse(numero, out numeroDouble))
                return DecimalBinario(numeroDouble);

            return "Valor inválido";
        }

        /// <summary>
        /// Determina si el contenido en el string recibido es un numero binario valido
        /// </summary>
        /// <param name="binario">String que contiene el numero a revisar</param>
        /// <returns>bool</returns>
        private static bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Constructor por defecto, inicializa el atributo numero en cero
        /// </summary>
        public Operando()
        {
            Numero = "0";
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="numero">Valor numerico a asignar al atributo numero</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor parametrizado (sobrecarga)
        /// </summary>
        /// <param name="strNumero">String que contiene el valor numerico para asignar al atributo numero</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Devuelve la resta de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Devuelve elproducto de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Devuelve el cociente de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
                return double.MinValue;

            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Devuelve la suma de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Comprueba que el valor recibido sea numerico y lo retorna en formato double
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>double numero | 0</returns>
        private static double ValidarOperando(string strNumero)
        {
            double numero = 0;

            double.TryParse(strNumero, out numero);

            return numero;
        }

    }
}
