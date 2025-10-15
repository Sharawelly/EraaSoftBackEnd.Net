using Microsoft.EntityFrameworkCore;
using Task_12.Data;
using Task_12.Models;

namespace Task_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _applicationDb = new ApplicationDbContext();

            #region problem 1

            //var customers = _applicationDb.Customers;

            //// Table header
            //Console.WriteLine("{0,-15} | {1,-15} | {2,-30}", "First Name", "Last Name", "Email");
            //Console.WriteLine(new string('-', 65));

            //// Table rows
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine("{0,-15} | {1,-15} | {2,-30}", customer.FirstName, customer.LastName, customer.Email);
            //}

            #endregion


            #region problem 2

            //var order = _applicationDb.Orders.FirstOrDefault(o => o.OrderId == 3);

            //if (order != null)
            //    Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Customer ID: {order.CustomerId}, Staff ID: {order.StaffId}, Store ID: {order.StoreId}");


            #endregion


            #region problem 3
            //var productsWithCategory = _applicationDb.Products
            //    .Where(p => p.Category.CategoryName == "Mountain Bikes")
            //    .Select(p => new
            //    {
            //        p.ProductId,
            //        p.ProductName,

            //    });

            //foreach (var product in productsWithCategory)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}");
            //}

            #endregion


            #region problem 4

            //var ordersPerStore = _applicationDb.Orders
            //    .GroupBy(o => o.StoreId)
            //    .Select(g => new
            //    {
            //        StoreId = g.Key,
            //        OrderCount = g.Count()
            //    });

            //foreach (var store in ordersPerStore)
            //    {
            //    Console.WriteLine($"Store ID: {store.StoreId}, Number of Orders: {store.OrderCount}");
            //}

            #endregion

            #region problem 5

            //var orders = _applicationDb.Orders.Where(o => o.ShippedDate == null);

            //foreach (var order in orders)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Customer ID: {order.CustomerId}, Staff ID: {order.StaffId}, Store ID: {order.StoreId}");
            //}

            #endregion


            #region problem 6

            //var customersWithOrders = _applicationDb.Customers.Select(c => new { 
            //c.FirstName,
            //c.LastName,
            //count = c.Orders.Count()
            //});


            //foreach (var customer in customersWithOrders)
            //{
            //    Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}, Number of Orders: {customer.count}");
            //}


            #endregion


            #region problem 7

            //var products = _applicationDb.Products.Where(p => p.OrderItems.FirstOrDefault(o => p.ProductId == o.ProductId) == null);


            //foreach (var product in products)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}");
            //}

            #endregion


            #region problem 8


            //var productsWithLowStock = _applicationDb.Products
            //.Where(p => p.Stocks.Any(s => s.Quantity < 5));

            //foreach (var product in productsWithLowStock)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}");
            //}

            #endregion

            #region problem 9

            //var product = _applicationDb.Products.First();

            //Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.ListPrice}");

            #endregion


            #region problem 10

            //var products = _applicationDb.Products.Where(p => p.ModelYear == 2016);


            //foreach (var product in products)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Model Year: {product.ModelYear}");
            //}

            #endregion


            #region problem 11


            //var productsWithOrders = _applicationDb.Products.Select(p => new
            //{
            //    p.ProductId,
            //    p.ProductName,
            //    p.ModelYear,
            //    count = p.OrderItems.Count(),
            //});

            //foreach (var product in productsWithOrders)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Model Year: {product.ModelYear}, Number of Orders: {product.count}");
            //}

            #endregion


            #region problem 12

            //int products = _applicationDb.Products.Count(e => e.CategoryId == 3);


            //Console.WriteLine($"Number of products in category 3: {products}");


            #endregion

            #region problem 13

            //var avg = _applicationDb.Products.Average(a => a.ListPrice);

            //Console.WriteLine($"The Avg is: {avg}");

            #endregion


            #region problem 14

            //var product = _applicationDb.Products.Find(3);

            //if (product != null)
            //{

            //  Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.ListPrice}");
            //}
            //else
            //{
            //    Console.WriteLine("Product not found.");
            //}

            #endregion


            #region problem 15

            //var products = _applicationDb.Products.Where(p => p.OrderItems.Any(o => o.Quantity > 3));

            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product ID: {p.ProductId}, Product Name: {p.ProductName}");
            //}



            #endregion


            #region problem 16

            //var staffs = _applicationDb.Staffs.Select(s => new
            //{
            //    s.FirstName,
            //    s.LastName,
            //    count = s.Orders.Count()
            //});

            //foreach (var staff in staffs)
            //{
            //    Console.WriteLine($"Staff: {staff.FirstName} {staff.LastName}, Number of Orders: {staff.count}");
            //}


            #endregion

            #region problem 17


            //var activeStaffs = _applicationDb.Staffs.Where(s => s.Active == 1);

            //foreach (var staff in activeStaffs)
            //{
            //    Console.WriteLine($"Staff ID: {staff.StaffId}, Name: {staff.FirstName} {staff.LastName}, Active: {staff.Active}");
            //}

            #endregion


            #region problem 18

            //var products = _applicationDb.Products
            //.Include(p => p.Category)
            //.Include(p => p.Brand);

            //foreach (var product in products)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Category: {product.Category.CategoryName}, Brand: {product.Brand.BrandName}");
            //}

            #endregion


            #region problem 19
            //var orders = _applicationDb.Orders.Where(o => o.ShippedDate != null);

            //foreach (var order in orders)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Customer ID: {order.CustomerId}, Staff ID: {order.StaffId}, Store ID: {order.StoreId}");
            //}

            #endregion


            #region problem 20



            var products = _applicationDb.Products
            .Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.BrandId,
                p.CategoryId,
                p.ModelYear,
                p.ListPrice,
                TotalQuantityOrdered = p.OrderItems.Sum(oi => oi.Quantity)
            });

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Total Quantity Ordered: {product.TotalQuantityOrdered}");
            }

            #endregion
        }
    }
}
