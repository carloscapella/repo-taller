using System;
using System.Collections.Generic;
using System.Linq;

namespace Taller_1
{

    public class Poliza
    {
        #region Atributos

        private readonly decimal factor;
        public int IdPol { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoAsegurado { get; set; }

        #endregion

        #region Constructores

        public Poliza()
        {
            factor = (decimal)0.75;
            Console.WriteLine("Creando poliza desde el padre...");
        }

        public Poliza(decimal paramFactor, int idPol, decimal montoAsegurado)
        {
            factor = paramFactor;
            IdPol = idPol;
            MontoAsegurado = montoAsegurado;
            Console.WriteLine("Creando poliza desde el padre tercer constructor...");
        }

        public Poliza(int idPol, decimal descuento, decimal montoAsegurado)
        {
            IdPol = idPol;
            Descuento = descuento;
            MontoAsegurado = montoAsegurado;
        }

        public Poliza(decimal paramFactor)
        {
            factor = paramFactor;
            Console.WriteLine("Creando poliza desde el padre segundo constructor...");
        }

        #endregion

        #region Metodos publicos
        public decimal CalcularTotalAPagar()
        {
            return MontoAsegurado * factor;
        }

        #endregion
    }

    public class PolizaVida : Poliza
    {
        #region Constructores de PolizaVida
        public PolizaVida()
        {
            Console.WriteLine("\nCreando poliza desde la poliza de vida (hijo)");
        }

        public PolizaVida(decimal paramFactor) : base(paramFactor)
        {
            Console.WriteLine("\nCreando poliza desde la poliza de vida (hijo) segundo constructor");
        }
        #endregion
    }

    class Program
    {

        private static void Herencia()
        {
            Poliza polizaUno = new Poliza();
            polizaUno.MontoAsegurado = 5000;
            polizaUno.IdPol = 1234;
            Console.WriteLine($"el total a pagar es: {polizaUno.CalcularTotalAPagar()}");


            Poliza polizaDos = new Poliza((decimal)0.3);
            polizaDos.MontoAsegurado = 10000;
            Console.WriteLine($"el total a pagar es: {polizaDos.CalcularTotalAPagar()}");


            PolizaVida polizaVida = new PolizaVida();
            polizaVida.MontoAsegurado = 15000;
            Console.WriteLine($"el total a pagar es: {polizaVida.CalcularTotalAPagar()}");


            PolizaVida polizaVidaDos = new PolizaVida((decimal)0.45);
            polizaVidaDos.MontoAsegurado = 8000;
            Console.WriteLine($"el total a pagar es: {polizaVidaDos.CalcularTotalAPagar()}");


            Poliza polizaTres = new Poliza((decimal)0.3, 12345, (decimal)6800);
            Console.WriteLine($"el total a pagar es: {polizaTres.CalcularTotalAPagar()} y la ");


            // forma 1 de inicializar una lista de objetos 
            List<Poliza> listaPolizas = new List<Poliza>
            {
                new Poliza((decimal)0.3, 1, (decimal)6800),
                new Poliza((decimal)0.45, 22, (decimal)15700)
            };


            string[] intermediaryCodes = new string[] { "01", "02", "03" };

            List<string> lista = new List<string> { "01" };

            List<string> ThirdList = intermediaryCodes.ToList().Except(lista).ToList();
            Console.WriteLine("\n\ndiff");
            Console.WriteLine(string.Join(",", ThirdList));
            Console.ReadKey();

            // forma 2 de inicializar una lista de objetos 

            // List<Poliza> listaPolizas = new List<Poliza>();
            //Poliza polizaGeneral = new Poliza((decimal)0.3, 1, (decimal)6800);
            //listaPolizas.Add(polizaGeneral);
            //polizaGeneral = new Poliza((decimal)0.45, 22, (decimal)15700);
            //listaPolizas.Add(polizaGeneral);
        }



        public class Empleado
        {
            // los readonly solo se setean en su definicion o en el constructor de la clase
            protected decimal _totalVendido = 0;

            public Empleado()
            {
            }

            public bool EsCorredor { get; set; }

            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public decimal GetTotalVendido()
            {
                return _totalVendido;
            }
        }

        public class Corredor : Empleado
        {
            private readonly float comision = (float)0.035;

            public Corredor()
            {

            }

            public bool EnviarEmail()
            {
                return false;
                //throw NotImplementedException();
            }

            // Retorna el Monto Total vendido
            public decimal VenderPoliza(float valorPoliza)
            {   // 100 + 3.5 $
                _totalVendido += (decimal)(valorPoliza + (valorPoliza * comision));
                return _totalVendido;
            }
        }

        public class Telemercadeo : Empleado
        {
            private readonly float comision = (float)0.025;
            public Telemercadeo()
            {

            }

            // Retorna el Monto Total vendido
            public decimal VenderPoliza(float valorPoliza)
            {   // 100 + 3.5 $
                _totalVendido += (decimal)(valorPoliza + (valorPoliza * comision));
                return _totalVendido;
            }
        }

        public class Aseguradora
        {
            public List<Empleado> listaEmpleados;
            public string Name { get; set; }

            public Aseguradora()
            {
                listaEmpleados = new List<Empleado>();
            }

            // Retorna el Monto Total vendido
            public decimal ObtenerTotalVendidoEnLaEmpresa()
            {
                return listaEmpleados.Sum(x => x.GetTotalVendido());
            }
        }


        static void Main(string[] args)
        {



            var car = new List<string> { "1", "2" };
            var los = new List<string> { "3", "4", "1", "2" };

            var todo = car.Union(los).ToList();

            int respuesta = 0;

            Aseguradora aseguradora = new Aseguradora();

            while (respuesta != 9)
            {
                Console.Clear();

                Console.WriteLine("**********************************");
                Console.WriteLine("********* Menu de usuario ********");
                if (!string.IsNullOrEmpty(aseguradora.Name))
                {
                    Console.WriteLine($"******* Aseguradora: {aseguradora.Name} ********");
                    Console.WriteLine($"******* Cant Empleados: {aseguradora.listaEmpleados.Count()} ********");
                }
                Console.WriteLine("**********************************\n\n");

                Console.WriteLine("Seleccione una accion:");
                Console.WriteLine("1. Setear el nombre de la Aseguradora");
                Console.WriteLine("2. Registrar un empleado:");
                Console.WriteLine("3. Registrar una venta:");
                Console.WriteLine("4. Reporte:");
                Console.WriteLine("9. Salir:\n");

                string opcionSeleccionada = Console.ReadLine();

                try
                {
                    respuesta = int.Parse(opcionSeleccionada);

                    switch (respuesta)
                    {
                        case 1:
                            ConigurarAsegurador(aseguradora);
                            break;
                        case 2:
                            RegistrarEmpleado(aseguradora);
                            break;
                        case 3:
                            RegistrarVenta(aseguradora);
                            break;
                        default:
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Error: opcion incorrecta");
                }

            }
        }

        private static void RegistrarVenta(Aseguradora aseguradora)
        {
            Console.Clear();

            Console.Write("Indique la cedula del empleado:");

            string dato = Console.ReadLine();

            var vendedor = aseguradora.listaEmpleados.FirstOrDefault(x => x.Cedula.Equals(dato));

            if (vendedor == null)
            {
                Console.WriteLine("Error cedula de empleado no registrada, intente de nuevo:");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Empleado seleccionado: {vendedor.Nombre}");
                Console.Write("Indique el monto de la poliza: ");

                var montoString = Console.ReadLine();

                if (vendedor.EsCorredor)
                {
                    Corredor tempCorredor = (Corredor) vendedor;
                    float monto = float.Parse(montoString);
                    Console.WriteLine($"EL monto total a pagar es {tempCorredor.VenderPoliza(monto)}");
                }
                else
                {
                    if (vendedor.EsCorredor)
                    {
                        Telemercadeo tempCorredor = (Telemercadeo)vendedor;
                        float monto = float.Parse(montoString);
                        Console.WriteLine($"EL monto total a pagar es {tempCorredor.VenderPoliza(monto)}");
                    }
                }
                Console.ReadLine();
            }
        }

        private static void RegistrarEmpleado(Aseguradora aseguradora)
        {
            Console.Clear();

            Console.Write("Indique el tipo de empleado: (1-Corredor, 2-Telemercadeo");

            string dato = Console.ReadLine();

            Empleado empleado = null;

            if (dato.Equals("1"))
            {
                empleado = new Corredor();
                empleado.EsCorredor = true;
            }

            else
            {
                empleado = new Telemercadeo();
            }

            Console.Write("Indique la cedula del empleado:");
            dato = Console.ReadLine();
            empleado.Cedula = dato;

            Console.Write("Indique el nombre del empleado:");
            dato = Console.ReadLine();
            empleado.Nombre = dato;

            Console.Write("Indique el apellido del empleado:");
            dato = Console.ReadLine();
            empleado.Apellido = dato;

            aseguradora.listaEmpleados.Add(empleado);

            Console.Write("Empleado registrado");
            Console.ReadLine();

        }

        private static void ConigurarAsegurador(Aseguradora aseguradora)
        {
            Console.Clear();

            Console.Write("Indique el nombre de la aseguradora:");

            string nombre = Console.ReadLine();

            aseguradora.Name = nombre;
        }
    }
}
