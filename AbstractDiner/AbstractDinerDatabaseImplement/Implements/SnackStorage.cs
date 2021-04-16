using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.Interfaces;
using AbstractDinerBusinessLogic.ViewModels;
using AbstractDinerDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractDinerDatabaseImplement.Implements
{
    public class SnackStorage : ISnackStorage
    {
        public List<SnackViewModel> GetFullList()
        {
            using (var context = new AbstractDinerDatabase())
            {
                return context.Snacks
                .Include(rec => rec.SnackComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new SnackViewModel
                {
                    Id = rec.Id,
                    SnackName = rec.SnackName,
                    Price = rec.Price,
                    SnackComponents = rec.SnackComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
               .ToList();
            }
        }

        public List<SnackViewModel> GetFilteredList(SnackBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractDinerDatabase())
            {
                return context.Snacks
                .Include(rec => rec.SnackComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.SnackName.Contains(model.SnackName))
                .ToList()
                .Select(rec => new SnackViewModel
                {
                   Id = rec.Id,
                   SnackName = rec.SnackName,
                   Price = rec.Price,
                   SnackComponents = rec.SnackComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }

        public SnackViewModel GetElement(SnackBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractDinerDatabase())
            {
                var product = context.Snacks
                .Include(rec => rec.SnackComponents)
               .ThenInclude(rec => rec.Component)
               .FirstOrDefault(rec => rec.SnackName == model.SnackName || rec.Id
               == model.Id);
                return product != null ?
                new SnackViewModel
                {
                    Id = product.Id,
                    SnackName = product.SnackName,
                    Price = product.Price,
                    SnackComponents = product.SnackComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
                } :
               null;
            }
        }

        public void Insert(SnackBindingModel model)
        {
            using (var context = new AbstractDinerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Snack snack = new Snack
                        {
                            SnackName = model.SnackName,
                            Price = model.Price
                        };
                        context.Snacks.Add(snack);
                        context.SaveChanges();
                        CreateModel(model, snack, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(SnackBindingModel model)
        {
            using (var context = new AbstractDinerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Snacks.FirstOrDefault(rec => rec.Id ==
                       model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(SnackBindingModel model)
        {
            using (var context = new AbstractDinerDatabase())
            {
                Snack element = context.Snacks.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Snacks.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Snack CreateModel(SnackBindingModel model, Snack snack,
            AbstractDinerDatabase context)
        {
            snack.SnackName = model.SnackName;
            snack.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.SnackComponents.Where(rec =>
                rec.SnackId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.SnackComponents.RemoveRange(productComponents.Where(rec =>
                !model.SnackComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count = model.SnackComponents[updateComponent.ComponentId].Item2;
                    model.SnackComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var sc in model.SnackComponents)
            {
                context.SnackComponents.Add(new SnackComponent
                {
                    SnackId = snack.Id,
                    ComponentId = sc.Key,
                    Count = sc.Value.Item2
                });

                try
                {
                    context.SaveChanges();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            return snack;
        }
    }
}
