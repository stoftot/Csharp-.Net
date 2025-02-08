namespace Web.DataAccess.Models;

public class Subject
{
    public string Code { get; set; }
    public string Name { get; set; }

    public static string NormalizeCode(string code)
    {
        return code.ToUpper();
    }
}