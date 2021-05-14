using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.Enums;
using AbstractDinerBusinessLogic.Interfaces;
using AbstractDinerBusinessLogic.ViewModels;
using AbstractDinerDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractDinerDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new AbstractDinerDatabase())
            {
                return context.Orders
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    SnackName = rec.Snack.SnackName,
                    SnackId = rec.SnackId,
                    ImplementerId = rec.ImplementerId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    ImplementerFIO = context.Implementers.FirstOrDefault(r => r.Id == rec.ImplementerId).ImplementerFIO,
                })
                .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractDinerDatabase())
            {
                return context.Orders
                .Include(rec => rec.Snack)
               .Include(rec => rec.Client)
               .Include(rec => rec.Implementer)
               .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue &&
               rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue &&
               rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <=
               model.DateTo.Value.Date) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
               (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status ==
               OrderStatus.Принят) ||
                (model.ImplementerId.HasValue && rec.ImplementerId ==
               model.ImplementerId && rec.Status == OrderStatus.Выполняется))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    SnackId = rec.SnackId,
                    SnackName = rec.Snack.SnackName,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                    Status = rec.Status,
                    Sum = rec.Sum
                })
               .ToList();
            }

        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractDinerDatabase())
            {
                var order = context.Orders
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    SnackId = order.SnackId,
                    SnackName = context.Snacks.FirstOrDefault(rec => rec.Id == order.SnackId)?.SnackName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new AbstractDinerDatabase())
            {
                if (model.ClientId.HasValue == false)
                {
                    throw new Exception("Клиент не указан");
                }
                Order order = new Order
                {
                    SnackId = model.SnackId,
                    ClientId = (int)model.ClientId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new AbstractDinerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new AbstractDinerDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.SnackId = model.SnackId;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId;
            order.Status = model.Status;
            order.Sum = model.Sum;
            return order;
        }
    }
}
