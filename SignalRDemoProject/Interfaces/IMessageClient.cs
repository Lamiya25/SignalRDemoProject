namespace SignalRDemoProject.Interfaces
{
    //strongly typed hubs ozelliyi ile type i deqiq hublar tanimlamaq, metnsel yapilanmanin yaratdigi handikapolardan birazda olsun qurtula bilmeyi ve cllientta triggerlanacaq olan metod alertinin serverde debug zamanindaki denetimin etkinlesdirmeyi saglayabiliriz
    public interface IMessageClient
    {
        Task Clients(List<string> clients);

        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);
    }
}
