using System;

namespace CaesarCipherLibrary
{
    public abstract class CaesarBase
    {
        protected int Key { get; set; } // Dichiaro una chiave

        private char Cipher(char ch) // 
        {
            if (!char.IsLetter(ch)) // 
                return ch;

            char offset; // 

            if (char.IsUpper(ch)) // controllo se il carattere è maiuscolo o minuscolo
                offset = 'A'; // 
            else // 
                offset = 'a';

            return (char)(((ch - offset + Key) % 26) + offset); // 
        }

        protected string DoWork (string m) // 
        {
            string message = string.Empty; // 

            foreach (char ch in m) // 
                message += Cipher(ch); // 

            return message; // 
        }
    }

    public class CaesarCode:CaesarBase
    {
        public string CipherText { get; set; }
        public CaesarCode (string message, int key)
        {
            Key = key;
            CipherText = DoWork(message);
        }
    }
}
