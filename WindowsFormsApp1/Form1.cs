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
        private char currentPlayer = 'X';
        private char[,] board = new char[3, 3];
        private bool moveMade = false; // Track if a move has been made
        private List<Player> players;
        private Tuple<int, int, char> lastMove; // Store the last move
        public Form1()
        {
            InitializeComponent();
            InitializePlayers();
            InitializeBoard();
        }
        public class Player
        {
            public char Symbol { get; set; }
            public int Wins { get; set; }
        }
        private void InitializePlayers()
        {
            players = new List<Player>
            {
                new Player { Symbol = 'X', Wins = 0 },
                new Player { Symbol = 'O', Wins = 0 }
            };
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }

            // Update the UI after initializing the board
            UpdateUI();
        }

        private void ResetGame()
        {
            InitializeBoard();
            currentPlayer = 'X';
            moveMade = false; // Reset the moveMade flag
            lastMove = null; // Reset the lastMove


        }

        private void UpdateUI()
        {
            // Update the UI based on the current state of the board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int buttonIndex = i * 3 + j;
                    Button button = (Button)this.Controls[buttonIndex];

                    // Set the button text to the symbol in the game board
                    button.Text = board[i, j].ToString();
                    if (board[i, j] == 'X')
                    {
                        button.ForeColor = Color.Red; // Change the color for X
                    }
                    else if (board[i, j] == 'O')
                    {
                        button.ForeColor = Color.RosyBrown; // Change the color for O
                    }
                    else
                    {
                        button.ForeColor = SystemColors.ControlText; // Default color for empty cell
                    }

                    button.Text = board[i, j].ToString();
                }

            }
        }
        private void Cell_Click(object sender, EventArgs e)
        {
            // Cell click logic disabled as the game is played through "Add Move" and "Delete Move" buttons
        }


        private void DeleteMoveButton_Click(object sender, EventArgs e)
        {
            if (!gameOver && lastMove != null)
            {
                // Get the last move
                int row = lastMove.Item1;
                int col = lastMove.Item2;

                // Delete the last move
                DeleteMove(row, col);
                currentPlayer = lastMove.Item3;

                UpdateUI(); // Update the UI after deleting the move

                lastMove = null; // Reset the lastMove after deletion
            }
            else
            {
                MessageBox.Show("No move to delete.");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Handle the "Update" button click event
            ResetGame();
        }

        private bool GetUserMoveInput(out int row, out int col)
        {
            //we'll use InputBoxes from Microsoft.VisualBasic to get row an column from user
            string rowInput = Microsoft.VisualBasic.Interaction.InputBox("Enter row (0-2):", "Row Input");
            string colInput = Microsoft.VisualBasic.Interaction.InputBox("Enter column (0-2):", "Column Input");

            if (int.TryParse(rowInput, out row) && int.TryParse(colInput, out col))
            {
                if (row >= 0 && row <= 2 && col >= 0 && col <= 2)
                {
                    return true;
                }
            }

            MessageBox.Show("Invalid input. Please enter numbers between 0 and 2 for row and column.");
            row = col = -1;
            return false;
        }

        private bool IsValidMove(int row, int col)
        {
            return board[row, col] == ' ';
        }

        private bool CheckForWinner()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        private bool CheckForDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false; // There is an empty cell, game is not a draw
                    }
                }
            }

            return true; // All cells are filled, it's a draw
        }

        private void HandleGameEnd()
        {
            gameOver = true;

            // Increment player wins count and display
            if (CheckForWinner())
            {
                if (currentPlayer == 'X')
                {
                    var winningPlayer = players.First(p => p.Symbol == currentPlayer);
                    winningPlayer.Wins++;
                    MessageBox.Show($"Player {currentPlayer} wins!");
                }

                else
                {
                    var winningPlayer = players.First(p => p.Symbol == currentPlayer);
                    winningPlayer.Wins++;
                    MessageBox.Show($"Player {currentPlayer} wins!");
                }



            }
            else if (CheckForDraw())
            {
                MessageBox.Show("It's a draw!");
            }
            // Sort players by wins (descending order)
            players = players.OrderByDescending(p => p.Wins).ToList();

            var playerStats = players.Select(p => $"Player {p.Symbol}: {p.Wins} wins").ToArray();
            MessageBox.Show(string.Join("\n", playerStats));


            // Ask the user if they want to play another round

            DialogResult result = MessageBox.Show("Do you want to play another round?", "Game Over", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ResetGame();
                gameOver = false; // Reset the game over flag
            }
            else
            {
                // Close the application 
                Application.Exit();
            }
        }

        //variable to track if the game is over
        private bool gameOver = false;


        private void MakeMoveButton_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                int row, col;
                if (GetUserMoveInput(out row, out col))
                {
                    if (IsValidMove(row, col))
                    {
                        MakeMove(row, col);
                        lastMove = new Tuple<int, int, char>(row, col, currentPlayer);


                        UpdateUI(); // Update the UI after making the move

                        if (CheckForWinner())
                        {

                            HandleGameEnd();
                        }
                        else if (CheckForDraw())
                        {

                            HandleGameEnd();
                        }
                        else
                        {
                            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                            moveMade = false; // Reset the moveMade flag for the next player
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid move. Cell already taken.");
                    }
                }
            }
            else
            {
                MessageBox.Show("The game is over. Please start a new round.");
            }
        }

        private void MoveMade()
        {
            UpdateUI(); // Update the UI after making the move

            if (CheckForWinner())
            {
                MessageBox.Show($"Player {currentPlayer} wins!");
                ResetGame();
            }
            else if (CheckForDraw())
            {
                MessageBox.Show("It's a draw!");
                ResetGame();
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                moveMade = false; // Reset the moveMade flag for the next player
            }
        }

        private void MakeMove(int row, int col)
        {
            board[row, col] = currentPlayer;
            moveMade = true; // Set the moveMade flag
        }

        private void DeleteMove(int row, int col)
        {
            board[row, col] = ' ';
        }









    }


}

