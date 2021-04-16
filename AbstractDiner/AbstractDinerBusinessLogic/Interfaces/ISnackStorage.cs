using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractDinerBusinessLogic.Interfaces
{
    public interface ISnackStorage
    {
        List<SnackViewModel> GetFullList();
        List<SnackViewModel> GetFilteredList(SnackBindingModel model);
        SnackViewModel GetElement(SnackBindingModel model);
        void Insert(SnackBindingModel model);
        void Update(SnackBindingModel model);
        void Delete(SnackBindingModel model);
 }

}
