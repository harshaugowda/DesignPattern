using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational_Pattern
{
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostService();
    }

    /* Shipping cost service*/
    public interface IShippingCostService
    {
        decimal? ShippingCost { get; }
    }
    class IndiaShippingCost : IShippingCostService
    {
        public decimal? ShippingCost => 10;
    }
    class UsaShippingCost : IShippingCostService
    {
        public decimal? ShippingCost => 30;
    }

    /* Discount service*/
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    public class IndiaDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    class UsaDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    /* Factory */

    class IndiaShoppingCartFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new IndiaDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new IndiaShippingCost();
        }
    }

    class UsaShoppingCartFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new UsaDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new UsaShippingCost();
        }
    }

    /* Concreate class */
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private int _cost;

        public ShoppingCart(IDiscountService discountService, IShippingCostService shippingCostService)
        {
            _discountService = discountService;
            _shippingCostService = shippingCostService;

        }
    }
}
