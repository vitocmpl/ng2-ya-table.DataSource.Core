using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ng2YaTable.DataSource.Core;
using Ng2YaTable.DataSource.Demo.Models;
using Ng2YaTable.DataSource.Demo.Repos;

namespace Ng2YaTable.DataSource.Demo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private UsersRepository usersRepo = null;
        public ValuesController(UsersRepository usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DataSourceResult<User>), 200)]
        public async Task<DataSourceResult<User>> Get([FromBody]DataSourceRequest parameters)
        {
            var query = from u in await usersRepo.GetUsers()
                        select u;

            return await query.ToDataSourceResult(parameters);
        }
    }
}
