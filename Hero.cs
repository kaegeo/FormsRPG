using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CPT230RPGWithClasses
{
    /*
     * Brett Fowler
     * Course CPT-230-W37
     * Coding Assignnent 11 - RPG (Final)
     * 2023 Summer
     */
    internal class Hero : IAttackableDamageable
    {
        //Hero Data
        protected string name;
        public int maxHP;
        protected int hp;
        protected int attack;

        public Label lblHP;
        public Label lblName;
        public ProgressBar progressBar;
        public PictureBox pictureBox;

        protected Random random;

        //Hero Constructors
        public Hero()
        {
            this.name = "Hero";
            this.hp = 100;
            this.maxHP = HP;
            this.attack = 10;
            this.lblHP = new Label();
            this.lblName = new Label();
            this.progressBar = new ProgressBar();
            this.pictureBox = new PictureBox();
            this.random = new Random();
        }

        public Hero(string name, int hp, int attack, Label lblHP, Label lblName, ProgressBar progressBar, PictureBox pictureBox)
        {
            this.name = name;
            this.hp = hp;
            this.maxHP = hp;
            this.attack = attack;

            this.lblHP = lblHP;
            this.lblHP.Text = this.hp.ToString();

            this.lblName = lblName;
            this.lblName.Text = this.name;

            this.progressBar = progressBar;
            this.progressBar.Maximum = this.maxHP;
            this.progressBar.Value = this.hp;

            this.pictureBox = pictureBox;

            this.random = new Random();
        }

        //Hero properties
        // Hero name property
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

        // Hero HP property
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

        // Hero attack property
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

        // Hero maxHP property
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

        // Hero lblHP property
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

        // Hero progressBar property
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

        //Hero Methods
        // Method to get hero name value
        public string GetName()
        {
            return this.Name;
        }

        // Method to check if hero is alive (HP value greater than 0)
        public bool IsAlive()
        {
            return this.HP > 0;
        }

        // Method to determine how much damage will be applied to hero HP on hit
        public virtual string TakeDamage(IAttackableDamageable source)
        {
            int damage = source.AttackDamage();
            this.HP -= damage;
            if(this.HP < 0)
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

        // Method to determine HP received from healing sources and update Hero data
        public virtual string ReceiveHealth(Hero source)
        {
            int heal = source.Cure();
            this.HP += heal;
            if (this.HP < 0)
            {
                this.HP = 0;
            }
            else if (this.HP > maxHP)
            {
                this.HP = maxHP;
            }
            this.lblHP.Text = this.HP.ToString();
            this.progressBar.Value = this.HP;
            this.PictureBoxChange();
            return $"{source.Name} healed {this.Name} for {heal}!\r\n";
        }

        // Method to determine how much damage hero will attempt to apply on attack
        public virtual int AttackDamage()
        {
            return random.Next(this.Attack, this.Attack * 2);
        }

        // Method to determine how much to heal ally for
        public virtual int Cure()
        {
            return random.Next(this.Attack * 2, this.Attack * 4);
        }

        // Placeholder method to change picturebox of hero based on status
        public virtual void PictureBoxChange()
        {

        }

        public virtual string Backstab(Villain target)
        {
            return "hit";
        }

    }
}
