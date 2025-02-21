using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Web.Service.DTO_s;
using Web.Service.Services;

namespace Web.Components.Pages.Classrooms;

public class CreateClassroomBase : ComponentBase
{
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    [Inject] private IClassRoomService ClassRoomService { get; set; } = null!;

    [SupplyParameterFromForm(FormName = "CreateClassroom")]
    protected CreatFormData FormData { get; set; } = new();
    
    protected async Task CreateClassRoom()
    {
        var newClassRoom = new CreateClassroomDto(FormData.Code, FormData.Capacity);
        var createdClassroom = await ClassRoomService.CreateClassroom(newClassRoom);
        Navigation.NavigateTo($"/classroom/{createdClassroom.Code}");
    }
    
    protected class CreatFormData
    {
        [Required(ErrorMessage = "Classroom code is required")]
        public string Code { get; set; } = string.Empty;
        
        [Range(1, 300, ErrorMessage = "Capacity must be between 1 and 300")]
        public int Capacity { get; set; }
    }
}