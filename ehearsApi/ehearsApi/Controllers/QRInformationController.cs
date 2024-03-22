using ehearsApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ehearsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRInformationController : ControllerBase
    {
        private readonly dhearsApiContext dbContext;

        public QRInformationController(dhearsApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //[Authorize]
        [HttpGet]
        [Route("{qrCode}")]
        public async Task<IActionResult> GetReasonType([FromRoute] string qrCode)
        {
            var qrinfos = await dbContext.CallSPQRInformation(qrCode);

            if (qrinfos == null || qrinfos.Count == 0)
            {
                return NotFound();
            }

            return Ok(qrinfos);
        }
    }
}
