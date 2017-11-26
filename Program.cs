using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Brainfuck_Interpreter
{
    class Program
    {

        public static void Main(string[] args)
        {
            byte[] memory = new byte[255];
            int memoryPtr = 0;

            string program = Console.ReadLine();

            for (int i = 0; i < program.Length; i++)
            {
                switch (program[i])
                {
                    case '+':
                        memory[memoryPtr]++;
                        break;
                    case '-':
                        memory[memoryPtr]--;
                        break;
                    case '>':
                        memoryPtr++;
                        break;
                    case '<':
                        memoryPtr--;
                        break;
                    case '.':
                        Console.Write((char)memory[memoryPtr]);
                        break;
                    case ',':
                        memory[memoryPtr] = Convert.ToByte(Console.ReadLine());
                        break;
                    case '[':
                        if (memory[memoryPtr] == 0)
                        {
                            int open = 0;
                            int newPtr = i + 1;

                            while (program[newPtr] != ']' || open > 0) 
                            {
                                if (program[newPtr] == '[')
                                {
                                    open++;
                                }
                                else if (program[newPtr] == ']')
                                {
                                    open--;
                                }
                                newPtr++;
                                i = newPtr;
                            }
                        }
                        break;
                    case ']':
                        if (memory[memoryPtr] != 0)
                        {
                            int open = 0;
                            int newPtr = i - 1;

                            while (program[newPtr] != '[' || open > 0)
                            {
                                if (program[newPtr] == ']')
                                {
                                    open++;
                                }
                                else if (program[newPtr] == '[')
                                {
                                    open--;
                                }
                                newPtr--;
                                i = newPtr;
                            }
                        }
                        break;  
                }
            }
            Console.WriteLine("\n");

        }


    }
}
