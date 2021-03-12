using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.Interfaces;
using AbstractDinerBusinessLogic.ViewModels;
using AbstractDinnerListImplement.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace AbstractDinnerListImplement.Implements
{
    public class SnackStorage : ISnackStorage
    {
        private readonly DataListSingleton source;

        public SnackStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<SnackViewModel> GetFullList()
        {
            List<SnackViewModel> result = new List<SnackViewModel>();
            foreach (var component in source.Snacks)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }

        public List<SnackViewModel> GetFilteredList(SnackBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<SnackViewModel> result = new List<SnackViewModel>();
            foreach (var snack in source.Snacks)
            {
                if (snack.SnacksName.Contains(model.SnackName))
                {
                    result.Add(CreateModel(snack));
                }
            }
            return result;
        }

        public SnackViewModel GetElement(SnackBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var snack in source.Snacks)
            {
                if (snack.Id == model.Id || snack.SnacksName ==
                model.SnackName)
                {
                    return CreateModel(snack);
                }
            }
            return null;
        }

        public void Insert(SnackBindingModel model)
        {
            Snack tempSnack = new Snack
            {
                Id = 1,
                SnackComponents = new Dictionary<int, int>()
            };
            foreach (var snack in source.Snacks)
            {
                if (snack.Id >= tempSnack.Id)
                {
                    tempSnack.Id = snack.Id + 1;
                }
            }
            source.Snacks.Add(CreateModel(model, tempSnack));
        }

        public void Update(SnackBindingModel model)
        {
            Snack tempSnack = null;
            foreach (var snack in source.Snacks)
            {
                if (snack.Id == model.Id)
                {
                    tempSnack = snack;
                }
            }
            if (tempSnack == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempSnack);
        }

        public void Delete(SnackBindingModel model)
        {
            for (int i = 0; i < source.Snacks.Count; ++i)
            {
                if (source.Snacks[i].Id == model.Id)
                {
                    source.Snacks.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Snack CreateModel(SnackBindingModel model, Snack snack)
        {
            snack.SnacksName = model.SnackName;
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
                    snack.SnackComponents[component.Key] =
                    model.SnackComponents[component.Key].Item2;
                }
                else
                {
                    snack.SnackComponents.Add(component.Key,
                    model.SnackComponents[component.Key].Item2);
                }
            }
            return snack;
        }
        
        private SnackViewModel CreateModel(Snack snack)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
        Dictionary<int, (string, int)> snackComponents = new
        Dictionary<int, (string, int)>();
            foreach (var pc in snack.SnackComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                snackComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new SnackViewModel
            {
                Id = snack.Id,
                SnackName = snack.SnacksName,
                Price = snack.Price,
                SnackComponents = snackComponents
            };
        }
    }
}
