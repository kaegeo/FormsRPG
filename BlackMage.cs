using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230RPGWithClasses
{
    /*
     * Brett Fowler
     * Course CPT-230-W37
     * Coding Assignnent 11 - RPG (Final)
     * 2023 Summer
     */
    internal class BlackMage : Hero, IAttackableDamageable
    {
        public BlackMage() : base()
        {
            this.pictureBox.Image = Properties.Resources.BlackMage;
            this.Name = "Black Mage";
            this.lblName.Text = "Black Mage";
        }

        public BlackMage(string name, int hp, int attack, Label lblHP, Label lblName, ProgressBar progressBar, PictureBox pictureBox) : base(name, hp, attack, lblHP, lblName, progressBar, pictureBox)
        {
            this.pictureBox.Image = Properties.Resources.BlackMage;
        }

        // Method to determine how much damage will be applied to hero HP on hit
        public override string TakeDamage(IAttackableDamageable source)
        {
            string damage = base.TakeDamage(source);
            this.PictureBoxChange();
            return damage;
        }

        // Method to determine how much damage hero will attempt to apply on attack
        public override int AttackDamage()
        {
            return random.Next(this.Attack * 3, this.Attack * 5);
        }

        // method to change picture box based on status
        public override void PictureBoxChange()
        {
            if (this.HP == 0)
            {
                this.pictureBox.Image = Properties.Resources.BlackMage_Dead;
            }
            else if ((double)this.hp / (double)this.maxHP <= .25)
            {
                this.pictureBox.Image = Properties.Resources.BlackMage_Wounded;
            }
            else
            {
                this.pictureBox.Image = Properties.Resources.BlackMage;
            }
        }
    }
}
