using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioConListasCirculares
{
    class CentralDeAutobuses
    {
        private Autobus primero;
        private Autobus ultimo;
        private string mostrarRecorrido;

        public object dato { get; private set; }

        public CentralDeAutobuses()
        {
            primero = null;
            ultimo = null;
        }

        public void agregar(Autobus nuevoAutobus)
        {
            //Autobus tmp = primero;
            //tmp = nuevoAutobus;   

            if (primero == null)
            {
                primero = nuevoAutobus;
                ultimo = primero;
                primero.siguiente = primero;
            }
            else
            {
                ultimo.siguiente = nuevoAutobus;
                nuevoAutobus.siguiente = primero;
                ultimo = nuevoAutobus;
            }
        }

        public Autobus buscarPorNombre(string nombre)
        {
            Autobus tmp = primero;

            while (tmp.siguiente != primero && tmp.nombre != nombre)
            {
                tmp = tmp.siguiente;
            }

            return tmp;
        }

        public void eliminar(string nombre)
        {
            Autobus tmp = primero;
            Autobus anterior = ultimo;

            do
            {
                if (tmp.nombre == nombre)
                {
                    if (tmp.nombre == primero.nombre)
                    {
                        primero = primero.siguiente;
                        ultimo.siguiente = primero;
                    }
                    else if (tmp.nombre == ultimo.nombre)
                    {
                        anterior.siguiente = ultimo.siguiente;
                        ultimo = anterior;
                    }
                    //Se encarga de eliminar cuando solo existe un solo nodo (No sirve)
                    else if (tmp.nombre == tmp.siguiente.nombre)
                    {
                        tmp = null;
                        primero = tmp;
                    }
                    else
                    {
                        anterior.siguiente = tmp.siguiente;
                    }

                }
                //Se encarga de ir recorriendo la lista circular simple
                anterior = tmp;
                tmp = tmp.siguiente;
            } while (tmp != primero);

        }

        public void agregarInicio(Autobus nuevoAutobus)
        {
            Autobus tmp = nuevoAutobus;

            tmp.siguiente = primero;
            primero = tmp;
            ultimo.siguiente = tmp;
        }

        public string recorrido(string nombre, int horaInicio, int horaFinal)
        {
            double tiempoTotal = 0;
            DateTime info = DateTime.Now;
            Autobus miAutobus = buscarPorNombre(nombre);
            DateTime HoraInicio = new DateTime(info.Year, info.Month, info.Day, horaInicio, info.Minute, info.Second);
            DateTime HoraFinal = new DateTime(info.Year, info.Month, info.Day, horaFinal, info.Minute, info.Second);

            HoraInicio = HoraInicio.AddMinutes(1000);
            //tiempoTotal += miAutobus.tiempo;
            mostrarRecorrido = " " + miAutobus.nombre + ":" + HoraInicio.ToString() + "\r\n";

            //miAutobus = miAutobus.siguiente;


            return mostrarRecorrido;
        }

        public void agregarDesde(string nombre, Autobus nuevoAutobus)
        {
            Autobus tmp = buscarPorNombre(nombre);
            tmp.siguiente = nuevoAutobus;
            nuevoAutobus.siguiente = tmp.siguiente;
        }

        public override string ToString()
        {
            Autobus tmp = primero;
            string mostrar = "";

            if (tmp != null)
            {
                while (tmp.siguiente != primero)
                {
                    mostrar += tmp.ToString();
                    tmp = tmp.siguiente;
                }
                mostrar += tmp.ToString();
            }
            return mostrar;
        }
    }
}
