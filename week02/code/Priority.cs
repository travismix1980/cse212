public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Create a queue of items with varying priority. cheeseburger(3), hamburger(2), fries(4), ketchup(1) and make sure they come out of queue in the right order also check to make sure that we are getting error messages if there are no more items in the queue
        // Expected Result: fries, cheeseburger, hamburger, ketchup, The queue is empty
        Console.WriteLine("Test 1");
        var q1 = new PriorityQueue();
        q1.Enqueue("cheeseburger", 3);
        q1.Enqueue("hamburger", 2);
        q1.Enqueue("fries", 4);
        q1.Enqueue("ketchup", 1);
        for(int i = 0; i < 5; i++){
            Console.WriteLine(q1.Dequeue());
        }
        // Defect(s) Found: Dequeue() in PriorityQueue was not removing items from the queue so it would just keep repeating the item that was highest priority in the queue

        Console.WriteLine("---------");

        // Test 2
        // Scenario: check to make sure we are getting all items out of the queue in proper order if multiple items have the same priority level. Input is batteries(12), tires(18), rims(18), bananas(3), cherry(1), door(22), steeringwheel(18)
        // Expected Result: door, tires, rims, steeringwheel, batteries, bananas, cherry
        Console.WriteLine("Test 2");
        var q2 = new PriorityQueue();
        q2.Enqueue("batteries", 12);
        q2.Enqueue("tires", 18);
        q2.Enqueue("rims", 18);
        q2.Enqueue("bananas", 3);
        q2.Enqueue("cherry", 1);
        q2.Enqueue("door", 22);
        q2.Enqueue("steeringwheel", 18);
        for(int i = 0; i < 7; i++){
            Console.WriteLine(q2.Dequeue());
        }

        // Defect(s) Found: system seems to be skipping the last item in queue when finding highest priority changed for loop to (int index = 0; index <= _queue.Count - 1; index++) so it starts at the beginning of the queue and not the second item and set range to index <= _queue.Count which could have been done by removing -1 from the end of the middle section as well.  This make sure that we are able to see the whole queue before we get to the very end of it.

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}
