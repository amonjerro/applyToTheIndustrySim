using System;
using UnityEngine;
public enum SkillType
{
    Programming,
    Design,
    Graphics,
    Leadership,
    Sound,
    Production,
    ForeignLang
}

[Serializable]
public struct Skill
{
    public string name;
    public int value;
    public SkillType skillType;

    public Skill(string nm, int val, SkillType type)
    {
        name = nm;
        value = val;
        skillType = type;
    }

    public static Skill operator +(Skill a, Skill b)
    {
        if (a.name != b.name)
        {
            Debug.Log(a.name);
            Debug.Log(b.name);
            throw new ArgumentException("The two skills being added are not of the same type");
        }
        return new Skill(a.name, a.value + b.value, a.skillType);
    }

    public static Skill operator *(Skill a, int b)
    {
        return new Skill(a.name, a.value * b, a.skillType);
    }

    public override string ToString()
    {

        return "Name: " + name + ", Value: " + value.ToString();
    }
}