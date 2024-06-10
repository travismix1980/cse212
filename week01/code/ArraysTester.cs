using System.Security.Cryptography.X509Certificates;

public static class ArraysTester
{
    /// <summary>
    /// Entry point for the tests
    /// </summary>
    public static void Run()
    {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        double[] multiples = MultiplesOf(7, 5);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{7, 14, 21, 28, 35}
        multiples = MultiplesOf(1.5, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{1.5, 3.0, 4.5, 6.0, 7.5, 9.0, 10.5, 12.0, 13.5, 15.0}
        multiples = MultiplesOf(-2, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{-2, -4, -6, -8, -10, -12, -14, -16, -18, -20}

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 1);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{9, 1, 2, 3, 4, 5, 6, 7, 8}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 5);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 3);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 9);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{1, 2, 3, 4, 5, 6, 7, 8, 9}
    }
    /// <summary>
    /// This function will produce a list of size 'length' starting with 'number' followed by multiples of 'number'.  For
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    ///
    /// To implement MultiplesOf is a pretty simple solution
    /// step 1 create a new array called results
    /// step 2 write a for loop that runs 1 <= length
    /// step 3 in the for loop add the result of number times i to our list
    /// step 4 return the array we created
    private static double[] MultiplesOf(double number, int length) // cannot return a list from the method that is expecting an array and yet the assignment specified a list here so changed the return type of the method
    {
        /// To implement MultiplesOf is a pretty simple solution
        /// step 1 create a new array called results
        double[] results = new double[length];
        /// step 2 write a for loop that runs 1 <= length
        for (var i = 1; i <= length; i++)
        {
            /// step 3 in the for loop add the result of number times i to our array
            results[i - 1] = (number * i);
        }

        /// step 4 return the array we created
        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is
    /// <c>&lt;List&gt;{1, 2, 3, 4, 5, 6, 7, 8, 9}</c> and an amount is 3 then the list returned should be
    /// <c>&lt;List&gt;{7, 8, 9, 1, 2, 3, 4, 5, 6}</c>.  The value of amount will be in the range of <c>1</c> and
    /// <c>data.Count</c>.
    /// <br /><br />
    /// Because a list is dynamic, this function will modify the existing <c>data</c> list rather than returning a new list.
    /// </summary>
    ///
    /// Another simple problem to solve.
    /// step 1 create a temp list to store our data in that needs rotated called temp
    /// step 2 create an int variable called amountToMove to store data.Count - amount which tells us what actually      needs moved
    /// step 3 using GetRange(0, data.Count - amount) store all the need to be moved items in to the temp list
    /// step 4 using RemoveRange(0, data.Count - amount) remove the data that needs rotated from data
    /// step 5 using AddRange(temp)
    private static void RotateListRight(List<int> data, int amount)
    {
        /// step 1 create a temp list to store our data in that needs rotated called temp
        List<int> temp = new();
        /// step 2 create an int variable called amountToMove to store data.Count - amount which tells us what actually needs moved
        int amountToMove = data.Count - amount;
        /// step 3 using GetRange(0, data.Count - amount) store all the need to be moved items in to the temp list
        temp.AddRange(data.GetRange(0, amountToMove));
        /// step 4 using RemoveRange(0, data.Count - amount) remove the data that needs rotated from data
        data.RemoveRange(0, amountToMove);
        /// step 5 using AddRange(temp)
        data.AddRange(temp);
    }
}
