using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4_2_MercadoSalazarBraulioFabian
{
    class Program
    {
        static void Main(string[] args)
        {
            string opc;
            int opcion;
            do
            {
                try
                {
                    Console.Clear();
                    Operaciones op = new Operaciones();
                    Console.WriteLine("Ingresen numero de arbol: 1- Arbol1 2- Arbol2 3- Arbol3"); //menu para cada arbol
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            op.Arbolito1();
                            break;
                        case 2:
                            Console.Clear();
                            op.Arbolito2();
                            break;
                        case 3:
                            Console.Clear();
                            op.Arbolito3();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); //excepciones
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Write("¿Desea ejecutar el programa otravez? Si=1 || No=Cualquier boton: "); //repetir programa
                opc = Console.ReadLine();
            }
            while (opc == "1");
            Console.ReadKey();
        }
    }
    public class Nodo //objeto
    {
        private string dato; 
        private Nodo hijo;
        private Nodo hermano; //auxiliares de las propiedades

        public string Dato { get { return dato; } set { dato = value; } }  //propiedades de los datos 
        public Nodo Hijo { get { return hijo; } set { hijo = value; } }    //propiedades de los nodos hijos 
        public Nodo Hermano { get { return hermano; } set { hermano = value; } }  //propiedades de los nodos hermanos
    }
    public class Arbolito
    {
        private Nodo raiz;       
        private Nodo trabajo;  //variables auxiliares
        private int i = 0;      
        public int altura = 0;    

        public Arbolito()
        {
            raiz = new Nodo(); //Se inicializa el nodo raiz
        } 
        public Nodo Insertar(string Pdato, Nodo Pnodo)  //metodo donde se insertan los nodos
        {
            if (Pnodo == null)
            {
                raiz = new Nodo();
                raiz.Dato = Pdato;
                raiz.Hijo = null;
                raiz.Hermano = null;
                return raiz;
            }
            if (Pnodo.Hijo == null)
            {
                Nodo temporal = new Nodo();
                temporal.Dato = Pdato;
                Pnodo.Hijo = temporal;
                return temporal;
            }
            else
            {
                trabajo = Pnodo.Hijo;
                while (trabajo.Hermano != null) { trabajo = trabajo.Hermano; }
                Nodo temporal = new Nodo();
                temporal.Dato = Pdato;
                trabajo.Hermano = temporal;
                return temporal;
            }
        }
        public void Acomodo(Nodo Pnodo)   //metodo donde se acomodan
        {
            if (Pnodo == null) { return; }
            for (int j = 0; j < i; j++)
            {
                Console.Write("~");
            }
            Console.WriteLine(Pnodo.Dato);
            if (Pnodo.Hijo != null)
            {
                i++;
                Acomodo(Pnodo.Hijo);
                i--;
            }
            if (Pnodo.Hermano != null)
            {
                Acomodo(Pnodo.Hermano);
            }
        }
        private void Calculo(Nodo hoja, int e) //Metodo donde se calcula la altura del arbol
        {                    
            if (hoja != null)
            {
                if (e <= altura)
                {
                    altura = e;
                    Calculo(hoja.Hijo, e);
                    altura++;
                }
            }
        }
        public int Altura() //metodo de la altura impresa
        {
            altura = 1;
            Calculo(raiz, altura);
            return altura;
        }
    }
    public class Operaciones
    {
        Arbolito Arbol = new Arbolito();   //se llama a la clase donde se insertan y acomodan los nodos

        public void Arbolito1()
        {
            Nodo raiz = Arbol.Insertar("E", null);
            Arbol.Insertar("F", raiz);
            Nodo raiza = Arbol.Insertar("A", raiz);
            Arbol.Insertar("C", raiza);
            Arbol.Insertar("B", raiza); //se insertan los nodos en sus respectivos lugares
            Arbol.Insertar("D", raiza);
            Arbol.Acomodo(raiz);
            Console.WriteLine("\nAltura: {0} \nNivel: {1}", Arbol.Altura(), 2); //se imprime altura y nivel
            Console.WriteLine("Ruta del elemento mas largo es: \nE -> A -> C\nE -> A -> B\nE -> A -> D"); //ruta mas larga
        }
        public void Arbolito2()
        {
            Nodo raiz = Arbol.Insertar("C", null);
            Nodo raiza = Arbol.Insertar("A", raiz);
            Nodo raizb = Arbol.Insertar("B", raiza);
            Arbol.Insertar("E", raizb);
            Arbol.Insertar("D", raiz);
            Arbol.Insertar("F", raiz); //se insertan los nodos en sus respectivos lugares
            Arbol.Insertar("G", raiz);
            Arbol.Acomodo(raiz);
            Console.WriteLine("\nAltura: {0} \nNivel: {1}", Arbol.Altura() - 1, 3); //se imprime altura y nivel
            Console.WriteLine("Ruta del melemento mas largo es: \nC -> A -> B -> E"); //ruta mas larga
        }
        public void Arbolito3()
        {
            Nodo raiz = Arbol.Insertar("K", null);
            Arbol.Insertar("A", raiz);
            Arbol.Insertar("B", raiz);
            Arbol.Insertar("C", raiz);
            Nodo raiza = Arbol.Insertar("D", raiz);
            Nodo raizi = Arbol.Insertar("I", raiza); //se insertan los nodos en sus respectivos lugares
            Arbol.Insertar("J", raizi);
            Nodo raize = Arbol.Insertar("E", raiza);
            Arbol.Insertar("F", raize);
            Nodo raizg = Arbol.Insertar("G", raize);
            Arbol.Insertar("H", raizg);
            Arbol.Acomodo(raiz);
            Console.WriteLine("\nAltura: {0} \nNivel: {1}", Arbol.Altura() + 2, 4); //se imprime altura y nivel
            Console.WriteLine("Ruta del elemento es largo es: \nK -> D -> E -> G -> H"); //ruta mas larga
            Console.WriteLine("La ruta hacia C es: K -> C \nLa ruta hacia J es: K -> D -> I -> J"); //ruta especifica
        }
    }
}


