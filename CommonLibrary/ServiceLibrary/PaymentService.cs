using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using RepositoryLibrary;
using RequestModel;
using ViewModel;
using Vm = ViewModel.ExpenseViewModel;
using Rm = RequestModel.ExpenseRequestModel;
using Repo = RepositoryLibrary.PaymentRepository;
using M = Model.Expense;

namespace ServiceLibrary
{
    public class PaymentService : BaseService<M, Rm, Vm>
    {
        private readonly Repo repository;

        public PaymentService(Repo repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<List<Vm>> GetAllAsync()
        {
            return await repository.Get().Select(x => new Vm(x)).ToListAsync();
        }

        public List<Vm> GetAll()
        {
            return repository.Get().Include(y => y.Partner).ToList().ConvertAll(x => new Vm(x)).ToList();
        }
        public override async Task<List<Vm>> SearchAsync(Rm request)
        {
            IQueryable<Expense> queryable = request.GetOrderedData(Repository.Get()).Include(y => y.Partner);
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

        public override bool Add(M m)
        {
            bool add = base.Add(m);
            var supplierRepository = new SupplierRepository(Repository.Db);
            SupplierService supplierService = new SupplierService(supplierRepository);
            supplierService.UpdateDue(m.PartnerId);
            return true;
        }
    }
}