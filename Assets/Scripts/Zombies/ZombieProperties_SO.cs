using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie", menuName = "Zombies/New Zombie")]
public class ZombieProperties_SO : ScriptableObject
{
    public string zombieName;
    public int health;
    public int damage;
    public float attackSpeed;
    public float speed;
}
