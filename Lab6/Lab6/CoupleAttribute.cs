using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]

    class CoupleAttribute : System.Attribute
    {
        public string Pair { get; set; }
        public double Probability { get; set; }
        public string ChildType { get; set; }

        public CoupleAttribute (string pair, double probability, string childType)
        {
            Pair = pair;
            Probability = probability;
            ChildType = childType;
        }

        public CoupleAttribute()
        {
        }

        private static bool hasAffection(double prob)
        {
            int random = UniqueRandom.Instance.Next(100);
            return random < prob * 100;
        }

        private static CoupleAttribute GetAttribute(Human first, Human second)
        {
            foreach (CoupleAttribute attr in first)
            {
                if (attr.Pair == second.GetType().Name)
                {
                    return attr;
                }
            }

            throw new System.Exception("Wrong types.");
        }

        public static Name Couple(Human first, Human second)
        {
            CoupleAttribute firstAttr = GetAttribute(first, second);
            CoupleAttribute secondAttr = GetAttribute(second, first);

            bool rightward = hasAffection(firstAttr.Probability);
            bool leftward = hasAffection(secondAttr.Probability);
            string name = "Default";

            if (rightward && leftward)
            {
                var method = first.GetType().GetMethods()[1];
                name = (string)method.Invoke(first, null);
            }
            else
            {
                throw new System.Exception("No mutual affection.");
            }

            Type type = Type.GetType("Lab6." + firstAttr.ChildType, true);
            object obj = Activator.CreateInstance(type, name);

            return (Name)obj;
        }
    }
}