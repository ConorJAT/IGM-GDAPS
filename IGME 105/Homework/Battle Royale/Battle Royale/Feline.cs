//Conor Race
//Oct. 26th, 2021
//Purpose: Sub-class for CommonCharacter class. Allows for the 
//creation and usage of Feline character objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Royale
{
    class Feline : CommonCharacter
    {
        private bool bonusLife;
        private bool clawFury;
        private bool dodges;
        private bool riposte;
        private int reviveHealth;
        Random rng = new Random();

        /// <summary>
        /// Constructor for Feline class. Extends off of base class constructor, while
        /// also setting defaults for two additional fields, unique to this class.
        /// </summary>
        /// <param name="name"> The name of the Feline. </param>
        /// <param name="pwr"> The Feline's power. </param>
        /// <param name="hp"> The Feline's health points. </param>
        public Feline (string name, int pwr, int hp)
            : base (name, pwr, hp)
        {
            bonusLife = true;
            reviveHealth = hp;
            dodges = false;
            riposte = false;
        }

        /// <summary>
        /// Property; Allows for the retrieval of whether the Feline has a extra life or not.
        /// </summary>
        public bool ExtraLife { get { return bonusLife; } }

        /// <summary>
        /// Property; Allows for the retrieval and edit of whether a Feline is able to dodge
        /// an attack per turn.
        /// </summary>
        public bool Dodges { get { return dodges; } set { dodges = value; } }

        /// <summary>
        /// Property; Allows for the retrieval of whether a Feline performs a Riposte attack
        /// on its next attack.
        /// </summary>
        public bool Riposte { get { return riposte; } }

        /// <summary>
        /// Generates and returns a random attack value based on the Felines's power AND
        /// several other variables. Particulary, the Feline's attack method is dependent on
        /// boolean variables: "bonusLife," "riposte," and "clawFury." Damage generally goes
        /// up as more conditions are met.
        /// </summary>
        /// <returns> A random int which serves as a damage value. </returns>
        public override int Attack()
        {
            // All Out Feline Fury: +10 base, x10 total damage modifiers -> damage = (randomValue(1, Feline's Power) + 10) * 10
            if (clawFury && !bonusLife && riposte)
            {
                clawFury = false;
                riposte = false;
                return (base.Attack() + 10) * 10;
            }
            // Special Riposte Attack: x10 damage modifier -> damage = randomValue(1, Feline's Power) * 10
            else if (clawFury && riposte)
            {
                clawFury = false;
                riposte = false;
                return base.Attack() * 10;
            }
            // Desperate Special Attack: +10 base, x5 total damage modifiers -> damage = (randomValue(1, Feline's Power) + 10) * 5
            else if (clawFury && !bonusLife)
            {
                clawFury = false;
                return (base.Attack() + 10) * 5;
            }
            // Desperate Riposte Attack: +5 base, x2 total damage modifiers -> damage = (randomValue(1, Feline's Power) + 5) * 2
            else if (riposte && !bonusLife)
            {
                riposte = false;
                return (base.Attack() + 5) * 2;
            }
            // Special Attack ONLY: x5 damage modifier -> damage = randomValue(1, Feline's Power) * 5
            else if (clawFury)
            {
                clawFury = false;
                return base.Attack() * 5;
            }
            // Riposte Attack ONLY: x2 damage modifier -> damage = randomValue(1, Feline's Power) * 2
            else if (riposte)
            {
                riposte = false;
                return base.Attack() * 2;
            }
            // Desperate Attack ONLY: +5 damage modifier -> damage = randomValue(1, Feline's Power) + 5
            else if (!bonusLife)
            {
                return base.Attack() + 5;
            }
            // Standard Attack: No modifiers -> damage = randomValue(1, Feline's Power)
            else
            {
                return base.Attack();
            }
        }

        /// <summary>
        /// Takes an int value as a parameter and subtracts it from the character's
        /// total health. In the Feline class, the "dodges" boolean is used as a possibility
        /// that the feline could dodge the attack entirely and take no damage when true.
        /// If false, the Feline takes the damage instead.
        /// </summary>
        /// <param name="damage"> How much damage the Feline is possibly taking. </param>
        public override void TakeDamage(int damage)
        {
            // Does not call the base method if "dodges" is true.
            if (dodges)
            {
                return;
            }
            // If the Feline fails to dodge, they take the damage instead.
            base.TakeDamage(damage);
        }

        /// <summary>
        /// Tests whether a character is ready to flee battle via a particular condition. For
        /// Felines, they have a special condition where they will flee only when they are on
        /// their last lives AND their health is equal to or below 25.
        /// </summary>
        /// <returns> Returns true if condition is met. False otherwise. </returns>
        public override bool ReadyToFlee()
        {
            // Flee Condition: Feline on last life AND health is less than or equal to 25 HP.
            if (!bonusLife && health <= 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tests whether a character is dead (no health left). For Felines, when their health
        /// becomes 0 for the first time in battle, false is returned and "bonusLife" is set to
        /// false (signify extra life). On the second time around, the Feline will be considered
        /// dead.
        /// </summary>
        /// <returns> True if health = 0 AND its extra life has been used. False otherwise. </returns>
        public override bool IsDead()
        {
            // First Death: The Feline escapes death and lives again to fight.
            // Health is restored to max and "bonusLife" is set to false. A little
            // message is printed to signify the usage of an extra life.
            if (bonusLife && health == 0)
            {
                bonusLife = false;
                health = reviveHealth;
                Console.WriteLine($"    {name} was lucky to survive death! (This time...)");
                return false;
            }
            // Feline will die once its health reaches 0 AND its extra life has been
            // exhausted.
            else if (!bonusLife && health == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Setter method for "dodges" field. Felines have a 20% to dodge an incoming attack. If the
        /// chance is met, "dodges" is set to true. "riposte" is also set to true, as a dodge guarantees
        /// a riposte strike.
        /// </summary>
        public void Dodge()
        {
            // Felines have a 20% chance of dodging an attack. Switch to true if condition met.
            if (rng.Next(1,101) <= 20)
            {
                dodges = true;
                riposte = true;
            }
            // Remains false if condition is not met.
            else
            {
                dodges = false;
            }
        }

        /// <summary>
        /// Feline's special attack switch. During each round, every Feline has a chance to unleash
        /// a special attack. There are no prerequisites to trigger to this special attack (unlike 
        /// the Wolven class, involving its packSize to be greater than 0).
        /// </summary>
        public void ScratchEmUp()
        {
            // Felines have a 20% chance of activating their special attacks.
            if (rng.Next(1, 101) <= 20)
            {
                Console.ForegroundColor = ConsoleColor.White;
                // Message indicates when special attack is activated.
                Console.WriteLine($"{name} unleashes a storm of claws and slashes!");
                Console.ForegroundColor = ConsoleColor.Gray;
                clawFury = true;
            }
            else
            {
                clawFury = false;
            }
        }

        /// <summary>
        /// Returns a complex string highlighting all of the Feline's unique abilities, in
        /// addition to its base stats from the base ToString method.
        /// </summary>
        /// <returns> Returns a constructed string of Feline's complete stats. </returns>
        public override string ToString()
        {
            return base.ToString() + "Race: Feline\nList of Abilities:\n" +
                                     "   Lucky Cat : \t\tFeline folk are always seemingly lucky. When Felines die their first time,\n" +
                                     "               \t\tthey do not die. Instead, they re-enter battle with full health. Ability\n" +
                                     "               \t\tonly usable once!\n\n" +
                                     "   Now or Never : \tOn their second (last) lives, Felines deal +5 additional damage (+10 on\n" +
                                     "                  \tSpecial Attacks).\n\n" +
                                     "   Dodge : \t\tFeline folk are often very nimble and thus have a 20% chance to dodge attacks.\n\n" +
                                     "   Riposte : \t\tIf a Feline successfully dodges an attack, they spring into action, dealing\n" +
                                     "             \t\t2x more damage on their next attack.\n\n" +
                                     "   \"Scratch Em\' Up!\" : \tUnleashes a storm of slashes onto the foe, dealing 5x damage on\n" +
                                     "                       \tthe next attack (10x on Riposte hits).";
        }
    }
}
