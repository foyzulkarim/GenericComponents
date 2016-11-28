using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vm = ViewModel.ProductDictionaryViewModel;
using Rm = RequestModel.ProductDictionaryRequestModel;
using Repo = RepositoryLibrary.ProductDictionaryRepository;
using M = Model.ProductDictionary;
using Model;
using RepositoryLibrary;
using System.Data.Entity;

namespace ServiceLibrary
{
    public class ProductDictionaryService : BaseService<M, Rm, Vm>
    {
        private readonly Repo repository;
        public ProductDictionaryService(Repo repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<List<Vm>> GetAllAsync()
        {
            return await repository.Get().Select(x => new Vm(x)).ToListAsync();
        }

        public List<Vm> GetAll()
        {
            return repository.Get().ToList().ConvertAll(x => new Vm(x)).ToList();
        }

        public override async Task<List<Vm>> SearchAsync(Rm request)
        {
            var queryable = request.GetOrderedData(Repository.Get());
            queryable = request.SkipAndTake(queryable);
            var list = await queryable.ToListAsync();
            return list.ConvertAll(x => new Vm(x));
        }


        public override Vm GetDetail(string id)
        {
            var model = Repository.GetById(id);
            if (model == null)
            {
                return null;
            }
            return new Vm(model);
        }
    }
}