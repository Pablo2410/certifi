using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Module
{
    public class DischargeModule : NancyModule
    {
        public DischargeModule()
        {
            Get("/discharge/dash", p => View["dash", GetDashModel()]);
        }

        private dynamic GetDashModel()
        {
            var areas = GetAreaHierarchy();

            var requirements = ExtractRequirements(areas);
            
            return new
            {
                Areas = areas,
                Requirements = requirements
            };
        }

        private IList<RequirementHierarchyModel> ExtractRequirements(IList<AreaModel> areas)
        {
            var results = new List<RequirementHierarchyModel>();

            foreach (var area in areas)
            {
                foreach(var topic in area.Topics)
                {
                    foreach(var group in topic.Groups)
                    {
                        foreach(var req in group.Requirements)
                        {
                            var reqModel = new RequirementHierarchyModel
                            {
                                Name = req.Name,
                                Breadcrumb = new List<string>
                                {
                                    area.Name,
                                    topic.Name,
                                    group.Name
                                }
                            };

                            results.Add(reqModel);
                        }
                    }
                }
            }

            return results;
        }

        private IList<AreaModel> GetAreaHierarchy()
        {
            return new List<AreaModel>
            {
                new AreaModel
                {
                    Name = "Environment",
                    Incomplete = 3,
                    IsActive = true,
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
        }
    }

    public class AreaModel
    {
        public string Name { get; set; }

        public int Incomplete { get; set; }

        public bool IsComplete {
            get { return Incomplete == 0; }
        }

        public string NavCss
        {
            get
            {
                if (IsActive)
                    return "glyphicon-minus";
                if (IsEmpty)
                    return "glyphicon-ok";
                return "glyphicon-plus";
            }
        }

        public bool IsActive { get; set; }

        public bool IsEmpty { get; set; }

        public IEnumerable<TopicModel> Topics { get; set; }
    }

    public class TopicModel
    {
        public string Name { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
    }

    public class GroupModel
    {
        public string Name { get; set; }
        public IEnumerable<RequirementModel> Requirements { get; set; }
    }

    public class RequirementModel
    {
        public string Name { get; set; }

        public string Id
        {
            get { return Name.ToLower().Replace(" ", ""); }
        }
    }

    public class RequirementHierarchyModel : RequirementModel
    {
        public RequirementHierarchyModel() : base()
        {
            Breadcrumb = new List<string>();
        }

        public IList<string> Breadcrumb { get; set; }

        public string BreadCrumbString
        {
            get
            {
                return string.Join(" • ", Breadcrumb);
            }
        }
    }
}
