using System.ComponentModel;
using Checkers.Classes;

namespace Checkers
{
    public partial class Form1 : Form
    {
        private GameManager gameManager = new GameManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameManager.Initialize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameManager.ResetGame(this);
        }
    }
}