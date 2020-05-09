using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum RESISTANCE { FIRE, ICE, WIND}
public enum ATTACK { SLASH, SHOOT, FIREBALL}
public enum ITEM { NONE, SWORD, STAFF, BOW, LONGSWORD, STICK}

public class Monster
{
    string m_name;

    int health;

    int speed;

    List<RESISTANCE> resistances = new List<RESISTANCE>();
    List<ATTACK> attacks = new List<ATTACK>();

    List<ITEM> items = new List<ITEM>();

    public Monster(string n, int h, int s, List<RESISTANCE> r, List<ATTACK> a, List<ITEM> i)
    {
        m_name = n;
        health = h;
        speed = s;
        resistances = r;
        attacks = a;
        items = i;
    }

    public Monster(JObject monster, JObject Prototype = null)
    {
        m_name = (string)monster.GetValue("Name");
        
        if(Prototype != null)
        {
            JToken token;
            if(Prototype.TryGetValue("Health", out token))
            {
                health = (int)token;
            }

            if (Prototype.TryGetValue("Speed", out token))
            {
                speed = (int)token;
            }

            if (Prototype.TryGetValue("Resistances", out token))
            {
                foreach(JToken v in (JArray)token)
                {
                    resistances.Add((RESISTANCE)Enum.Parse(typeof(RESISTANCE), (string)v));
                }
            }

            if (Prototype.TryGetValue("Attacks", out token))
            {
                foreach (JToken v in (JArray)token)
                {
                    attacks.Add((ATTACK)Enum.Parse(typeof(ATTACK), (string)v));
                }
            }

            if (Prototype.TryGetValue("Items", out token))
            {
                foreach (JToken v in (JArray)token)
                {
                    items.Add((ITEM)Enum.Parse(typeof(ITEM), (string)v));
                }
            }
        }

        // Overwritting with final monster values

        JToken t;
        if (monster.TryGetValue("Health", out t))
        {
            health = (int)t;
        }

        if (monster.TryGetValue("Speed", out t))
        {
            speed = (int)t;
        }

        if (monster.TryGetValue("Resistances", out t))
        {
            foreach (JToken v in (JArray)t)
            {
                resistances.Add((RESISTANCE)Enum.Parse(typeof(RESISTANCE), (string)v));
            }
        }

        if (monster.TryGetValue("Attacks", out t))
        {
            foreach (JToken v in (JArray)t)
            {
                attacks.Add((ATTACK)Enum.Parse(typeof(ATTACK), (string)v));
            }
        }

        if (monster.TryGetValue("Items", out t))
        {
            foreach (JToken v in (JArray)t)
            {
                items.Add((ITEM)Enum.Parse(typeof(ITEM), (string)v));
            }
        }

        if (monster.TryGetValue("BonusHealth", out t))
        {
            health += (int)t;
        }
    }

    public string Info()
    {
        string stuff = "Name: " + m_name + "\n" + "Health: " + health + "\n" + "Speed: " + speed;

        return stuff;
    }
}
