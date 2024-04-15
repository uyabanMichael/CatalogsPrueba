using Catalogos.Entities.Dto;
using Catalogos.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Business.Interfaces
{
    public interface ICatalogs
    {
        Task<taskOut> GetTaskAsync();
        Task<taskOut> GetIdTaskAsync(task input);
        Task<taskOut> AddTaskAsync(task input);



    }
}
