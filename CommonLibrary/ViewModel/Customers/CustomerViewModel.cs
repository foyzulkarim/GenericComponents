using Model.Customers;

namespace ViewModel.Customers
{
    public class CustomerViewModel : BaseViewModel<Customer>
    {
        public CustomerViewModel(Customer x) : base(x)
        {
            this.Name = x.Name;
            this.HouseNo = x.HouseNo;
            this.RoadNo = x.RoadNo;
            this.Area = x.Area;
            this.Thana = x.Thana;
            this.District = x.District;
            this.Phone = x.Phone;
            this.Email = x.Email;
            this.Remarks = x.Remarks;
            this.Point = x.Point;
            this.MembershipCardNo = x.MembershipCardNo;
            this.Country = x.Country;
        }

        public string MembershipCardNo { get; set; }

        public string Name { get; set; }

        public string HouseNo { get; set; }
        public string RoadNo { get; set; }
        public string Area { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public int Point { get; set; }

    }
}