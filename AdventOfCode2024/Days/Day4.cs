using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
    internal class Day4
    {
        public static void Day4P2()
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day4.input"));

            var total = 0;
            var rowCount = lines.Length;
            var colCount = lines[0].Length;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < colCount; columnIndex++)
                {
                    var charToCheck = lines[rowIndex][columnIndex];
                    if (charToCheck != 'M' && charToCheck != 'S')
                    {
                        continue;
                    }

                    if (rowIndex <= rowCount - 3 && columnIndex <= colCount - 3)
                    {
                        if (lines[rowIndex + 1][columnIndex + 1] == 'A' &&

                            ((lines[rowIndex][columnIndex] == 'M' && lines[rowIndex + 2][columnIndex + 2] == 'S') ||
                            (lines[rowIndex][columnIndex] == 'S' && lines[rowIndex + 2][columnIndex + 2] == 'M')) &&

                            ((lines[rowIndex][columnIndex + 2] == 'M' && lines[rowIndex + 2][columnIndex] == 'S') ||
                            (lines[rowIndex][columnIndex + 2] == 'S' && lines[rowIndex + 2][columnIndex] == 'M')))
                        {
                            total++;
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }
        
        public static void Day4P1()
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day4.input"));

            var total = 0;
            var rowCount = lines.Length;
            var colCount = lines[0].Length;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < colCount; columnIndex++)
                {
                    var charToCheck = lines[rowIndex][columnIndex];
                    if (charToCheck != 'X')
                    {
                        continue;
                    }

                    //check in the following order
                    //W, NW, N, NE, E, SE, S, SW

                    //W
                    if (columnIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex][columnIndex - 1]}{lines[rowIndex][columnIndex - 2]}{lines[rowIndex][columnIndex - 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //NW
                    if (rowIndex >= 3 && columnIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex - 1][columnIndex - 1]}{lines[rowIndex - 2][columnIndex - 2]}{lines[rowIndex - 3][columnIndex - 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //N
                    if (rowIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex - 1][columnIndex]}{lines[rowIndex - 2][columnIndex]}{lines[rowIndex - 3][columnIndex]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //NE
                    if (rowIndex >= 3 && columnIndex <= colCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex - 1][columnIndex + 1]}{lines[rowIndex - 2][columnIndex + 2]}{lines[rowIndex - 3][columnIndex + 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //E
                    if (columnIndex <= colCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex][columnIndex + 1]}{lines[rowIndex][columnIndex + 2]}{lines[rowIndex][columnIndex + 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //SE
                    if (rowIndex <= rowCount - 4 && columnIndex <= colCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex + 1][columnIndex + 1]}{lines[rowIndex + 2][columnIndex + 2]}{lines[rowIndex + 3][columnIndex + 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //S
                    if (rowIndex <= rowCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex + 1][columnIndex]}{lines[rowIndex + 2][columnIndex]}{lines[rowIndex + 3][columnIndex]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //SW
                    if (rowIndex <= rowCount - 4 && columnIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex + 1][columnIndex - 1]}{lines[rowIndex + 2][columnIndex - 2]}{lines[rowIndex + 3][columnIndex - 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }
    }
}
