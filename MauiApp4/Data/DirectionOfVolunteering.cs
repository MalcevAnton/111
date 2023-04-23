namespace MauiApp4.Data;

public class DirectionOfVolunteering
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Описание направления
    /// </summary>
    public string Description { get; set; }
    
    public string FullDescription { get; set; }
    
    /// <summary>
    /// Руководитель
    /// </summary>
    public EmployeeData Employee { get; set; }

    public List<string> CarouselImages { get; set; } = new();

    public int NavigationIndex { get; set; }

    public string NavigationUrl => $"/about-direction/{NavigationIndex}";
}