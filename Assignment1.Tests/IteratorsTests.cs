using Xunit;

namespace Assignment1.Tests;


public class IteratorsTests
{
    [Fact]
    public void flatten_list_of_ints()
    {
        // Arrange
        var listOfNumbers1 = new List<int> {1, 2, 3, 4};
        var listOfNumbers2 = new List<int> {5, 6, 7, 8};
        var listOfLists = new List<List<int>> {listOfNumbers1, listOfNumbers2};

        // Act
        var flattenList = Iterators.Flatten(listOfLists);

        // Assert
        Assert.Equal(new List<int> {1, 2, 3, 4, 5, 6, 7, 8}, flattenList);
    }

    [Fact]
    public void flatten_list_of_strings()
    {
        // Arrange
        var listOfNumbers1 = new List<String> {"Hi", "Hello"};
        var listOfNumbers2 = new List<String> {"Greetings", "Ciao"};
        var listOfLists = new List<List<String>> {listOfNumbers1, listOfNumbers2};

        // Act
        var flattenList = Iterators.Flatten(listOfLists);

        // Assert
        Assert.Equal(new List<string> {"Hi", "Hello", "Greetings", "Ciao"}, flattenList);
    }

    [Fact]
    public void filterOutOddNumbers()
    {
        // Arrange
        var numbers = new List<int> {1, 2, 3, 4, 5, 6};
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;

        // Act
        var evenNumbers = Iterators.Filter(numbers, Even);

        // Assert
        Assert.Equal(new List<int> {2, 4, 6}, evenNumbers);
    }

    [Fact]
    public void filterOutTheNameBob()
    {
        // Arrange
        var names = new List<String> {"Bob", "Thomas", "Jens", "Sofie"};
        Predicate<String> bob = Bob;
        bool Bob(String name) {
            if(name.Equals("Bob")){
                return true;
            } else {
                return false;
            }
        }

        // Act
        var namesWithBob = Iterators.Filter(names, Bob);

        // Assert
        Assert.Equal(new List<String> {"Bob"}, namesWithBob);
    }
}