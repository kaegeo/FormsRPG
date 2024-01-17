using CPT230RPG2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT230RPGWithClasses
{
    /*
     * Brett Fowler
     * Course CPT-230-W37
     * Coding Assignnent 11 - RPG (Final)
     * 2023 Summer
     */
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        // Start new game on New Game button click
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Dungeon dungeon = new Dungeon();
            dungeon.Show();
            this.Hide();
        }

        // Continue from auto save bin file on Continue Game button click
        private void btnContinueGame_Click(object sender, EventArgs e)
        {
            Dungeon dungeon = new Dungeon();
            dungeon.loadSave = "Auto";
            dungeon.Show();
            this.Hide();
        }

        // Continue from PlaySave bin file on Load Game button click
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            Dungeon dungeon = new Dungeon();
            dungeon.loadSave = "PlaySave";
            dungeon.Show();
            this.Hide();
        }
    }
}
