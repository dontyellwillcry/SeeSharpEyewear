using SeeSharpEyewear.Models;


namespace SeeSharpEyewear.Services;

public static class ShadesService
{
    static List<Shades> Shades { get; }
    static int nextId = 3;
    static ShadesService()
    {
        Shades = new List<Shades>
        {
            new Shades { Id = 1, Name = "Ray-Ban Clubmaster", Color = "Brown / Gold", Shape = "browline" },
            new Shades { Id = 1, Name = "Ottoto Bellona", Color = "Pink / Gold", Shape = "Oval" },
            new Shades { Id = 1, Name = "Oakley Socket 5.5", Color = "Gunmetal", Shape = "Rectangle" },

        };
    }

    public static List<Shades> GetAll() => Shades;

    public static Shades? Get(int id) => Shades.FirstOrDefault(p => p.Id == id);

    public static void Add(Shades shade)
    {
        shade.Id = nextId++;
        Shades.Add(shade);
    }

    public static void Delete(int id)
    {
        var shade = Get(id);
        if (shade is null)
            return;

        Shades.Remove(shade);
    }

    public static void Update(Shades shade)
    {
        var index = Shades.FindIndex(p => p.Id == shade.Id);
        if (index == -1)
            return;

        Shades[index] = shade;
    }
}