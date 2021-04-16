using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.Interfaces;
using AbstractDinerBusinessLogic.ViewModels;
using AbstractDinerDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    SnackId = rec.SnackId,
                    SnackName = context.Snacks.FirstOrDefault(pr => pr.Id == rec.SnackId).SnackName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId,
                    ClientFIO = context.Clients.FirstOrDefault(x => x.Id == rec.ClientId).ClientFIO
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
            if (model.DateFrom != null && model.DateTo != null)
            {
                using (var context = new AbstractDinerDatabase())
                {
                    return context.Orders
                        .Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                        .Select(rec => new OrderViewModel
                        {
                            Id = rec.Id,
                            SnackId = rec.SnackId,
                            SnackName = context.Snacks.FirstOrDefault(pr => pr.Id == rec.SnackId).SnackName,
                            Count = rec.Count,
                            Sum = rec.Sum,
                            Status = rec.Status,
                            DateCreate = rec.DateCreate,
                            DateImplement = rec.DateImplement,
                            ClientId = rec.ClientId,
                        })
                        .ToList();
                }
            }
            using (var context = new AbstractDinerDatabase())
            {
                return context.Orders
                .Where(rec => rec.SnackId == model.SnackId)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    SnackId = rec.SnackId,
                    SnackName = context.Snacks.FirstOrDefault(pr => pr.Id == rec.SnackId).SnackName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
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
                    ClientId = order.ClientId,
                } :
                null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (var context = new AbstractDinerDatabase())
            {
                Order order = new Order
                {
                    SnackId = model.SnackId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                    ClientId = (int)model.ClientId,
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
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.SnackId = model.SnackId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                element.ClientId = (int)model.ClientId;
                CreateModel(model, element);
                context.SaveChanges();
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
            if (model == null)
            {
                return null;
            }

            using (var context = new AbstractDinerDatabase())
            {
                Snack element = context.Snacks.FirstOrDefault(rec => rec.Id == model.SnackId);
                if (element != null)
                {
                    if (element.Orders == null)
                    {
                        element.Orders = new List<Order>();
                    }
                    element.Orders.Add(order);
                    context.Snacks.Update(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}
