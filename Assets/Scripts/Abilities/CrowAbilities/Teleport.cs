using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Teleport : Ability
{
    public override void Action()
    {
        var enemy = character.GetCloseEnemy();
        var directonToEnemy = character.GetDirectionToCloseEnemy();
        transform.position = enemy.transform.position + directonToEnemy;
        character.FlipToEnemy();
        character.OnAttack();
    }
}
