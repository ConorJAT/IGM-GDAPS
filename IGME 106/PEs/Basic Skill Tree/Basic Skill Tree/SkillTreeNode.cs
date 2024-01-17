// Conor Race
// March 23rd, 2022
// IGME.106.07

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Skill_Tree
{
    class SkillTreeNode
    {
        private string skill;
        private bool isLearned;
        private SkillTreeNode leftSkill;
        private SkillTreeNode rightSkill;


        public SkillTreeNode(string skillName, bool isLearned) 
        {
            skill = skillName;
            this.isLearned = isLearned;
            leftSkill = null;
            rightSkill = null;
        }
    

        public SkillTreeNode NextSkillLeft { get { return leftSkill; } set { leftSkill = value; } }


        public SkillTreeNode NextSkillRight { get { return rightSkill; } set { rightSkill = value; } }


        public void ListAllSkills()
        {
            if (leftSkill != null)
                leftSkill.ListAllSkills();

            Console.WriteLine("Skill: " + skill);

            if (rightSkill != null)
                rightSkill.ListAllSkills();
        }


        public void ListLearnedSkills()
        {
            if (isLearned)
            {
                Console.WriteLine("Learned: " + skill);

                if (leftSkill != null)
                    leftSkill.ListLearnedSkills();

                if (rightSkill != null)
                    rightSkill.ListLearnedSkills();
            }

            return;
        }


        public void ListLearnableSkills()
        {
            if (isLearned)
            {
                if (leftSkill != null)
                {
                    leftSkill.ListLearnableSkills();
                }

                if(rightSkill != null)
                {
                    rightSkill.ListLearnableSkills();
                }
            }

            else
            {
                Console.WriteLine("Can Learn: " + skill);
            }

            /*if (isLearned && leftSkill != null && leftSkill.isLearned)
                leftSkill.ListLearnableSkills();

            else if (isLearned && leftSkill != null && !leftSkill.isLearned)
                Console.WriteLine("Can Learn: " + leftSkill.skill);*/


            /*if (isLearned && rightSkill != null && rightSkill.isLearned)
                rightSkill.ListLearnableSkills();

            else if (isLearned && rightSkill != null && !rightSkill.isLearned)
                Console.WriteLine("Can Learn: " + rightSkill.skill);*/
        }
    }
}
