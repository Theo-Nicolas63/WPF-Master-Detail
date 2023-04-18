using Managements;


namespace Test_DataContract
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new Stub.Stub());
            manager.ChargeDonnées();
            manager.Persistance = new Modeles.Persistance.DataContractPers();
            manager.SauvergardeDonnées();
        }
    }
}
