using System;
using System.Collections.Generic;
using System.Linq;
using AbstractDinerBusinessLogic.Interfaces;
using AbstractDinerBusinessLogic.ViewModels;
using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinnerFileImplement.Models;

namespace AbstractDinerFileImplement.Implements
{
    public class SnackStorage : ISnackStorage
    {
        private readonly FileDataListSingleton source;

        public SnackStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<SnackViewModel> GetFullList()
        {
            return source.Snacks.Select(CreateModel).ToList();
        }

        public List<SnackViewModel> GetFilteredList(SnackBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Snacks.Where(rec => rec.SnackName.Contains(model.SnackName)).Select(CreateModel).ToList();
        }

        public SnackViewModel GetElement(SnackBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var product = source.Snacks.FirstOrDefault(rec => rec.SnackName == model.SnackName || rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }

        public void Insert(SnackBindingModel model)
        {
        int maxId = source.Snacks.Count > 0 ? source.Snacks.Max(rec => rec.Id) : 0;
            var element = new Snack
            {
                Id = maxId + 1,
                SnackComponents = new Dictionary<int, int>()
            };
            source.Snacks.Add(CreateModel(model, element));
        }

        public void Update(SnackBindingModel model)
        {
            var element = source.Snacks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(SnackBindingModel model)
        {
            Snack element = source.Snacks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Snacks.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Snack CreateModel(SnackBindingModel model, Snack snack)
        {
            snack.SnackName = model.SnackName;
            snack.Price = model.Price;
            // удаляем убранные
            foreach (var key in snack.SnackComponents.Keys.ToList())
            {
                if (!model.SnackComponents.ContainsKey(key))
                {
                    snack.SnackComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.SnackComponents)
            {
                if (snack.SnackComponents.ContainsKey(component.Key))
                {
                    snack.SnackComponents[component.Key] = model.SnackComponents[component.Key].Item2;
                }
                else
                {
                    snack.SnackComponents.Add(component.Key, model.SnackComponents[component.Key].Item2);
                }
            }
            return snack;
        }

        private SnackViewModel CreateModel(Snack product)
        {
            return new SnackViewModel
            {
                Id = product.Id,
                SnackName = product.SnackName,
                Price = product.Price,
                SnackComponents = product.SnackComponents.ToDictionary(recPC => recPC.Key, recPC =>
                    (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
