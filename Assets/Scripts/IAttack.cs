interface IAttack
{
    /// <summary>
    /// Момент нанесения урона.
    /// </summary>
    void OnAttack();
    /// <summary>
    /// Атака.
    /// </summary>
    /// <param name="input">Входные данные нажатия клавиши.</param>
    /// <returns>True, если атака совершена. False, если атака не совершена.</returns>
    //bool Attack(bool input);
}