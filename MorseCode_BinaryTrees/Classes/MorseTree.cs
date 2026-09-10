using MorseCode_BinaryTrees.Classes;
using System;
using System.Collections.Generic;
using System.Text;

public class MorseTree
{
    private readonly MorseNode root;

    public MorseTree()
    {
        root = new MorseNode(); // Empty root node
        InitializeTree();
    }

    // Populates the binary tree with the standard International Morse Code
    private void InitializeTree()
    {
        Insert('E', "."); Insert('T', "-");
        Insert('I', ".."); Insert('A', ".-"); Insert('N', "-."); Insert('M', "--");
        Insert('S', "..."); Insert('U', "..-"); Insert('R', ".-."); Insert('W', ".--");
        Insert('D', "-.."); Insert('K', "-.-"); Insert('G', "--."); Insert('O', "---");
        Insert('H', "...."); Insert('V', "...-"); Insert('F', "..-."); Insert('L', ".-..");
        Insert('P', ".--."); Insert('J', ".---"); Insert('B', "-..."); Insert('X', "-..-");
        Insert('C', "-.-."); Insert('Y', "-.--"); Insert('Z', "--.."); Insert('Q', "--.-");
    }

    // 1. Insert a character into the tree by following its Morse signal path
    public void Insert(char character, string morseCode)
    {
        MorseNode current = root;

        foreach (char symbol in morseCode)
        {
            if (symbol == '.')
            {
                if (current.Left == null) current.Left = new MorseNode();
                current = current.Left;
            }
            else if (symbol == '-')
            {
                if (current.Right == null) current.Right = new MorseNode();
                current = current.Right;
            }
        }
        current.Character = character;
    }

    // 2. DECODING: O(N) time complexity relative to the length of the Morse string
    public string Decode(string morseMessage)
    {
        StringBuilder decodedText = new StringBuilder();
        // Split words by triple space, letters by single space
        string[] words = morseMessage.Split(new[] { "   " }, StringSplitOptions.None);

        foreach (string word in words)
        {
            string[] letters = word.Split(' ');
            foreach (string letterCode in letters)
            {
                if (string.IsNullOrWhiteSpace(letterCode)) continue;

                MorseNode current = root;
                foreach (char symbol in letterCode)
                {
                    if (current == null) break;
                    current = symbol == '.' ? current.Left : current.Right;
                }

                if (current != null && current.Character != ' ')
                {
                    decodedText.Append(current.Character);
                }
            }
            decodedText.Append(' '); // Add spaces between words
        }

        return decodedText.ToString().Trim();
    }

    // 3. ENCODING: Requires a lookup map extracted from the tree (Depth-First Search)
    public string Encode(string text)
    {
        Dictionary<char, string> lookupTable = new Dictionary<char, string>();
        PopulateLookupTable(root, "", lookupTable);

        StringBuilder encodedMorse = new StringBuilder();
        text = text.ToUpper();

        foreach (char character in text)
        {
            if (character == ' ')
            {
                encodedMorse.Append("   "); // 3 spaces to separate words
            }
            else if (lookupTable.TryGetValue(character, out string code))
            {
                encodedMorse.Append(code).Append(' '); // 1 space to separate letters
            }
        }

        return encodedMorse.ToString().Trim();
    }

    // Helper method to turn the tree paths back into strings for quick encoding lookup
    private void PopulateLookupTable(MorseNode node, string currentPath, Dictionary<char, string> table)
    {
        if (node == null) return;

        if (node.Character != ' ')
        {
            table[node.Character] = currentPath;
        }

        PopulateLookupTable(node.Left, currentPath + ".", table);
        PopulateLookupTable(node.Right, currentPath + "-", table);
    }
}
