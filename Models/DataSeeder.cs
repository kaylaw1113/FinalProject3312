using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuffteksWebsite.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BuffteksWebsiteContext(serviceProvider.GetRequiredService<DbContextOptions<BuffteksWebsiteContext>>()))
            {

                // CLIENTS
                if (context.Clients.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client { FirstName="Jack", LastName="Daniels", CompanyName="Whiskey Inc.", Email="jdaniels@whiskey.com", Phone="123-456-7890" },
                    new Client { FirstName="Kristen", LastName="Bell", CompanyName="Frozen Industries", Email="kbell@frozeninc.com", Phone="332-552-5675" },
                    new Client { FirstName="Michelle", LastName="Obama", CompanyName="White House Inc.", Email="mobama@bwhinc.com", Phone="882-338-7550" }
                };
                context.AddRange(clients);
                context.SaveChanges();


                // CLIENTS
                if (context.Members.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var members = new List<Member>
                {
                    new Member { FirstName="Maggie", LastName="Sanchez", Major="CIS", Email="msanchez@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Peter", LastName="Perez", Major="CIS", Email="pperez@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Jessica", LastName="Williams", Major="CIS", Email="jwiliams@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Layla", LastName="Washington", Major="CIS", Email="lwashington@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Dylan", LastName="Burns", Major="CIS", Email="dburns@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Rachael", LastName="Morris", Major="CIS", Email="rmorris@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Sam", LastName="Smith", Major="CIS", Email="ssmith@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Beyonce", LastName="Knowles-Carter", Major="CIS", Email="bknowlescarter@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="Aubrey", LastName="Gram", Major="CIS", Email="agram@buffs.wtamu.edu", Phone="555-555-5555" },
                    new Member { FirstName="James", LastName="Arnold", Major="CIS", Email="jarnold@buffs.wtamu.edu", Phone="555-555-5555" }
                };
                context.AddRange(members);
                context.SaveChanges();

                // PROJECTS
                if (context.Projects.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project { ProjectName="Sandwhiches", ProjectDescription="Branching into the food industry" },
                    new Project { ProjectName="Ice Delivery", ProjectDescription="Delivering ice to people of Arendelle" },
                    new Project { ProjectName="Stay Fit", ProjectDescription="Fitness" }
                };
                context.AddRange(projects);
                context.SaveChanges();

                //PROJECT ROSTER BRIDGE TABLE - THERE MUST BE PROJECTS AND PARTICIPANTS MADE FIRST
                if (context.ProjectRoster.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                

                //quickly grab the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();                

            }
        }
    }
}