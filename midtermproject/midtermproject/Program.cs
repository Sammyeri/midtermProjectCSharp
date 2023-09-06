using midtermproject;
using System;

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

List<Order> orders = new List<Order>();
List<Product> Cart = new List<Product>();

Console.WriteLine("Welcome! To Coney Island!");
Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("| Our menu: \t \t \t \t \t  \t  |");
Console.WriteLine("| Number : Item : Category : Description : Price(USD) |");
foreach(Product item in menu)
{
    Console.WriteLine($"| {item.ProductId +1} : {item.Name} : {item.Description}: {item.Category}: {item.Price} |");
    
}
Console.WriteLine("-----------------------------------------------------------");


while (true)
{
    Console.WriteLine("Please enter the name or number of the item you would like, followed by the quantity, or q to quit");
    string userInputSelection = Console.ReadLine();

    string[] tempChoices = new string[2];

    if (String.IsNullOrEmpty(userInputSelection))
    {
        Console.WriteLine("Please enter something.");
        continue;
    }
    else if(userInputSelection.Trim().ToLower() == "q" || userInputSelection.Trim().ToLower() == "quit")
    {
        break;
    }
    else if (userInputSelection.Contains(" "))
    {
        tempChoices = userInputSelection.Split(' ');
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

    if (firstsucceded && secondsecceded && quantity > 0 && itemNum > 0)
    {
        Console.WriteLine($" The total for {quantity} of the {menu[itemNum -1].Name} is {(quantity * menu[itemNum -1].Price).ToString("#.##")}");
        orders.Add(new Order(menu[itemNum - 1], quantity));
    }
    else if (secondsecceded && quantity > 0)
    {
        if(menu.Select(n => n.Name.ToLower()).Contains(tempChoices[0]))
        {
            int index = menu.Where(n => n.Name == tempChoices[0]).FirstOrDefault().ProductId;
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
            Console.WriteLine($"Sorry, we do not have {tempChoices[1]} amount of {menu[itemNum -1].Name} in stock");
        }
        else
        {
            Console.WriteLine($"Sorry, we do not have {tempChoices[1]} amount of {tempChoices[0]} in stock");

        }
        continue;
    }
}

Console.WriteLine("your order: ");
foreach(Order order in orders)
{
    Console.WriteLine($"{order.Product.Name} : {order.Quantity}");
}

decimal orderTotal = 0m;

foreach (Order order in orders)
{
    for(int i = 0; i < order.Quantity; i++)
    {
        orderTotal += order.Product.Price ;
    }
}

Console.WriteLine($"Your total is {orderTotal}");

Payment paymentInfo;
while (true)
{
    Console.WriteLine("How are you paying today? (cash, credit, or check) ?");
    string paymentChoice = Console.ReadLine();

    if (paymentChoice.Trim().ToUpper() == PaymentType.CASH.ToString())
    {
        Cash cash = new Cash(orderTotal);
        cash.GatherPaymentDetails();

        if (cash.Change == -1)
        {
            continue;
        }
        else
        {
            cash.CompletePayment();
            paymentInfo = cash;
            break;
        }

    }
    else if (paymentChoice.Trim().ToUpper() == PaymentType.CREDIT.ToString())
    {

    }
    else if (paymentChoice.Trim().ToUpper() == PaymentType.CHECK.ToString())
    {

    }
    else
    {
        Console.WriteLine("You chose an invalid option");
    }
}