using System;
using System.Security.Authentication.ExtendedProtection;
using Producto;

namespace Maquina
{
    public class Maquina
    {
        
        public string selected_product;
        public double balance;
        public double product_price;
        
        List<Producto.Producto> Productos = new List<Producto.Producto>()
        {
            new Producto.Producto(name: "Sabritas", price: 18, code: "A1", stock: 5),
            new Producto.Producto(name: "Galletas", price: 20, code: "B1", stock: 5),
            new Producto.Producto(name: "Pan", price: 15, code: "C1", stock: 5),
        };

        public void MachineLoop(){
            while(true){
                Show_Message();
                Select_Product();
                Check_Selection();
                Recive_Balance();
                Compare_Balance();
                break;
            }
        }
        public void Show_Message()
        {
             Console.WriteLine("Poseo en existencia: \n");

            foreach(var Producto in Productos)
            {
                Console.WriteLine("Codigo: " + Producto.code + "   " + Producto.name + "  $ " + Producto.price);
            }
        }

        public void Select_Product()
        {
            Console.WriteLine("Por favor inserte el codigo de su producto");
            selected_product = Console.ReadLine();
        }

        public void Check_Selection()
        {
            bool selectedcode = false;
            foreach (var Producto in Productos )
            {
                if (Producto.code == selected_product)
                {
                    selectedcode = true;
                    Console.WriteLine($"Tu seleccion fue " + Producto.name + " su costo es = " + Producto.price);
                    product_price = Producto.price;
                    break;
                }
            }
        }
        
        public void Recive_Balance()
        {
            Console.WriteLine("Inserte su saldo");
            balance = int.Parse(Console.ReadLine());
        }

        public void Compare_Balance()
        {
            if (balance > product_price)
            {
                Monedero.Monedero monedero = new Monedero.Monedero(this);
                monedero.Deliver_Change();
                Drop_Product();
            }
            if (balance == product_price)
            {
                Drop_Product();
            }
            if (balance < product_price)
            {
                Console.WriteLine("Tu saldo es insuficiente, por favor de insertar");
                string add_balance = Console.ReadLine();

                int.TryParse(add_balance, out int add_value);

                balance += add_value;
                Compare_Balance();
            }
        }

        public void Drop_Product()
        {
            bool selectedcode = false;
            foreach (var Producto in Productos )
            {
                if (Producto.code == selected_product)
                {
                    selectedcode = true;
                    Console.WriteLine($"Que disfrute su " + Producto.name );
                    break;
                }
            }
        }
    }

    
}