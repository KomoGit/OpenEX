using System;

public interface IAbility 
{
    public void AbilityActivate();
    private void DrainPerSecond(object sender, EventArgs e) { }
}
