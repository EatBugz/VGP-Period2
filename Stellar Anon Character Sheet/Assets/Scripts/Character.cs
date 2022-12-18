using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public enum ClassType { Assault, Scout, Support, Medic }
    public enum SpeciesType {
        Bythir, Corvaxx, Eldurgy, Graund, Human, Ilid, Numo, Stellos
    }

    // character inventory
    private List<Item> inventory;

    // character attributes
    private string name;
    private SpeciesType species;
    private ClassType profession;
    private int level = 1;
    private int experience;
    private int armorClass;
    private int movement;

    // character stats
    private int generalSkill;
    private int meleeSkill;
    private int firearmSkill;
    private int intelligenceSkill;
    private int dexteritySkill;
    private int generalDetermination;
    private int determinationOfWill;
    private int determinationOfBody;
    private int generalPower;
    private int powerOfStrength;
    private int powerOfCharisma;
    private int save;

    // constructor
    public Character(string n, SpeciesType sT, ClassType cT) {
        this.name = n;
        this.species = sT;
        this.profession = cT;
    }


    ///   Accessability Functions   \\\
    public string getName() { return this.name; }

    public string getProfessionString() {
        if (this.profession == ClassType.Assault) return "Assault";
        if (this.profession == ClassType.Scout) return "Scout";
        if (this.profession == ClassType.Support) return "Support";
        if (this.profession == ClassType.Medic) return "Medic";
        return null;
    }

    public string getSpeciesString() { 
        if (this.species == SpeciesType.Bythir) return "Bythir";
        if (this.species == SpeciesType.Corvaxx) return "Corvaxx";
        if (this.species == SpeciesType.Eldurgy) return "Eldurgy";
        if (this.species == SpeciesType.Graund) return "Graund";
        if (this.species == SpeciesType.Human) return "Human";
        if (this.species == SpeciesType.Ilid) return "Ilid";
        if (this.species == SpeciesType.Numo) return "Numo";
        if (this.species == SpeciesType.Stellos) return "Stellos";
        return null;
    }

    public int getLevel() { return this.level; }
}
