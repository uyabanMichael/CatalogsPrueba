using Catalogos.Business.Interfaces;
using Catalogos.Data.Interface;
using Catalogos.Entities.Dto;
using Catalogos.Entities.Model;
using System.Xml;

namespace Catalogos.Business
{
    public class CatalogsServices : ICatalogs
    {
        private readonly IRepository<task> _repositoryTask;


        public async Task<taskOut> GetTaskAsync()
        {
            var output = new taskOut();
            return output;


        }

        public async Task<taskOut> GetIdTaskAsync(task input)
        {
            var output = new taskOut();
            var reg = await _repositoryTask.SelectByKey(input.Id);
            return output;
        }

        public async Task<taskOut> AddTaskAsync(task input)
        {
            var output = new taskOut();
            await _repositoryTask.AddItem(input);
            return output;
        }

    }
}
