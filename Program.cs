using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_9_Банников
{
    public class Program
    {
        // Ограничения для размера массива
        const int MIN_LENGTH = 1;
        const int MAX_LENGTH = 100;
        // Ограничения для элеменов массива
        const int MIN_VALUE = -100;
        const int MAX_VALUE = 100;

        public static int ReadIntNumber(string outputMessage, int left, int right)
        {
            bool isInputCorrect = false;
            int num = MIN_VALUE;
            do
            {
                Console.WriteLine(outputMessage);
                string input = Console.ReadLine();
                isInputCorrect = int.TryParse(input, out num);
                if ((!isInputCorrect) || (!(num >= left && num < right)))
                {
                    Console.WriteLine("Неверно введено число!");
                    isInputCorrect = false;
                }
            } while (!isInputCorrect);
            return num;
        }

        static void Main(string[] args)
        {
            int menuCheck = 0;
            do
            {
                menuCheck = Program.ReadIntNumber("Выберите задание лр для выполнения:\n" +
                    "1 - Задание 1\n2 - Задание 2\n3 - Задание 3\n4 - Выход", 1, 5);
                switch (menuCheck)
                {
                    case 1:
                        Console.WriteLine("\n|------------------Задание 1------------------|");
                        Console.WriteLine("Конструктор без параметра");
                        ChessboardCell cc1 = new ChessboardCell();
                        cc1.Show();

                        Console.WriteLine("\nКонструктор c параметром");
                        ChessboardCell cc2 = new ChessboardCell(3, 1);
                        cc2.Show();
                        try
                        {
                            cc2 = new ChessboardCell(-100, 2);
                            cc2.Show();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("\nКонструктор копирования");
                        ChessboardCell cc3 = new ChessboardCell(cc2);
                        cc3.Show();

                        bool answer = ChessboardCell.isSameColor(cc2, cc3);
                        Console.WriteLine($"\nОдного ли цвета cc2 и cc3 (стат. функция)? {answer}");

                        answer = (cc2.isBlack() == cc3.isBlack());
                        Console.WriteLine($"Одного ли цвета cc2 и cc3 (метод)? {answer}");

                        Console.WriteLine($"\nКоличество созданных объектов: {ChessboardCell.count}\n");
                        break;
                    case 2:
                        Console.WriteLine("\n|------------------Задание 2------------------|");
                        cc1 = new ChessboardCell();
                        cc2 = new ChessboardCell(3, 1);

                        Console.WriteLine("Значение 1 клетки до инкремента");
                        cc1.Show();
                        cc1++;
                        Console.WriteLine("Значение 1 клетки после инкремента");
                        cc1.Show();

                        Console.WriteLine("\nЗначение 2 клетки до инвертирования");
                        cc2.Show();
                        cc2 = !cc2;
                        Console.WriteLine("Значение 2 клетки после инвертирования");
                        cc2.Show();

                        Console.WriteLine($"\nСумма координат 2 клетки = {(int)cc2}");

                        string color1 = cc1;
                        string color2 = cc2;
                        Console.WriteLine($"Цвета клеток №1 и №2: {color1}, {color2}\n");
                        break;
                    case 3:
                        Console.WriteLine("\n|------------------Задание 3------------------|");
                        Console.WriteLine("Конструктор без параметра");
                        ChessboardCellArray emptyCells = new ChessboardCellArray();
                        emptyCells.Show();

                        Console.WriteLine("Конструктор c параметром");
                        int length = ReadIntNumber("Введите длину массива:", 0, 101);
                        int arrCheck = Program.ReadIntNumber("\nВведите способ задания массива:\n" + 
                            "1 - с помощью генератора случайных чисел\n2 - вводом с клавиатуры", 1, 3);
                        ChessboardCellArray cells = new ChessboardCellArray(length, arrCheck);
                        cells.Show();

                        Console.WriteLine("Конструктор копирования");
                        ChessboardCellArray sameCells = new ChessboardCellArray(cells);
                        sameCells.Show();
                        
                        try
                        {
                            Console.WriteLine($"cells[2]:");
                            cells[2].Show();
                            Console.WriteLine($"cells[-1]:");
                            cells[-1].Show();
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        try
                        {
                            cells[3].Horizontal = 8;
                            Console.WriteLine("\ncells[3].Horizontal = 8");
                            cells[3].Show();
                            cells[-1].Vertical = 7;
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("\nДля сравнения: массив otherCells не изменился, т.к. копирование глубокое");
                        sameCells.Show();

                        cells.ClosestToA1();

                        Console.WriteLine($"Количество созданных объектов: {ChessboardCellArray.arrCount}\n");
                        break;
                }
            } while (menuCheck != 4);
        }
    }
}
