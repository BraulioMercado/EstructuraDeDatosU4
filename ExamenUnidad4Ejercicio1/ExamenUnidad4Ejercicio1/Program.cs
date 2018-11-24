using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad4Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dijkstra op = new Dijkstra(); //se llama a la clase donde se hace el proceso
            op.Menu(); //se llama al menu
        }
    }
    class Dijkstra
    {

        private static int DistanciaMinima(int[] distancia, bool[] caminocorto, int vertice) //calculo de la distancia minima de cada ciudad
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < vertice; ++v)
            {
                if (caminocorto[v] == false && distancia[v] <= min)
                {
                    min = distancia[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        private static void Imprimir(int[] distancia, int vertice) //metodo para imprimir
        {
            Console.WriteLine("\nCiudad    Distancia");

            for (int i = 0; i < vertice; ++i)
                Console.WriteLine("{0}\t  {1}", i + 1, distancia[i]); //imprimimos la distancia dependiendo de la ciudad de origen
        }

        public static void DijkstraAlgo(int[,] grafo, int source, int vertice) //procedimiento utilizando el metodo Dijkstra
        {
            int[] distancia = new int[vertice];
            bool[] caminocorto = new bool[vertice];

            for (int i = 0; i < vertice; ++i)
            {
                distancia[i] = int.MaxValue;
                caminocorto[i] = false;
            }

            distancia[source] = 0;

            for (int count = 0; count < vertice - 1; ++count)
            {
                int u = DistanciaMinima(distancia, caminocorto, vertice);
                caminocorto[u] = true;

                for (int v = 0; v < vertice; ++v)
                    if (!caminocorto[v] && Convert.ToBoolean(grafo[u, v]) && distancia[u] != int.MaxValue && distancia[u] + grafo[u, v] < distancia[v])
                        distancia[v] = distancia[u] + grafo[u, v];
            }
            Imprimir(distancia, vertice);

        }
        public void Menu() //menu
        {
            Dijkstra op = new Dijkstra();

            int[,] graph =  {
                {0, 349, 957, 1855, 0, 2534, 0, 0}, //1=San Francisco 
                {349, 0,   834, 0,  0, 2451, 0, 0}, //2=LosAngeles
                {957, 834, 0,  908, 0, 0, 0, 0},  //3=Denver
                {1855, 0,  908, 0, 860, 722,  606, 0}, //4=Chicago //grafo donde esta la distancia de cada ciudad con las demas (matriz de adyacencia)
                {0, 0, 0, 860, 0, 191, 0, 0}, //5=Boston
                {2534, 2451, 0, 722, 191, 0, 760, 1090}, //6=NuevaYork
                {0, 0, 0, 606, 0,  760, 0, 595}, //7=Atlanta
                {0, 0, 0, 0, 0, 1090, 595, 0} //8=Miami
                            };

            bool ban = true;
            do
            {
                try
                {
                    string opc;
                    Console.Clear();
                    Console.Write("1Boston--Los Angeles \n2NuevaYork--San Francisco \n3Atlanta-San Francisco \n4Denver--Nueva York \n\nIngrese distancia que desea ver: "); //menu
                    opc = (Console.ReadLine()); //menu
                    if (opc == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Boston--Los Angeles");
                        Console.WriteLine("Numero 2 es la distancia mas corta entre esas 2 ciudades"); //el numero 2 es donde sale exactamente la distancia entre boston y los angeles
                        Console.WriteLine("\n1=San Francisco \n2=Los Angeles \n3=Denver \n4=Chicago \n5=Boston \n6=Nueva York \n7=Atlanta \n8=Miami");
                        DijkstraAlgo(graph, 4, 8); //mandamos los parametros al metodo, usamos 4 porque es donde esta situado boston en la matriz
                        Console.WriteLine("Toque cualquier tecla: ");
                        Console.ReadKey();
                    }
                    else if (opc == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("NuevaYork--San Francisco");
                        Console.WriteLine("Numero 1 es la distancia mas corta entre esas 2 ciudades"); //el numero 1 es donde sale exactamente la distancia entre nueva york y san francisco
                        Console.WriteLine("\n1=San Francisco \n2=Los Angeles \n3=Denver \n4=Chicago \n5=Boston \n6=Nueva York \n7=Atlanta \n8=Miami");
                        DijkstraAlgo(graph, 5, 8); //mandamos los parametros al metodo, usamos 5 porque es donde esta situado Nueva york en la matriz
                        Console.WriteLine("Toque cualquier tecla: ");
                        Console.ReadKey();
                    }
                    else if (opc == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("Atlanta-San Francisco");
                        Console.WriteLine("Numero 1 es la distancia mas corta entre esas 2 ciudades"); //el numero 1 es donde sale exactamente la distancia entre atlanta y san francisco
                        Console.WriteLine("\n1=San Francisco \n2=Los Angeles \n3=Denver \n4=Chicago \n5=Boston \n6=Nueva York \n7=Atlanta \n8=Miami");
                        DijkstraAlgo(graph, 6, 8); //mandamos los parametros al metodo, usamos 6 porque es donde esta situado Atlanta en la matriz
                        Console.WriteLine("Toque cualquier tecla: ");
                        Console.ReadKey();
                    }
                    else if (opc == "4")
                    {
                        Console.Clear();
                        Console.WriteLine("Denver--Nueva York");
                        Console.WriteLine("Numero 6 es la distancia mas corta entre esas 2 ciudades"); //el numero 6 es donde sale exactamente la distancia entre demver nueva york
                        Console.WriteLine("\n1=San Francisco \n2=Los Angeles \n3=Denver \n4=Chicago \n5=Boston \n6=Nueva York \n7=Atlanta \n8=Miami");
                        DijkstraAlgo(graph, 2, 8); //mandamos los parametros al metodo, usamos 2 porque es donde esta situado denver en la matriz
                        Console.WriteLine("Toque cualquier tecla: ");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!!-" + e.Message);
                    Console.ReadKey(); //error try catch
                }
            }
            while (ban == true);
            Console.ReadKey();
        }
    }
}