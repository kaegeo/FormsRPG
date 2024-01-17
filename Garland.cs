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
    internal class Garland : Villain
    {
        public Garland() : base()
        {
            this.pictureBox.Image = Properties.Resources.Garland;
            this.Name = "Garland";
            this.lblName.Text = "Garland";
        }

        public Garland(string name, int hp, int attack, Label lblHP, Label lblName, ProgressBar progressBar, PictureBox pictureBox) : base(name, hp, attack, lblHP, lblName, progressBar, pictureBox)
        {
            this.pictureBox.Image = Properties.Resources.Garland;
        }

        // Method to determine how much damage will be applied to villain HP on hit
        public override string TakeDamage(IAttackableDamageable source)
        {
            string damage = base.TakeDamage(source);
            // Garland has a chance to randomly perform a counter attack if attacked
            if (random.NextDouble() >= .5)
            {
                damage = $"{CounterAttack(source)}\r\n{damage}";
            }
            return damage;
        }

        // Method to determine how much damage villain will attempt to apply on attack
        public override int AttackDamage()
        {
            return random.Next(this.Attack, this.Attack * 3);
        }

        // Method for Garland to perform a counter attack
        public string CounterAttack(IAttackableDamageable source)
        {
            int damage = this.AttackDamage();
            source.HP -= damage;
            if (source.HP < 0)
            {
                source.HP = 0;
            }
            else if (source.HP > source.MaxHP)
            {
                source.HP = source.MaxHP;
            }
            source.LblHP.Text = source.HP.ToString();
            source.ProgressBar.Value = source.HP;
            source.PictureBoxChange();
            return $"{this.Name} countered {source.Name} for {damage}.";
        }
    }
}
