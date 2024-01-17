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
    internal class Thief : Hero
    {
        public Thief() : base()
        {
            this.pictureBox.Image = Properties.Resources.BlackMage;
            this.Name = "Thief";
            this.lblName.Text = "Thief";
        }

        public Thief(string name, int hp, int attack, Label lblHP, Label lblName, ProgressBar progressBar, PictureBox pictureBox) : base(name, hp, attack, lblHP, lblName, progressBar, pictureBox)
        {
            this.pictureBox.Image = Properties.Resources.Thief;
        }

        // Method to determine how much damage will be applied to hero HP on hit
        public override string TakeDamage(IAttackableDamageable source)
        {
            string damage;
            // Thief has a chance to randomly avoid taking damage
            if (random.NextDouble() >= .5)
            {
                damage = $"{this.Name} avoided the attack from {source.Name}.";
            }
            else
            {
                damage = base.TakeDamage(source);
                this.PictureBoxChange();
            }

            return damage;
        }

        // Method to determine how much damage hero will attempt to apply on attack
        public override int AttackDamage()
        {
            return random.Next(this.Attack * 2, this.Attack * 4);
        }

        // method to change picture box based on status
        public override void PictureBoxChange()
        {
            if (this.HP == 0)
            {
                this.pictureBox.Image = Properties.Resources.Thief_Dead;
            }
            else if ((double)this.hp / (double)this.maxHP <= .25)
            {
                this.pictureBox.Image = Properties.Resources.Thief_Wounded;
            }
            else
            {
                this.pictureBox.Image = Properties.Resources.Thief;
            }
        }

        // Method for Thief to perform a backstab attack
        public override string Backstab(Villain target)
        {
            int damage = this.AttackDamage() * 2;
            target.HP -= damage;
            if (target.HP < 0)
            {
                target.HP = 0;
            }
            else if (target.HP > target.maxHP)
            {
                target.HP = target.maxHP;
            }
            target.lblHP.Text = target.HP.ToString();
            target.progressBar.Value = target.HP;
            return $"{this.Name} backstabbed {target.Name} for {damage} and joined the party.\r\n";
        }
    }
}
