using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Doublerer _doublerer;
        private GameState _gameState;
        private MenuForm _menuForm;
        public Form1(MenuForm menuForm)
        {
            InitializeComponent();
            _doublerer = new Doublerer(20, 100);
            _gameState = new GameState();
            _gameState = GameState.Running;
            ShowInfo();
            _menuForm = menuForm;
            _menuForm.OnScoreShow += MenuForm_OnScoreShow;
        }

        private string MenuForm_OnScoreShow()
        {
            return _doublerer.Target.ToString();
        }

        private void ShowInfo()
        {
            lblCurrent.Text = _doublerer.Current.ToString();
            lblTarget.Text = _doublerer.Target.ToString();
        }

        private void ChangeGameState(GameState state)
        {
            _gameState = state;
        }

        private void CheckGameState()
        {
            switch (_gameState)
            {
                case GameState.Running:
                    break;
                case GameState.Win:
                    ShowRestartWindow("Restart", "You've won! Congrats");

                    break;
                case GameState.Lose:
                    ShowRestartWindow("Restart", "Sorry, you've lost");
                    break;
                default:
                    break;
            }
        }

        private void ShowRestartWindow(string caption, string text)
        {
            if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _doublerer.StartGame(20,100);
                ShowInfo();
            }
            else 
            {
                Hide();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _doublerer.Add();
            ShowInfo();
            ChangeGameState(_doublerer.GetGameState());
            CheckGameState();
        }

        private void btnMulty_Click(object sender, EventArgs e)
        {
            _doublerer.Multi();
            ShowInfo();
            ChangeGameState(_doublerer.GetGameState());
            CheckGameState();
        }
    }
}
