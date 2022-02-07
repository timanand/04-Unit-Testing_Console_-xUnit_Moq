using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using Xunit;
using Moq;

namespace UnitTestDemo.Tests
{
    public class SampleClass1DTests
    {

        [Fact]
        public void UserCanDrink_UserIsOfAge_ReturnsTrue()
        {
            // Arrange
            var dataSource = new Mock<IDataSource>();
            var user = new User(23);  // we have configured a user that is older than 21

            // we want to use this method, 'GetUser'. Passing any Guid.
            // When GetUser method is called it will return user ie. 23
            // 
            dataSource
                .Setup(m => m.GetUser(It.IsAny<Guid>()))
                .Returns(user);

            var classThatWeAreActuallyTesting = new SampleClass1D(dataSource.Object);


            // Act
            var isOldEnoughToDrink = classThatWeAreActuallyTesting.UserCanDrink(Guid.NewGuid());


            // Assert
            Assert.True(isOldEnoughToDrink);

        }



        [Fact]
        public void UserCanDrink_UserIsNotOfAge_ReturnsFalse()
        {
            // Arrange
            var dataSource = new Mock<IDataSource>();
            var user = new User(19);  // we have configured a user that is under than 21

            // we want to use this method, 'GetUser'. Passing any Guid.
            // When GetUser method is called it will return user ie. 23
            // 
            dataSource
                .Setup(m => m.GetUser(It.IsAny<Guid>()))
                .Returns(user);

            var classThatWeAreActuallyTesting = new SampleClass1D(dataSource.Object);


            // Act
            var isOldEnoughToDrink = classThatWeAreActuallyTesting.UserCanDrink(Guid.NewGuid());


            // Assert
            Assert.False(isOldEnoughToDrink);

        }


        [Fact]
        public void UserCanDrink_CallsDataSource()
        {

            // arrange
            var dataSource = new Mock<IDataSource>();
            var user = new User(123);

            dataSource.Setup(m => m.GetUser(It.IsAny<Guid>())).Returns(user);

            var classThatWeAreActuallyTesting = new SampleClass1D(dataSource.Object);


            // act
            classThatWeAreActuallyTesting.UserCanDrink(Guid.NewGuid());

            // assert
            // What this is going to assert is that this method (ie. GetUser) was called on this data source (ie. dataSource) exactly one time.
            dataSource.Verify(m => m.GetUser(It.IsAny<Guid>()), Times.Once);
        }



        [Theory]
        [InlineData(23)]
        [InlineData(31)]
        [InlineData(65)]
        [InlineData(20)]


        public void UserCanDrink_UserIsOfAge_ReturnsTrue_MultipleTest(int age)
        {
            // Arrange
            var dataSource = new Mock<IDataSource>();
            var user = new User(age);  // we have configured a user that is older than 21

            // we want to use this method, 'GetUser'. Passing any Guid.
            // When GetUser method is called it will return user ie. 23
            // 
            dataSource
                .Setup(m => m.GetUser(It.IsAny<Guid>()))
                .Returns(user);

            var classThatWeAreActuallyTesting = new SampleClass1D(dataSource.Object);


            // Act
            var isOldEnoughToDrink = classThatWeAreActuallyTesting.UserCanDrink(Guid.NewGuid());


            // Assert
            Assert.True(isOldEnoughToDrink);

        }



    }
}
