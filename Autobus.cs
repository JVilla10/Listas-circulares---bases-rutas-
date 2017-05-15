using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioConListasCirculares
{
    class Autobus
    {
        public Autobus siguiente;
        private string _nombre;
        private double _tiempo;

        public Autobus(string nombre, double tiempo)
        {
            this.nombre = nombre;
            this.tiempo = tiempo;
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public double tiempo
        {
            get { return _tiempo; }
            set { _tiempo = value; }
        }

        public override string ToString()
        {
            string mostrar = "";

            mostrar = "Nombre de la base: " + _nombre + "\r\n"
                + "Tiempo para llegar a la siguiente base: " + _tiempo + "\r\n" + "\r\n";
            return mostrar;
        }
    }
}
