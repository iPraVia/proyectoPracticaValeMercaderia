using System;
using System.Collections.Generic;

namespace controlValeMercaderia.Controller
{
    internal class CalcularDigitoVerificador
    {
        private String RUT;
        private String digitoVerificador;
        
        public CalcularDigitoVerificador(string rut)
        {
            RUT = rut;
            calcularDigitoVerificador();
        }

        private void calcularDigitoVerificador()
        {
            invertirRUT();
        }
        private void invertirRUT()
        {
            string rutInvertido = string.Empty;

            for (int i = RUT.Length - 1; i >= 0 ; i--)
            {
                rutInvertido += RUT[i];
            }

            subProceso1(rutInvertido);

        }
        private void subProceso1(string ri)
        {
            int suma = 0;

            int contador = 2;
            for (int i = 0; i <= ri.Length - 1; i++)
            {
                if (contador < 7)
                {
                    suma += int.Parse(ri[i].ToString()) * contador;
                    contador++;
                }
                else if (contador == 7)
                {
                    suma += int.Parse(ri[i].ToString()) * contador;
                    contador = 2;
                }
            }
            subProceso2( suma);    
        }
        private void subProceso2(int valor)
        {
            int resto = valor / 11;

            int producto = resto * 11;

            int dv = 11 -  Math.Abs(valor - producto);

            asignarDV(dv);
        }
        private void asignarDV(int dv)
        {
            switch (dv)
            {
                case 11:
                    digitoVerificador = "0";
                    break;
                case 10:
                    digitoVerificador = "K";
                    break;
                default:
                    digitoVerificador = dv.ToString();
                    break;
            }
        }
        public string getDV() => digitoVerificador;
        public string getRutFormateado()
        {
            List<char> charList = new List<char>();

            int contador = 0;
            for(int i=RUT.Length -1; i >= 0;)
            {
                if(contador == 3)
                {
                    charList.Insert(0,'.');
                    contador = 0;
                }
                else
                {
                    charList.Insert(0, RUT[i]);
                    contador++;
                    i--;
                }
            }
            string texto = $"{new string(charList.ToArray())} - {getDV()}";

            return texto;
        }
    }
}
