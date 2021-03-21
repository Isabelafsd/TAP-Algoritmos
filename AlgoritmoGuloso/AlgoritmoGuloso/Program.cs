using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoGuloso
{
    class Program
    {
        class Item
        {
            //prop+tab+tab atalho para  public int MyProperty { get; set; }

            public int peso { get; set; }
            public int valor { get; set; }

            public Item(int peso, int valor)
            {
                this.peso = peso;
                this.valor = valor;
            }
        }


        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item(12, 4));
            itens.Add(new Item(2, 2));
            itens.Add(new Item(1, 1));
            itens.Add(new Item(4, 10));
            itens.Add(new Item(1, 2));
            int capacidadeMochila = 15;
            AlgoritmoGuloso(itens, capacidadeMochila);
            Console.ReadKey();
        }

        static void AlgoritmoGuloso(List<Item> itens, int capacidadeMochila)
        {
            var itensOrdenados = from i in itens
                                 orderby (i.valor/i.peso) descending
                                 select i;

            int pesoTotal = 0, valorTotal = 0;
            Console.WriteLine("Itens selecionados: ");
            foreach(Item i in itensOrdenados)
            {
                if(i.peso <= capacidadeMochila)
                {
                    pesoTotal += i.peso;
                    valorTotal += i.valor;
                    capacidadeMochila -= i.peso;
                    Console.WriteLine("Peso total: " + i.peso + " - Valor total: " + i.valor);
                }
               
            }
            Console.WriteLine("Mochilha: ");
            Console.WriteLine("Peso total: " + pesoTotal + " - Valor total: " + valorTotal);
        }
    }
}
