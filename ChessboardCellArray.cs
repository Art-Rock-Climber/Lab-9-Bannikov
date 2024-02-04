using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_9_Банников
{
    public class ChessboardCellArray
    {
        public static int arrCount = 0;
        ChessboardCell[] cells;

        public int Length
        {
            get => cells.Length;
        }

        public ChessboardCellArray() 
        { 
            cells = new ChessboardCell[0];
            arrCount++;
        }

        public ChessboardCellArray(int length, int check)
        {
            cells = new ChessboardCell[length];

            switch (check)
            {
                case 1:
                    Random rnd = new Random();
                    for (int i = 0; i < length; i++) cells[i] = new ChessboardCell(rnd.Next(1, 9), rnd.Next(1, 9));
                    break;
                case 2:
                    for (int i = 0; i < length; i++)
                    {
                        int hor = Program.ReadIntNumber($"\nВведите координату {i+1} клетки по горизонтали", 1, 9);
                        int ver = Program.ReadIntNumber($"Введите координату {i+1} клетки по вертикали", 1, 9);
                        cells[i] = new ChessboardCell(hor, ver);
                    }
                    break;
            }
            arrCount++;
        }

        public ChessboardCellArray(ChessboardCellArray otherCells)
        {
            cells = new ChessboardCell[otherCells.Length];
            for (int i = 0; i < otherCells.Length; i++) cells[i] = new ChessboardCell(otherCells[i]);
            arrCount++;
        }

        public void Show()
        {
            if (cells.Length != 0)
            {
                Console.WriteLine("Ваш массив:");
                for (int i = 0; i < Length; i++) cells[i].Show();
            }
            else Console.WriteLine("Ваш массив пустой");
            Console.WriteLine("");
        }

        public ChessboardCell this[int index]
        {
            get
            {
                if (index >= 0 && index < Length) return cells[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Length) cells[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public static ChessboardCell closestCell = null;

        public void ClosestToA1()
        {
            double distance = 0;
            double minDistance = Length * Length;

            if (cells.Length == 0)
            {
                Console.WriteLine("Невозможно выполнить поиск в пустом массиве!\n");
            }
            else
            {
                if (cells.Length == 1)
                {
                    closestCell = cells[0];
                }
                else
                {
                    for (int i = 0; i < Length; i++)
                    {
                        distance = Math.Pow(Math.Pow(cells[i].Horizontal - 1, 2) + Math.Pow(cells[i].Vertical - 1, 2), 0.5);
                        if (distance < minDistance)
                        {
                            closestCell = cells[i];
                            minDistance = distance;
                        }
                    }
                }
                Console.Write("Ближайшая к A1 клетка: ");
                closestCell.Show();
                Console.WriteLine("");
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ChessboardCellArray);
        }

        public bool Equals(ChessboardCellArray otherCells)
        {
            bool answer = true;
            for (int i = 0; i < otherCells.Length; i++)
            {
                if (cells[i] != otherCells[i]) answer = false;
            }

            return answer;
        }
    }
}
