using UnityEngine;

public abstract class Plant : ScriptableObject
{
    [SerializeField] protected string plantName;
    [SerializeField] protected int sunCost;
    [SerializeField] protected int plantHealth;
    [SerializeField] protected float plantCooldown;
    [SerializeField] protected PlantType plantType;
    [SerializeField] protected PlantClass plantClass;
    [SerializeField] protected Sprite plantDisplaySprite;
}
public enum PlantType
{
    Support,
    Offensive,
    Defensive,
    OneTimeUse
}

public enum PlantClass
{
    Peashooter,
    Sunflower,
    Wallnut,
    CherryBomb,
    PotatoMine
}
