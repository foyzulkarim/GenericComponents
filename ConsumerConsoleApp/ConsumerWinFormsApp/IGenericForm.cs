using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons.Model;
using Commons.RequestModel;
using Commons.Service;
using Commons.ViewModel;

namespace ConsumerWinFormsApp
{
    public interface IGenericForm<T, TRm, TVm> where TVm : BaseViewModel<T> where TRm : RequestModel<T> where T : Entity
    {
        T CreateModel();
        void ClearForm();   
        Task LoadGridView();
    }
}