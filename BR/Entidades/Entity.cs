namespace tupacAlumnos;

public class Entity
{
    private static int lastUnicNumber = 0;
    private int UnicNumber { get; set; }

    public Entity()
    {
        UnicNumber = ++lastUnicNumber;
    }
    public string GetUnicNumber()
    {
        return $"{UnicNumber.ToString()}";
    }
}