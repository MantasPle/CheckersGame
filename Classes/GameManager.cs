using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Classes
{
    public class GameManager
    {
        private Board _checkerBoard;

        public GameManager()
        {
            _checkerBoard = new Board();
        }

        public void Initialize(Form form)
        {
            _checkerBoard.CreateBoard(form);
        }

        public void ResetGame(Form form)
        {
            _checkerBoard.ResetBoard(form);
        }

       
    }
}
