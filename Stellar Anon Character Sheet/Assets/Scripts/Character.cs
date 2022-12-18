using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public enum ClassType { Null, Assault, Scout, Support, Medic }
    public enum SpeciesType { Null, Bythir, Corvaxx, Eldurgy, Graund, Human, Ilid, Numo, Stellos }
    public enum ArmorType { Null, Light, Medium, Heavy }
    public enum WeaponType { Null, Traditional, Mechanical, Experimental }

    // character inventory
    private List<Item> inventory;

    // character attributes
    private string name;
    private SpeciesType species;
    private ClassType profession;
    private int level = 1;
    private int maxHitPoints;
    private int hitDieType;
    private int experience;
    private int armorClass;
    private int movement;
    private string startingFeature;
    private int currency = 200;

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

    // character proficiencies
    private List<ArmorType> armorProf = new List<ArmorType>();
    private List<WeaponType> weaponProf = new List<WeaponType>();

    // constructor
    public Character(string n, SpeciesType sT, ClassType cT) {
        this.name = n;
        this.species = sT;
        this.profession = cT;

        updateStatsOnSpecies();
    }

    // method that sets stats based on species type of character
    public void updateStatsOnSpecies() {
        if (this.species == SpeciesType.Bythir) {
            this.hitDieType = 8;
            this.movement = 30;
            this.maxHitPoints = 11;
            this.generalSkill = 2;
            this.meleeSkill = 1;
            this.firearmSkill = 1;
            this.intelligenceSkill = 3;
            this.dexteritySkill = 1;
            this.generalDetermination = 2;
            this.determinationOfWill = 3;
            this.determinationOfBody = 2;
            this.generalPower = 1;
            this.powerOfStrength = 1;
            this.powerOfCharisma = 0;
            this.save = 2;
            this.startingFeature = "Natural Weapons. You innately possess the weapon: Claws --- MS(2), Kinetic, 1d6 S";
        }
        else if (this.species == SpeciesType.Eldurgy) {
            this.hitDieType = 6;
            this.movement = 30;
            this.maxHitPoints = 8;
            this.generalSkill = 2;
            this.meleeSkill = 0;
            this.firearmSkill = 1;
            this.intelligenceSkill = 3;
            this.dexteritySkill = 2;
            this.generalDetermination = 2;
            this.determinationOfWill = 3;
            this.determinationOfBody = 1;
            this.generalPower = 1;
            this.powerOfStrength = 0;
            this.powerOfCharisma = 2;
            this.save = 2;
            this.startingFeature = "Strong Willed. Once per day, if you fail a DW stat check or saving throw, you can choose to succeed instead.";
        }
        else if (this.species == SpeciesType.Human) {
            this.hitDieType = 8;
            this.movement = 30;
            this.maxHitPoints = 10;
            this.generalSkill = 2;
            this.meleeSkill = 2;
            this.firearmSkill = 2;
            this.intelligenceSkill = 2;
            this.dexteritySkill = 2;
            this.generalDetermination = 2;
            this.determinationOfWill = 2;
            this.determinationOfBody = 2;
            this.generalPower = 2;
            this.powerOfStrength = 2;
            this.powerOfCharisma = 2;
            this.save = 2;
            this.startingFeature = "Jack of All Trades. Once per day, you can give yourself advantage on one stat check.";  
        }
        else {
            this.hitDieType = 0;
            this.movement = 0;
            this.maxHitPoints = 0;
            this.generalSkill = 0;
            this.meleeSkill = 0;
            this.firearmSkill = 0;
            this.intelligenceSkill = 0;
            this.dexteritySkill = 0;
            this.generalDetermination = 0;
            this.determinationOfWill = 0;
            this.determinationOfBody = 0;
            this.generalPower = 0;
            this.powerOfStrength = 0;
            this.powerOfCharisma = 0;
            this.save = 0;
            this.startingFeature = "";  
        }
    }

    // method that gives bonuses based on class choice
    public void classBonus(int[] bonus) {
        // stat bonuses
        this.movement += bonus[0];
        this.maxHitPoints += bonus[1];
        this.generalSkill += bonus[2];
        this.meleeSkill += bonus[3];
        this.firearmSkill += bonus[4];
        this.intelligenceSkill += bonus[5];
        this.dexteritySkill += bonus[6];
        this.generalDetermination += bonus[7];
        this.determinationOfWill += bonus[8];
        this.determinationOfBody += bonus[9];
        this.generalPower += bonus[10];
        this.powerOfStrength += bonus[11];
        this.powerOfCharisma += bonus[12];
        this.save += bonus[13];

        // proficiency bonuses
        for (int i = 0; i < armorProf.Count; i++) armorProf.RemoveAt(0);
        for (int i = 0; i < weaponProf.Count; i++) weaponProf.RemoveAt(0);
        if (this.profession == ClassType.Assault) {
            this.armorProf.Add(ArmorType.Light);
            this.armorProf.Add(ArmorType.Medium);
            this.armorProf.Add(ArmorType.Heavy);
            this.weaponProf.Add(WeaponType.Traditional);
            this.weaponProf.Add(WeaponType.Mechanical);
        }
        else if (this.profession == ClassType.Scout) {
            this.armorProf.Add(ArmorType.Light);
            this.armorProf.Add(ArmorType.Medium);
            this.weaponProf.Add(WeaponType.Traditional);
            this.weaponProf.Add(WeaponType.Mechanical);
        }
        else if (this.profession == ClassType.Support) {
            this.armorProf.Add(ArmorType.Medium);
            this.armorProf.Add(ArmorType.Heavy);
            this.weaponProf.Add(WeaponType.Mechanical);
            this.weaponProf.Add(WeaponType.Experimental);
        }
        else if (this.profession == ClassType.Support) {
            this.armorProf.Add(ArmorType.Light);
            this.armorProf.Add(ArmorType.Medium);
            this.weaponProf.Add(WeaponType.Mechanical);
            this.weaponProf.Add(WeaponType.Experimental);
        }
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
    public int getExperience() { return this.experience; }
    public int getMovement() { return this.movement; }
    public int getArmorClass() { return this.armorClass; }
    public string getStartingFeature() { return this.startingFeature; }
    public int getHitDieType() { return this.hitDieType; }
    public int getMaxHitPoints() { return this.maxHitPoints; }

    // get the stats
    public int getGeneralSkill() { return this.generalSkill; }
    public int getMeleeSkill() { return this.meleeSkill; }
    public int getFirearmSkill() { return this.firearmSkill; }
    public int getIntelligenceSkill() { return this.intelligenceSkill; }
    public int getDexteritySkill() { return this.dexteritySkill; }
    public int getGeneralDetermination() { return this.generalDetermination; }
    public int getDeterminationOfWill() { return this.determinationOfWill; }
    public int getDeterminationOfBody() { return this.determinationOfBody; }
    public int getGeneralPower() { return this.generalPower; }
    public int getPowerOfStrength() { return this.powerOfStrength; }
    public int getPowerOfCharisma() { return this.powerOfCharisma; }
    public int getSave() { return this.save; }
}
