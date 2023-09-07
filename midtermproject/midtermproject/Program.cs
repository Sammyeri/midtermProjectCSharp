using midtermproject;
using System;
using System.Text;

List<Product> menu = new List<Product>
{
    new Product("Fries", "Appetizer", "Our hot and crispy french fries!", 2.99m, 0),
    new Product("Chicken wings", "Appetizer", "Crispy traditional wings served with your choice of sauce", 8m, 1),
    new Product("Gyro Dinner", "Entree", "Gyro meat, tzadziki sauce, tomato and onion wrapped in a grilled pita", 14.09m, 2),
    new Product("Club Sandwich", "Entree", "Classic triple-decker with turkey, bacon, lettuce and mayonaise", 8.19m, 3),
    new Product("Iced tea", "Drink", "Our homemade Iced tea, Unsweetened or Sweetened!", 2.59m, 4),
    new Product("Milk Shake", "Drink", "Choice of vanilla, chocolate, or strawberry", 4.19m, 5),
    new Product("Baklava", "Dessert", "Our sweet and flaky baklava - a golden treat", 2.49m, 6),
    new Product("Brown Sundae", "Dessert", "Our yummy, gooey brownie over some good ole ice cream", 5.19m, 7),
    new Product("Kid's Chicken strips & fries", "Entree", "made with real gold!", 2000m, 8),
    new Product("Kid's Grilled cheese & fries", "Entree", "a plain grilled cheese with your choice of bread", 5.99m, 9),
    new Product("Potato skins", "Appetizer", "With bacon, cheddar cheese and sour cream", 6.59m, 10),
    new Product("Mozzarella Cheese sticks", "Appetizer", "the classic!", 7.99m, 11)

};
bool again = true;
while (again)
{
    List<Order> orders = new List<Order>();
    List<Product> cart = new List<Product>();

    Console.WriteLine("Welcome to Coney Island!");
    Console.WriteLine("[---------------------------------------------------------------------------------------------------------------------------------]");
    foreach (Product product in menu)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("| {0,-2}", product.ProductId);
        sb.AppendFormat(" : {0, -29}", product.Name);
        sb.AppendFormat(" : {0, -10}", product.Category);
        sb.AppendFormat(" : {0, -69}", product.Description);
        sb.AppendFormat(" : {0, -5} |", product.Price);

        Console.WriteLine(sb.ToString());

    }
    Console.WriteLine("[---------------------------------------------------------------------------------------------------------------------------------]");


    while (true)
    {
        Console.WriteLine("Please enter the name or number of the item you would like, followed by the quantity(seperated by commaas, or q to quit");
        string userInputSelection = Console.ReadLine();

        string[] tempChoices = new string[2];

        if (String.IsNullOrEmpty(userInputSelection))
        {
            Console.WriteLine("Please enter something.");
            continue;
        }
        else if (userInputSelection.Trim().ToLower() == "q" || userInputSelection.Trim().ToLower() == "quit")
        {
            break;
        }
        else if (userInputSelection.Contains(","))
        {
            tempChoices = userInputSelection.Split(',');
        }
        else
        {
            continue;
        }

        int itemNum = -1;
        bool firstsucceded = int.TryParse(tempChoices[0], out itemNum);

        int quantity = 0;
        bool secondsecceded = int.TryParse(tempChoices[1], out quantity);

        if (firstsucceded && secondsecceded && quantity > 0 && itemNum >= 0)
        {
            Console.WriteLine($" The total for {quantity} of the {menu[itemNum].Name} is {(quantity * menu[itemNum].Price).ToString("#.##")}");
            orders.Add(new Order(menu[itemNum], quantity));
        }
        else if (secondsecceded && quantity > 0)
        {
            if (menu.Select(n => n.Name.ToLower()).Contains(tempChoices[0].ToLower()))
            {
                int index = menu.Where(n => n.Name.ToLower() == tempChoices[0].ToLower()).FirstOrDefault().ProductId;
                Console.WriteLine($" The total for {quantity} of the {menu[index].Name} is {(quantity * menu[index].Price).ToString("#.##")}");
                orders.Add(new Order(menu[index], quantity));
            }
            else
            {
                Console.WriteLine($"Sorry, {tempChoices[0]} is not on the menu");
                continue;
            }
        }
        else
        {
            if (firstsucceded)
            {
                Console.WriteLine($"Sorry, we do not have {tempChoices[1]} amount of {menu[itemNum - 1].Name} in stock");
            }
            else
            {
                Console.WriteLine($"Sorry, we do not have {tempChoices[1]} amount of {tempChoices[0]} in stock");

            }
            continue;
        }
    }

    Console.WriteLine("your order: ");
    foreach (Order order in orders)
    {
        Console.WriteLine($"{order.Product.Name} : {order.Quantity}");
    }

    decimal orderTotal = 0m;

    foreach (Order order in orders)
    {
        for (int i = 0; i < order.Quantity; i++)
        {
            orderTotal += order.Product.Price;
        }
    }

    Console.WriteLine($"Your total is {orderTotal}");

    Payment paymentInfo;
    PaymentType selectedPaymentType;
    Cash cash = new Cash(0.0m, PaymentType.CASH, orderTotal);
    Credit credit = new Credit(0.08m, PaymentType.CREDIT, "", "", "");
    Check check = new Check(0.0m, PaymentType.CHECK, "");

    while (true)
    {
        Console.WriteLine("How are you paying today? (cash, credit, or check) ?");
        string paymentChoice = Console.ReadLine();

        if (paymentChoice.Trim().ToUpper() == PaymentType.CASH.ToString())
        {
            cash.GatherPaymentDetails();
            selectedPaymentType = PaymentType.CASH;
            if (cash.Change == -1)
            {
                continue;
            }
            else
            { 
                paymentInfo =(Payment)cash;
                break;
                
            }

            
        }
        else if (paymentChoice.Trim().ToUpper() == PaymentType.CREDIT.ToString())
        {
            Console.WriteLine("Enter a Credit Card Number:");
            string a = Console.ReadLine();
            Console.WriteLine("Enter your expiration date with a four digit year and a two digit month");
            string b = Console.ReadLine();
            Console.WriteLine("Enter your 3 digit or 4 digit CVV or Security Code");
            string c = Console.ReadLine();
            credit.CardNumber(a);
            credit.Expiration(b);
            credit.CVV(c);

            selectedPaymentType = PaymentType.CREDIT;
            break;
        }
        else if (paymentChoice.Trim().ToUpper() == PaymentType.CHECK.ToString())
        {
            Console.WriteLine("Enter Check number");
            string a = Console.ReadLine();
            check.Checknum(a);
            selectedPaymentType = PaymentType.CHECK;
            break;
        }
        else
        {
            Console.WriteLine("You chose an invalid option");
        }
    }

    static void DisplayReceipt(decimal subTotal, decimal salesTax, decimal grandTotal, List<Product> cart)
    {
        Console.WriteLine("Thank you for letting us feed you yummy food! Here is your receipt:");
        Console.WriteLine("----------------------------");
        DisplayMenu(cart);
    }

    static void DisplayMenu(List<Product> cart)
    {
        for (int i = 0; i < cart.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cart[1]}");
        }
    }
   
    Payment payment;

    switch (selectedPaymentType)
    {
        case PaymentType.CREDIT:
            payment = new Payment(0.08m, PaymentType.CREDIT);
            payment.SubTotal = orderTotal;
            payment.CalculateSalesTax();
            payment.CalculateGrandTotal();

            DisplayReceipt(payment.SubTotal, payment.SalesTax, payment.GrandTotal, cart);
            Console.WriteLine($"Payment Type: {selectedPaymentType}");
            Console.WriteLine($"Subtotal: {payment.SubTotal}");
            Console.WriteLine($"Sales Tax: {payment.SalesTax.ToString("#.##")}");
            Console.WriteLine($"Grand Total: {payment.GrandTotal}");
            
            break;
        case PaymentType.CASH:
            payment = new Payment(0.0m, PaymentType.CASH);
            payment.SubTotal = orderTotal;
            payment.CalculateSalesTax();
            payment.CalculateGrandTotal();
           
            DisplayReceipt(payment.SubTotal, payment.SalesTax, payment.GrandTotal, cart);
            Console.WriteLine($"Payment Type: {selectedPaymentType}");
            Console.WriteLine($"Subtotal: {payment.SubTotal}");
            Console.WriteLine($"Sales Tax: {payment.SalesTax}");
            Console.WriteLine($"Grand Total: {payment.GrandTotal}");
            cash.CompletePayment();
            

            
            break;
        case PaymentType.CHECK:
            payment = new Payment(0.0m, PaymentType.CHECK);
            payment.SubTotal = orderTotal;
            payment.CalculateSalesTax();
            payment.CalculateGrandTotal();

            DisplayReceipt(payment.SubTotal, payment.SalesTax, payment.GrandTotal, cart);
            Console.WriteLine($"Payment Type: {selectedPaymentType}");
            Console.WriteLine($"Subtotal: {payment.SubTotal}");
            Console.WriteLine($"Sales Tax: {payment.SalesTax}");
            Console.WriteLine($"Grand Total: {payment.GrandTotal}");
            
            break;
        default:
            throw new ArgumentException("Invalid payment type");

    }

    while (true)
    {
        Console.WriteLine("Would you like to start a new order (y/n)?");
        ConsoleKeyInfo choice = Console.ReadKey();
        Console.WriteLine(" ");

        if(Char.ToLower(choice.KeyChar) == 'y')
        {
            break;
        }
        else if(Char.ToLower(choice.KeyChar) == 'n')
        {
            Console.WriteLine("Thank you for visiting Coney Island!");
            again = false;
            break;
        }
        else
        {
            Console.WriteLine($"Sorry, {choice.KeyChar} is not a valid option");
        }
    }
}
