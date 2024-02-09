namespace Dinero
{
    public class Dinero
    {
        public int value {get; set;}
        public int amount {get; set;}
        public string type {get; set;}

        public Dinero(int value, int amount, string type){
            this.value = value;
            this.amount = amount;
            this.type = type;
        }

    }
}