namespace MauiApp4.Data;

public static class DirectionOfVolunteeringExtensions
{
    private static int _navigationIndex = 0;
    
    /// <summary>
    /// Добавляет новое направление
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static List<DirectionOfVolunteering> New(this List<DirectionOfVolunteering> direction, Action<DirectionOfVolunteering> action)
    {
        direction.Add(new DirectionOfVolunteering());
        var last = direction.Last();
        action.Invoke(last);
        last.NavigationIndex = _navigationIndex;
        _navigationIndex++;
        return direction;
    }

    /// <summary>
    /// Заполняет направление информацией
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="name"Название направления></param>
    /// <param name="shortDescription">Краткое Описание направления</param>
    /// <param name="fullDescription">Полное описание</param>
    /// <returns></returns>
    public static DirectionOfVolunteering FillInformation(this DirectionOfVolunteering direction,
        string name, string shortDescription, string fullDescription)
    {
        direction.Name = name;
        direction.Description = shortDescription;
        direction.FullDescription = fullDescription;
        
        return direction;
    }
    
    /// <summary>
    /// Устанавливает руководителя направления
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="fullName">ФИО руководителя</param>
    /// <param name="phoneNumber">Контактный номер</param>
    /// <param name="email">Контактный email</param>
    /// <param name="photoUrl">Относительный путь до фото</param>
    /// <returns></returns>
    public static DirectionOfVolunteering AddEmployee(this DirectionOfVolunteering direction,
        string fullName, string phoneNumber, string email, string photoUrl = null)
    {
        EmployeeData employeeData = new()
        {
            FullName = fullName,
            PhoneNumber = phoneNumber,
            Email = email,
            PhotoUrl = photoUrl
        };

        direction.Employee = employeeData;
        
        return direction;
    }

    public static DirectionOfVolunteering AddCarouselImages(this DirectionOfVolunteering direction, params string[] paths)
    {
        string sourcePath = "images";

        foreach (var path in paths)
        {
            string resultPath = Path.Combine(sourcePath, path);
            string withExtension = Path.ChangeExtension(resultPath, "jpg");
            direction.CarouselImages.Add(withExtension);
        }
        
        return direction;
    }
}