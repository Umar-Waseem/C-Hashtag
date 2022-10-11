
namespace Task
{
    class MenuItem
    {
        public int id;
        public int price;
        public string title;
        public string description;

        public MenuItem(int id ,int price, string title, string description)
        {
            this.id = id;
            this.price = price;
            this.title = title;
            this.description = description;
        }
    }

    class Menu
    {
        public List<MenuItem> items;

        public Menu()
        {
            items = new List<MenuItem>();
        }

        public void AddAnItem(MenuItem item)
        {
            items.Add(item);
            Console.WriteLine(item.title + " was added");
        }

        public void RemoveItemById(int idItem)
        {
            items.RemoveAll(s => s.id == idItem);
        }

        public MenuItem GetItemById(int idItem)
        {
            // return item with id idItem in the list items
            return items.Find(s => s.id == idItem);
        }

        public void PrintMenu()
        {
            Console.WriteLine("-----------MENU-----------");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("-----");
                Console.WriteLine("id:" + items[i].id);
                Console.WriteLine("title:" + items[i].title);
                Console.WriteLine("price" + items[i].price);
            }
            Console.WriteLine();
        }
        
    }

    class Bill
    {
        public double totalBill;
        public int numberOfItems;
        public double gst;
        public List<MenuItem> cart;
        public string billId;

        public Bill(string id)
        {
            this.billId = id;
            this.cart = new List<MenuItem>();
            this.totalBill = 0;
            this.numberOfItems = 0;
        }

        public void AddItemToBill(MenuItem item)
        {
            cart.Add(item);
            totalBill += item.price;
            numberOfItems++;
        }

        public void removeItemById(int idItem)
        {
            totalBill -= this.cart.Find(s => s.id == idItem).price;
            cart.RemoveAll(s =>
            {
                return s.id == idItem;
            });
            this.numberOfItems--;
            
        }

        public void DisplayBill()
        {
            Console.WriteLine("Bill Id: " + billId);
            Console.WriteLine("Your bill ->");
            // calculate 17% GST
            gst = totalBill * 0.17;
            // gst in 2 decimal places
            gst = Math.Round(gst, 2);
            Console.WriteLine("GST: " + gst);
            Console.WriteLine("Total to pay: " + (totalBill + gst));
            Console.WriteLine("Number of items in bill: " + numberOfItems);
        
            Console.WriteLine("Items in bill: " );
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine("-----");
                Console.WriteLine("id: " + cart[i].id);
                Console.WriteLine("title: " + cart[i].title);
                Console.WriteLine("price: " + cart[i].price);
            }
            Console.WriteLine();
        }
    }

    class MainWork
    {
        public static void Main()
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            Menu menu = new();
            Bill bill = new(str);
            menu.AddAnItem(new MenuItem(1, 20, "Ice Cream", "Cold"));
            menu.AddAnItem(new MenuItem(2, 30, "Pizza", "Spicy"));
            menu.AddAnItem(new MenuItem(3, 40, "Biryani", "Spicy"));
            menu.AddAnItem(new MenuItem(4, 50, "Pulao", "Spicy"));
            menu.AddAnItem(new MenuItem(5, 60, "Keema", "Spicy"));
            menu.AddAnItem(new MenuItem(6, 70, "Chicken", "Spicy"));
            menu.PrintMenu();


            bool choice = true;

            while (choice)
            {
                MenuDirections();
                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter id of item to add to bill");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bill.AddItemToBill(menu.GetItemById(id));
                        break;
                    case 2:
                        Console.WriteLine("Enter id of item to remove from bill");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        bill.removeItemById(id2);
                        break;
                    case 3:
                        bill.DisplayBill();
                        break;
                    case 4:
                        choice = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }

        }

        private static void MenuDirections()
        {
            Console.WriteLine("Enter 1 to add item to bill");
            Console.WriteLine("Enter 2 to remove item from bill");
            Console.WriteLine("Enter 3 to display bill");
            Console.WriteLine("Enter 4 to exit");
            Console.WriteLine("Enter you choice: ");
        }
    }
}