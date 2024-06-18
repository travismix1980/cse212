/*
This seems to be a class that uses a stack to perform as a calculator.
It clearly checks for numbers and also special mathmatical symbols to determine
if we need to add subtract multiply or divide those numbers

For problem two we get Determine the result of the function if the following inputs are provided

1) 5 3 7 + *  I would say that the result will be 50 based on the input set of characters.  The stack
should pop off ast * + 7 3 5 if we are just popping things off the end so lets go through the code step by step
first we would get the + symbol and then pop off and store 7 and 3 which is 10.  Then we store 10 in res and put
that back on the stack.  Next we go through the stack again and we get the * symbol for multiplication and we have the numbers 5 and 10 left so 5 * 10 is 50.

2) 6 2 + 5 3 - / and I would say the result would be 4.  So first we loop through and find the + and we have 6 and 2 making 6 + 2 = 8 and store 8 back on the stack.  this gives us 8 5 3 - / so we then subtrack 3 from 5 = 2 which goes back in the stack for a 8 -2 / so we then divide 8 by 2 = 4

3) Invalid Case 1 is caused by a stack count of less than 2 so input characters could be just a -
   Invalid Case 2 is a divide by zero error so if our inputs were 0 3 /
   Invalid Case 3 seems to be cause by trying to do math with an empty string so 2 4 "invalid character to search for so not a + - / *" maybe 2 4 ^
   Invalid Case 4 is caused by stack.Count not equaling 1 at the end of a loop through cycle. so maybe an input of 1 2 + -
*/

public static class MysteryStack2
{
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    public static float Run(string text)
    {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' '))
        {
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+")
                {
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    res = op1 * op2;
                }
                else
                {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item))
            {
                stack.Push(float.Parse(item));
            }
            else if (item == "")
            {
            }
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}
