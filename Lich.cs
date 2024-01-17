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
    internal class Lich : Villain
    {
        public Lich() : base()
        {
            this.pictureBox.Image = Properties.Resources.Lich;
            this.Name = "Lich";
            this.lblName.Text = "Lich";
        }

        public Lich(string name, int hp, int attack, Label lblHP, Label lblName, ProgressBar progressBar, PictureBox pictureBox) : base(name, hp, attack, lblHP, lblName, progressBar, pictureBox)
        {
            this.pictureBox.Image = Properties.Resources.Lich;
        }

        // Method to determine how much damage will be applied to villain HP on hit
        public override string TakeDamage(IAttackableDamageable source)
        {
            string damage = base.TakeDamage(source);
            return damage;
        }

        // Method to determine how much damage villain will attempt to apply on attack
        public override int AttackDamage()
        {
            return random.Next(this.Attack, this.Attack * 2);
        }
    }
}
