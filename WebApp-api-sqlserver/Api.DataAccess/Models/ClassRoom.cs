namespace Web.DataAccess.Models;

public class ClassRoom
{
    public string Code { get; set; }
    public int Capacity { get; set; }

    public static string NormalizeCode(string code) => code.ToUpper();
}