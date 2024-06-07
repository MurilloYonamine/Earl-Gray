public class CombinationObject : InteractibleObject
{
    public override void Active()
    {
        base.Active();
        LevelManager.Instance.AddCombination(this);
    }

    public override void Desactive()
    {
        base.Desactive();
        LevelManager.Instance.RemoveCombination(this);
    }
}
