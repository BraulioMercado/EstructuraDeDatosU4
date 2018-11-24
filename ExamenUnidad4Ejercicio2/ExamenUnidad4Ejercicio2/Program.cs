using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad4Ejercicio2
{
    public class Arbol
    {
        public class Nodo
        {
            public int info; //valor del nodo
            public char letra; //Letra del nodo
            public Nodo izq, der;
        }
        Nodo raiz; //se crea el objeto

        public Arbol()
        {
            raiz = null; //constructor
        }

        public void Insertar(int info, char letra)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = info; //valor del nodo
            nuevo.letra = letra; //letra del nodo
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo; //el primero lo toma como raiz
            else //se acomoda el nodo
            {
                Nodo anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if (info < reco.info)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if (info < anterior.info)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }
        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.letra + " ");
                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);
            Console.WriteLine();
        }

        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izq);
                ImprimirPost(reco.der);
                Console.Write(reco.letra + " ");
            }
        }

        public void ImprimirPost()
        {
            ImprimirPost(raiz);
            Console.WriteLine();
        }

        public void Arbol1()
        {
            Arbol Llamada = new Arbol(); //Se llama a la clase arbol
            Llamada.Insertar(100, 'C');
            Llamada.Insertar(90, 'B');
            Llamada.Insertar(80, 'F');
            Llamada.Insertar(70, 'E');
            Llamada.Insertar(60, 'L');
            Llamada.Insertar(50, 'K');
            Llamada.Insertar(75, 'M'); //insertamos datos
            Llamada.Insertar(91, 'G');
            Llamada.Insertar(93, 'N');
            Llamada.Insertar(92, 'R');
            Llamada.Insertar(94, 'S');
            Llamada.Insertar(110, 'D');
            Llamada.Insertar(105, 'I');
            Llamada.Insertar(104, 'H');
            Llamada.Insertar(103, 'O');
            Llamada.Insertar(120, 'J');
            Llamada.Insertar(115, 'P');
            Llamada.Insertar(130, 'Q');
            Console.Write("\nPostorden: "); //imprimimos postorden
            Llamada.ImprimirPost();
            Console.Write("\nPreorden: ");  //imprimimos preorden
            Llamada.ImprimirPre();
        }

        public void Arbol2()
        {
            Arbol Llamada = new Arbol(); //Se crea un objeto de la clase arbol
            //Se insertan datos en nuestro arbol
            Llamada.Insertar(100, 'A');
            Llamada.Insertar(90, 'B');
            Llamada.Insertar(80, 'C');
            Llamada.Insertar(95, 'D');
            Llamada.Insertar(110, 'E');
            Llamada.Insertar(120, 'F');
            Llamada.Insertar(115, 'G');
            Llamada.Insertar(130, 'H');
            Console.Write("\nPostorden: "); //imprimimos postorden
            Llamada.ImprimirPost();
            Console.Write("\nPreorden: "); //imprimimos preorden
            Llamada.ImprimirPre();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Arbol op = new Arbol(); //se llama a la clase arbol
            Console.WriteLine("~~~Arbol 1~~~");
            op.Arbol1();

            Console.WriteLine("\n~~~Arbol 2~~~");
            op.Arbol2();
            Console.ReadKey();
        }
    }
}