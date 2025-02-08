using System.Text;

namespace Web.DataAccess.DTO;

public class SubjectDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
}

public class CreateSubjectDTO(string name)
{
    public string Code { get;} = GenerateCode(name);
    public required string Name { get; init; } = name;

    private static string GenerateCode(string name)
    {
        var chars = name.Split("");
        var code = new StringBuilder();
        
        for (int i = 0; i < chars.Length; i++)
        {
          if(i % 3 == 0) continue;
          code.Append(chars[i].ToUpper());
        }

        return code.ToString();
    }
}