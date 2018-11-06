using Certifi.UI.Services;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Module.API
{
    public class RequirementsModule : NancyModule
    {
        private readonly ICertifiDatabase _certifiDatabase;

        public RequirementsModule(ICertifiDatabase certifiDatabase)
        {
            _certifiDatabase = certifiDatabase;

            Get("/api/requirements", p => GetRequirements());
        }

        public dynamic GetRequirements()
        {
            //TODO Load requirements
            //var n = _certifiDatabase.Execute("select count(*) from requirements");

            var areas = new List<AreaModel>
            {
                new AreaModel
                {
                    Name = "Environment",
                    Incomplete = 3,
                    Topics = new List<TopicModel>
                    {
                        new TopicModel
                        {
                            Name = "Topic 1",
                            Groups = new List<GroupModel>
                            {
                                new GroupModel
                                {
                                    Name = "Group 1",
                                    Requirements = new List<RequirementModel>
                                    {
                                        new RequirementModel
                                        {
                                            Name = "Requirement 1"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 2"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 3"
                                        },
                                    }
                                },
                                new GroupModel
                                {
                                    Name = "Group 2",
                                    Requirements = new List<RequirementModel>
                                    {
                                        new RequirementModel
                                        {
                                            Name = "Requirement 4"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 5"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 6"
                                        },
                                    }
                                },
                            }
                        },
                        new TopicModel
                        {
                            Name = "Topic 2",
                            Groups = new List<GroupModel>
                            {
                                new GroupModel
                                {
                                    Name = "Group 3",
                                    Requirements = new List<RequirementModel>
                                    {
                                        new RequirementModel
                                        {
                                            Name = "Requirement 7"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 8"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 9"
                                        },
                                    }
                                },
                                new GroupModel
                                {
                                    Name = "Group 4",
                                    Requirements = new List<RequirementModel>
                                    {
                                        new RequirementModel
                                        {
                                            Name = "Requirement 10"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 11"
                                        },
                                        new RequirementModel
                                        {
                                            Name = "Requirement 12"
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
                new AreaModel
                {
                    Name = "Health & Safety",
                    Incomplete = 1,
                    Topics = new List<TopicModel>()
                },
                new AreaModel
                {
                    Name = "Welfare",
                    Incomplete = 0,
                    Topics = new List<TopicModel>()
                },
                new AreaModel
                {
                    Name = "Product Safety",
                    Incomplete = 7,
                    Topics = new List<TopicModel>()
                },
                new AreaModel
                {
                    Name = "Quality",
                    Incomplete = 0,
                    IsEmpty = true,
                    Topics = new List<TopicModel>()
                }
            };

            return new
            {
                Areas = areas
            };
        }
    }
}
