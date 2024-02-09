namespace Monedero
{
    public class Monedero
    {
        Maquina.Maquina maquina;
        public double change_to_give;
        public double price;
        public double balance;

        List<Dinero.Dinero> Denominaciones = new List<Dinero.Dinero>()
        {
            new Dinero.Dinero(value: 1, amount: 10, type: "Moneda"),
            new Dinero.Dinero(value: 2, amount: 10, type: "Moneda"),
            new Dinero.Dinero(value: 5, amount: 10, type: "Moneda"),
            new Dinero.Dinero(value: 10, amount: 10, type: "Moneda"),
            new Dinero.Dinero(value: 20, amount: 10, type: "Billete"),  
        };

        public Monedero(Maquina.Maquina maquina)
        {
            this.maquina = maquina;
        }

        public void Deliver_Change()
        {
            price = maquina.product_price;
            balance = maquina.balance;
            System.Console.WriteLine(balance + " " + price);
            change_to_give = maquina.balance - maquina.product_price;

            Denominaciones.Sort((x, y) => y.value.CompareTo(x.value));

            foreach (var denominacion in Denominaciones)
            {
                while ( change_to_give >= denominacion.value && denominacion.amount > 0)
                {
                    Console.WriteLine("Entregar " + denominacion.value + " " + denominacion.type);
                    change_to_give-= denominacion.value;
                    denominacion.amount--;
                }
            }
        }
    }
}