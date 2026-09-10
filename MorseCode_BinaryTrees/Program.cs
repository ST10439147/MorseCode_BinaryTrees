public class Program
{
    public static void Main(string[] args)
    {
        MorseTree translator = new MorseTree();

        // Test Encoding
        string originalText = "HELLO WORLD";
        string encoded = translator.Encode(originalText);
        Console.WriteLine($"Original: {originalText}");
        Console.WriteLine($"Encoded:  {encoded}\n");

        // Test Decoding
        string morseCode = ".... . .-.. .-.. ---   .-- --- .-. .-.. -..";
        string decoded = translator.Decode(morseCode);
        Console.WriteLine($"Morse:   {morseCode}");
        Console.WriteLine($"Decoded: {decoded}");
    }
}