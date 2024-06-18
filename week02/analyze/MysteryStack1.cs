/*
so to me it would seem that this code will take in some text as a string
and then spit it back out in reverse.  This could be useful for reversing
strings.
*/

public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}
