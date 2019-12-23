using AcmeWidgetBusinessModels.Data.Entities;
using AcmeWidgetCompanyEmployeeActivity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AcmeWidget.Tests
{
    public class AcmeWidgetRepositoryTests
    {
        private readonly Mock<ILogger<AcmeWidgetRepository>> _mockLogger;
        
        public AcmeWidgetRepositoryTests()
        {
            _mockLogger = new Mock<ILogger<AcmeWidgetRepository>>();
        }

        [Fact]
        public void GetActivities_Activities_ReturnSixActivities()
        {
            var options = new DbContextOptionsBuilder<AcmeDBContext>()
                .UseInMemoryDatabase("AcmeDBForTest")
                .Options;

            using (var context = new AcmeDBContext(options)) {
                context.ActivityTable.Add(new Activity() { ActivityId = 1, ActivityName = "Painting" });
                context.ActivityTable.Add(new Activity() { ActivityId = 2, ActivityName = "Dance" });
                context.ActivityTable.Add(new Activity() { ActivityId = 3, ActivityName = "Video Games" });
                context.ActivityTable.Add(new Activity() { ActivityId = 4, ActivityName = "Monopoly" });
                context.ActivityTable.Add(new Activity() { ActivityId = 5, ActivityName = "Build a Tower" });
                context.ActivityTable.Add(new Activity() { ActivityId = 6, ActivityName = "Robot Fighting" });

              

                context.SaveChanges();

                var acmeRepo = new AcmeWidgetRepository(context, _mockLogger.Object);

                IEnumerable<Activity> activities = acmeRepo.GetAllActivities();
                int count = 0;
                foreach(var item in activities)
                {
                    count++;
                }
                Assert.Equal(6, count);

            }
        }

        [Fact]
        public void ShowRegistrationDetailbyCategory_RegisteredUserInfo_ReturnedListandEmptyList()
        {
            var options = new DbContextOptionsBuilder<AcmeDBContext>()
               .UseInMemoryDatabase("AcmeDBForTest2") //Using seprate database to make independent from another test cases.
               .Options;

            using (var context = new AcmeDBContext(options))
            {

                context.ActivityTable.Add(new Activity() { ActivityId = 1, ActivityName = "Painting" });
                context.ActivityTable.Add(new Activity() { ActivityId = 2, ActivityName = "Dance" });
                context.ActivityTable.Add(new Activity() { ActivityId = 3, ActivityName = "Video Games" });
                context.ActivityTable.Add(new Activity() { ActivityId = 4, ActivityName = "Monopoly" });
                context.ActivityTable.Add(new Activity() { ActivityId = 5, ActivityName = "Build a Tower" });
                context.ActivityTable.Add(new Activity() { ActivityId = 6, ActivityName = "Robot Fighting" });

                #region ActivityID1
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.1@Test.com",
                    FirstName = "User1",
                    LastName = "User1"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.2@Test.com",
                    FirstName = "User2",
                    LastName = "User2"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.3@Test.com",
                    FirstName = "User3",
                    LastName = "User3"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.4@Test.com",
                    FirstName = "User4",
                    LastName = "User4"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.5@Test.com",
                    FirstName = "User5",
                    LastName = "User5"
                });
                #endregion
                #region ActivityID2
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 2,
                    Comments = "XYZ",
                    EmailAddress = "User.1@Test.com",
                    FirstName = "User1",
                    LastName = "User1"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 2,
                    Comments = "XYZ",
                    EmailAddress = "User.2@Test.com",
                    FirstName = "User2",
                    LastName = "User2"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 2,
                    Comments = "XYZ",
                    EmailAddress = "User.3@Test.com",
                    FirstName = "User3",
                    LastName = "User3"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 2,
                    Comments = "XYZ",
                    EmailAddress = "User.4@Test.com",
                    FirstName = "User4",
                    LastName = "User4"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 2,
                    Comments = "XYZ",
                    EmailAddress = "User.5@Test.com",
                    FirstName = "User5",
                    LastName = "User5"
                });
                #endregion
                #region ActivityID3
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 3,
                    Comments = "XYZ",
                    EmailAddress = "User.1@Test.com",
                    FirstName = "User1",
                    LastName = "User1"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 3,
                    Comments = "XYZ",
                    EmailAddress = "User.2@Test.com",
                    FirstName = "User2",
                    LastName = "User2"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 3,
                    Comments = "XYZ",
                    EmailAddress = "User.3@Test.com",
                    FirstName = "User3",
                    LastName = "User3"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 3,
                    Comments = "XYZ",
                    EmailAddress = "User.4@Test.com",
                    FirstName = "User4",
                    LastName = "User4"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 3,
                    Comments = "XYZ",
                    EmailAddress = "User.5@Test.com",
                    FirstName = "User5",
                    LastName = "User5"
                });
                #endregion
                #region ActivityID4
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 4,
                    Comments = "XYZ",
                    EmailAddress = "User.1@Test.com",
                    FirstName = "User1",
                    LastName = "User1"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 4,
                    Comments = "XYZ",
                    EmailAddress = "User.2@Test.com",
                    FirstName = "User2",
                    LastName = "User2"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 4,
                    Comments = "XYZ",
                    EmailAddress = "User.3@Test.com",
                    FirstName = "User3",
                    LastName = "User3"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 4,
                    Comments = "XYZ",
                    EmailAddress = "User.4@Test.com",
                    FirstName = "User4",
                    LastName = "User4"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 4,
                    Comments = "XYZ",
                    EmailAddress = "User.5@Test.com",
                    FirstName = "User5",
                    LastName = "User5"
                });
                #endregion
                #region ActivityID5
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 5,
                    Comments = "XYZ",
                    EmailAddress = "User.1@Test.com",
                    FirstName = "User1",
                    LastName = "User1"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 5,
                    Comments = "XYZ",
                    EmailAddress = "User.2@Test.com",
                    FirstName = "User2",
                    LastName = "User2"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 5,
                    Comments = "XYZ",
                    EmailAddress = "User.3@Test.com",
                    FirstName = "User3",
                    LastName = "User3"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 5,
                    Comments = "XYZ",
                    EmailAddress = "User.4@Test.com",
                    FirstName = "User4",
                    LastName = "User4"
                });
                context.RegistrationTable.Add(new Registration()
                {
                    ActivityId = 5,
                    Comments = "XYZ",
                    EmailAddress = "User.5@Test.com",
                    FirstName = "User5",
                    LastName = "User5"
                });
                #endregion

                context.SaveChanges();
                var acmeRepo = new AcmeWidgetRepository(context, _mockLogger.Object);              
                int activityId = 1;
                var sut = acmeRepo.ShowRegistrationDetailbyCategory(activityId);
                Assert.Equal(5, sut.Count); // Check if function Returned Rows
                
                activityId = 7;
                sut = acmeRepo.ShowRegistrationDetailbyCategory(activityId);
                Assert.Empty(sut); //check if List is empty

            }
        }

        [Fact]
        public void SaveUserRegistration_Registration_ReturnTrue()
        {
            var options = new DbContextOptionsBuilder<AcmeDBContext>()
                .UseInMemoryDatabase("AcmeDBForTest")
                .Options;

            using (var context = new AcmeDBContext(options))
            {
                Registration newUser = new Registration() {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.6@Test.com",
                    FirstName = "User6",
                    LastName = "User6"
                };
                var acmeRepo = new AcmeWidgetRepository(context, _mockLogger.Object);

                var sut = acmeRepo.SaveUserRegistration(newUser);

                Assert.True(sut);

            }
        }

        [Fact]
        public void CheckUserisAlreadyRegisteredforActivity_Registration_ReturnTrue()
        {
            var options = new DbContextOptionsBuilder<AcmeDBContext>()
                .UseInMemoryDatabase("AcmeDBForTest")
                .Options;

            using (var context = new AcmeDBContext(options))
            {
                Registration newUser = new Registration()
                {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.6@Test.com",
                    FirstName = "User6",
                    LastName = "User6"
                };
                var acmeRepo = new AcmeWidgetRepository(context, _mockLogger.Object);

                var sut = acmeRepo.CheckUserisAlreadyRegisteredforActivity(newUser);

                Assert.True(sut);

            }
        }

        [Fact]
        public void CheckUserisAlreadyRegisteredforActivity_Registration_ReturnFalse()
        {
            var options = new DbContextOptionsBuilder<AcmeDBContext>()
                .UseInMemoryDatabase("AcmeDBForTest")
                .Options;

            using (var context = new AcmeDBContext(options))
            {
                Registration newUser = new Registration()
                {
                    ActivityId = 1,
                    Comments = "XYZ",
                    EmailAddress = "User.7@Test.com",
                    FirstName = "User7",
                    LastName = "User7"
                };
                var acmeRepo = new AcmeWidgetRepository(context, _mockLogger.Object);

                var sut = acmeRepo.CheckUserisAlreadyRegisteredforActivity(newUser);

                Assert.False(sut);

            }
        }

       

    }
}
