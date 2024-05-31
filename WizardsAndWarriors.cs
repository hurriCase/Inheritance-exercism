using System;

abstract class Character
{
    protected bool vulnerable = false;
    private string _characterType;
    protected int damagePoints = 0;
    protected Character(string characterType) => this._characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => this.vulnerable;

    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior : Character
{    
    public Warrior() : base("Warrior"){}

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool _SpellPrepared = false;
    public Wizard() : base("Wizard") => base.vulnerable = true;

    public override int DamagePoints(Character target) => _SpellPrepared ? 12 : 3;

    public void PrepareSpell() => _SpellPrepared = true;

    public override bool Vulnerable() => !_SpellPrepared;
}
