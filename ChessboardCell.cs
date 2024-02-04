using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_9_Банников
{
    public class ChessboardCell
    {
        public static int count;

        private int horizontal;
        private int vertical;

        // Свойства
        public int Horizontal
        {
            get => horizontal;
            set
            {
                if ((value < 1) || (value > 8))
                {
                    value = 1;
                    throw new Exception("Координаты клетки на шахматной доске должны быть в диапазоне от 1 до 8");
                }

                horizontal = value;
            }
        }

        public int Vertical
        {
            get => vertical;
            set
            {
                if ((value < 1) || (value > 8))
                {
                    value = 1;
                    throw new Exception("Координаты клетки на шахматной доске должны быть в диапазоне от 1 до 8");
                }

                vertical = value;
            }
        }

        // Конструкторы
        public ChessboardCell()
        {
            Horizontal = 1;
            Vertical = 1;
            count++;
        }

        public ChessboardCell(int horizontal, int vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            count++;
        }

        public ChessboardCell(ChessboardCell otherCell)
        {
            Horizontal = otherCell.Horizontal;
            Vertical = otherCell.Vertical;
            count++;
        }

        // Методы
        public static bool isSameColor(ChessboardCell firstCell, ChessboardCell secondCell)
        {

            if (Math.Abs(firstCell.Horizontal - secondCell.Horizontal) % 2 == Math.Abs(firstCell.Vertical - secondCell.Vertical) % 2) return true;
            else return false;
        }

        public bool isBlack() // True, если совпадает по цвету с клеткой A1 или cell(1, 1), т.е. если чёрного цвета
        {
            if (Math.Abs(Horizontal - Vertical) % 2 == 0) return true;
            else return false;
        }

        public void Show()
        {
            Console.WriteLine($"{horizontal} клетка по горизонтали, {vertical} по вертикали");
        }

        // Операторы
        public static ChessboardCell operator ++(ChessboardCell cell)
        {
            cell.Horizontal++;
            cell.Vertical++;
            return cell;
        } // обе координты увеличиваются на 1

        public static ChessboardCell operator !(ChessboardCell cell)
        {
            int temp = cell.Horizontal;
            cell.Horizontal = cell.Vertical;
            cell.Vertical = temp;
            return cell;
        } // Инвертирование клетки относительно глав. диагонали

        public static explicit operator int(ChessboardCell cell) // Явное приведение к int = horisontal + vertical
        {
            int sumHorPlusVer = cell.Horizontal + cell.Vertical;
            return sumHorPlusVer;
        }
        
        public static implicit operator string(ChessboardCell cell)
        {
            if (cell.isBlack()) return "Чёрная";
            else return "Белая";
        }

        public static bool operator ==(ChessboardCell firstCell, ChessboardCell secondCell)
        {
            int Δx = Math.Abs(firstCell.Horizontal - secondCell.Horizontal);
            int Δy = Math.Abs(firstCell.Vertical - secondCell.Vertical);

            bool answer = (Δx != 0) && (Δy != 0) && (Δx + Δy == 3);
            if (answer) return true;
            else return false;
        }

        public static bool operator !=(ChessboardCell firstCell, ChessboardCell secondCell)
        {
            if (firstCell.Vertical != secondCell.Vertical) return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ChessboardCell);
        }

        public bool Equals(ChessboardCell otherCell)
        {
            return ((Horizontal == otherCell.Horizontal) && (Vertical == otherCell.Vertical));
        }
    }
}
