using System;

public interface IAbility 
{
    public void AbilityActivate();
    /// <summary>
    /// Drains Energy Per Second.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DrainEnergy(object sender, EventArgs e) { }
}
