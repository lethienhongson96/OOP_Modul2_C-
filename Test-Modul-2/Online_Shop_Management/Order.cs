using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop_Management
{
    class OrderList
    {
        public List<Order> orders = new List<Order>();
        public void AddOrder(Order order)
        {
            if (order.products.Count != 0)
            {
                Random rnd = new Random();
                order.orderId = rnd.Next(100, 10000);
                this.orders.Add(order);
            }
            else
                Console.WriteLine("No products");
        }
        public Order FindOrderByID(int id)
        {
            return orders.Find(
                     delegate (Order or)
                     {
                         return or.orderId == id;
                     }
                 );
        }
        public void SearchOrderById(int id)
        {
            if (FindOrderByID(id) != null)
                Console.WriteLine(FindOrderByID(id));
            else
                Console.WriteLine($"not found {id} !!");
        }

        public List<Order> FindOrderByNameCus(string name)
        {
            return orders.FindAll(
                delegate (Order order)
                {
                    return order.customer.name == name;
                }
            );
        }
        public void SearchOrdersByNameCus(string name)
        {
            if (FindOrderByNameCus(name).Count != 0)
            {
                FindOrderByNameCus(name).ForEach(el => Console.WriteLine(el));
            }
            else
                Console.WriteLine($"not found {name} !!!");
        }
        public void ShowAllOrder()
        {
            orders.ForEach(el => Console.WriteLine(el));
        }

        public void Cancel(int id)
        {
            if (FindOrderByID(id) != null)
            {
                orders.Remove(FindOrderByID(id));
                Console.WriteLine($"{id} deleted");
            }
            else
                Console.WriteLine($"not found {id}");
        }

        public Bill Pay(Order order)
        {
            Bill bill = new Bill();
            if (order.isPaid)
            {
                bill.isPaid = false;
                bill.products = order.products;
                bill.orderId = order.orderId;
                bill.total = order.total;
                bill.customer = order.customer;
                bill.CreateAt = DateTime.Now;
                orders.Remove(order);
                Console.WriteLine("pay success !!!");
                return bill;
            }
            return bill;
        }

    }
    class Order
    {
        public int orderId { get; set; }
        public bool isPaid = true;
        public List<Product> products = new List<Product>();
        public double total { get; set; }
        public Customer customer { get; set; }
        public Order() { }
        public void AddProd(Product prod, int amount)
        {
            if (FindProd(prod.prodId) == null)
            {
                prod.amount = amount;
                prod.SetTotalOfProd();
                products.Add(prod);
            }

            else
            {
                FindProd(prod.prodId).amount += amount;
                FindProd(prod.prodId).SetTotalOfProd();
            }
            SetTotalOrder();
        }
        public void SetTotalOrder()
        {
            double sum = 0;
            products.ForEach(el => sum += el.total);
            this.total = sum;
        }
        public Product FindProd(int id)
        {
            return products.Find(
                delegate (Product pr)
                {
                    return pr.prodId == id;
                }
                );
        }
        public static Order CreateOrder()
        {
            Order order = new Order();
            order.customer = Customer.CreateCustumer();
            return order;
        }
        public override string ToString()
        {
            return $"{orderId} {products} {total} {customer}";
        }

        public void EditCustumer(Customer newcustomer)
        {
            this.customer = newcustomer;
        }
        public void RemoveProd(int id)
        {
            this.products.Remove(FindProd(id));
        }

        public void ShowAllProds()
        {
            products.ForEach(el => Console.WriteLine(el));
        }

    }

    class ProductList
    {
        public List<Product> myProdList = new List<Product>();

        public Product FindProdById(int id)
        {
            return myProdList.Find(
                delegate (Product prod)
                {
                    return prod.prodId == id;
                }
                );
        }

        public void AddNewProduct(Product product)
        {
            if (myProdList.Contains(product)==false)
            {
                myProdList.Add(product);
                SetIdForProd();
            }
            else
                Console.WriteLine($"{product.prodId} not available");
        }

        public void DeleteProduct(int id)
        {
            if (FindProdById(id) != null)
            {
                myProdList.Remove(FindProdById(id));
                SetIdForProd();
            }
               
            else
                Console.WriteLine($"not found {id}");
        }

        public void SetIdForProd()
        {
            int i = 0;
            foreach (var item in myProdList)
            {
                i++;
                item.prodId = i;
            }
        }
    }

    class Product
    {
        public int prodId { get; set; }

        public string prodname;
        public double price { get; set; }
        public int amount { get; set; }
        public double total { get; set; }
        public void SetTotalOfProd()
        {
            this.total = price * amount;
        }

        public static Product CreateProduct()
        {
            Product product = new Product();
            Console.WriteLine("enter name product");
            product.prodname = Console.ReadLine();
            Console.WriteLine("enter price product");
            product.price = Convert.ToDouble(Console.ReadLine());
            product.amount = 1;
            return product;
        }
        public override string ToString()
        {
            return $"{prodId} {prodname} {price}";
        }
    }

    class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int phoneNum { get; set; }

        public static Customer CreateCustumer()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter custumer's name");
            customer.name = Console.ReadLine();

            Console.WriteLine("enter custumer's address");
            customer.address = Console.ReadLine();

            Console.WriteLine("enter custumer's phone Number");
            customer.phoneNum = Convert.ToInt32(Console.ReadLine());
            customer.Setid();
            return customer;
        }
        public void Setid()
        {
            Random rnd = new Random();
            this.id = rnd.Next(100, 10000);
        }
        public override string ToString()
        {
            return $"{id} {name} {address} {phoneNum}";
        }
    }
}
