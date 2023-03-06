using TicTacToeLogic;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        TicTacToeGame game;
        Button[] buttons;
        int winAnnouncement = 0;
        public Form1()
        {
            InitializeComponent();
            game = new TicTacToeGame();
            buttons = new Button[9];

            for (int i = 0; i < 9; i++)
            {
                buttons[i] = Controls.Find("button" + (i + 1), true)[0] as Button;
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonClick;
                buttons[i].Tag = i;
                buttons[i].Text = " ";

            }
        }
        private void ShowGame()
        {
            for (int i = 0; i < 9; i++)
            {
                switch (game.GameData[i])
                {
                    case 1:
                        buttons[i].Text = "O";
                        buttons[i].Enabled = false;
                        buttons[i].FlatStyle = FlatStyle.Flat;
                        buttons[i].FlatAppearance.BorderColor = Color.Empty;
                        buttons[i].ForeColor = Color.Green;
                        break;
                    case 2:
                        buttons[i].Text = "X";
                        buttons[i].Enabled = false;
                        buttons[i].FlatStyle = FlatStyle.Flat;
                        buttons[i].FlatAppearance.BorderColor = Color.Empty;
                        buttons[i].ForeColor = Color.Red;
                        break;
                    default:
                        buttons[i].Text = " ";
                        buttons[i].Enabled = true;
                        break;
                }
            }
        }
        private void handleButtonClick(object? sender, EventArgs e)
        {
            Button clickButton = (Button)sender;
            int gameIndexNumber = (int)clickButton.Tag;
            PlayerTurn(gameIndexNumber);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            while (true)
            {
                Random randomNum = new Random();
                var gameIndexNumber = randomNum.Next(9);
                if (game.GameData[gameIndexNumber] == 0)
                {
                    game.GameData[gameIndexNumber] = 2;
                    ShowGame();
                    break;
                } else if(game.IsSomeOneWin()) 
                {
                    DisableAllButton();
                    break; 
                }
            }
            if (game.IsSomeOneWin() && winAnnouncement == 0)
            {
                winAnnouncement += 1;
                DisableAllButton();
                MessageBox.Show("Computer Win!!");
            }
            else if (isDraw())
            {
                DisableAllButton();
                MessageBox.Show("Draw!!");
            }
        }
        private bool isDraw()
        {
            int[] notPlay = game.GameData.Where(x => x == 0).ToArray();
            if (notPlay.Length == 0)
            {
                DisableAllButton();
                return true;
            }
            else { return false; }
        }

        private void PlayerTurn(int gameIndexNumber)
        {
            while (true)
            {
                if (game.GameData[gameIndexNumber] == 0)
                {
                    game.GameData[gameIndexNumber] = 1;
                    ShowGame();
                    break;
                }
                else if (game.IsSomeOneWin()) 
                {
                    DisableAllButton();
                    break; 
                }
            }
            if (game.IsSomeOneWin() && winAnnouncement == 0)
            {
                winAnnouncement += 1;
                DisableAllButton();
                MessageBox.Show("Player Win!!");
            }
            else if (isDraw())
            {
                DisableAllButton();
                MessageBox.Show("Draw!!");
                
            }
        }
        private void DisableAllButton()
        {
            foreach (var item in buttons)
            {
                item.Enabled = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new TicTacToeGame();
            RestAllButton();
            winAnnouncement = 0;
            foreach (var item in buttons)
            {
                item.BackColor = SystemColors.Control;
            }
            ShowGame();
        }

        private void RestAllButton()
        {
            foreach(var item in buttons) 
            {
                item.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}