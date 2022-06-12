using Xunit;
using ScrumBoard;
using System;

namespace ScrumBoardTests
{
    public class TestsForScrumBoard
    {
        [Fact]
        public void Create_board()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            Assert.Equal("Test", board.GetName());
        }

        [Fact]
        public void Create_new_column()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("Column");

            Assert.Equal("Column", board.GetColumn(0).GetName());
        }
        [Fact]
        public void Create_new_column_when_board_is_full()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            for (int i = 0; i < 9; i++)
            {
                board.AddColumn("Column");
            }

            Assert.Throws<Exception>(() => board.AddColumn("Column"));
        }

        [Fact]
        public void Delete_existing_column()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("Column");

            board.DeleteColumn("Column");

            Assert.Empty(board.GetColumns());
        }
        [Fact]
        public void Delete_not_existing_column()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");

            Assert.Throws<Exception>(() => board.DeleteColumn("Column"));
        }
        [Fact]
        public void Create_new_task_when_column_exist()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("Column");

            board.AddTask("task", "description", Priority.low);

            Assert.Equal("task", board.GetColumn(0).GetTasks()[0].Title);
            Assert.Equal("description", board.GetColumn(0).GetTasks()[0].Description);
            Assert.Equal(Priority.low, board.GetColumn(0).GetTasks()[0].Priority);
        }
        [Fact]
        public void Create_new_task_when_columns_not_exist()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");

            Assert.Throws<Exception>(() => board.AddTask("task", "description", Priority.low));
        }

        [Fact]
        public void Move_task_to_exist_columns()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("first");
            board.AddColumn("second");
            board.AddTask("task", "description", Priority.low);

            board.MoveTask("task", "second");

            Assert.Equal("task", board.GetColumn(1).GetTasks()[0].Title);
        }
        [Fact]
        public void Move_task_to_not_exist_columns()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("first");

            board.AddTask("task", "description", Priority.low);

            Assert.Throws<Exception>(() => board.MoveTask("task", "second"));
        }
        [Fact]
        public void Move_not_existing_task()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("first");
            board.AddColumn("second");

            Assert.Throws<Exception>(() => board.MoveTask("task", "second"));
        }
        [Fact]
        public void Delete_existing_task()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("Column");
            board.AddTask("task", "description", Priority.low);

            board.DeleteTask("task");

            Assert.Empty(board.GetColumn(0).GetTasks());
        }
        [Fact]
        public void Delete_moved_task()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("first");
            board.AddColumn("second");
            board.AddTask("task", "description", Priority.low);
            board.MoveTask("task", "second");

            board.DeleteTask("task");

            Assert.Empty(board.GetColumn(1).GetTasks());
        }

        [Fact]
        public void Delete_not_existing_task()
        {
            ScrumBoard.ScrumBoard board = new ScrumBoard.ScrumBoard("Test");
            board.AddColumn("first");
            board.AddColumn("second");
            board.AddTask("task1", "description1", Priority.low);
            board.AddTask("task2", "description2", Priority.low);
            board.MoveTask("task2", "second");

            Assert.Throws<Exception>(() => board.DeleteTask("task"));
        }
    }
}