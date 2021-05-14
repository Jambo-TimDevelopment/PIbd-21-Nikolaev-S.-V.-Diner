using AbstractDinerBusinessLogic.Interfaces;
using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using AbstractDinerBusinessLogic.Enums;
using AbstractDinerBusinessLogic.HelperModels;

namespace AbstractDinerBusinessLogic.BusinessLogic
{
    public class OrderLogic
    {
        private readonly object locker = new object();
        
        private readonly IOrderStorage _orderStorage;
        
        private readonly IClientStorage _clientStorage;
        
        public OrderLogic(IOrderStorage orderStorage, IClientStorage clientStorage)
        {
            _orderStorage = orderStorage;
            _clientStorage = clientStorage;
        }
        
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                ClientId = model.ClientId,
                SnackId = model.SnackId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = model.ClientId
                })?.Email,
                Subject = $"Новый заказ",
                Text = $"Заказ от {DateTime.Now} на сумму {model.Sum:N2} принят."
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = _orderStorage.GetElement(new OrderBindingModel
                {
                    Id =
               model.OrderId
                });
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
            if (order.Status != OrderStatus.Принят)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    ImplementerId = model.ImplementerId,
                    SnackId = order.SnackId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now,
                    Status = OrderStatus.Выполняется
                });
                MailLogic.MailSendAsync(new MailSendInfo
                {
                    MailAddress = _clientStorage.GetElement(new ClientBindingModel
                    {
                        Id = order.ClientId
                    })?.Email,
                    Subject = $"Заказ №{order.Id}",
                    Text = $"Заказ №{order.Id} передан в работу."
                });
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                SnackId = order.SnackId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
            // Отправить письмо
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                SnackId = order.SnackId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
            // Отправить письмо
        }
    }
}
