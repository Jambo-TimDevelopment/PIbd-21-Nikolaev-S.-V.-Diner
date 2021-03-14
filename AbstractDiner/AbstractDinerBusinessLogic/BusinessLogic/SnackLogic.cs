using System;
using System.Collections.Generic;
using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.ViewModels;
using AbstractDinerBusinessLogic.Interfaces;

namespace AbstractDinerBusinessLogic.BusinessLogic
{
    public class SnackLogic 
    {
        private readonly ISnackStorage _snackStorage;

        public SnackLogic(ISnackStorage snackStorage)
        {
            _snackStorage = snackStorage;
        }

        public List<SnackViewModel> Read(SnackBindingModel model)
        {
            if (model == null)
            {
                return _snackStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SnackViewModel> { _snackStorage.GetElement(model) };
            }
            return _snackStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SnackBindingModel model)
        {
            var element = _snackStorage.GetElement(new SnackBindingModel
            {
                SnackName = model.SnackName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _snackStorage.Update(model);
            }
            else
            {
                _snackStorage.Insert(model);
            }
        }

        public void Delete(SnackBindingModel product)
        {
            var element = _snackStorage.GetElement(new SnackBindingModel
            {
                Id = product.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _snackStorage.Delete(product);
        }
    }
}
