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
    internal interface IAttackableDamageable : IAttackable, IDamageable
    {
        // Interface properties to interact with target and target's HP values
        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public Label LblHP { get; set; }
        public ProgressBar ProgressBar { get; set; }

        // Interface method to initiate possible change in picture box
        public void PictureBoxChange();

        // Interface method to initiate alive check
        public bool IsAlive();
    }
}
