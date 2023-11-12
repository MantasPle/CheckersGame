using System.ComponentModel;

namespace Checkers
{
    public partial class Form1 : Form
    {
        private Board board = new Board();
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            board.CreateBoard(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.ResetBoard(this);
        }
    }
}