using System;
using System.Collections.Generic;


namespace Forca_Bruta
{

    class Item {
        //prop+tab+tab atalho para  public int MyProperty { get; set; }

        public int peso { get; set; }
        public int valor { get; set; }

        public Item(int peso, int valor)
        {
            this.peso = peso;
            this.valor = valor;
        }

      
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item(12, 4));
            itens.Add(new Item(2, 2));
            itens.Add(new Item(1, 1));
            itens.Add(new Item(4, 10));
            itens.Add(new Item(1, 2));

            /* VALORES DE TESTES
            itens.Add(new Item(3, 5));
            itens.Add(new Item(9, 10));
            itens.Add(new Item(7, 4));
            itens.Add(new Item(3, 2));
            itens.Add(new Item(8, 15));
            itens.Add(new Item(4, 5));
            itens.Add(new Item(2, 3));
            itens.Add(new Item(19, 3));
            itens.Add(new Item(1, 20));
            */

            int capacidadeMochila = 15;

            ForcaBruta(itens, capacidadeMochila);

            Console.ReadKey();
        }

        static void ForcaBruta(List<Item> itens, int mochila)
        {
            /*Esta na mochila - 0 
              Não está na mochilha - 1
              Ex: 00001 - item 1 na mochila e itens 2,3,4,5 fora.
            */
            string combinacaoResultado = "";
            int melhorValor = 0;
            int pesoOcupado = 0;

            int totalItens = itens.Count;
            int combinacoes = (int)Math.Pow(2, itens.Count);

            for(int i=0; i<combinacoes; i++)
            {
                string binario = Convert.ToString(i, 2); //Converter numero inteiro pra binário
                binario = binario.PadLeft(totalItens, '0'); //Preenche com 0 os espaços vazios(itens que não estão na mochila)
                int valorTotal = 0;
                int pesoTotal = 0;

                for(int j = 0; j < totalItens; j++)
                {
                    if (binario[j] != '0')
                    {
                        pesoTotal += itens[j].peso;
                        valorTotal += itens[j].valor;

                    } 
                }
                
                Console.WriteLine(binario + " - Peso: " + pesoTotal + " Valor: "  + valorTotal);

                if(pesoTotal <= mochila && valorTotal > melhorValor) //confere se o peso da combinação é menor do que da mochilha e se é o maior valor
                {
                    combinacaoResultado = binario;
                    melhorValor = valorTotal;
                    pesoOcupado = pesoTotal;
                }

          
            }

            Console.WriteLine("\n\nResposta: " + combinacaoResultado + " - Peso: " + pesoOcupado + " Valor: " + melhorValor);

        }
    }
}
