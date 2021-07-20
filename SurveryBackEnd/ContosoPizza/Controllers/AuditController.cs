
using System.Linq;
using ContosoPizza.Models;
using ContosoPizza.Parmas;
using ContosoPizza.Repository;
using ContosoPizza.Utils;
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
        public string GetAudit([FromQuery] Pager pager)
        {
            var pageIndex = pager.PageIndex;
            var pageSize = pager.PageSize;
            var info = _auditInfo.Table;
            var pagingInfo = info.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var res = new
            {
                Code = 200,
                Data = new { Data = pagingInfo, Pager = new { pageIndex, pageSize, rowsTotal = info.Count() } },
                Msg = "获取日志列表成功!"
            };
            return JsonHelper.Serialize(res);
        }
    }
}