/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: make a queue and make sure you are able to get an error message if you add more people than queue than the queue can handle.  Also check to make sure we can add new customers
        // Expected Result: should  get an error message about going over max queue size and we should be able to add customers
        Console.WriteLine("Test 1");

        var q1 = new CustomerService(2);
        q1.AddNewCustomer();
        q1.AddNewCustomer();
        q1.AddNewCustomer();

        // Defect(s) Found: no error message when going over max queue size error check happening before attempting to add to queue and checking for a number that was higher than maxsize.  changed check to make sure we are checking for maxsize

        Console.WriteLine("=================");

        // Test 2
        // Scenario: can we actually serve customers and when no more customers in queue do we get a empty queue message
        // Expected Result: with 2 customers looping through 3 times we should get 2 customers of output and then an empty queue message so customer1 data, customer2 data,  empty queue message
        Console.WriteLine("Test 2");
        var q2 = new CustomerService(2);
        q2.AddNewCustomer();
        q2.AddNewCustomer();
        for(int i = 0; i < 3; i++){
            q2.ServeCustomer();
        }
        // Defect(s) Found: no error message and we are removing customers before outputting their data

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // test 3
        // Scenario: if maxqueue size is set to 0 or is invalid is does it should be set to 10 by default
        // Expected Result: maxqueue size should be set to 10

        Console.WriteLine("Test 3");
        var q3 = new CustomerService(0);
        Console.WriteLine($"Max Size should equal 10 and is actually {q3._maxSize}");

        // Defect(s) Found: none

        Console.WriteLine("=================");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if(_queue.Count > 0)
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        else
        {
            Console.WriteLine("Queue is Empty");
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}
