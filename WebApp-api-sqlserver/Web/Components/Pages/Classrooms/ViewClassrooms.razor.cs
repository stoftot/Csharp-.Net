using Microsoft.AspNetCore.Components;
using Web.Service.DTO_s;
using Web.Service.Services;

namespace Web.Components.Pages.Classrooms;

public class ViewClassroomsBase : ComponentBase
{
    [Inject] private IClassRoomService ClassRoomService { get; init; } = null!;

    protected IEnumerable<ViewClassroomDto>? Classrooms { get; set; } = null;

    protected override async Task OnInitializedAsync()
    {
        //await Task.Delay(500);
        
        Classrooms = await ClassRoomService.GetAllClassrooms();
    }
}