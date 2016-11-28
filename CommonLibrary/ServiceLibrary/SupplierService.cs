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
using Vm = ViewModel.PartnerViewModel;
using Rm = RequestModel.PartnerRequsetModel;
using Repo = RepositoryLibrary.SupplierRepository;
using M = Model.Partner;

namespace ServiceLibrary
{
    public class SupplierService : BaseService<M, Rm, Vm>
    {
        private readonly Repo repository;

        public SupplierService(Repo repository) : base(repository)
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
            IQueryable<M> queryable = request.GetOrderedData(Repository.Get());
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

        public async Task<SupplierHistoryViewModel> GetHistoryAsync(string partnerId)
        {
            var purchaseRequest = new PurchaseRequestModel("", "Modified", "True") { ParentId = partnerId, Page = -1 };
            var purchaseService = new PurchaseService(new PurchaseRepository(repository.Db));
            ExpenseRequestModel paymentRequest = new ExpenseRequestModel("", "Modified", "True") { ParentId = partnerId, Page = -1 };
            var paymentService = new PaymentService(new PaymentRepository(repository.Db));
            List<PurchaseViewModel> purchases = await purchaseService.SearchAsync(purchaseRequest);
            List<ExpenseViewModel> payments = await paymentService.SearchAsync(paymentRequest);
            List<SupplierHistoryDetailViewModel> histories = new List<SupplierHistoryDetailViewModel>();
            histories.AddRange(purchases.ConvertAll(x => new SupplierHistoryDetailViewModel(x)));
            histories.AddRange(payments.ConvertAll(x => new SupplierHistoryDetailViewModel(x)));

            SupplierHistoryViewModel history = new SupplierHistoryViewModel
            {
                Payments = payments,
                Purchases = purchases,
                PurchaseTotal = purchases.Sum(x => x.Total),
                PaymentTotal = payments.Sum(x => x.Amount),
                Histories = histories.OrderBy(x => x.Created).ToList()
            };
            return history;
        }



        public bool UpdateDue(string partnerId)
        {
            IQueryable<Purchase> supplierPurchases = repository.Db.Purchases.Where(x => x.PartnerId == partnerId);
            double purchaseTotal = 0;
            if (supplierPurchases.Any())
            {
                purchaseTotal = supplierPurchases
                    .Select(x => x.Total)
                    .Sum(x => x != null ? x : 0);
            }


            IQueryable<Expense> supplierPayments = repository.Db.Expenses.Where(x => x.PartnerId == partnerId);
            double paymentTotal = 0;
            if (supplierPayments.Any())
            {
                paymentTotal = supplierPayments
                    .Select(x => x.Amount)
                    .Sum(x => x != null ? x : 0);
            }

            var entity = repository.Db.Partners.Find(partnerId);
            entity.Due = purchaseTotal - paymentTotal;
            repository.Db.Entry(entity).State = EntityState.Modified;
            repository.Db.SaveChanges();
            return true;
        }
    }
}