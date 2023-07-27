using Ardalis.ApiEndpoints;
using CSMA.API.Core.ProjectAggregate;
using CSMA.API.Core.ProjectAggregate.Specifications;
using CSMA.API.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CSMA.API.Web.Endpoints.ProjectEndpoints;

public class CreateToDoItem : EndpointBaseAsync
  .WithRequest<CreateToDoItemRequest>
  .WithActionResult
{
  private readonly IRepository<Project> _repository;

  public CreateToDoItem(IRepository<Project> repository)
  {
    _repository = repository;
  }

  [HttpPost(CreateToDoItemRequest.Route)]
  [SwaggerOperation(
    Summary = "Creates a new ToDo Item for a Project",
    Description = "Creates a new ToDo Item for a Project",
    OperationId = "Project.CreateToDoItem",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(
    CreateToDoItemRequest request,
    CancellationToken cancellationToken = new())
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }

    var newItem = new ToDoItem()
    {
      Title = request.Title!,
      Description = request.Description!
    };

    if(request.ContributorId.HasValue) 
    { 
      newItem.AddContributor(request.ContributorId.Value);
    }
    entity.AddItem(newItem);
    await _repository.UpdateAsync(entity);

    return Created(GetProjectByIdRequest.BuildRoute(request.ProjectId), null);
  }
}
