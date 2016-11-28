using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Vm = ViewModel.Customers.CustomerViewModel;
using Rm = RequestModel.Customers.CustomerRequestModel;
using Repo = RepositoryLibrary.Customer.CustomerRepository;
using M = Model.Customers.Customer;

namespace ServiceLibrary.Customers
{
    public class CustomerService : BaseService<M, Rm, Vm>
    {
        public CustomerService(Repo repository) : base(repository)
        {
            
        }             
    }
}
