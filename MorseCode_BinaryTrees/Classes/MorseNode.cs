using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCode_BinaryTrees.Classes
{
    public class MorseNode
    {
        public char Character { get; set; }
        public MorseTree Left { get; set; }

        public MorseTree Right { get; set; }

        public MorseNode(char character = ' ')
        {
            Character = character;
            Left = null;
            Right = null;
        }

    }
}
