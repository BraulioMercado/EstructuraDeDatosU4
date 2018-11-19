using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafo op2 = new Grafo();
            Console.WriteLine("A=1; B=2; C=3; D=4; E=5; F=6; G=7");
            Console.WriteLine("\nRecorridos simples: ");
            Console.WriteLine("Codigo:");
            op2.Proceso();
            Console.WriteLine("\nA mano:");
            Console.WriteLine("-->1-->2-->3-->4-->5-->6-->7");
            Console.WriteLine("-->1-->2-->3-->7-->6-->4-->5");
            Console.WriteLine("-->1-->2-->7-->6-->5-->4-->3");
            Console.WriteLine("-->1-->2-->7-->3-->4-->6-->5");
            Console.ReadKey(); //solo con este algoritmo sale un recorrido, que es por dfs, por lo que calcule a mano los demas

                
        }
    }
    class Grafo
    {
        public void Proceso()
        {
            Procedimiento op = new Procedimiento(8);
            op.Añadir(1, 2);
            op.Añadir(2, 3);
            op.Añadir(2, 7);
            op.Añadir(3, 7);
            op.Añadir(3, 4);
            op.Añadir(4, 6);
            op.Añadir(4, 5); //añadimos los nodos y junto al nodo al que esta conectado
            op.Añadir(5, 6);
            op.Añadir(6, 7);
            op.DFS(1);
        }
    }
    class Procedimiento
    {
        private int vertices; //numero de vertices(nodos)
        private List<Int32>[] adj; //lista donde se almacena
        public Procedimiento(int v) //constructor de la clase
        {
            vertices = v;
            adj = new List<Int32>[v];
            for (int i = 0; i < v; i++) //for de los vertices en la lista
            {
                adj[i] = new List<int>();

            }

        }
        public void Añadir(int c, int v) //metodo para añadir los vertices junto con los que estan conectados
        {
            adj[c].Add(v);

        }
        public void DFS(int v) //metodo donde se recorren todos los nodos, indicando el primero
        {
            bool[] visited = new bool[vertices]; //nodos ya recorridos
            Stack<Int32> stack = new Stack<int>(); //se mandan aqui los nodos ya recorridos
            visited[v] = true;
            stack.Push(v);

            while (stack.Count != 0) //si la pila contiene elementos, sigue
            {
                v = stack.Pop();
                Console.Write("-->" + v); //se imrpime el nodo que se saco de la pila(el visitado)
                foreach (var item in adj[v]) //foreach
                {
                    if (!visited[item]) //if para visitar el nodo que no se haya visitado aun
                    {
                        visited[item] = true;
                        stack.Push(item);
                    }
                }
            }
        }
    }
}
