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
    internal interface IDamageable
    {
        // Interface method to apply damage to attacked target
        public abstract string TakeDamage(IAttackableDamageable source);
    }
}
