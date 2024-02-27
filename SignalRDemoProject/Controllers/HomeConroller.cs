using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemoProject.Business;
using SignalRDemoProject.Hubs;

namespace SignalRDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeConroller : ControllerBase
    {
       readonly MyBusiness _myBusiness;
        readonly IHubContext<MyHub> _hubContext; //belede ede bilersen my busnesslede ede bilersen

        public HomeConroller(MyBusiness myBusiness, IHubContext<MyHub> hubContext)
        {
            _myBusiness = myBusiness;
            _hubContext = hubContext;
        }


        [HttpGet("{message}")]
        public async Task<OkResult> Index(string message ) {
        
        await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}

