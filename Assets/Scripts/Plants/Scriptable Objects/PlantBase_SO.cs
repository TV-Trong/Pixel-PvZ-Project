using UnityEngine;

public abstract class PlantBase_SO : ScriptableObject
{
    [SerializeField] protected string plantName;
    [SerializeField] protected int sunCost;
    [SerializeField] protected int plantHealth;
    [SerializeField] protected float plantCooldown;
    [SerializeField] protected PlantType plantType;
    [SerializeField] protected PlantClass plantClass;
    [SerializeField] protected Sprite plantDisplaySprite;


    public PlantType PlantType { get { return plantType; } protected set { plantType = value; } }
    public float PlantCooldown { get { return plantCooldown; } protected set { plantCooldown = value; } }
    public int PlantHealth { get { return plantHealth; } protected set { plantHealth = value; } }
    public int SunCost { get { return sunCost; } protected set { sunCost = value; } }
    public string PlantName { get { return plantName; } protected set { plantName = value; } }
    public PlantClass PlantClass { get { return plantClass; } protected set { plantClass = value; } }
    public Sprite PlantDisplaySprite { get { return plantDisplaySprite; } protected set { plantDisplaySprite = value; } }
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
