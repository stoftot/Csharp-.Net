using Microsoft.AspNetCore.Components;
using Web.Service.DTO_s;
using Web.Service.Services;

namespace Web.Components.Pages.Classrooms;

public class ViewSpeceficClassroomBase : CreateClassroomBase
{
    [Parameter] public string ClassroomCode { get; set; }

    [Inject] protected IClassRoomService ClassRoomService { get; set; }

    public ViewClassroomDto? Classroom { get; private set; } = null;

    [SupplyParameterFromForm(FormName = "UpdateClassroom")]
    protected new CreatFormData UpdateFormData { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Classroom = await ClassRoomService.GetClassroom(ClassroomCode);
        UpdateFormData = new CreatFormData { Code = Classroom.Code, Capacity = Classroom.Capacity };
    }

    protected async Task UpdateClassRoom()
    {
    }

    protected async Task DeleteClassRoom()
    {
    }
}