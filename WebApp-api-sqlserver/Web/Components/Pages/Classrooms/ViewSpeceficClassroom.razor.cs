using Microsoft.AspNetCore.Components;
using Web.Service.DTO_s;
using Web.Service.Services;

namespace Web.Components.Pages.Classrooms;

public class ViewSpeceficClassroomBase : CreateClassroomBase
{
    [Parameter] public string ClassroomCode { get; set; }

    protected ViewClassroomDto? Classroom { get; private set; } = null;

    [SupplyParameterFromForm(FormName = "UpdateClassroom")]
    protected CreatFormData UpdateFormData { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Classroom = await ClassRoomService.GetClassroom(ClassroomCode);
        UpdateFormData.Code = Classroom.Code;
        UpdateFormData.Capacity = Classroom.Capacity;
    }

    protected async Task UpdateClassRoom()
    {
        var classroom = new UpdateClassroomDto(UpdateFormData.Capacity);
        await ClassRoomService.UpdateClassroom(UpdateFormData.Code, classroom);
        Navigation.NavigateTo(Navigation.Uri);
    }

    protected async Task DeleteClassRoom()
    {
    }
}