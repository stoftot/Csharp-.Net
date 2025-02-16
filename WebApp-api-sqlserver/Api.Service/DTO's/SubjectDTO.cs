using System.Text;

namespace Api.Service.DTO_s;

public class GetSubjectDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
}

public class CreateSubjectDTO(string name)
{
    public string Code { get; } = GenerateCode(name);
    public string Name { get; } = name;

    private static string GenerateCode(string name)
    {
        var chars = name.ToCharArray();
        var code = new StringBuilder();

        for (int i = 0; i < chars.Length; i++)
        {
            if (i % 3 == 0)
                code.Append(char.ToUpper(chars[i]));
        }

        return code.ToString();
    }
}