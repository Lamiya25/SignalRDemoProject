using Microsoft.AspNetCore.SignalR;

namespace SignalRDemoProject.Hubs
{
    public class MessageHub:Hub
    {
        public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        {
            #region Caller 
            //Tekce servere alert gonderen clientla elaqe qurar. 
            //     await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All 
            //Servere bagli olan butun clientlarla elaqe qurur. 
            //     await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Other 
            //Sadece servere bildirim gonderen client xaricinde Servere bagli olan butun clientlara mesaj gonderir.
            //  await Clients.Others.SendAsync("receiveMessage", message);
            #endregion


            #region Hub Clients Metods


            #region AllExcept 
            //belirtilen clientlar xaricinde servere bagli olan butun clientlara bildiride bulunur.
            // await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client 

            //Servere bagli olan clientlar arasindan sadece belirli bir clienta bildiride bulunur.
            // await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);


            #endregion

            #region Clients 
            //Servere bagli olan clientlar arasindan sadece bildirilenlere mesaj gonderir

            // await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Group 

            //Belirtilen grupdaki butun clientlara bildiridi bulunur.
            //evvelce gruplar yaradilsin ve sonra clientlar gruplara subscribe olunsun.
            // await Clients.Groups(groupName).SendAsync("receiveMessage", message);
            #endregion


            #region Groups 



            #endregion

            #region GroupExcept

            //Belirtilen grupdaki belirtilen clientlar disindaki tum clientlara mesaj iletmemizi saglayir

            await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);

            #endregion

            #region OthersInGroup 

            #endregion

            #region User 

            #endregion

            #region Users 

            #endregion

            #endregion


        }


        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }


        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }

    }
}
