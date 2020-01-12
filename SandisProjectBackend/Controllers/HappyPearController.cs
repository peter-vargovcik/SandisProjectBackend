using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SandisProjectBackend.repo;

namespace SandisProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HappyPearController : ControllerBase
    {
        private AppDb _db;

        public HappyPearController(AppDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await _db.Connection.OpenAsync();
            var query = new HappyPearQuery(_db);
            var result = await query.WeeksListAsync();
            return new OkObjectResult(result);
        }
    }
}