using System;
using System.Text;
using static System.Console;

namespace the_caesar_cipher
{
    class Program
    {
        static StringBuilder Decrypt(StringBuilder ciphertext,int key)
        {
            StringBuilder plaintext = new StringBuilder(ciphertext.ToString());
            
            for (int index=0; index < plaintext.Length; index++)
            {
                if (ciphertext[index] != ' ')
                {
                    int character =
                    (((ciphertext[index]+26-'A')-key)%26)+'A';
                    plaintext[index] = (char)character;
                }
            }
            return plaintext;
        }
        static void Main(string[] args)
        {   
            StringBuilder ciphertext = new StringBuilder();
            Write("Введте ваше сообщение: ");
            ciphertext.Append(ReadLine());
            //последовательно проверять все пространство ключей
            for (int testkey=1; testkey <= 25; testkey++)
            {   
                StringBuilder plaintext = Decrypt(ciphertext, testkey);
                Console.WriteLine("Сдвиг на {0,2}: Полученный текст: {1,2}",
                              testkey, plaintext);   
                              
            }
        }
    }
}
