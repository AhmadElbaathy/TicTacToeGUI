using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            // Auto-generated code by the form designer
            this.SuspendLayout();

            // Buttons for the game grid
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Size = new System.Drawing.Size(80, 80);
                    button.Location = new System.Drawing.Point(j * 80, i * 80);
                    button.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button.Tag = i * 3 + j;
                    button.Click += new EventHandler(Cell_Click);
                    button.Enabled = false; // Disable interaction with cells
                    button.BackColor = System.Drawing.Color.Transparent;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                    this.Controls.Add(button);
                }
            }

            // Button for making a move
            Button makeMoveButton = new Button();
            makeMoveButton.Size = new System.Drawing.Size(80, 40);
            makeMoveButton.Location = new System.Drawing.Point(0, 240);
            makeMoveButton.Text = "Add Move";
            makeMoveButton.Click += new EventHandler(MakeMoveButton_Click);
            makeMoveButton.BackColor = System.Drawing.Color.Transparent;
            makeMoveButton.BackColor = System.Drawing.Color.Transparent;
            makeMoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            makeMoveButton.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // Button for deleting a move
            Button deleteMoveButton = new Button();
            deleteMoveButton.Size = new System.Drawing.Size(80, 40);
            deleteMoveButton.Location = new System.Drawing.Point(90, 240);
            deleteMoveButton.Text = "Delete Move";
            deleteMoveButton.Click += new EventHandler(DeleteMoveButton_Click);
            deleteMoveButton.BackColor = System.Drawing.Color.Transparent;
            deleteMoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            deleteMoveButton.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // Button for updating the game
            Button updateButton = new Button();
            updateButton.Size = new System.Drawing.Size(80, 40);
            updateButton.Location = new System.Drawing.Point(180, 240);
            updateButton.Text = "Update";
            updateButton.Click += new EventHandler(UpdateButton_Click);
            updateButton.BackColor = System.Drawing.Color.Transparent;
            updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            updateButton.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(makeMoveButton);
            this.Controls.Add(deleteMoveButton);
            this.Controls.Add(updateButton);

            this.ClientSize = new System.Drawing.Size(260, 280);
            this.Name = "MainForm";
            this.Text = "Tic Tac Toe";
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.tic_tac_toe;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ResumeLayout(false);
        }

        #endregion
    }
}

