using CPT230RPGWithClasses;

namespace CPT230RPG2
{
    /*
     * Brett Fowler
     * Course CPT-230-W37
     * Coding Assignnent 11 - RPG (Final)
     * 2023 Summer
     */
    public partial class Battle : Form
    {
        // Initiate hero and villain arrays
        private Hero[] heroes;
        private Villain[] villains;
        public int bonusAttack;
        // Initiate the queue for turn order
        Queue<int> theQueue;
        // Initiate random object for turn actions
        Random random = new Random();
        // Determine the current turn and remove hero or villain from the queue
        int currentTurn;

        // Variable for source dungeon
        public Dungeon dungeon;

        // Variable for battle mode type
        public string battleMode;

        public Battle()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            TurnProgression();
        }

        // method to determine turn progression and set up hero turn options
        private void TurnProgression()
        {
            if (theQueue.Count > 0)
            {

                // Determine the current turn and remove hero or villain from the queue
                currentTurn = theQueue.Dequeue();
                //Heroes' turn
                if (currentTurn < heroes.Length && currentTurn >= 0)
                {
                    if (heroes[currentTurn].IsAlive())
                    {
                        gbxTurnOption.Visible = true;
                        gbxTurnOption.Text = heroes[currentTurn].Name;
                        if (heroes[currentTurn].GetType().Name == "WhiteMage")
                        {
                            btnAttck.Text = "Attack";
                            btnCure.Visible = true;
                        }
                        else if (heroes[currentTurn].GetType().Name == "BlackMage")
                        {
                            btnAttck.Text = "Fira";
                            btnCure.Visible = false;
                        }
                        else
                        {
                            btnAttck.Text = "Attack";
                            btnCure.Visible = false;
                        }
                    }
                    else
                    {
                        TurnProgression();
                    }
                }

                //Villains' turn
                else
                {
                    VillainTurn();

                }
            }
            //Restart the queue
            SetupTurn();
        }

        // Method to end battle and return to dungeon
        private void EndBattle()
        {
            if (battleMode == "boss")
            {
                dungeon.bossDefeated = true;
            }
            dungeon.Show();
            this.Close();
        }

        // method for certain heroes to heal party member
        private void HeroTurnAid(Hero target, Hero source)
        {
            //get hero's attack damage
            string heal = target.ReceiveHealth(source);

            textBox1.Text = $"{heal}{textBox1.Text}";

            //see if we won
            if (!villains[0].IsAlive() && !villains[1].IsAlive())
            {
                //we won
                theQueue.Clear();
                btnRun.Enabled = false;
                MessageBox.Show("The heroes terminated the villains!", "We Won!!!");
            }
        }

        // method for hero to attack a chosen target villain
        private void HeroTurnAttack(Villain target, IAttackableDamageable source)
        {
            //hit the villain
            string damage = target.TakeDamage(source);

            //print what happened to the output
            textBox1.Text = $"{damage}{textBox1.Text}";

            //see if we won
            if (!villains[0].IsAlive() && !villains[1].IsAlive())
            {
                //we won
                theQueue.Clear();
                btnRun.Enabled = false;
                MessageBox.Show("The heroes terminated the villains!", "We Won!!!");
                EndBattle();
            }
            else if (!heroes[0].IsAlive() && !heroes[1].IsAlive())
            {
                //we lost
                theQueue.Clear();
                btnRun.Enabled = false;
                MessageBox.Show("The villains defeated the heroes!", "Heroes Have Perished");
            }
        }

        // method for villain to attack a random hero
        private void VillainTurn()
        {
            IAttackableDamageable source = villains[currentTurn - heroes.Length];
            if (source.IsAlive())
            {
                //pick a target
                int target = random.Next(0, heroes.Length);
                while (!heroes[target].IsAlive())
                {
                    target = random.Next(0, heroes.Length);
                }

                //hit the hero
                string damage = heroes[target].TakeDamage(source);

                //print what happened to the output
                textBox1.Text = $"{damage}{textBox1.Text}";

                //see if we lost
                if (!heroes[1].IsAlive() && bonusAttack != 0)
                {
                    // Thief will backstab a random target and join the party if the second hero dies
                    heroes[1] = new Thief("Thief", 60, 10, lblHeroHP1, lblHero1, pbrHero1, pbxHero1);
                    int backstabTarget = random.Next(0, villains.Length);
                    while (!villains[backstabTarget].IsAlive())
                    {
                        backstabTarget = random.Next(0, villains.Length);
                    }
                    string backstab = heroes[1].Backstab(villains[backstabTarget]);
                    textBox1.Text = $"{backstab}{textBox1.Text}";
                    bonusAttack = 0;
                    if (!villains[0].IsAlive() && !villains[1].IsAlive())
                    {
                        //we won
                        theQueue.Clear();
                        btnRun.Enabled = false;
                        MessageBox.Show("The heroes terminated the villains!", "We Won!!!");
                        EndBattle();
                    }
                }
                else if (!heroes[0].IsAlive() && !heroes[1].IsAlive())
                {
                    //we lost
                    theQueue.Clear();
                    btnRun.Enabled = false;
                    MessageBox.Show("The villains defeated the heroes!", "Heroes Have Perished");
                }
            }
            TurnProgression();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup the heroes
            heroes = new Hero[2];
            heroes[0] = new BlackMage("Black Mage", 60, 8, lblHeroHP0, lblHero0, pbrHero0, pbxHero0);
            heroes[1] = new WhiteMage("White Mage", 85, 5, lblHeroHP1, lblHero1, pbrHero1, pbxHero1);

            if (battleMode == "boss")
            {
                //Setup the boss villains
                villains = new Villain[2];
                villains[0] = new Garland("Garland", 160, 10, lblVillainHP0, lblVillain0, pbrVillain0, pbxVillain0);
                villains[1] = new Lich("Lich", 120, 8, lblVillainHP1, lblVillain1, pbrVillain1, pbxVillain1);
            }
            else
            {
                //Setup the random villains
                villains = new Villain[2];
                villains[0] = new Creep("Creep A", 50, 5, lblVillainHP0, lblVillain0, pbrVillain0, pbxVillain0);
                villains[1] = new Creep("Creep B", 50, 5, lblVillainHP1, lblVillain1, pbrVillain1, pbxVillain1);
            }

            //Setup and start the queue
            theQueue = new Queue<int>();
            SetupTurn();
        }

        // Method build the queue and set up turn order
        private void SetupTurn()
        {
            for (int i = 0; i < heroes.Length; i++)
            {
                if (heroes[i].IsAlive())
                {
                    theQueue.Enqueue(i);
                }
            }
            for (int i = 0; i < villains.Length; i++)
            {
                if (villains[i].IsAlive())
                {
                    theQueue.Enqueue(i + heroes.Length);
                }
            }
        }

        private void btnAttck_Click(object sender, EventArgs e)
        {
            btnTarget1.Visible = true;
            btnTarget1.Text = villains[0].Name;
            btnTarget2.Visible = true;
            btnTarget2.Text = villains[1].Name;

            if (!villains[0].IsAlive())
            {
                btnTarget1.Enabled = false;
            }
            if (!villains[1].IsAlive())
            {
                btnTarget2.Enabled = false;
            }
        }

        private void btnTarget1_Click(object sender, EventArgs e)
        {
            if (btnTarget1.Text == heroes[0].Name)
            {
                HeroTurnAid(heroes[0], heroes[currentTurn]);
            }
            else
            {
                HeroTurnAttack(villains[0], heroes[currentTurn]);
            }
            btnTarget1.Visible = false;
            btnTarget2.Visible = false;
            gbxTurnOption.Visible = false;
            btnTarget1.Enabled = true;
            btnTarget2.Enabled = true;
            TurnProgression();
        }

        private void btnTarget2_Click(object sender, EventArgs e)
        {
            if (btnTarget2.Text == heroes[1].Name)
            {
                HeroTurnAid(heroes[1], heroes[currentTurn]);
            }
            else
            {
                HeroTurnAttack(villains[1], heroes[currentTurn]);
            }
            btnTarget1.Visible = false;
            btnTarget2.Visible = false;
            gbxTurnOption.Visible = false;
            btnTarget1.Enabled = true;
            btnTarget2.Enabled = true;
            TurnProgression();
        }

        private void btnCure_Click(object sender, EventArgs e)
        {
            btnTarget1.Visible = true;
            btnTarget1.Text = heroes[0].Name;
            btnTarget2.Visible = true;
            btnTarget2.Text = heroes[1].Name;
        }
    }
}