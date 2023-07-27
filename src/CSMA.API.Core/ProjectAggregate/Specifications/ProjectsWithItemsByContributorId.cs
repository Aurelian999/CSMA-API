﻿using Ardalis.Specification;

namespace CSMA.API.Core.ProjectAggregate.Specifications;

public class ProjectsWithItemsByContributorIdSpec : Specification<Project>
{
  public ProjectsWithItemsByContributorIdSpec(int contributorId)
  {
    Query
        .Where(project => project.Items.Any(item => item.ContributorId == contributorId))
        .Include(project => project.Items);
  }
}
