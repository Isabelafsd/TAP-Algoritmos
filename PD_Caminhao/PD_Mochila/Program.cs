using System;
using System.Collections.Generic;

namespace PD_Mochila
{
    class Program
    {
        class Item
        {
            //prop+tab+tab atalho para  public int MyProperty { get; set; }
            public int qtd { get; set; }
            public double beneficio { get; set; }
            public Item(int peso, double valor)
            {
                this.qtd = peso;
                this.beneficio = valor;
            }
        }

        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item(2, 10));
            itens.Add(new Item(3, 13));
            itens.Add(new Item(4, 11.5));
            itens.Add(new Item(8, 10));
            itens.Add(new Item(12, 7));
            itens.Add(new Item(12, 8));
            //itens.Add(new Item(1, 2)); 
            int capacidade = 20;
            Console.WriteLine("Sem repetição: ");
            programacaoDinamicaSemRepeticao(itens, capacidade);
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Com repetição: ");
            programacaoDinamicaComRepeticao(itens, capacidade);
            Console.ReadKey();


        }

        static void programacaoDinamicaSemRepeticao(List<Item> itens, int capacidade) 
        {
            double[,] tabela = new double[itens.Count, capacidade + 1];
            //Preenchimento da primeira linha
            for (int j = 0; j < tabela.GetLength(1); j++) 
            {
                if (j < itens[0].qtd)
                    tabela[0, j] = 0;
                else
                    tabela[0, j] = itens[0].beneficio;
            }

            //Preenchimento das demais linhas
            for (int i = 1; i < tabela.GetLength(0); i++)
            {
                for (int j = 1; j < tabela.GetLength(1); j++)
                {
                    if (j < itens[i].qtd)
                        tabela[i, j] = tabela[i-1, j];
                    else
                        tabela[i, j] = Math.Max(tabela[i - 1, j], tabela[i - 1, j - itens[i].qtd] + itens[i].beneficio);
                }
                
            }

            printTable(tabela);
        }
        static void programacaoDinamicaComRepeticao(List<Item> itens, int capacidade)
        {
            double[,] tabela = new double[itens.Count, capacidade + 1];
            //Preenchimento da primeira linha
            for (int j = 0; j < tabela.GetLength(1); j++)
            {
                if (j < itens[0].qtd)
                    tabela[0, j] = 0;
                else
                    tabela[0, j] = tabela[0, j - itens[0].qtd] + itens[0].beneficio; 
            }

            //Preenchimento das demais linhas
            for (int i = 1; i < tabela.GetLength(0); i++)
            {
                for (int j = 1; j < tabela.GetLength(1); j++)
                {
                    if (j < itens[i].qtd)
                        tabela[i, j] = tabela[i - 1, j];
                    else
                        tabela[i, j] = Math.Max(tabela[i - 1, j], tabela[i, j - itens[i].qtd] + itens[i].beneficio);
                }

            }

            printTable(tabela);
        }

        static void printTable(double [,] tabela)
        {

            for (int i = 0; i < tabela.GetLength(1); i++)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
               
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    Console.Write(tabela[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
