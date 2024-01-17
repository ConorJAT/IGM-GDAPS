// Conor Race
// March 23rd, 2022
// IGME.106.07

using System;

namespace Basic_Skill_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            SkillTreeNode rootSkill = new SkillTreeNode("Dragon Style", true);

            rootSkill.NextSkillLeft = new SkillTreeNode("Claw Slash", true);
            rootSkill.NextSkillLeft.NextSkillLeft = new SkillTreeNode("Bone Break Strike", true);
            rootSkill.NextSkillLeft.NextSkillRight = new SkillTreeNode("Storm Strike Dash", false);

            rootSkill.NextSkillRight = new SkillTreeNode("Dragon Breath", true);
            rootSkill.NextSkillRight.NextSkillLeft = new SkillTreeNode("Fire Breathing", false);
            rootSkill.NextSkillRight.NextSkillRight = new SkillTreeNode("Dragon's Meditation", false);

            Console.WriteLine("List of All Skills:");
            rootSkill.ListAllSkills();

            Console.WriteLine("\n\nList of All Skills You've Learned:");
            rootSkill.ListLearnedSkills();

            Console.WriteLine("\n\nList of All Skills You Can Learn:");
            rootSkill.ListLearnableSkills();
        }
    }
}
