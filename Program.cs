using System;
using static System.Console;

namespace the_caesar_cipher
{
    public class CaesarCipher
    {
        //символы латинской азбуки
        const string ABC = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

        private string CodeEncode(string text, int k)
        {
            //добавляем в алфавит маленькие буквы
            var fullABC =ABC +ABC.ToLower();
            var letterQty = fullABC.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullABC.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullABC[codeIndex];
                }
            }
            return retVal;
        }
    //шифрование текста
    public string Encrypt(string plainMessage, int key)
        => CodeEncode(plainMessage, key);

    //дешифрование текста
    public string Decrypt(string encryptedMessage, int key)
        => CodeEncode(encryptedMessage, -key);

    }
    class Program
    {

        static void Main(string[] args)
        {
            var cipher = new CaesarCipher();
            Write("Введите текст: ");
            var message = ReadLine();
            Write("Введите ключ: ");
            var secretKey = Convert.ToInt32(ReadLine());
            var encryptedText = cipher.Encrypt(message, secretKey);
            WriteLine("Зашифрованное сообщение: {0}", encryptedText);
            WriteLine("Расшифрованное сообщение: {0}", cipher.Decrypt(encryptedText, secretKey));
        }
    }
}
