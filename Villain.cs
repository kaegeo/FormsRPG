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
    internal class Villain : IAttackableDamageable
    {
        //Villain Data
        protected string name;
        public int maxHP;
        protected int hp;
        protected int attack;

        public Label lblHP;
        public Label lblName;
        public ProgressBar progressBar;
        public PictureBox pictureBox;

        protected Random random;

        //Villain Constructors
        public Villain()
        {
            this.name = "Villain";
            this.hp = 100;
            this.maxHP = HP;
            this.Attack = 10;
            this.lblHP = new Label();
            this.lblName = new Label();
            this.progressBar = new ProgressBar();
            this.pictureBox = new PictureBox();
            this.random = new Random();
        }

        public Villain(string name, int hp, int attack, Label lblHP, Label lblName, ProgressBar progressBar, PictureBox pictureBox)
        {
            this.name = name;
            this.hp = hp;
            this.maxHP = HP;
            this.attack = attack;

            this.lblHP = lblHP;
            this.lblHP.Text = this.hp.ToString();

            this.lblName = lblName;
            this.lblName.Text = this.Name;

            this.progressBar = progressBar;
            this.progressBar.Maximum = this.maxHP;
            this.progressBar.Value = this.hp;

            this.pictureBox = pictureBox;

            this.random = new Random();
        }

        //Villain properties
        // Villain name property
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        // Villain HP property
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }

        // Villain maxHP property
        public int MaxHP
        {
            get
            {
                return maxHP;
            }
            set
            {
                maxHP = value;
            }
        }

        // Villain attack property
        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
            }
        }

        // Villain lblHP property
        public Label LblHP
        {
            get
            {
                return lblHP;
            }
            set
            {
                lblHP.Text = this.hp.ToString();
            }
        }

        // Villain progressBar property
        public ProgressBar ProgressBar
        {
            get
            {
                return progressBar;
            }
            set
            {
                progressBar.Value = this.HP;
            }
        }

        //Villain Methods
        // Method to get name value
        public string GetName()
        {
            return this.Name;
        }

        // Method to check if villain is alive (HP value more than 0)
        public bool IsAlive()
        {
            return this.HP > 0;
        }

        // Method to determine how much damage villain will take on hit
        public virtual string TakeDamage(IAttackableDamageable source)
        {
            int damage = source.AttackDamage();
            this.HP -= damage;
            if (this.HP < 0)
            {
                this.HP = 0;
            }
            else if (this.HP > this.maxHP)
            {
                this.HP = this.maxHP;
            }
            this.lblHP.Text = this.HP.ToString();
            this.progressBar.Value = this.HP;
            return $"{source.Name} hit {this.Name} for {damage}!\r\n";
        }

        // Method to determine how much damage villain will attempt to hit with
        public virtual int AttackDamage()
        {
            return random.Next(this.Attack, this.Attack * 2);
        }

        // Placeholder method to change picturebox of hero based on status
        public virtual void PictureBoxChange()
        {

        }
    }
}
