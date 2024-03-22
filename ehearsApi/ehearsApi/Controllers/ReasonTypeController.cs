using ehearsApi.Data;
using ehearsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ehearsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonTypeController : ControllerBase
    {
        private readonly dhearsApiContext dbContext;

        public ReasonTypeController(dhearsApiContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReasonType(Models.ReasonType odjReasonType)
        {
            var reasontype = new ReasonType()
            {
                reasonTypeId = Guid.NewGuid(),
                reasonTypeName = odjReasonType.reasonTypeName
            };

            dbContext.ReasonTypes.Add(reasontype);
            await dbContext.SaveChangesAsync();

            return Ok(reasontype);
        }

        //[Authorize]
        [HttpPut]
        [Route("{reasonTypeId:guid}")]
        public async Task<IActionResult> UpdateReasonType([FromRoute] Guid reasonTypeId, Models.ReasonType odjReasonType)
        {
            var reasontype = await dbContext.ReasonTypes.FindAsync(reasonTypeId);

            if (reasontype != null)
            {
                reasontype.reasonTypeName = odjReasonType.reasonTypeName;

                await dbContext.SaveChangesAsync();
                return Ok(reasontype);
            }

            return NotFound();
        }

        //[Authorize]
        [HttpDelete]
        [Route("{reasonTypeId:guid}")]
        public async Task<IActionResult> DeleteReasonType([FromRoute] Guid reasonTypeId) 
        {
            var reasontype = await dbContext.ReasonTypes.FindAsync(reasonTypeId);

            if (reasontype != null)
            {
                dbContext.Remove(reasontype);
                await dbContext.SaveChangesAsync();
                return Ok(reasontype);
            }

            return NotFound();
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetReasonTypes()
        {
            return Ok(await dbContext.ReasonTypes.OrderBy(rt => rt.reasonTypeName).ToListAsync());
        }

        //[Authorize]
        [HttpGet]
        [Route("{reasonTypeId:guid}")]
        public async Task<IActionResult> GetReasonType([FromRoute] Guid reasonTypeId)
        {
            var reasontype = await dbContext.ReasonTypes.FindAsync(reasonTypeId);

            if (reasontype != null) 
            {
                return Ok(reasontype);
            }

            return NotFound();
        }
    }
}
