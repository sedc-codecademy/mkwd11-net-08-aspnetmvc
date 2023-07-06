﻿using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Services;
using SEDC.PizzaApp.Refactored.Services.Abstraction;
using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Refactored.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;

        public OrderController(IOrderService orderService, 
                               IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");

            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetUsersForDropdown();
            return View(orderViewModel);
        }
       
        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderViewModel model = _orderService.GetOrderForEditing(id.Value);
                ViewBag.Users = _userService.GetUsersForDropdown();
                return View(model);
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.EditOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }
        }

        [HttpPost]
        public IActionResult Delete(OrderDetailsViewModel orderDetailsViewModel)
        {
            try
            {
                _orderService.DeleteOrder(orderDetailsViewModel.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }
        }
    }
}
