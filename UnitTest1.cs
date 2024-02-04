using Лаб_9_Банников;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCellConstructor()
        {
            // Arrange
            ChessboardCell expected = new ChessboardCell(1, 1);

            // Act
            ChessboardCell cell = new ChessboardCell();
            ChessboardCell sameCell = new ChessboardCell(cell);

            // Assert
            Assert.AreEqual(expected, cell);
            Assert.AreEqual(expected, sameCell);
        }

        [TestMethod]
        public void TestHorVer()
        {
            // Arrange
            ChessboardCell expected = new ChessboardCell(2, 5);

            // Act
            ChessboardCell cell = new ChessboardCell();
            cell.Horizontal = 2;
            cell.Vertical = 5;

            // Assert
            Assert.AreEqual(expected, cell);
        }

        [TestMethod]
        public void TestIsSameColor()
        {
            // Act
            bool answer1 = ChessboardCell.isSameColor(new ChessboardCell(), new ChessboardCell(3, 5));
            bool answer2 = ChessboardCell.isSameColor(new ChessboardCell(), new ChessboardCell(1, 8));

            // Assert
            Assert.IsTrue(answer1);
            Assert.IsFalse(answer2);
        }

        [TestMethod]
        public void TestIsBlack()
        {
            // Act
            bool answer1 = new ChessboardCell(7, 5).isBlack();
            bool answer2 = new ChessboardCell(3, 6).isBlack();

            // Assert
            Assert.IsTrue(answer1);
            Assert.IsFalse(answer2);
        }

        [TestMethod]
        public void TestCellCount()
        {
            // Arrange
            ChessboardCell.count = 0;
            int expected = 0;

            // Assert
            Assert.AreEqual(expected, ChessboardCell.count);
        }

        [TestMethod]
        public void TestCellCount1()
        {
            // Arrange
            ChessboardCell.count = 0;
            int expected = 3;

            // Act
            ChessboardCell cell1 = new ChessboardCell();
            ChessboardCell cell2 = new ChessboardCell(1, 2);
            ChessboardCell cell3 = new ChessboardCell(cell2);

            // Assert
            Assert.AreEqual(expected, ChessboardCell.count);
        }

        [TestMethod]
        public void TestInc()
        {
            // Arrange
            ChessboardCell expected = new ChessboardCell(2, 4);

            // Act
            ChessboardCell cell = new ChessboardCell(1, 3);
            cell++;

            // Assert
            Assert.AreEqual(expected, cell);
        }

        [TestMethod]
        public void TestLogicalNot()
        {
            // Arrange
            ChessboardCell expected = new ChessboardCell(2, 4);

            // Act
            ChessboardCell cell = new ChessboardCell(4, 2);
            cell = !cell;

            // Assert
            Assert.AreEqual(expected, cell);
        }

        [TestMethod]
        public void TestExpInt()
        {
            // Arrange
            int expected = 6;

            // Act
            ChessboardCell cell = new ChessboardCell(2, 4);
            int sumCell = (int)cell;

            // Assert
            Assert.AreEqual(expected, sumCell);
        }

        [TestMethod]
        public void TestImpStr()
        {
            // Arrange
            string expected1 = "Чёрная";
            string expected2 = "Белая";

            // Act
            string cell1 = new ChessboardCell(1, 3);
            string cell2 = new ChessboardCell(1, 4);

            // Assert
            Assert.AreEqual(expected1, cell1);
            Assert.AreEqual(expected2, cell2);
        }

        [TestMethod]
        public void TestAreEqual()
        {
            // Arrange
            bool expected1 = true;
            bool expected2 = false;

            // Act
            ChessboardCell cell1 = new ChessboardCell(1, 3);
            ChessboardCell cell2 = new ChessboardCell(2, 1);
            ChessboardCell cell3 = new ChessboardCell(3, 2);
            ChessboardCell cell4 = new ChessboardCell(1, 8);

            // Assert
            Assert.AreEqual(expected1, cell1 == cell2);
            Assert.AreEqual(expected1, cell1 == cell3);
            Assert.AreEqual(expected2, cell1 == cell4);
        }

        [TestMethod]
        public void TestAreNotEqual()
        {
            // Arrange
            bool expected1 = true;
            bool expected2 = false;

            // Act
            ChessboardCell cell1 = new ChessboardCell(1, 3);
            ChessboardCell cell2 = new ChessboardCell(8, 2);
            ChessboardCell cell3 = new ChessboardCell(3, 3);

            // Assert
            Assert.AreEqual(expected1, cell1 != cell2);
            Assert.AreEqual(expected2, cell1 != cell3);
        }

        [TestMethod]
        public void TestCellConstructorEx()
        {
            // Assert
            Assert.ThrowsException<Exception>(() => (new ChessboardCell(-1, 1)));
            Assert.ThrowsException<Exception>(() => (new ChessboardCell(1, -1)));
            Assert.ThrowsException<Exception>(() => (new ChessboardCell(100, 8)));
            Assert.ThrowsException<Exception>(() => (new ChessboardCell(8, 9)));
        }

        [TestMethod]
        public void TestLength()
        {
            // Arrange
            ChessboardCellArray cells1 = new ChessboardCellArray();
            ChessboardCellArray cells2 = new ChessboardCellArray(10, 1);
            int expected1 = 0;
            int expected2 = 10;

            // Assert
            Assert.AreEqual(expected1, cells1.Length);
            Assert.AreEqual(expected2, cells2.Length);
        }

        [TestMethod]
        public void TestCellArrayConstructor()
        {
            // Arrange
            ChessboardCellArray expected = new ChessboardCellArray();

            // Act
            ChessboardCellArray cells1 = new ChessboardCellArray(0, 0);
            ChessboardCellArray cells2 = new ChessboardCellArray(cells1);

            // Assert
            Assert.AreEqual(expected, cells1);
            Assert.AreEqual(expected, cells2);
        }

        [TestMethod]
        public void TestCellArrayConstructor2()
        {
            // Arrange
            ChessboardCellArray cells = new ChessboardCellArray(20, 1);
            ChessboardCellArray otherCells = new ChessboardCellArray(cells);

            // Act
            cells[0] = new ChessboardCell();
            cells[1] = new ChessboardCell();
            cells[2] = new ChessboardCell();
            cells[3] = new ChessboardCell();
            cells[4] = new ChessboardCell();

            // Assert
            Assert.AreNotEqual(cells, otherCells);
        }

        [TestMethod]
        public void TestCellArrayIndexEx()
        {
            // Arrange
            ChessboardCellArray cells = new ChessboardCellArray(5, 1);

            // Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => (cells[6]));
            Assert.ThrowsException<IndexOutOfRangeException>(() => (cells[-1]));
        }

        [TestMethod]
        public void TestClosestToA1()
        {
            // Arrange
            ChessboardCellArray cells = new ChessboardCellArray();

            // Act
            cells.ClosestToA1();

            // Assert
            Assert.AreEqual(null, ChessboardCellArray.closestCell);
        }

        [TestMethod]
        public void TestClosestToA1_2()
        {
            // Arrange
            ChessboardCellArray cells = new ChessboardCellArray(10, 1);

            // Act
            cells.ClosestToA1();

            // Assert
            Assert.AreNotEqual(null, ChessboardCellArray.closestCell);
        }
    }
}