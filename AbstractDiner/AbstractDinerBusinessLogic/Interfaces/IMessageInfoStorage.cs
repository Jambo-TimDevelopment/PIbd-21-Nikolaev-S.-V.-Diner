using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.ViewModels;
using System.Collections.Generic;


namespace AbstractDinerBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        
        void Insert(MessageInfoBindingModel model);
    }
}
