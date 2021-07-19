
using System.Linq;
using ContosoPizza.Models;
using ContosoPizza.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditController : ControllerBase
    {
        private IConfiguration _configuration;
        private IRepository<AuditInfo> _auditInfo;

        public AuditController(IConfiguration configuration, IRepository<AuditInfo> auditInfo)
        {
            _configuration = configuration;
            _auditInfo = auditInfo;
        }


        [HttpGet]
        public dynamic GetAudit()
        {
            var info = _auditInfo.Table.ToList();
            var res = new
            {
                Code = 200,
                Data = info,
                Msg = "获取日志列表成功!"
            };
            return res;
        }
    }
}