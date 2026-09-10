using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCode_BinaryTrees.Classes
{
    public class MorseNode
    {
        public char Character { get; set; }
        public MorseNode Left { get; set; }

        public MorseNode Right { get; set; }

        public MorseNode(char character = ' ')
        {
            Character = character;
            Left = null;
            Right = null;
        }

    }
}
